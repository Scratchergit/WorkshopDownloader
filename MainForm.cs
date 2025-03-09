using System.Diagnostics;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Net.Http;

namespace ModDownloader
{
    public partial class MainForm : Form
    {
        private const string CONFIG_FILE = "config.json";
        private const string STEAMCMD_URL = "https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip";
        private Config _config;
        private bool _isDownloading;
        private CancellationTokenSource? _cancellationTokenSource;
        private System.Windows.Forms.Timer _animationTimer;
        private int _currentFrame;
        private readonly string[] _loadingFrames = new[] { "⌛", "⏳" };
        private readonly HttpClient _httpClient = new HttpClient();

        public MainForm()
        {
            InitializeComponent();
            LoadConfig();
            SetupAnimationTimer();
            UpdateGameList();
        }

        private void SetupAnimationTimer()
        {
            _animationTimer = new System.Windows.Forms.Timer();
            _animationTimer.Interval = 500; // 500ms interval
            _animationTimer.Tick += AnimationTimer_Tick;
        }

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            if (_isDownloading)
            {
                _currentFrame = (_currentFrame + 1) % _loadingFrames.Length;
                lblLoading.Text = $"{_loadingFrames[_currentFrame]} Downloading...";
            }
        }

        private void LoadConfig()
        {
            try
            {
                if (File.Exists(CONFIG_FILE))
                {
                    string json = File.ReadAllText(CONFIG_FILE);
                    _config = JsonConvert.DeserializeObject<Config>(json) ?? new Config();
                    
                    // Clean empty games
                    _config.Games = _config.Games.Where(g => 
                        !string.IsNullOrWhiteSpace(g.Id) && 
                        !string.IsNullOrWhiteSpace(g.Name)
                    ).ToList();
                }
                else
                {
                    _config = new Config();
                }

                // Update UI with config values
                txtSteamCMD.Text = _config.SteamCmdPath;
                txtWorkshop.Text = _config.WorkshopPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading config: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _config = new Config();
            }
        }

        private void SaveConfig()
        {
            try
            {
                string json = JsonConvert.SerializeObject(_config, Formatting.Indented);
                File.WriteAllText(CONFIG_FILE, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving config: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateGameList()
        {
            lstGames.Items.Clear();
            foreach (var game in _config.Games)
            {
                lstGames.Items.Add(game.Name);
            }
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (_isDownloading)
                return;

            if (string.IsNullOrWhiteSpace(txtModIds.Text))
            {
                MessageBox.Show("Please enter mod IDs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] modIds = txtModIds.Text.Split(',')
                                        .Select(id => id.Trim())
                                        .Where(id => !string.IsNullOrWhiteSpace(id))
                                        .ToArray();

            if (!modIds.Any())
            {
                MessageBox.Show("No valid mod IDs found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _isDownloading = true;
            _cancellationTokenSource = new CancellationTokenSource();
            btnDownload.Enabled = false;
            btnStop.Enabled = true;
            progressBar.Value = 0;
            lblLoading.Visible = true;
            _animationTimer.Start();

            try
            {
                string? lastSuccessfulFolder = null;
                int totalMods = modIds.Length;

                for (int i = 0; i < modIds.Length; i++)
                {
                    if (_cancellationTokenSource.Token.IsCancellationRequested)
                        break;

                    string modId = modIds[i];
                    var progress = new Progress<int>(p =>
                    {
                        int overallProgress = (int)((i * 100 + p) / (float)totalMods);
                        progressBar.Value = Math.Min(100, Math.Max(0, overallProgress));
                    });

                    var result = await DownloadMod(modId, _config.CurrentGameId, progress, _cancellationTokenSource.Token);
                    if (result.Success)
                    {
                        lastSuccessfulFolder = result.ModsFolder;
                    }
                }

                if (lastSuccessfulFolder != null && Directory.Exists(lastSuccessfulFolder))
                {
                    Process.Start("explorer.exe", lastSuccessfulFolder);
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Download cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during download: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isDownloading = false;
                btnDownload.Enabled = true;
                btnStop.Enabled = false;
                lblLoading.Visible = false;
                _animationTimer.Stop();
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
        }

        private void btnBrowseSteamCMD_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog
            {
                Description = "Select SteamCMD Directory",
                UseDescriptionForTitle = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _config.SteamCmdPath = dialog.SelectedPath;
                txtSteamCMD.Text = dialog.SelectedPath;

                // Set workshop path automatically
                string workshopPath = Path.Combine(dialog.SelectedPath, "steamapps", "workshop", "content");
                Directory.CreateDirectory(workshopPath);
                _config.WorkshopPath = workshopPath;
                txtWorkshop.Text = workshopPath;

                SaveConfig();
            }
        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            string gameName = txtNewGameName.Text.Trim();
            string gameId = txtNewGameId.Text.Trim();

            if (string.IsNullOrWhiteSpace(gameName) || string.IsNullOrWhiteSpace(gameId))
            {
                MessageBox.Show("Game Name and Game ID cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_config.Games.Any(g => g.Id == gameId))
            {
                MessageBox.Show("A game with this ID already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _config.Games.Add(new Game { Id = gameId, Name = gameName });
            SaveConfig();
            UpdateGameList();

            txtNewGameName.Clear();
            txtNewGameId.Clear();
        }

        private void lstGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGames.SelectedIndex >= 0)
            {
                string selectedName = lstGames.SelectedItem.ToString() ?? "";
                var game = _config.Games.FirstOrDefault(g => g.Name == selectedName);
                if (game != null)
                {
                    _config.CurrentGameId = game.Id;
                }
            }
        }

        private async Task<(bool Success, string? ModsFolder)> DownloadMod(string modId, string gameId, IProgress<int> progress, CancellationToken cancellationToken)
        {
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string tempDir = Path.Combine(exeDir, "temp");
            Directory.CreateDirectory(tempDir);

            try
            {
                string steamCmdPath = Path.Combine(_config.SteamCmdPath, "steamcmd.exe");
                var startInfo = new ProcessStartInfo
                {
                    FileName = steamCmdPath,
                    Arguments = $"+login anonymous +workshop_download_item {gameId} {modId} +quit",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WorkingDirectory = _config.SteamCmdPath
                };

                using var process = new Process { StartInfo = startInfo };
                process.Start();

                bool downloading = false;
                int currentProgress = 0;

                while (!process.StandardOutput.EndOfStream)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        process.Kill();
                        throw new OperationCanceledException();
                    }

                    string? line = await process.StandardOutput.ReadLineAsync();
                    if (line == null) continue;

                    if (line.Contains("Downloading item"))
                    {
                        downloading = true;
                        progress.Report(10);
                    }
                    else if (line.Contains("Download Complete"))
                    {
                        progress.Report(90);
                    }
                    else if (downloading && line.Contains("Success"))
                    {
                        progress.Report(100);
                    }
                    else if (downloading)
                    {
                        currentProgress = Math.Min(currentProgress + 2, 85);
                        progress.Report(currentProgress);
                    }

                    await Task.Delay(100, cancellationToken);
                }

                await process.WaitForExitAsync(cancellationToken);

                if (process.ExitCode == 0)
                {
                    string modPath = Path.Combine(_config.WorkshopPath, gameId, modId);
                    if (Directory.Exists(modPath))
                    {
                        string modsFolder = Path.Combine(exeDir, "mods");
                        Directory.CreateDirectory(modsFolder);

                        foreach (string file in Directory.GetFiles(modPath))
                        {
                            string fileName = Path.GetFileName(file);
                            if (fileName != "preview.png" && fileName != "workshop_data.json")
                            {
                                File.Copy(file, Path.Combine(modsFolder, fileName), true);
                            }
                        }

                        Directory.Delete(modPath, true);
                        return (true, modsFolder);
                    }
                }

                return (false, null);
            }
            finally
            {
                if (Directory.Exists(tempDir))
                {
                    Directory.Delete(tempDir, true);
                }
            }
        }

        private async void btnDownloadSteamCMD_Click(object sender, EventArgs e)
        {
            if (_isDownloading)
                return;

            using var dialog = new FolderBrowserDialog
            {
                Description = "Select Directory for SteamCMD",
                UseDescriptionForTitle = true
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            string targetDir = dialog.SelectedPath;
            string zipPath = Path.Combine(targetDir, "steamcmd.zip");

            _isDownloading = true;
            _cancellationTokenSource = new CancellationTokenSource();
            btnDownloadSteamCMD.Enabled = false;
            btnBrowseSteamCMD.Enabled = false;
            progressBar.Value = 0;
            lblLoading.Text = "⬇️ Downloading SteamCMD...";
            lblLoading.Visible = true;
            _animationTimer.Start();

            try
            {
                using var response = await _httpClient.GetAsync(STEAMCMD_URL, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                var canReportProgress = totalBytes != -1;

                using var contentStream = await response.Content.ReadAsStreamAsync();
                using var fileStream = new FileStream(zipPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true);
                var buffer = new byte[8192];
                long totalRead = 0;

                while (true)
                {
                    if (_cancellationTokenSource.Token.IsCancellationRequested)
                        break;

                    var bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length, _cancellationTokenSource.Token);
                    if (bytesRead == 0)
                        break;

                    await fileStream.WriteAsync(buffer, 0, bytesRead, _cancellationTokenSource.Token);
                    totalRead += bytesRead;

                    if (canReportProgress)
                    {
                        var progress = (int)((totalRead * 100) / totalBytes);
                        progressBar.Value = progress;
                    }
                }

                // Extract the zip file
                lblLoading.Text = "📦 Extracting SteamCMD...";
                System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, targetDir);

                // Clean up the zip file
                File.Delete(zipPath);

                // Set the SteamCMD path in config
                _config.SteamCmdPath = targetDir;
                txtSteamCMD.Text = targetDir;

                // Set workshop path automatically
                string workshopPath = Path.Combine(targetDir, "steamapps", "workshop", "content");
                Directory.CreateDirectory(workshopPath);
                _config.WorkshopPath = workshopPath;
                txtWorkshop.Text = workshopPath;

                SaveConfig();

                MessageBox.Show("SteamCMD has been downloaded and installed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Download cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading SteamCMD: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isDownloading = false;
                btnDownloadSteamCMD.Enabled = true;
                btnBrowseSteamCMD.Enabled = true;
                lblLoading.Visible = false;
                _animationTimer.Stop();
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            base.OnFormClosing(e);
        }
    }

    public class Config
    {
        public List<Game> Games { get; set; } = new();
        public string SteamCmdPath { get; set; } = "";
        public string WorkshopPath { get; set; } = "";
        public string CurrentGameId { get; set; } = "";
    }

    public class Game
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
    }
} 
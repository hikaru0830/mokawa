using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mkw.Services
{
    public class ViteManifestService
    {
        private readonly IWebHostEnvironment _env;
        private Dictionary<string, ViteManifestEntry>? _manifest;
        private readonly string _manifestPath;
        private readonly string _viteServerUrl;

        public ViteManifestService(IWebHostEnvironment env, IConfiguration config)
        {
            _env = env;
            // Vite 5 打包後的路徑
            _manifestPath = Path.Combine(_env.WebRootPath, "dist", ".vite", "manifest.json");
            _viteServerUrl = config["Vite:ServerUrl"] ?? "http://localhost:5173";
        }

        // 核心方法：取得進入點資訊
        public ViteManifestEntry? GetManifestEntry(string key = "index.html")
        {
            // 1. 如果是開發模式，我們手動建立一個虛擬的 Entry，指向 Vite Dev Server
            if (_env.IsDevelopment())
            {
                return new ViteManifestEntry
                {
                    // 開發模式下，Vite 會動態處理 CSS，所以我們只需要給 JS 進入點
                    // 假設你的 Vite 進入點是 src/main.jsx
                    File = $"{_viteServerUrl}/src/main.jsx"
                };
            }

            // 2. 如果是正式模式，讀取 manifest.json
            if (_manifest == null)
            {
                LoadManifest();
            }

            return (_manifest != null && _manifest.TryGetValue(key, out var entry)) ? entry : null;
        }

        private void LoadManifest()
        {
            if (!File.Exists(_manifestPath)) return;

            try
            {
                var json = File.ReadAllText(_manifestPath);
                _manifest = JsonSerializer.Deserialize<Dictionary<string, ViteManifestEntry>>(json);
            }
            catch
            {
                _manifest = new Dictionary<string, ViteManifestEntry>();
            }
        }
    }
    public class ViteManifestEntry
    {
        [JsonPropertyName("file")]
        public string File { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("src")]
        public string? Src { get; set; }

        [JsonPropertyName("isEntry")]
        public bool? IsEntry { get; set; }

        [JsonPropertyName("css")]
        public List<string>? Css { get; set; }
    }
}

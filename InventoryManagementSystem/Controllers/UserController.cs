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
            new User("Admin", "123", "Someone", "+3753333175444"),
            };
        }

        public List<User> LoadData()
        {
            return users;
        }
        public void Add(User user)
        {
            users.Add(user);
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

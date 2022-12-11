using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Controller
{
    public class LoginController
    {
        public LoginController()
        {
        }
        /*public bool CanLogin(string name, string pass, out string fullName)
        {
            var command = new SqlCommand("SELECT * FROM tbUser WHERE username=@username AND password=@password", dataBase.GetConnection());
            command.Parameters.AddWithValue("@username", name);
            command.Parameters.AddWithValue("@password", pass);
            dataBase.OpenConnection();
            DataReader = command.ExecuteReader();
            DataReader.Read();
            if (DataReader.HasRows)
            {
                fullName = DataReader["fullname"].ToString();
                DataReader.Close();
                dataBase.CloseConnection();

                return true;
            }
            else
            {
                DataReader.Close();
                dataBase.CloseConnection();
                fullName = default;
                return false;
            }
        }*/
    }
}

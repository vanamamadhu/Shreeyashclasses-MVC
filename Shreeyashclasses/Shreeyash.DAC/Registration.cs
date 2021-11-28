using Shreeyashclasses.Models;
using Shreeyashclasses.Shreeyash.Interface;
using System;
using System.Data.OleDb;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shreeyashclasses.Shreeyash.DAC
{
    public class Registration : IRegistration
    {
        private OleDbConnection connection = new OleDbConnection();
        public bool CreateUser(User newUser) 
        {
            try
            {
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\ShreeyasDataBase\\ShreeyashclassesDB.accdb") + ";Persist Security Info=False;";
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                newUser.CreatedDate = DateTime.Now;
                command.CommandText = "INSERT INTO Users(USERNAME,[PASSWORD],CREATEDDATE,PHONENO,CLASS,NAME,SURNAME,ROLE,SUBJECTS,ADDRESS) VALUES ('" 
                                      + newUser.UserName + "','" + newUser.Password + "','" + newUser.CreatedDate + "','" + newUser.PhoneNumber + "','" + newUser.Class + "','" + newUser.Name + "','" + newUser.Surname + "','" + newUser.Role + "','" + newUser.Subjects + "','" + newUser.Address + "');";
                var result = command.ExecuteNonQuery();
                connection.Close();
                return result == 0 ? false : true;
            }
            catch (Exception ex)
            {
                connection.Close();
                //here we can inplement custom exception for trach the error/issues
                return false;
            }
        }

        public bool UpdateUser(User newUser)
        {
            return true;
        }
    }
}
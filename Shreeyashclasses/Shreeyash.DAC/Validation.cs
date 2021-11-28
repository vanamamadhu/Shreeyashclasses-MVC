using Shreeyashclasses.Models;
using Shreeyashclasses.Shreeyash.Interface;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;

namespace Shreeyashclasses.Shreeyash.DAC
{
    public class Validation: IValidation
    {
        private OleDbConnection connection = new OleDbConnection();
        public Validation()
        { }

        public User ValidateUser(User user) 
        {
            try
            {
                int count = 1;
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\ShreeyasDataBase\\ShreeyashclassesDB.accdb") + ";Persist Security Info=False;";
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "Select * from Users where USERNAME ='" + user.UserName + "' and PASSWORD ='" + user.Password + "'";

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user.Name = reader["NAME"] as string;
                    user.Surname = reader["SURNAME"] as string;
                    user.UserName = reader["USERNAME"] as string;
                    user.CreatedDate = Convert.ToDateTime(reader["CREATEDDATE"]);
                    user.PhoneNumber = reader["PHONENO"] as string;
                    user.Class = reader["CLASS"] as string;
                    user.Role = reader["ROLE"] as string;
                    user.Subjects = reader["SUBJECTS"] as string;
                    user.Subjects = reader["ADDRESS"] as string;
                }
                if (count == 0)
                {
                    connection.Close();
                    return null;
                }
                else
                {
                    connection.Close();
                    return user;
                }
            }
            catch (Exception ex)
            {
                connection.Close();
                //here we can inplement custom exception for trach the error/issues
                return null;
            }
            
        }
    }
}
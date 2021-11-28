using Shreeyashclasses.Shreeyash.Interface;
using Shreeyashclasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.IO;

namespace Shreeyashclasses.Shreeyash.DAC
{
    public class Questions : IQuestions
    {
        private OleDbConnection connection = new OleDbConnection();
        public bool InsertNewQuestion(Question newQuestion) 
        {
            try
            {
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\ShreeyasDataBase\\ShreeyashclassesDB.accdb") + ";Persist Security Info=False;";
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Questions(QUESTION,OPTIONONE,OPTIONTWO,OPTIONTHREE,OPTIONFOUR,ANSWER,CREATEDDATE,MODIFIEDDATE) VALUES ('"
                                      + newQuestion.QuestionName + "','" + newQuestion.OptionOne + "','" + newQuestion.OptionTwo + "','" + newQuestion.OptionThree + "','" + newQuestion.OptionFour + "','" + newQuestion.Answer + "','" + newQuestion.CreatedDate + "','" + newQuestion.ModifiedDate + "');";
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

        public List<Question> GetQuestions() 
        {
            try
            {
                List<Question> listofQuestions = new List<Question>();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\ShreeyasDataBase\\ShreeyashclassesDB.accdb") + ";Persist Security Info=False;";
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "Select * from Questions";

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Question question = new Question();
                    question.Id = Convert.ToInt32(reader["ID"]);
                    question.QuestionName = reader["QUESTION"] as string;
                    question.OptionOne = reader["OPTIONONE"] as string;
                    question.OptionTwo = reader["OPTIONTWO"] as string;
                    question.OptionThree = reader["OPTIONTHREE"] as string;
                    question.OptionFour = reader["OPTIONFOUR"] as string;
                    question.Answer = reader["ANSWER"] as string;
                    question.CreatedDate = Convert.ToDateTime(reader["CREATEDDATE"]);
                    question.ModifiedDate = Convert.ToDateTime(reader["MoDIFIEDDATE"]);
                    listofQuestions.Add(question);
                }
                if (listofQuestions.Count == 0)
                {
                    connection.Close();
                    return null;
                }
                else
                {
                    connection.Close();
                    return listofQuestions;
                }
            }
            catch (Exception ex)
            {
                connection.Close();
                //here we can inplement custom exception for trach the error/issues
                return null;
            }
        }

        public Question GetQuestion(int Id)
        {
            try
            {
                List<Question> listofQuestions = new List<Question>();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\ShreeyasDataBase\\ShreeyashclassesDB.accdb") + ";Persist Security Info=False;";
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "Select * from Questions where ID=" + Id;

                OleDbDataReader reader = command.ExecuteReader();
                Question question = new Question();
                while (reader.Read())
                {
                    question.Id = Convert.ToInt32(reader["ID"]);
                    question.QuestionName = reader["QUESTION"] as string;
                    question.OptionOne = reader["OPTIONONE"] as string;
                    question.OptionTwo = reader["OPTIONTWO"] as string;
                    question.OptionThree = reader["OPTIONTHREE"] as string;
                    question.OptionFour = reader["OPTIONFOUR"] as string;
                    question.Answer = reader["ANSWER"] as string;
                    question.CreatedDate = Convert.ToDateTime(reader["CREATEDDATE"]);
                    question.ModifiedDate = Convert.ToDateTime(reader["MoDIFIEDDATE"]);
                }
                if (question == null)
                {
                    connection.Close();
                    return null;
                }
                else
                {
                    connection.Close();
                    return question;
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
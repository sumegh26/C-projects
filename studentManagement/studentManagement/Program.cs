using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace studentManagement
{
    class Program
    {
        public static void studentPanel()
        {
            int menu_sel = -1;
            //int count = 0;
            Console.Clear();
            Console.WriteLine(" ---------------------------------------------");
            Console.WriteLine("| Welcome student                             |");
            Console.WriteLine("| 1. Register                                 |");
            Console.WriteLine("| 2. View Courses                             |");
            Console.WriteLine("| 3. Apply for a Course                       |");
            Console.WriteLine(" ----------------------------------------------");
            menu_sel = Convert.ToInt32(Console.ReadLine());
            switch (menu_sel)
            {
                case 1://REGISTER NEW STUDENT
                    addNewStu();
                    break;
                case 2:
                    display(2);
                    break;
                case 3:
                    Console.WriteLine("To apply for a new course,Please Register again with a new Roll no!");
                    Console.ReadLine();
                    break;
            }

        }

        public static void adminPanel()
        {
            int menu_sel = -1;
            Console.Clear();
            Console.WriteLine(" ----------------------------------------------");
            Console.WriteLine("| Welcome admin                               |");
            Console.WriteLine("| 1. Add a new course                         |");
            Console.WriteLine("| 2. View Courses                             |");
            Console.WriteLine("| 3. View Student                             |");
            Console.WriteLine(" ----------------------------------------------");
            menu_sel = Convert.ToInt32(Console.ReadLine());
            switch (menu_sel)
            {
                case 1:
                    addNewCourse();
                    break;
                case 2:
                    display(2);
                    break;
                case 3:
                    display(1);
                    break;

            }
        }

        public static void display(int c)
        {
            Console.Clear();
            string provider = ConfigurationManager.AppSettings
               ["provider"];

            string connnectionString = ConfigurationManager.AppSettings
                ["connectionString"];

            DbProviderFactory factory =
                DbProviderFactories.GetFactory(provider);

            using (DbConnection connection =
                factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                    return;
                }
                connection.ConnectionString = connnectionString;
                connection.Open();
                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                    return;
                }
              
                

                switch (c)
            {


                case 1: //view all students
                             command.Connection = connection;
                             command.CommandText = "Select * From student";

                             using (DbDataReader dataReader =
                               command.ExecuteReader())
                                {
                                     Console.WriteLine("\tROLL NO. \t NAME \t\t\t\t\t\t  DATE OF BIRTH \t\t\t  COURSEID");
                                     Console.WriteLine("\t---------------------------------------------------------------------------------------------------------------------------");
                            while (dataReader.Read())
                                  {
                                     Console.WriteLine($"\t{dataReader["ROLLNO"]}" 
                                           + $"\t\t{dataReader["NAME"]}"+$"{dataReader["DATEOFBIRTH"]}"+ $"{dataReader["COURSEID"]}") ;
                                   }
                                 }
                        Console.WriteLine("\t Press Enter to continue.");
                        break;
                    
                case 2:  //view all courses
                           command.Connection = connection;
                           command.CommandText = "Select * From course";

                              using (DbDataReader dataReader =
                                command.ExecuteReader())
                              {
                                      Console.WriteLine("\tCOURSEID \t COURSENAME \t\t  DURATION \t\t   FEES");
                                      Console.WriteLine("\t----------------------------------------------------------------------------");
                            while (dataReader.Read())
                                  {
                                
                                      Console.WriteLine($"\t{dataReader["COURSEID"]}"
                                         + $"      \t {dataReader["COURSENAME"]}" + $"{dataReader["DURATION"]}" + $"{dataReader["FEES"]}");
                                   }
                              }
                        Console.WriteLine("\t Press Enter to continue.");
                        break;


            }
                
                Console.ReadLine();
            }
        }

        public static void addNewStu()
        {
            Console.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                int rn, ci;
                string sname, BD;
                conn.ConnectionString = "Server=MSI;Database=student_sms;Trusted_Connection=true";
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO student (ROLLNO, NAME, DATEOFBIRTH, COURSEID) VALUES (@0, @1, @2, @3)", conn);

                Console.WriteLine("Enter Roll No:");
                rn = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter your Name");
                sname = Console.ReadLine();

                Console.WriteLine("Enter your Birth Date[dd/mm/yyyy]");
                BD = Console.ReadLine();

                Console.WriteLine("Enter CourseID");
                ci = Convert.ToInt32(Console.ReadLine());

                insertCommand.Parameters.Add(new SqlParameter("0", rn));
                insertCommand.Parameters.Add(new SqlParameter("1", sname));
                insertCommand.Parameters.Add(new SqlParameter("2", BD));
                insertCommand.Parameters.Add(new SqlParameter("3", ci));

                Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
                Console.WriteLine("New student registration done! Press enter.");
                Console.ReadLine();
                Console.Clear();

            }
        }

        public static void addNewCourse()
        {
            Console.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                int ci;
                string cname, dur;
                float fe;
                conn.ConnectionString = "Server=MSI;Database=student_sms;Trusted_Connection=true";
                conn.Open();

                Console.WriteLine("Let's add a new course!");
                SqlCommand insertCommand = new SqlCommand("INSERT INTO course (COURSEID, COURSENAME, DURATION, FEES) VALUES (@0, @1, @2, @3)", conn);

                Console.WriteLine("Enter COURSEID:");
                ci = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter course name");
                cname = Console.ReadLine();

                Console.WriteLine("Enter course duration");
                dur = Console.ReadLine();

                Console.WriteLine("Enter fees");
                fe = Convert.ToInt32(Console.ReadLine());

                insertCommand.Parameters.Add(new SqlParameter("0", ci));
                insertCommand.Parameters.Add(new SqlParameter("1", cname));
                insertCommand.Parameters.Add(new SqlParameter("2", dur));
                insertCommand.Parameters.Add(new SqlParameter("3", fe));

                Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
                Console.WriteLine("Done! Press enter.");
                Console.ReadLine();
                Console.Clear();

            }
        }


        static void Main(string[] args)
        {
            int menu_sel = -1;
            while (menu_sel != 0)
            {
                Console.Clear();
                Console.WriteLine(" --------------------------------------------");
                Console.WriteLine("| Welcome to SMS (Student Management System)  |");
                Console.WriteLine("|                                             |");
                Console.WriteLine("|  Tell us who you are:                       |");
                Console.WriteLine("| 1. Student                                  |");
                Console.WriteLine("| 2. Admin                                    |");
                Console.WriteLine("| 0. Exit                                     |");
                Console.WriteLine("|                                             |");
                Console.WriteLine(" --------------------------------------------");
                menu_sel =Convert.ToInt32( Console.ReadLine());
                switch(menu_sel)
                {
                    case 1:
                        studentPanel();
                        break;
                    case 2:
                        adminPanel();
                        break;
                    case 0:
                        Console.WriteLine("Are you sure?"); 
                        Console.WriteLine("Press Enter to confirm.");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Enter a valid response!.");
                        Console.ReadLine();
                        continue;
                }
            }
        }
    }
}



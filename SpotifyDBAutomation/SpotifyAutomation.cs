/*summary :DB Automation for Insert and select query
  Author: Vedhashni V
  Date  : 20-08-21
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System;
using System.Text;

namespace SpotifyDBAutomation
{
    
    public class SpotifyAutomation
    {

       SpotifyModel model = new SpotifyModel();
        public static string connectionstring= @"Data Source=(localdb)\MSSQLLocalDB;Database=spotify;Integrated Security=True;";
        SqlConnection connection = new SqlConnection(connectionstring);


        public int InsertIntoTable(SpotifyModel model)
        {
            int count = 0;
            try
            {
                using (connection)
                {
                    SqlCommand InsertCommand = new SqlCommand("Insert INTO TrackTable (PlaylistId, TrackName, ArtistName) VALUES (@1, @2, @3)", connection);

                    //InsertCommand.Parameters.Add(new SqlParameter("1", "4"));
                    InsertCommand.Parameters.Add(new SqlParameter("1", "2"));
                    InsertCommand.Parameters.Add(new SqlParameter("2", "track7"));
                    InsertCommand.Parameters.Add(new SqlParameter("3", "ABC"));

                    
                    //Opening the connection
                    connection.Open();
                    //returns the number of rows updated
                    int result = InsertCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        //Count the insert value
                        count++;
                        Console.WriteLine("Inserted Successfully");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Closing the connection
                connection.Close();
            }
            return count;
        }


        public int retriveData()
        {
            SpotifyModel model = new SpotifyModel();
            int count = 0;
            try
            {
                using (connection)
                {
                    //Retrieve query
                    string query = @"select * from TrackTable";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    //open sql connection
                    connection.Open();
                    //sql reader to read data
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            DisplayDetails(sqlDataReader);
                            count++;
                        }

                    }
                    //close reader
                    sqlDataReader.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                this.connection.Close();
            }
            return count;

        }
        //Display the details
        public void DisplayDetails(SqlDataReader sqlDataReader)
        {

            SpotifyModel model1 = new SpotifyModel();
            model1.TrackId = Convert.ToInt32(sqlDataReader["TrackId"]);
            model1.PlaylistId = Convert.ToInt32(sqlDataReader["PLaylistId"]);
            model1.TrackName = Convert.ToString(sqlDataReader["TrackName"]);
            model1.ArtistName = Convert.ToString(sqlDataReader["ArtistName"]);

            Console.WriteLine("TrackId :{0} PlaylistId :{1} TrackName :{2} ArtistName :{3} ", model1.TrackId, model1.PlaylistId, model1.TrackName, model1.ArtistName);
            Console.WriteLine("\n");



        }



        public int EditExistingContact(SpotifyModel model1)
        {
            
            int count = 0;
            try
            {
                using (connection)
                {
                    //Query Execution(Update)
                  
            string query = @"update TrackTable set PlaylistId='4' where TrackName='track4'";
            //Passing the query and dbconnection
            SqlCommand sqlCommand = new SqlCommand(query, this.connection);
            //Opening the connection
            connection.Open();
            int result = sqlCommand.ExecuteNonQuery();
            
                    if (result != 0)
                    {
                        count++;
                        Console.WriteLine("Updated SuccessFully");
                        
                    }
                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //closes the connection
                connection.Close();
            }
            return count;

        }

        public int Delete(SpotifyModel model)
        {
            int count = 0;
            try
            {
                using (connection)
                {
                    //Query Execution(Delete)
                    string query = @"delete from TrackTable where ArtistName='hjk'";
                    //Passing the query and dbconnection
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    //Opening the connection
                    connection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        count++;
                        Console.WriteLine("Deleted SuccessFully");

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //closes the connection
                connection.Close();
            }
            return count;

        }
    }
}

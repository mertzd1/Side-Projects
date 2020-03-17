using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;



namespace WPF_ZooManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();
            //this connects the Mainwindow to the database
            string connectionString = ConfigurationManager.ConnectionStrings["WPF_ZooManager.Properties.Settings.PandDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            ShowZoos();
            ShowAnimals();
        }

        private void ShowZoos()
        {
            try
            {
                string query = "select * from Zoo";
                //the SqlDataAdaper can be thought of as an Inferface to make Tables usable by C# objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable zooTable = new DataTable();

                    sqlDataAdapter.Fill(zooTable);
                    //Shows information of the Table in DataTable should be shown in our listBox
                    listZoos.DisplayMemberPath = "Location";
                    //Shows value should be deleivered, when an Item form listbos is selected
                    listZoos.SelectedValuePath = "Id";
                    //The reference to the data this listBox should populate
                    listZoos.ItemsSource = zooTable.DefaultView;

                }
            }
            catch (Exception e) //this is a generic exception
            {
                //MessageBox.Show(e.ToString());
            }


        }

        private void ShowAssociatedAnimals()
        {
            try
            {
                string query = "select * from Animal a inner join ZooAnimal za " +
                    "on a.Id = za.AnimalId where za.ZooId = @ZooId";
                
                //cannot pass @ZooId to an sqladapter we must add it to sqlcommand
                SqlCommand sqlcommand = new SqlCommand(query, sqlConnection);//this takes the query and passes to sqladapter
                //the SqlDataAdaper can be thought of as an Inferface to make Tables usable by C# objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand);

                using (sqlDataAdapter)
                {
                    sqlcommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);

                    DataTable animalTable = new DataTable();

                    sqlDataAdapter.Fill(animalTable);
                    //Shows information of the Table in DataTable should be shown in our listBox
                    listAssociatedAnimals.DisplayMemberPath = "Name";
                    //Shows value should be deleivered, when an Item form listbos is selected
                    listAssociatedAnimals.SelectedValuePath = "Id";
                    //The reference to the data this listBox should populate
                    listAssociatedAnimals.ItemsSource = animalTable.DefaultView;

                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }


        }
        private void ShowAnimals()
        {
            try
            {
                string query = "select * from Animal";

                
                //the SqlDataAdaper can be thought of as an Inferface to make Tables usable by C# objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {                   

                    DataTable allAnimalTable = new DataTable();

                    sqlDataAdapter.Fill(allAnimalTable);
                    //Shows information of the Table in DataTable should be shown in our listBox
                    listAnimals.DisplayMemberPath = "Name";
                    //Shows value should be deleivered, when an Item form listbos is selected
                    listAnimals.SelectedValuePath = "Id";
                    //The reference to the data this listBox should populate
                    listAnimals.ItemsSource = allAnimalTable.DefaultView;

                }
            }
            catch (Exception e)
            {
              //  MessageBox.Show(e.ToString());
            }


        }

        private void listZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ShowAssociatedAnimals();
            ShowSelectedZooInTextBox();
        }

     

        private void DeleteZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Zoo where Id= @ZooId";
                //shorter way of using sqlcommand
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {

              //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowZoos(); //this updates the list after you delete a zoo
            }
            
            
        }

        private void AddZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Zoo values (@Location)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Location", myTextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {

             //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowZoos(); 
            }


        }

        private void ShowSelectedAnimalInTextBox()
        {
            try
            {
                string query = "select Name from Animal where Id=@AnimalId";


                //cannot pass @ZooId to an sqladapter we must add it to sqlcommand
                SqlCommand sqlcommand = new SqlCommand(query, sqlConnection);//this takes the query and passes to sqladapter
                //the SqlDataAdaper can be thought of as an Inferface to make Tables usable by C# objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand);

                using (sqlDataAdapter)
                {
                    sqlcommand.Parameters.AddWithValue("@AnimalId", listAnimals.SelectedValue);

                    DataTable zoolDataTable = new DataTable();

                    sqlDataAdapter.Fill(zoolDataTable);
                    myTextBox.Text = zoolDataTable.Rows[0]["Name"].ToString();

                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }



        }
        private void ShowSelectedZooInTextBox()
        {
            try
            {
                string query = "select Location from Zoo where Id=@ZooId";


                //cannot pass @ZooId to an sqladapter we must add it to sqlcommand
                SqlCommand sqlcommand = new SqlCommand(query, sqlConnection);//this takes the query and passes to sqladapter
                //the SqlDataAdaper can be thought of as an Inferface to make Tables usable by C# objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand);

                using (sqlDataAdapter)
                {
                    sqlcommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);

                    DataTable zoolDataTable = new DataTable();

                    sqlDataAdapter.Fill(zoolDataTable);
                    myTextBox.Text = zoolDataTable.Rows[0]["Location"].ToString();

                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }



        }
        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Animal values (@Name)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", myTextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {

                //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAnimals();
            }


        }
        private void AddAnimalToZoo_Click(object sender, RoutedEventArgs e) //do not forget to add the click to xaml
        {
            try
            {
                string query = "insert into ZooAnimal values (@ZooId, @AnimalId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();               
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAnimals.SelectedValue);                
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex) 
            {

               //MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();                
                ShowAssociatedAnimals();
            }

           
        }
        private void DeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Animal where Id= @AnimalId";
                //shorter way of using sqlcommand
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAnimals.SelectedValue) ;
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAnimals(); //this updates the list after you delete a zoo
            }

        }
        private void RemoveAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Animal where Id= @AnimalId";
                //shorter way of using sqlcommand
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAssociatedAnimals.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAssociatedAnimals(); //this updates the list after you delete a zoo
            }

        }

        private void UpdateZoo_Click(object sender, RoutedEventArgs e) //do not forget to add the click to xaml
        {
            try
            {
                string query = "update Zoo Set Location= @Location where Id =@ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@Location", myTextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowZoos();
            }


        }
        private void UpdateAnimal_Click(object sender, RoutedEventArgs e) //do not forget to add the click to xaml
        {
            try
            {
                string query = "update Animal Set Name= @Name where Id =@AnimalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAnimals.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@Name", myTextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAnimals();
            }


        }


        private void listAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowSelectedAnimalInTextBox();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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

namespace HRAM.UI.Views.Admin
{
    /// <summary>
    /// Interaction logic for OverviewView.xaml
    /// </summary>
    public partial class OverviewView : UserControl
    {
        public OverviewView()
        {
            InitializeComponent();
            LoadDataGrid();
        }
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=HRAMDATA; Integrated Security=True;");
        public void LoadDataGrid()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM dbo.[User]", sqlCon);
                DataTable dt = new DataTable();
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                dt.Load(sdr);
                datagrid.ItemsSource = dt.DefaultView;
                sdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
        public bool IsValid()
        {
            if (firstname_txt.Text == String.Empty)
            {
                MessageBox.Show("First Name is required!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (lastname_txt.Text == String.Empty)
            {
                MessageBox.Show("Last Name is required!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (email_txt.Text == String.Empty)
            {
                MessageBox.Show("Email is required!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void Insert_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    SqlCommand sqlCommand = new SqlCommand("usp_AddUser", sqlCon);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName", firstname_txt.Text);
                    sqlCommand.Parameters.AddWithValue("@LastName", lastname_txt.Text);
                    sqlCommand.Parameters.AddWithValue("@Email", email_txt.Text);
                    sqlCommand.Parameters.AddWithValue("@Password", pass_txt.Password);

                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    int newUserId = -1;
                    int succes = 0;
                    string result = "";

                    while (sqlDataReader.Read())
                    {
                        newUserId = Convert.ToInt32(sqlDataReader["newUserId"]);
                        succes = Convert.ToInt32(sqlDataReader["succes"]);
                        result = sqlDataReader["result"].ToString();
                    }

                    sqlDataReader.Close();

                    LoadDataGrid();
                    if(succes == 1)
                        MessageBox.Show("Registred!", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Invalid!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
        private void Delete_click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(" DELETE FROM dbo.[User] WHERE UserId = "+userid_txt.Text+" ", sqlCon);
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Deleted!", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
        private void Update_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = "UPDATE dbo.[User] SET FirstName = '" + firstname_txt.Text + "', LastName = '" + lastname_txt.Text + "', Email = '" + email_txt.Text + "' WHERE UserId = '" + userid_txt.Text + "' ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                LoadDataGrid();
                MessageBox.Show("Updates have been made!", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}

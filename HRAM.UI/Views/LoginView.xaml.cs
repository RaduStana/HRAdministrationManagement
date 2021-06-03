using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using HRAM.UI.ViewModels;
using HRAM.UI.Models;

namespace HRAM.UI.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent(); 
        }
        public static String _EmailLog;

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=HRAMDATA; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = "SELECT COUNT(1) FROM dbo.[User] WHERE Email=@Email AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon)
                {
                    CommandType = CommandType.Text
                };

                _EmailLog = EmailAddress.Text;

                sqlCmd.Parameters.AddWithValue("@Email", EmailAddress.Text);
                sqlCmd.Parameters.AddWithValue("@Password", Password.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    MainWindow MainWindowView = new MainWindow();
                    MainWindowView.Show();
                    System.Windows.Forms.Application.Exit();
                    Window.GetWindow(this).Close();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect.");
                }
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
    }
}

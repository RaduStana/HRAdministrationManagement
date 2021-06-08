using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace HRAM.UI.Views.Admin
{
    /// <summary>
    /// Interaction logic for HolidayCheck.xaml
    /// </summary>
    public partial class HolidaycheckView : UserControl
    {
        public HolidaycheckView()
        {
            InitializeComponent();
            LoadDataGrid();
        }
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=HRAMDATA; Integrated Security=True;");
        public void LoadDataGrid()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Select * from dbo.Holiday where State = 'neaprobat'", sqlCon);
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
        private void UpdateButton(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = "UPDATE dbo.Holiday SET State = 'aprobat' WHERE HolidayId = '" + holidayid_txt.Text + "' ";
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

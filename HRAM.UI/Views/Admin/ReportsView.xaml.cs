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
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class ReportsView : UserControl
    {
        public ReportsView()
        {
            InitializeComponent();
        }
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=HRAMDATA; Integrated Security=True;");
        public void LoadDataGrid(object sender, RoutedEventArgs e)
        {
            try
            {
                string q = "";
                if (!projectId_txt.Text.Equals(""))
                    q = "SELECT * FROM dbo.Project where ProjectId = '" + projectId_txt.Text + "'";
                else if (!departementId_txt.Text.Equals(""))
                    q = "SELECT * FROM Department where DepId = '" + departementId_txt.Text + "'";
                else
                    throw new Exception("Unkown source!");

                SqlCommand sqlCommand = new SqlCommand(q, sqlCon);
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
    }
}

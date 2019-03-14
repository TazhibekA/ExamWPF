using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace ExamWPFDataGrid
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Context context = new Context();
        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid();
        }
        List<Good> list = new List<Good>();
        private void FillDataGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT Id, Name, Cost, Count FROM Goods";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Goods");
                sda.Fill(dt);
                
                dataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void Update() {
            context.SaveChanges();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          

        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string columnName = dataGrid.CurrentColumn.HeaderStringFormat;

            
        }
    }
}

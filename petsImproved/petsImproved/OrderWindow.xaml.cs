using petsImproved.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
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

namespace petsImproved
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        PetsContext db;
        public static OrderWindow App;
        public OrderWindow() //зображує 
        {
            InitializeComponent();
            App = this;
            this.getData();
        }

        public void getData()
        {
            db = new PetsContext();
            db.Orders.Load();
            animalsGrid.ItemsSource = db.Orders.Local.ToBindingList();

            this.Closing += OrderWindow_Closing;
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            object item = animalsGrid.SelectedItem;
            int ID = 0;
            try
            {
                ID = Int32.Parse((animalsGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            }
            catch (Exception)
            {
                return;
            }
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PetsConnection2"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand command = new SqlCommand("DELETE FROM " + "tblOrder" + " WHERE " + "id" + " = '" + ID + "'", con))
                        {
                            command.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                    this.getData();
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
                }
            }
        }


        private void OrderWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }
    }
}
using petsImproved.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public OrderWindow() //зображує 
        {
            InitializeComponent();

            db = new PetsContext();
            db.Orders.Load();
            animalsGrid.ItemsSource = db.Orders.Local.ToBindingList();

            this.Closing += OrderWindow_Closing;
        }
       

        private void OrderWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }
    }
}
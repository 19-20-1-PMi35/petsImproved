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
using petsImproved.Models;

namespace petsImproved
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window
    {
        PetsContext db;
        public static MainWindow AppWindow;
        public MainWindow()
        {
            InitializeComponent();
            AppWindow = this;
            this.getData();
        }

        public void getData()
        {
            db = new PetsContext();
            db.Animals.Load();
            animalsGrid.ItemsSource = db.Animals.Local.ToBindingList();
            this.Closing += MainWindow_Closing;
        }

        private void AddPet(object sender, RoutedEventArgs e)
        {
            PetForm petForm = new PetForm();
            petForm.ShowDialog();
        }

        private void ShowOrders(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.ShowDialog();
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
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
            AnimalDetailed animalWindow = new AnimalDetailed();
            animalWindow.passId(ID);
            animalWindow.ShowDialog();
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }
    }
}
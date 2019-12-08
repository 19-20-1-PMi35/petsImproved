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
using System.Windows.Shapes;
using petsImproved.Models;

namespace petsImproved
{
    /// <summary>
    /// Interaction logic for OrdersForms.xaml
    /// </summary>
    public partial class OrdersForms : Window
    {
        private int id;
        public OrdersForms()
        {
            InitializeComponent();
        }
        public void passId(int elementId)
        {
            id = elementId;
        }
        private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }
        private void AddOrder(object sender, RoutedEventArgs e)
        {
            String name = Name.Text;
            String phone = Phone.Text;
            EntOrder order = new EntOrder();
            order.surname = name;
            order.pnone = phone;
            order.animalId = id;
            PetsContext context = new PetsContext();
            context.Orders.Add(order);
            context.SaveChanges();
            this.Close();
        }
    }
}

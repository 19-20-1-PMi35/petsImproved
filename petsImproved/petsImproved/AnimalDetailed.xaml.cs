using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;
using petsImproved.Models;

namespace petsImproved
{
    /// <summary>
    /// Interaction logic for AnimalDetailed.xaml
    /// </summary>
    public partial class AnimalDetailed : Window
    {
        private int id;


        public AnimalDetailed()
        {
            InitializeComponent();
        }
        private void AddOrder(object sender, RoutedEventArgs e)
        {
            OrdersForms orderForm = new OrdersForms();
            orderForm.passId(id);
            orderForm.ShowDialog();
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            PetsContext petsContext = new PetsContext();
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PetsConnection2"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand command = new SqlCommand("DELETE FROM " + "tblAnimal" + " WHERE " + "id" + " = '" + id + "'", con))
                        {
                            command.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                    petsImproved.MainWindow.AppWindow.getData();
                    this.Close();
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
                }
            }
        }
    public void init(int elementId)
        {
            id = elementId;
            PetsContext petsContext = new PetsContext();
            var petInfo = petsContext.Animals.Find(id);
            Name.Text = petInfo.name;
            Bread.Text = "Breed: " + petInfo.breed;
            Sex.Text = "Sex: " + petInfo.sex;
            Age.Text = "Age: " + petInfo.age.ToString();
            Description.Text = petInfo.description;

        }
    }
}


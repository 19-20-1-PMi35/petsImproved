using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
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
            this.Hide();
            orderForm.ShowDialog();
            this.Show();
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
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
            var sizeId = Convert.ToInt32(petInfo.sizeId);
            var typeId = Convert.ToInt32(petInfo.typeId);
            var sizeInfo = petsContext.Sizes.Find(sizeId);
            var typeInfo = petsContext.Types.Find(typeId);
            Name.Text = petInfo.name;
            Bread.Text = "Breed: " + petInfo.breed;
            Sex.Text = "Sex: " + petInfo.sex;
            Age.Text = "Age: " + petInfo.age.ToString();
            Size.Text = "Size: " + sizeInfo.size;
            Type.Text = "Type: " + typeInfo.type;
            Description.Text = petInfo.description;
            File.WriteAllBytes("image.jpg", petInfo.image);

            MemoryStream memorystream = new MemoryStream();
            memorystream.Write(petInfo.image, 0, (int)petInfo.image.Length);
            
            BitmapImage imgsource = new BitmapImage();

            memorystream.Seek(0, SeekOrigin.Begin);

            imgsource.BeginInit();
            imgsource.StreamSource = memorystream;
            imgsource.EndInit();
            NImage.Source = imgsource;


        }

        private void Main_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow main = new MainWindow();
            main.ShowDialog();
        }
    }
}


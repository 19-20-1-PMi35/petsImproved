using System;
using System.Collections.Generic;
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
    }
}


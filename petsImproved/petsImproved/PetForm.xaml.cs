﻿using System;
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
using Microsoft.Win32;
using petsImproved.Models;


namespace petsImproved
{
    /// <summary>
    /// Interaction logic for PetForm.xaml
    /// </summary>
    public partial class PetForm : Window
    {
        public string sex { get; set; }
        public string type { get; set; }
        public string size { get; set; }
        public byte[] imageData { get; set; }


        public PetForm()
        {
            InitializeComponent();
        }
        private void AddPet(object sender, RoutedEventArgs e)
        {
            String name = Name.Text;
            int age = Int32.Parse(Age.Text);
            String breed = Breed.Text;
            String description = Description.Text;
            EntAnimal animal = new EntAnimal();
            animal.name = name;
            animal.image = imageData;
            animal.age = age;
            int size_id = 0;
            if (size == "Small")
            {
                size_id = 1;
            }
            else if (size == "Medium")
            {
                size_id = 2;
            }
            else
            {
                size_id = 3;
            }
            animal.sizeId = size_id;
            int type_id = 0;
            if (type == "Cat")
            {
                type_id = 2;
            }
            else
            {
                type_id = 1;
            }
            animal.typeId = type_id;
            animal.breed = breed;
            animal.description = description;
            animal.sex = sex;
            PetsContext context = new PetsContext();
            context.Animals.Add(animal);
            context.SaveChanges();
            petsImproved.MainWindow.AppWindow.getData();
            this.Close();
        }
        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                sex = Convert.ToString(ck.Content);
        }
        private void Type_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                type = Convert.ToString(ck.Content);
        }
        private void Size_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                size = Convert.ToString(ck.Content);
        }
        private void Age_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }

        private void btnOpenFile_Click(Object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var imageStream = openFileDialog.OpenFile();

                imageData = Encoding.Default.GetBytes(new StreamReader(imageStream).ReadToEnd());
                imageStream.Position = 0;
                var str = new StreamReader(imageStream).ReadToEnd();
                txtEditor.Text = str;
            }

        }
    }
}
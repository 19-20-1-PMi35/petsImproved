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

namespace petsImproved
{
    /// <summary>
    /// Interaction logic for AnimalDetailed.xaml
    /// </summary>
    public partial class AnimalDetailed : Window
    {
        private int id;
        public void passId(int elementId)
        {
            id = elementId;
        }
        public AnimalDetailed()
        {
            InitializeComponent();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PharmacyApp.Data;
using PharmacyApp.Services;

namespace PharmacyApp
{
    /// <summary>
    /// Interaction logic for DrugDetailsWindow.xaml
    /// </summary>
    public partial class DrugDetailsWindow : Window
    {
        private readonly Drug _drug;
        
        public DrugDetailsWindow(Drug drug)
        {
            InitializeComponent();

            _drug = drug;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Text = _drug.Name;
            txtAdverseEffect.Text = _drug.AdverseEffect;
            txtIngredient.Text = _drug.Ingredient;
            txtSymptom.Text = _drug.RelievedSymptom;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

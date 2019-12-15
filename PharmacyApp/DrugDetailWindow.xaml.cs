using System;
using System.Collections.Generic;
using System.Linq;
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

namespace PharmacyApp
{
    /// <summary>
    /// Interaction logic for DrugDetailWindow.xaml
    /// </summary>
    public partial class DrugDetailWindow : Window
    {
        private Drug _drug;

        public DrugDetailWindow(Drug drug)
        {
            InitializeComponent();

            _drug = drug;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.symptomsList.ItemsSource = _drug.RelievedSymptoms.ToList();
            this.adverseEffectsList.ItemsSource = _drug.AdverseEffects.ToList();
            this.interactionsList.ItemsSource = _drug.Interactions.ToList();
            this.firmText.Text = _drug.Firm.Name;
            this.ingredientText.Text = _drug.Ingredient.Name;
        }
    }
}

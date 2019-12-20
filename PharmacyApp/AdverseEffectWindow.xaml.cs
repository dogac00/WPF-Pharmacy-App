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
    /// Interaction logic for AdverseEffectWindow.xaml
    /// </summary>
    public partial class AdverseEffectWindow : Window
    {
        private PharmacyUser _user;
        private DrugService _service;

        public AdverseEffectWindow(PharmacyUser user)
        {
            InitializeComponent();

            _user = user;
            _service = ServiceProvider.GetDrugService();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            this.adverseEffectsGrid.Columns[2].Visibility = Visibility.Collapsed;
            this.adverseEffectsGrid.Columns[3].Visibility = Visibility.Collapsed;
        }
    }
}

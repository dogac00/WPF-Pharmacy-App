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
using Microsoft.EntityFrameworkCore;
using PharmacyApp.Extensions;

namespace PharmacyApp
{
    /// <summary>
    /// Interaction logic for DrugsWindow.xaml
    /// </summary>
    public partial class DrugsWindow : Window
    {
        private PharmacyUser _user;

        public DrugsWindow(PharmacyUser user)
        {
            InitializeComponent();

            
            this.drugsTable.CanUserAddRows = false;
            this.drugsTable.CanUserDeleteRows = false;
            this.drugsTable.CanUserReorderColumns = false;
            this.drugsTable.AddButtonColumn("Detayları gör", ShowDetailsClick);

            _user = user;
        }

        private void ShowDetailsClick(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.drugsTable.ItemsSource = _user
                .Pharmacy
                .Drugs
                .Select(drug => drug.ToGridDrug())
                .ToList();
        }
    }
}

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
using PharmacyApp.Extensions;
using PharmacyApp.Services;

namespace PharmacyApp
{
    /// <summary>
    /// Interaction logic for DrugWindow.xaml
    /// </summary>
    public partial class DrugWindow : Window
    {
        private DrugService _drugService;
        private PharmacyUser _user;

        public DrugWindow(PharmacyUser user)
        {
            InitializeComponent();

            _user = user;
            _drugService = ServiceProvider.GetDrugService();

            this.drugsGrid.CanUserDeleteRows = false;
            this.drugsGrid.CanUserAddRows = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.drugsGrid.AddButtonColumn("Detay Gör", ShowDetailsButton);
            this.drugsGrid.AddButtonColumn("Sil", DeleteDrugButton);

            UpdateDrugsGrid();
        }

        private void UpdateDrugsGrid()
        {
            var drugs = _drugService.GetAllDrugs(_user);
            
            this.drugsGrid.ItemsSource = drugs;
            this.drugsGrid.HideColumn("Id");
            this.drugsGrid.HideColumn("User");
            this.drugsGrid.HideColumn("UserId");
            this.drugsGrid.HideColumn("Ingredient");
            this.drugsGrid.HideColumn("RelievedSymptom");
            this.drugsGrid.HideColumn("AdverseEffect");
            this.drugsGrid.RenameColumn("Name", "İsim");
        }

        private void DeleteDrugButton(object sender, RoutedEventArgs e)
        {
            var drug = this.drugsGrid.SelectedItem as Drug;

            _drugService.DeleteDrug(_user, drug);

            MessageBox.Show("İlaç silindi.");

            UpdateDrugsGrid();
        }

        private void ShowDetailsButton(object sender, RoutedEventArgs e)
        {
            var drug = this.drugsGrid.SelectedItem as Drug;
            
            DrugDetailsWindow window = new DrugDetailsWindow(drug);

            window.ShowDialog();
        }
    }
}

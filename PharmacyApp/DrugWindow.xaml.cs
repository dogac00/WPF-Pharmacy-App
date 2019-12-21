using System;
using System.Collections.Generic;
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

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.drugsGrid.AddButtonColumn("Detay Gör", ShowDetailsButton);
            this.drugsGrid.AddButtonColumn("Sil", DeleteDrugButton);

            await UpdateDrugsGrid();
        }

        private async Task UpdateDrugsGrid()
        {
            var drugs = await _drugService.GetAllDrugsAsync(_user);
            
            this.drugsGrid.ItemsSource = drugs;
            this.drugsGrid.HideColumn("Id");
            this.drugsGrid.HideColumn("User");
            this.drugsGrid.HideColumn("UserId");
            this.drugsGrid.HideColumn("Ingredient");
            this.drugsGrid.HideColumn("RelievedSymptom");
            this.drugsGrid.HideColumn("AdverseEffect");
            this.drugsGrid.RenameColumn("Name", "İsim");
        }

        private async void DeleteDrugButton(object sender, RoutedEventArgs e)
        {
            var drug = this.drugsGrid.SelectedItem as Drug;

            await _drugService.DeleteDrugAsync(_user, drug);

            MessageBox.Show("İlaç silindi.");

            await UpdateDrugsGrid();
        }

        private void ShowDetailsButton(object sender, RoutedEventArgs e)
        {
            var drug = this.drugsGrid.SelectedItem as Drug;
            
            DrugDetailsWindow window = new DrugDetailsWindow(drug);

            window.ShowDialog();
        }
    }
}

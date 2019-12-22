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
using PharmacyApp.Services;

namespace PharmacyApp
{
    /// <summary>
    /// Interaction logic for SearchDrugWindow.xaml
    /// </summary>
    public partial class SearchDrugWindow : Window
    {
        private PharmacyUser _user;
        private DrugService _service;

        public SearchDrugWindow(PharmacyUser user)
        {
            InitializeComponent();

            _user = user;
            _service = ServiceProvider.GetDrugService();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.drugPropertiesBox.ItemsSource = new List<string>
            {
                "İsim", "Etken Madde", "Semptom", "Yan Etki"
            };
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var property = this.drugPropertiesBox.SelectedItem as string;
            var keyword = txtSearchBox.Text;
            
            List<Drug> drugs;

            switch (property)
            {
                case "İsim":
                    drugs = _service.FindDrugs(_user, d => d.Name.Contains(keyword));
                    break;
                case "Etken Madde":
                    drugs = _service.FindDrugs(_user, d => d.Ingredient.Contains(keyword));
                    break;
                case "Semptom":
                    drugs = _service.FindDrugs(_user, d => d.RelievedSymptom.Contains(keyword));
                    break;
                case "Yan Etki":
                    drugs = _service.FindDrugs(_user, d => d.AdverseEffect.Contains(keyword));
                    break;
                default:
                    MessageBox.Show("Lütfen menüden geçerli bir değer seçiniz.");
                    return;
            }

            if (!drugs.Any())
            {
                MessageBox.Show("Aradığınız ilaç bulunamadı.");

                return;
            }

            StringBuilder drugDetails = new StringBuilder("\t\tBulunan İlaçlar\r\n");

            foreach (Drug drug in drugs)
            {
                string currentDrug = $"\t\t Bulunan İlaç Detayı\t\r\n" + 
                                     $"\tİlaç Adı\t\t{drug.Name}\t\r\n" +
                                     $"\tİlaç Etken Madde\t{drug.Ingredient}\t\r\n" +
                                     $"\tİlaç Semptom\t{drug.RelievedSymptom}\t\r\n" +
                                     $"\tİlaç Yan Etki\t{drug.AdverseEffect}\t\r\n";

                drugDetails.Append(currentDrug);
            }


            MessageBox.Show(drugDetails.ToString());
        }
    }
}

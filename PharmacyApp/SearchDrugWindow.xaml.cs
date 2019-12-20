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
            Drug toLook;

            switch (property)
            {
                case "İsim":
                    toLook = _service.FindDrug(_user, d => d.Name.Contains(keyword));
                    break;
                case "Etken Madde":
                    toLook = _service.FindDrug(_user, d => d.Ingredient.Contains(keyword));
                    break;
                case "Semptom":
                    toLook = _service.FindDrug(_user, d => d.RelievedSymptom.Contains(keyword));
                    break;
                case "Yan Etki":
                    toLook = _service.FindDrug(_user, d => d.AdverseEffect.Contains(keyword));
                    break;
                default:
                    throw new Exception();
            }

            if (toLook == null)
            {
                MessageBox.Show("Aradığınız ilaç bulunamadı.");

                return;
            }

            string drugDetails = $"İlaç Adı\t\t{ toLook.Name }\r\n" +
                                 $"İlaç Etken Madde\t{ toLook.Ingredient }\r\n" +
                                 $"İlaç Semptom\t{ toLook.RelievedSymptom }\r\n" +
                                 $"İlaç Yan Etki\t{ toLook.AdverseEffect }\r\n";

            MessageBox.Show(drugDetails);
        }
    }
}

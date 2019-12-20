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
    /// Interaction logic for AddDrugWindow.xaml
    /// </summary>
    public partial class AddDrugWindow : Window
    {
        private readonly PharmacyUser _user;
        private readonly DrugService _service;

        public AddDrugWindow(PharmacyUser user)
        {
            InitializeComponent();

            _user = user;
            _service = ServiceProvider.GetDrugService();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string ingredient = txtIngredient.Text;
            string symptom = txtSymptom.Text;
            string adverseEffect = txtAdverseEffect.Text;

            Drug drug = new Drug
            {
                AdverseEffect = adverseEffect,
                Ingredient = ingredient,
                Name = name,
                RelievedSymptom = symptom,
                UserId = _user.Id,
                User = _user
            };

            _service.AddDrug(_user, drug);

            MessageBox.Show("İlaç başarıyla eklendi.");

            this.Close();
        }
    }
}

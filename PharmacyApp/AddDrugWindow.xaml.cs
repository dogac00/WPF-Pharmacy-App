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
        private PharmacyUser _user;
        private DrugService _drugService;

        public AddDrugWindow(PharmacyUser user)
        {
            InitializeComponent();

            _user = user;
            _drugService = ServiceProvider.GetDrugService();
        }

        private void AddSymptomButton_Click(object sender, RoutedEventArgs e)
        {
            string symptom = symptomTextBox.Text;

            if (string.IsNullOrEmpty(symptom))
            {
                MessageBox.Show("Lütfen bir semptom giriniz.");

                return;
            }

            foreach (object item in symptomsList.Items)
            {
                string existingSymptom = item as string;

                if (symptom == existingSymptom)
                {
                    MessageBox.Show("Bu semptom zaten daha önce eklenmiş.");

                    return;
                }
            }

            this.symptomsList.Items.Add(symptom);
        }

        private void addAdverseEffectButton_Click(object sender, RoutedEventArgs e)
        {
            string effect = adverseEffectTextBox.Text;

            if (string.IsNullOrEmpty(effect))
            {
                MessageBox.Show("Lütfen bir yan etki giriniz.");

                return;
            }

            foreach (object item in adverseEffectsList.Items)
            {
                string adverseEffect = item as string;

                if (effect == adverseEffect)
                {
                    MessageBox.Show("Bu yan etki zaten daha önce eklenmiş.");

                    return;
                }
            }

            this.adverseEffectsList.Items.Add(effect);
        }

        private void addInteractionButton_Click(object sender, RoutedEventArgs e)
        {
            string interaction = interactionTextBox.Text;

            if (string.IsNullOrEmpty(interaction))
            {
                MessageBox.Show("Lütfen bir yan etki giriniz.");

                return;
            }

            foreach (object item in interactionsList.Items)
            {
                string existingInteraction = item as string;

                if (interaction == existingInteraction)
                {
                    MessageBox.Show("Bu etki zaten daha önce eklenmiş.");

                    return;
                }
            }

            this.interactionsList.Items.Add(interaction);
        }

        private async void addDrugButton_Click(object sender, RoutedEventArgs e)
        {
            List<Symptom> symptoms = new List<Symptom>();

            foreach (object item in this.symptomsList.Items)
            {
                symptoms.Add(new Symptom(item as string));
            }

            List<AdverseEffect> adverseEffects = new List<AdverseEffect>();

            foreach (object item in this.adverseEffectsList.Items)
            {
                adverseEffects.Add(new AdverseEffect(item as string));
            }

            List<Drug> interactions = new List<Drug>();

            foreach (object item in this.interactionsList.Items)
            {
                Drug found = _drugService.FindDrug(_user, item as string);

                if (found == null)
                    continue;

                interactions.Add(found);
            }

            string firm = this.firmTextBox.Text;
            string ingredient = this.ingredientTextBox.Text;
            string name = this.drugNameTextBox.Text;
            string price = this.priceTextBox.Text;

            if (string.IsNullOrEmpty(firm) || string.IsNullOrEmpty(ingredient) ||
                string.IsNullOrEmpty(name))
            {
                MessageBox.Show("İsim, firma ve içerik değerleri boş olamaz.");
                return;
            }

            Drug toAdd = new Drug(name, firm, new decimal(double.Parse(price)))
            {
                AdverseEffects = adverseEffects,
                Interactions = interactions,
                RelievedSymptoms = symptoms,
                Ingredient = new Ingredient(ingredient)
            };

            await _drugService.AddDrugAsync(_user, toAdd);

            MessageBox.Show($"Drug { name } added successfully.");

            this.Close();
        }

        private void priceTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox priceTextBox = sender as TextBox;

            string price = priceTextBox.Text;

            if (string.IsNullOrEmpty(price))
                return;

            bool canParse = double.TryParse(price, out var result);

            if (!canParse)
            {
                priceTextBox.Text = string.Empty;
                MessageBox.Show("Lütfen fiyat değeri olarak geçerli bir değer giriniz.");
            }
        }

        private async void drugNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox nameTextBox = sender as TextBox;

            string name = nameTextBox.Text;

            Drug drug = _drugService.FindDrug(_user, name);

            if (drug != null)
            {
                nameTextBox.Text = string.Empty;
                MessageBox.Show("Bu isimde bir ilaç zaten bulunmaktadır. Lütfen başka bir ilaç giriniz.");
            }
        }
    }
}

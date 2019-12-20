using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PharmacyApp.Data;

namespace PharmacyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PharmacyUser _user;

        public MainWindow(PharmacyUser user)
        {
            InitializeComponent();

            _user = user;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.helloLabel.Text = string.Concat("Merhaba, " , _user.UserName);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            DrugWindow window = new DrugWindow(_user);

            window.ShowDialog();
        }

        private void adverseEffectsButton_Click(object sender, RoutedEventArgs e)
        {
            AdverseEffectWindow window = new AdverseEffectWindow(_user);

            window.ShowDialog();
        }

        private void AddDrugButtonClick(object sender, RoutedEventArgs e)
        {
            AddDrugWindow window = new AddDrugWindow(_user);

            window.ShowDialog();
        }

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            SearchDrugWindow window = new SearchDrugWindow(_user);

            window.ShowDialog();
        }
    }
}

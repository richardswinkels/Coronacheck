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
using System.Windows.Shapes;
using WpfCoronaCheck.Classes;

namespace WpfCoronaCheck
{
    /// <summary>
    /// Interaction logic for AddEventWindow.xaml
    /// </summary>
    public partial class AddEventWindow : Window
    {
        DbConnection _dbConnection = new DbConnection();

        public string ExecutedAction { get; private set; }

        public AddEventWindow()
        {
            InitializeComponent();
        }

        private void AddBinnenwedstrijd()
        {
            try
            {
                //Maak nieuw binnenwedstrijd object met de waardes uit het formulier
                Binnenwedstrijd binnenwedstrijd = new Binnenwedstrijd((bool)cbWedstrijdDoorstroom.IsChecked)
                {
                    Naam = txbWedstrijdNaam.Text,
                    StartDatum = (DateTime)dpWedstrijdStartDatum.SelectedDate,
                    WedstrijdDuur = TimeSpan.Parse(txbWedstrijdDuur.Text)
                };

                //Voeg toe aan database
                _dbConnection.AddBinnenwedstrijd(binnenwedstrijd);
                //Zet uitgevoerde actie in property ExecutedAction
                ExecutedAction = "AddBinnenwedstrijd";
                this.Close();
            }
            catch (Exception)
            {

            }
        }

        private void AddBuitenwedstrijd()
        {
            try
            {
                //Maak nieuw buitenwedstrijd object met de waardes uit het formulier
                Buitenwedstrijd buitenwedstrijd = new Buitenwedstrijd((bool)cbWedstrijdDoorstroom.IsChecked)
                {
                    Naam = txbWedstrijdNaam.Text,
                    StartDatum = (DateTime)dpWedstrijdStartDatum.SelectedDate,
                    WedstrijdDuur = TimeSpan.Parse(txbWedstrijdDuur.Text)
                };

                //Voeg toe aan database
                _dbConnection.AddBuitenwedstrijd(buitenwedstrijd);
                //Zet uitgevoerde actie in property ExecutedAction
                ExecutedAction = "AddBuitenwedstrijd";
                this.Close();
            }
            catch (Exception)
            {

            }
        }

        private void BtnAddWedstrijd_Click(object sender, RoutedEventArgs e)
        {
            //Haal geselecteerde comboboxitem op
            ComboBoxItem cbiSoortWedstrijd = (ComboBoxItem)cmbSoortWedstrijd.SelectedItem;
            if (cbiSoortWedstrijd != null)
            {
                //Voer add methode uit op basis van de wedstrijdsoort
                switch (cbiSoortWedstrijd.Content.ToString())
                {
                    case "Binnenwedstrijd":
                        AddBinnenwedstrijd();
                        break;
                    case "Buitenwedstrijd":
                        AddBuitenwedstrijd();
                        break;
                }
            }
        }

        private void BtnAddMuseumUitje_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Maak nieuw museumuitje object met de waardes uit het formulier
                MuseumUitje museumUitje = new MuseumUitje((bool)cbMuseumDoorstroom.IsChecked, (bool)cbMuseumBinnenevent.IsChecked, Convert.ToDecimal(txbMuseumToegangsprijs.Text))
                {
                    Naam = txbMuseumNaam.Text,
                    StartDatum = (DateTime)dpMuseumStartDatum.SelectedDate,
                };
                //Voeg toe aan database
                _dbConnection.AddMuseumUitje(museumUitje);
                //Zet uitgevoerde actie in property ExecutedAction
                ExecutedAction = "AddMuseumUitje";
                this.Close();
            }
            catch (Exception)
            {

            }
        }

        private void BtnAddBioscoopUitje_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Maak nieuw bioscoopjeuitje object met de waardes uit het formulier
                BioscoopUitje bioscoopUitje = new BioscoopUitje((bool)cbBioscoopDoorstroom.IsChecked, (bool)cbBioscoopBinnenevent.IsChecked, DateTime.Parse(txbBioscoopAanvangstijdstip.Text), TimeSpan.Parse(txbBioscoopDuur.Text), txbBioscoopFilm.Text, txbBioscoopZaal.Text, txbBioscoopStoel.Text)
                {
                    Naam = txbBioscoopNaam.Text,
                    StartDatum = (DateTime)dpBioscoopStartDatum.SelectedDate,
                };
                //Voeg toe aan database
                _dbConnection.AddBioscoopUitje(bioscoopUitje);
                //Zet uitgevoerde actie in property ExecutedAction
                ExecutedAction = "AddBioscoopUitje";
                this.Close();
            }
            catch (Exception)
            {

            }
        }

        private void TcTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Verander hoogte van window op basis van geselecteerde tab
            switch (tcTabs.SelectedIndex)
            {
                case 0:
                    this.Height = 360;
                    break;
                case 1:
                    this.Height = 335;
                    break;
                case 2:
                    this.Height = 550;
                    break;
            }
        }
    }
}


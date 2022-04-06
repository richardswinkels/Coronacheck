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
    /// Interaction logic for EditEventWindow.xaml
    /// </summary>
    public partial class EditEventWindow : Window
    {
        DbConnection _dbConnection = new DbConnection();
        int _objectId;

        public string ExecutedAction { get; private set; }

        public EditEventWindow(string editAction, object objectToEdit)
        {
            InitializeComponent();

            //Laat bepaalde grid zien op basis van parameter editAction, geef te bewerken object mee als parameter
            switch (editAction)
            {
                case "EditBinnenwedstrijd":
                    ShowBinnenwedstrijdGrid(objectToEdit);
                    break;
                case "EditBuitenwedstrijd":
                    ShowBuitenwedstrijdGrid(objectToEdit);
                    break;
                case "EditMuseumUitje":
                    ShowMuseumUitjeGrid(objectToEdit);
                    break;
                case "EditBioscoopUitje":
                    ShowBioscoopUitjeGrid(objectToEdit);
                    break;
            }
        }

        private void ShowBinnenwedstrijdGrid(object objectToEdit)
        {
            //Laat grid zien, lees object uit en vul het formulier met de gegevens van het object
            gridWedstrijd.Visibility = Visibility.Visible;
            Binnenwedstrijd binnenwedstrijd = (Binnenwedstrijd)objectToEdit;
            txbWedstrijdNaam.Text = binnenwedstrijd.Naam;
            dpWedstrijdStartDatum.SelectedDate = binnenwedstrijd.StartDatum;
            cbWedstrijdDoorstroom.IsChecked = binnenwedstrijd.Doorstroom;
            txbWedstrijdDuur.Text = binnenwedstrijd.WedstrijdDuur.ToString(@"hh\:mm");
            //Koppel eventhandler aan de button
            btnAddWedstrijd.Click += BtnUpdateBinnenwedstrijd_Click;
            //Zet de hoogte van de window
            this.Height = 280;
            //Zet id van object in variabele
            _objectId = binnenwedstrijd.Id;
        }

        private void ShowBuitenwedstrijdGrid(object objectToEdit)
        {
            //Laat grid zien, lees object uit en vul het formulier met de gegevens van het object
            gridWedstrijd.Visibility = Visibility.Visible;
            Buitenwedstrijd buitenwedstrijd = (Buitenwedstrijd)objectToEdit;
            txbWedstrijdNaam.Text = buitenwedstrijd.Naam;
            dpWedstrijdStartDatum.SelectedDate = buitenwedstrijd.StartDatum;
            cbWedstrijdDoorstroom.IsChecked = buitenwedstrijd.Doorstroom;
            txbWedstrijdDuur.Text = buitenwedstrijd.WedstrijdDuur.ToString(@"hh\:mm");
            //Koppel eventhandler aan de button
            btnAddWedstrijd.Click += BtnUpdateBuitenwedstrijd_Click;
            //Zet de hoogte van de window
            this.Height = 280;
            //Zet id van object in variabele
            _objectId = buitenwedstrijd.Id;
        }

        private void ShowMuseumUitjeGrid(object objectToEdit)
        {
            //Laat grid zien, lees object uit en vul het formulier met de gegevens van het object
            gridMuseumUitje.Visibility = Visibility.Visible;
            MuseumUitje museumUitje = (MuseumUitje)objectToEdit;
            txbMuseumNaam.Text = museumUitje.Naam;
            dpMuseumStartDatum.SelectedDate = museumUitje.StartDatum;
            txbMuseumToegangsprijs.Text = museumUitje.Toegangsprijs.ToString("0.00");
            cbMuseumBinnenevent.IsChecked = museumUitje.BinnenEvent;
            cbMuseumDoorstroom.IsChecked = museumUitje.Doorstroom;
            //Zet de hoogte van de window
            this.Height = 310;
            //Zet id van object in variabele
            _objectId = museumUitje.Id;
        }

        private void ShowBioscoopUitjeGrid(object objectToEdit)
        {
            //Laat grid zien, lees object uit en vul het formulier met de gegevens van het object
            gridBioscoopUitje.Visibility = Visibility.Visible;
            BioscoopUitje bioscoopUitje = (BioscoopUitje)objectToEdit;
            txbBioscoopNaam.Text = bioscoopUitje.Naam;
            dpBioscoopStartDatum.SelectedDate = bioscoopUitje.StartDatum;
            txbBioscoopAanvangstijdstip.Text = bioscoopUitje.AanvangsTijdstip.ToString(@"hh\:mm");
            txbBioscoopDuur.Text = bioscoopUitje.Duur.ToString(@"hh\:mm");
            txbBioscoopFilm.Text = bioscoopUitje.Film;
            txbBioscoopZaal.Text = bioscoopUitje.Zaal;
            txbBioscoopStoel.Text = bioscoopUitje.Stoel;
            cbBioscoopBinnenevent.IsChecked = bioscoopUitje.BinnenEvent;
            cbBioscoopDoorstroom.IsChecked = bioscoopUitje.Doorstroom;
            //Zet de hoogte van de window
            this.Height = 530;
            //Zet id van object in variabele
            _objectId = bioscoopUitje.Id;
        }

        private void BtnUpdateBinnenwedstrijd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Maak nieuw binnenwedstrijd object met de waardes uit het formulier
                Binnenwedstrijd binnenwedstrijd = new Binnenwedstrijd((bool)cbWedstrijdDoorstroom.IsChecked)
                {
                    Id = _objectId,
                    Naam = txbWedstrijdNaam.Text,
                    StartDatum = (DateTime)dpWedstrijdStartDatum.SelectedDate,
                    WedstrijdDuur = TimeSpan.Parse(txbWedstrijdDuur.Text)
                };
                //Update in database
                _dbConnection.UpdateBinnenwedstrijd(binnenwedstrijd);
                //Zet uitgevoerde actie in property ExecutedAction
                ExecutedAction = "UpdateBinnenwedstrijd";
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnUpdateBuitenwedstrijd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Maak nieuw buitenwedstrijd object met de waardes uit het formulier
                Buitenwedstrijd buitenwedstrijd = new Buitenwedstrijd((bool)cbWedstrijdDoorstroom.IsChecked)
                {
                    Id = _objectId,
                    Naam = txbWedstrijdNaam.Text,
                    StartDatum = (DateTime)dpWedstrijdStartDatum.SelectedDate,
                    WedstrijdDuur = TimeSpan.Parse(txbWedstrijdDuur.Text)
                };
                //Update in database
                _dbConnection.UpdateBuitenwedstrijd(buitenwedstrijd);
                //Zet uitgevoerde actie in property ExecutedAction
                ExecutedAction = "UpdateBuitenwedstrijd";
                this.Close();
            }
            catch (Exception)
            {

            }
        }

        private void BtnUpdateMuseumUitje_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Maak nieuw bioscoopjeuitje object met de waardes uit het formulier
                MuseumUitje museumUitje = new MuseumUitje((bool)cbMuseumDoorstroom.IsChecked, (bool)cbMuseumBinnenevent.IsChecked, Convert.ToDecimal(txbMuseumToegangsprijs.Text))
                {
                    Id = _objectId,
                    Naam = txbMuseumNaam.Text,
                    StartDatum = (DateTime)dpMuseumStartDatum.SelectedDate,
                };
                //Update in database
                _dbConnection.UpdateMuseumUitje(museumUitje);
                //Zet uitgevoerde actie in property ExecutedAction
                ExecutedAction = "UpdateMuseumUitje";
                this.Close();
            }
            catch (Exception)
            {

            }
        }

        private void BtnUpdateBioscoopUitje_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Maak nieuw bioscoopjeuitje object met de waardes uit het formulier
                BioscoopUitje bioscoopUitje = new BioscoopUitje((bool)cbBioscoopDoorstroom.IsChecked, (bool)cbBioscoopBinnenevent.IsChecked, DateTime.Parse(txbBioscoopAanvangstijdstip.Text), TimeSpan.Parse(txbBioscoopDuur.Text), txbBioscoopFilm.Text, txbBioscoopZaal.Text, txbBioscoopStoel.Text)
                {
                    Id = _objectId,
                    Naam = txbBioscoopNaam.Text,
                    StartDatum = (DateTime)dpBioscoopStartDatum.SelectedDate,
                };
                //Update in database
                _dbConnection.UpdateBioscoopUitje(bioscoopUitje);
                //Zet uitgevoerde actie in property ExecutedAction
                ExecutedAction = "UpdateBioscoopUitje";
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}

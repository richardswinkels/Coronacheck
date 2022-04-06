using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
using WpfCoronaCheck.Classes;
using WpfCoronaCheck.Interfaces;

namespace WpfCoronaCheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        DbConnection _dbConnection = new DbConnection();

        private ObservableCollection<Wedstrijd> wedstrijden;
        private ObservableCollection<Binnenwedstrijd> binnenwedstrijden;
        private ObservableCollection<Buitenwedstrijd> buitenwedstrijden;
        private ObservableCollection<Uitje> uitjes;
        private ObservableCollection<MuseumUitje> museumUitjes;
        private ObservableCollection<BioscoopUitje> bioscoopUitjes;
        private ObservableCollection<ICoronaCheckEvenement> iCoronaCheckEvenementen;

        public ObservableCollection<Wedstrijd> Wedstrijden
        {
            get { return wedstrijden; }
            set { wedstrijden = value;
                NotifyPropertyChanged("Wedstrijden");
            }
        }

        public ObservableCollection<Binnenwedstrijd> Binnenwedstrijden
        {
            get { return binnenwedstrijden; }
            set { binnenwedstrijden = value;
                NotifyPropertyChanged("Binnenwedstrijden");
            }
        }

        public ObservableCollection<Buitenwedstrijd> Buitenwedstrijden
        {
            get { return buitenwedstrijden; }
            set { buitenwedstrijden = value;
                NotifyPropertyChanged("Buitenwedstrijden");
            }
        }

        public ObservableCollection<Uitje> Uitjes
        {
            get { return uitjes; }
            set { uitjes = value;
                NotifyPropertyChanged("Uitjes");
            }
        }

        public ObservableCollection<MuseumUitje> MuseumUitjes
        {
            get { return museumUitjes; }
            set { museumUitjes = value;
                NotifyPropertyChanged("MuseumUitjes");
            }
        }

        public ObservableCollection<BioscoopUitje> BioscoopUitjes
        {
            get { return bioscoopUitjes; }
            set { bioscoopUitjes = value;
                NotifyPropertyChanged("BioscoopUitjes");
            }
        }

        public ObservableCollection<ICoronaCheckEvenement> ICoronaCheckEvenementen
        {
            get { return iCoronaCheckEvenementen; }
            set { iCoronaCheckEvenementen = value;
                NotifyPropertyChanged("ICoronaCheckEvenementen");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            //Laad alle gegevens uit de database
            LoadBinnenwedstrijden();
            LoadBuitenwedstrijden();
            LoadMuseumUitjes();
            LoadBioscoopUitjes();
            //Zet de verschillende evenementen in de gezamelijke collecties
            PopulateWedstrijden();
            PopulateUitjes();
            PopulateICoronaCheck();

            //Koppel selectionchanged event aan de combobox
            cmbEvents.SelectionChanged += CmbEvents_SelectionChanged;
        }

        private void LoadBinnenwedstrijden()
        {
            //Haal alle binnenwedstrijden op uit de database
            Binnenwedstrijden = _dbConnection.GetAllBinnenwedstrijden();
        }

        private void LoadBuitenwedstrijden()
        {
            //Haal alle buitenwedstrijden op uit de database
            Buitenwedstrijden = _dbConnection.GetAllBuitenwedstrijden();
        }

        private void LoadMuseumUitjes()
        {
            //Haal alle museumuitjes op uit de database
            MuseumUitjes = _dbConnection.GetAllMuseumUitjes();
        }

        private void LoadBioscoopUitjes()
        {
            //Haal alle bioscoopuitjes op uit de database
            BioscoopUitjes = _dbConnection.GetAllBioscoopUitjes();
        }

        private void PopulateWedstrijden()
        {
            //Maak een nieuwe observablecollection voor de wedstrijden
            Wedstrijden = new ObservableCollection<Wedstrijd>();

            //Loop door alle binnenwedstrijden
            foreach (Binnenwedstrijd binnenwedstrijd in Binnenwedstrijden)
            {
                //Voeg binnenwedstrijd toe aan Wedstrijden
                Wedstrijden.Add(binnenwedstrijd);
            }

            //Loop door alle buitenwedstrijden
            foreach (Buitenwedstrijd buitenwedstrijd in Buitenwedstrijden)
            {
                //Voeg buitenwedstrijd toe aan Wedstrijden
                Wedstrijden.Add(buitenwedstrijd);
            }
        }

        private void PopulateUitjes()
        {
            //Maak een nieuwe observablecollection voor de uitjes
            Uitjes = new ObservableCollection<Uitje>();

            //Loop door alle museumuitjes
            foreach (MuseumUitje museumUitje in MuseumUitjes)
            {
                //Voeg museumuitje toe aan Uitjes
                Uitjes.Add(museumUitje);
            }

            //Loop door alle bioscoopuitjes
            foreach (BioscoopUitje bioscoopUitje in BioscoopUitjes)
            {
                //Voeg bioscoopuitje toe aan Uitjes
                Uitjes.Add(bioscoopUitje);
            }
        }

        private void PopulateICoronaCheck()
        {
            //Maak een nieuwe observablecollection voor ICoronaCheckEvenementen
            ICoronaCheckEvenementen = new ObservableCollection<ICoronaCheckEvenement>();

            //Loop door alle binnenwedstrijden
            foreach (Binnenwedstrijd binnenwedstrijd in Binnenwedstrijden)
            {
                //Voeg binnenwedstrijd toe aan ICoronaCheckEvenementen
                ICoronaCheckEvenementen.Add(binnenwedstrijd);
            }

            //Loop door alle buitenwedstrijden
            foreach (Buitenwedstrijd buitenwedstrijd in Buitenwedstrijden)
            {
                //Voeg buitenwedstrijd toe aan ICoronaCheckEvenementen
                ICoronaCheckEvenementen.Add(buitenwedstrijd);
            }

            //Loop door alle museumuitjes
            foreach (MuseumUitje museumUitje in MuseumUitjes)
            {
                //Voeg museumuitje toe aan ICoronaCheckEvenementen
                ICoronaCheckEvenementen.Add(museumUitje);
            }

            //Loop door alle bioscoopuitjes
            foreach (BioscoopUitje bioscoopUitje in BioscoopUitjes)
            {
                //Voeg bioscoopuitje toe aan ICoronaCheckEvenementen
                ICoronaCheckEvenementen.Add(bioscoopUitje);
            }
        }

        private void ShowAddWindow()
        {
            //Maak nieuwe instance van addEventWindow
            AddEventWindow addEventWindow = new AddEventWindow();
            //Verberg huidige window
            this.Hide();
            //Laat event window zien
            addEventWindow.ShowDialog();
            //Laat huidige window zien
            this.Show();
            //Herlaad database gegevens en repopulate de gezamelijke ObservableCollections op basis van de uitgevoerde actie
            switch (addEventWindow.ExecutedAction)
            {
                case "AddBinnenwedstrijd":
                    LoadBinnenwedstrijden();
                    PopulateWedstrijden();
                    PopulateICoronaCheck();
                    break;
                case "AddBuitenwedstrijd":
                    LoadBuitenwedstrijden();
                    PopulateWedstrijden();
                    PopulateICoronaCheck();
                    break;
                case "AddMuseumUitje":
                    LoadMuseumUitjes();
                    PopulateUitjes();
                    PopulateICoronaCheck();
                    break;
                case "AddBioscoopUitje":
                    LoadBioscoopUitjes();
                    PopulateUitjes();
                    PopulateICoronaCheck();
                    break;
            }
        }

        private void ShowEditWindow(string showAction, object objectToEdit)
        {
            //Maak nieuwe instance van editEventWindow, geef action parameter door
            EditEventWindow editEventWindow = new EditEventWindow(showAction, objectToEdit);
            //Verberg huidige window
            this.Hide();
            //Laat event window zien
            editEventWindow.ShowDialog();
            //Laat huidige window zien
            this.Show();
            //Herlaad database gegevens en repopulate de gezamelijke ObservableCollections op basis van de uitgevoerde actie
            switch (editEventWindow.ExecutedAction)
            {
                case "UpdateBinnenwedstrijd":
                    LoadBinnenwedstrijden();
                    PopulateWedstrijden();
                    PopulateICoronaCheck();
                    break;
                case "UpdateBuitenwedstrijd":
                    LoadBuitenwedstrijden();
                    PopulateWedstrijden();
                    PopulateICoronaCheck();
                    break;
                case "UpdateMuseumUitje":
                    LoadMuseumUitjes();
                    PopulateUitjes();
                    PopulateICoronaCheck();
                    break;
                case "UpdateBioscoopUitje":
                    LoadBioscoopUitjes();
                    PopulateUitjes();
                    PopulateICoronaCheck();
                    break;
            }
            //Reset de coronacheck status
            ResetCoronaCheckDisplay();
        }

        private void ResetCoronaCheckDisplay()
        {
            //Reset selectie
            lbEvents.SelectedItem = null;
            //Reset textblock en image
            tbCoronaCheckRequired.Text = "";
            imgCoronaCheckRequired.Source = null;
        }

        private void CmbEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Reset de coronacheck status
            ResetCoronaCheckDisplay();

            //Haal geselecteerde item op uit de combobox
            ComboBoxItem selectedItem = (ComboBoxItem)cmbEvents.SelectedItem;
            //Stel listbox binding in op basis van geselecteerde item
            switch (selectedItem.Content.ToString())
            {
                case "Evenementen":
                    lbEvents.SetBinding(ListBox.ItemsSourceProperty, new Binding { Source = this, Path = new PropertyPath("ICoronaCheckEvenementen") });
                    break;
                case "Wedstrijden":
                    lbEvents.SetBinding(ListBox.ItemsSourceProperty, new Binding { Source = this, Path = new PropertyPath("Wedstrijden") });
                    break;
                case "Binnenwedstrijden":
                    lbEvents.SetBinding(ListBox.ItemsSourceProperty, new Binding { Source = this, Path = new PropertyPath("Binnenwedstrijden") });
                    break;
                case "Buitenwedstrijden":
                    lbEvents.SetBinding(ListBox.ItemsSourceProperty, new Binding { Source = this, Path = new PropertyPath("Buitenwedstrijden") });
                    break;
                case "Uitjes":
                    lbEvents.SetBinding(ListBox.ItemsSourceProperty, new Binding { Source = this, Path = new PropertyPath("Uitjes") });
                    break;
                case "Museumuitjes":
                    lbEvents.SetBinding(ListBox.ItemsSourceProperty, new Binding { Source = this, Path = new PropertyPath("MuseumUitjes") });
                    break;
                case "Bioscoopuitjes":
                    lbEvents.SetBinding(ListBox.ItemsSourceProperty, new Binding { Source = this, Path = new PropertyPath("BioscoopUitjes") });
                    break;
            }
        }

        private void LbEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Haal geselecteerde item uit de listbox op en cast als ICoronaCheckEvenement
            ICoronaCheckEvenement selectedCoronaCheckEvent = (ICoronaCheckEvenement)lbEvents.SelectedItem;
            if (selectedCoronaCheckEvent != null)
            {
                if (selectedCoronaCheckEvent.CoronaCheckRequired())
                {
                    //Laat tekst en vinkje zien
                    tbCoronaCheckRequired.Text = "Coronacheck vereist";
                    Uri uriSource = new Uri(@"/Images/Check.png", UriKind.Relative);
                    imgCoronaCheckRequired.Source = new BitmapImage(uriSource);
                }
                else
                {
                    //Laat tekst en kruisje zien
                    tbCoronaCheckRequired.Text = "Coronacheck niet vereist";
                    Uri uriSource = new Uri(@"/Images/Cross.png", UriKind.Relative);
                    imgCoronaCheckRequired.Source = new BitmapImage(uriSource);
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Haal geselecteerde item uit de combobox op
            ComboBoxItem selectedItem = (ComboBoxItem)cmbEvents.SelectedItem;
            //Laat add window zien
            ShowAddWindow();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbEvents.SelectedItem != null)
            {
                //Haal type van SelectedItem op
                Type selectedType = lbEvents.SelectedItem.GetType();

                //Voer delete actie uit op basis van het type van SelectedItem en herlaad de gegevens uit de database
                if (selectedType == typeof(Binnenwedstrijd))
                {
                    _dbConnection.DeleteBinnenwedstrijd((Binnenwedstrijd) lbEvents.SelectedItem);
                    LoadBinnenwedstrijden();
                    PopulateWedstrijden();
                    PopulateICoronaCheck();
                }
                else if (selectedType == typeof(Buitenwedstrijd))
                {
                    _dbConnection.DeleteBuitenwedstrijd((Buitenwedstrijd)lbEvents.SelectedItem);
                    LoadBuitenwedstrijden();
                    PopulateWedstrijden();
                    PopulateICoronaCheck();
                }
                else if (selectedType == typeof(MuseumUitje))
                {
                    _dbConnection.DeleteMuseumuitje((MuseumUitje)lbEvents.SelectedItem);
                    LoadMuseumUitjes();
                    PopulateUitjes();
                    PopulateICoronaCheck();
                }
                else if (selectedType == typeof(BioscoopUitje))
                {
                    _dbConnection.DeleteBioscoopUitje((BioscoopUitje)lbEvents.SelectedItem);
                    LoadBioscoopUitjes();
                    PopulateUitjes();
                    PopulateICoronaCheck();
                }

                //Reset de coronacheck status
                ResetCoronaCheckDisplay();
            }
        }

        private void lbEvents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbEvents.SelectedItem != null)
            {
                //Haal type van SelectedItem op
                Type selectedType = lbEvents.SelectedItem.GetType();

                //Open edit window, geef parameter door met de gewenste actie
                if (selectedType == typeof(Binnenwedstrijd))
                {
                    ShowEditWindow("EditBinnenwedstrijd", lbEvents.SelectedItem);
                }
                else if (selectedType == typeof(Buitenwedstrijd))
                {
                    ShowEditWindow("EditBuitenwedstrijd", lbEvents.SelectedItem);
                }
                else if (selectedType == typeof(MuseumUitje))
                {
                    ShowEditWindow("EditMuseumUitje", lbEvents.SelectedItem);
                }
                else if (selectedType == typeof(BioscoopUitje))
                {
                    ShowEditWindow("EditBioscoopUitje", lbEvents.SelectedItem);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }
    }
}

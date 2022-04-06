using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfCoronaCheck.Classes
{
    public class DbConnection
    {
        string _connString = ConfigurationManager.ConnectionStrings["ConnCoronaCheck"].ConnectionString;

        public ObservableCollection<Binnenwedstrijd> GetAllBinnenwedstrijden()
        {
            ObservableCollection<Binnenwedstrijd> binnenwedstrijdList = new ObservableCollection<Binnenwedstrijd>();
            DataTable dtBinnenwedstrijden = new DataTable();

            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Binnenwedstrijden";
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtBinnenwedstrijden.Load(reader);

                    foreach (DataRow row in dtBinnenwedstrijden.Rows)
                    {
                        Binnenwedstrijd binnenwedstrijd = new Binnenwedstrijd(Convert.ToBoolean(row["Doorstroom"]))
                        {
                            Id = Convert.ToInt32(row["Id"].ToString()),
                            Naam = row["Naam"].ToString(),
                            StartDatum = DateTime.Parse(row["StartDatum"].ToString()),
                            WedstrijdDuur = TimeSpan.Parse(row["WedstrijdDuur"].ToString()),
                        };
                        binnenwedstrijdList.Add(binnenwedstrijd);
                    }
                }
                catch (Exception)
                {

                }
            }
            return binnenwedstrijdList;
        }

        public ObservableCollection<Buitenwedstrijd> GetAllBuitenwedstrijden()
        {
            ObservableCollection<Buitenwedstrijd> buitenwedstrijdList = new ObservableCollection<Buitenwedstrijd>();
            DataTable dtBuitenwedstrijden = new DataTable();

            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Buitenwedstrijden";
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtBuitenwedstrijden.Load(reader);

                    foreach (DataRow row in dtBuitenwedstrijden.Rows)
                    {
                        Buitenwedstrijd buitenwedstrijd = new Buitenwedstrijd(Convert.ToBoolean(row["Doorstroom"]))
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Naam = row["Naam"].ToString(),
                            StartDatum = DateTime.Parse(row["StartDatum"].ToString()),
                            WedstrijdDuur = TimeSpan.Parse(row["WedstrijdDuur"].ToString()),
                        };
                        buitenwedstrijdList.Add(buitenwedstrijd);
                    }
                }
                catch (Exception)
                {

                }
            }
            return buitenwedstrijdList;
        }

        public ObservableCollection<MuseumUitje> GetAllMuseumUitjes()
        {
            ObservableCollection<MuseumUitje> museumUitjesList = new ObservableCollection<MuseumUitje>();
            DataTable dtMuseumUitjes = new DataTable();

            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM MuseumUitjes";
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtMuseumUitjes.Load(reader);

                    foreach (DataRow row in dtMuseumUitjes.Rows)
                    {
                        MuseumUitje museumUitje = new MuseumUitje(Convert.ToBoolean(row["Doorstroom"]), Convert.ToBoolean(row["BinnenEvent"]), Convert.ToDecimal(row["ToegangsPrijs"]))
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Naam = row["Naam"].ToString(),
                            StartDatum = DateTime.Parse(row["StartDatum"].ToString()),
                        };
                        museumUitjesList.Add(museumUitje);
                    }
                }
                catch (Exception)
                {

                }
            }
            return museumUitjesList;
        }

        public ObservableCollection<BioscoopUitje> GetAllBioscoopUitjes()
        {
            ObservableCollection<BioscoopUitje> bioscoopUitjesList = new ObservableCollection<BioscoopUitje>();
            DataTable dtBioscoopUitjes = new DataTable();

            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM BioscoopUitjes";
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtBioscoopUitjes.Load(reader);

                    foreach (DataRow row in dtBioscoopUitjes.Rows)
                    {
                        BioscoopUitje bioscoopUitje = new BioscoopUitje(Convert.ToBoolean(row["Doorstroom"]), Convert.ToBoolean(row["BinnenEvent"]), DateTime.Parse(row["AanvangsTijdstip"].ToString()), TimeSpan.Parse(row["Duur"].ToString()), row["Film"].ToString(), row["Zaal"].ToString(), row["Stoel"].ToString())
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Naam = row["Naam"].ToString(),
                            StartDatum = DateTime.Parse(row["StartDatum"].ToString()),
                        };
                        bioscoopUitjesList.Add(bioscoopUitje);
                    }
                }
                catch (Exception)
                {

                }
            }
            return bioscoopUitjesList;
        }

        public void AddBinnenwedstrijd(Binnenwedstrijd binnenwedstrijd)
        {
            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO Binnenwedstrijden (Naam, StartDatum, WedstrijdDuur, Doorstroom) VALUES(@Naam, @StartDatum, @WedstrijdDuur, @Doorstroom);";
                    cmd.Parameters.AddWithValue("@Naam", binnenwedstrijd.Naam);
                    cmd.Parameters.AddWithValue("@StartDatum", binnenwedstrijd.StartDatum);
                    cmd.Parameters.AddWithValue("@WedstrijdDuur", binnenwedstrijd.WedstrijdDuur);
                    cmd.Parameters.AddWithValue("@Doorstroom", binnenwedstrijd.Doorstroom);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
            }
        }

        public void AddBuitenwedstrijd(Buitenwedstrijd buitenwedstrijd)
        {
            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO Buitenwedstrijden (Naam, StartDatum, WedstrijdDuur, Doorstroom) VALUES(@Naam, @StartDatum, @WedstrijdDuur, @Doorstroom);";
                    cmd.Parameters.AddWithValue("@Naam", buitenwedstrijd.Naam);
                    cmd.Parameters.AddWithValue("@StartDatum", buitenwedstrijd.StartDatum);
                    cmd.Parameters.AddWithValue("@WedstrijdDuur", buitenwedstrijd.WedstrijdDuur);
                    cmd.Parameters.AddWithValue("@Doorstroom", buitenwedstrijd.Doorstroom);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
            }
        }

        public void AddMuseumUitje(MuseumUitje museumUitje)
        {
            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO MuseumUitjes (Naam, StartDatum, Doorstroom, BinnenEvent, Toegangsprijs) VALUES(@Naam, @StartDatum, @Doorstroom, @BinnenEvent, @Toegangsprijs);";
                    cmd.Parameters.AddWithValue("@Naam", museumUitje.Naam);
                    cmd.Parameters.AddWithValue("@StartDatum", museumUitje.StartDatum);
                    cmd.Parameters.AddWithValue("@Doorstroom", museumUitje.Doorstroom);
                    cmd.Parameters.AddWithValue("@BinnenEvent", museumUitje.BinnenEvent);
                    cmd.Parameters.AddWithValue("@Toegangsprijs", museumUitje.Toegangsprijs);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
            }
        }

        public void AddBioscoopUitje(BioscoopUitje bioscoopUitje)
        {
            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO BioscoopUitjes (Naam, StartDatum, Doorstroom, BinnenEvent, AanvangsTijdstip, Duur, Film, Zaal, Stoel) VALUES(@Naam, @StartDatum, @Doorstroom, @BinnenEvent, @AanvangsTijdstip, @Duur, @Film, @Zaal, @Stoel);";
                    cmd.Parameters.AddWithValue("@Naam", bioscoopUitje.Naam);
                    cmd.Parameters.AddWithValue("@StartDatum", bioscoopUitje.StartDatum);
                    cmd.Parameters.AddWithValue("@Doorstroom", bioscoopUitje.Doorstroom);
                    cmd.Parameters.AddWithValue("@BinnenEvent", bioscoopUitje.BinnenEvent);
                    cmd.Parameters.AddWithValue("@AanvangsTijdstip", bioscoopUitje.AanvangsTijdstip);
                    cmd.Parameters.AddWithValue("@Duur", bioscoopUitje.Duur);
                    cmd.Parameters.AddWithValue("@Film", bioscoopUitje.Film);
                    cmd.Parameters.AddWithValue("@Zaal", bioscoopUitje.Zaal);
                    cmd.Parameters.AddWithValue("@Stoel", bioscoopUitje.Stoel);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
            }
        }

        public void UpdateBinnenwedstrijd(Binnenwedstrijd binnenwedstrijd)
        {
            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE Binnenwedstrijden SET Naam = @Naam, StartDatum = @StartDatum, WedstrijdDuur = @WedstrijdDuur, Doorstroom = @Doorstroom WHERE Id = @Id;";
                    cmd.Parameters.AddWithValue("@Naam", binnenwedstrijd.Naam);
                    cmd.Parameters.AddWithValue("@StartDatum", binnenwedstrijd.StartDatum);
                    cmd.Parameters.AddWithValue("@WedstrijdDuur", binnenwedstrijd.WedstrijdDuur);
                    cmd.Parameters.AddWithValue("@Doorstroom", binnenwedstrijd.Doorstroom);
                    cmd.Parameters.AddWithValue("@Id", binnenwedstrijd.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
            }
        }

        public void UpdateBuitenwedstrijd(Buitenwedstrijd buitenwedstrijd)
        {
            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE Buitenwedstrijden SET Naam = @Naam, StartDatum = @StartDatum, WedstrijdDuur = @WedstrijdDuur, Doorstroom = @Doorstroom WHERE Id = @Id;";
                    cmd.Parameters.AddWithValue("@Naam", buitenwedstrijd.Naam);
                    cmd.Parameters.AddWithValue("@StartDatum", buitenwedstrijd.StartDatum);
                    cmd.Parameters.AddWithValue("@WedstrijdDuur", buitenwedstrijd.WedstrijdDuur);
                    cmd.Parameters.AddWithValue("@Doorstroom", buitenwedstrijd.Doorstroom);
                    cmd.Parameters.AddWithValue("@Id", buitenwedstrijd.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
            }
        }

        public void UpdateMuseumUitje(MuseumUitje museumUitje)
        {
            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Update MuseumUitjes SET Naam = @Naam, StartDatum = @StartDatum, Doorstroom = @Doorstroom, BinnenEvent = @BinnenEvent, Toegangsprijs = @Toegangsprijs WHERE Id = @Id;";
                    cmd.Parameters.AddWithValue("@Naam", museumUitje.Naam);
                    cmd.Parameters.AddWithValue("@StartDatum", museumUitje.StartDatum);
                    cmd.Parameters.AddWithValue("@Doorstroom", museumUitje.Doorstroom);
                    cmd.Parameters.AddWithValue("@BinnenEvent", museumUitje.BinnenEvent);
                    cmd.Parameters.AddWithValue("@Toegangsprijs", museumUitje.Toegangsprijs);
                    cmd.Parameters.AddWithValue("@Id", museumUitje.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
            }
        }

        public void UpdateBioscoopUitje(BioscoopUitje bioscoopUitje)
        {
            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE BioscoopUitjes SET Naam = @Naam, StartDatum = @StartDatum, Doorstroom = @Doorstroom, BinnenEvent = @BinnenEvent, AanvangsTijdstip = @AanvangsTijdstip, Duur = @Duur, Film = @Film, Zaal = @Zaal, Stoel = @Stoel WHERE Id = @Id;";
                    cmd.Parameters.AddWithValue("@Naam", bioscoopUitje.Naam);
                    cmd.Parameters.AddWithValue("@StartDatum", bioscoopUitje.StartDatum);
                    cmd.Parameters.AddWithValue("@Doorstroom", bioscoopUitje.Doorstroom);
                    cmd.Parameters.AddWithValue("@BinnenEvent", bioscoopUitje.BinnenEvent);
                    cmd.Parameters.AddWithValue("@AanvangsTijdstip", bioscoopUitje.AanvangsTijdstip);
                    cmd.Parameters.AddWithValue("@Duur", bioscoopUitje.Duur);
                    cmd.Parameters.AddWithValue("@Film", bioscoopUitje.Film);
                    cmd.Parameters.AddWithValue("@Zaal", bioscoopUitje.Zaal);
                    cmd.Parameters.AddWithValue("@Stoel", bioscoopUitje.Stoel);
                    cmd.Parameters.AddWithValue("@Id", bioscoopUitje.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
            }
        }

        public void DeleteBinnenwedstrijd(Binnenwedstrijd binnenwedstrijd)
        {
            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM Binnenwedstrijden WHERE ID = @Id;";
                    cmd.Parameters.AddWithValue("@Id", binnenwedstrijd.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
            }
        }

        public void DeleteBuitenwedstrijd(Buitenwedstrijd buitenwedstrijd)
        {
            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM Buitenwedstrijden WHERE ID = @Id;";
                    cmd.Parameters.AddWithValue("@Id", buitenwedstrijd.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
            }
        }

        public void DeleteMuseumuitje(MuseumUitje museumUitje)
        {
            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM MuseumUitjes WHERE ID = @Id;";
                    cmd.Parameters.AddWithValue("@Id", museumUitje.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
            }
        }

        public void DeleteBioscoopUitje(BioscoopUitje bioscoopUitje)
        {
            using (SqlConnection con = new SqlConnection(_connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM BioscoopUitjes WHERE ID = @Id;";
                    cmd.Parameters.AddWithValue("@Id", bioscoopUitje.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
            }
        }
    }
}




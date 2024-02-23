using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient; // SQL Server local DB


namespace application
{
    public class SQL_command
    {
        public Dictionary<int, double> GetValeurheure(int id)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                // Récupérer la date actuelle pour filtrer les mesures du jour actuel
                DateTime currentDate = DateTime.Now.Date;

                string sql_Text = $"SELECT valeur, dateHeure FROM Mesure WHERE IdChannel = '{id}'";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Dictionary<int, double> valeursAgrégéesParHeure = new Dictionary<int, double>();
                        while (reader.Read())
                        {
                            // Utiliser la colonne correspondante pour récupérer les données
                            double valeur = Convert.ToDouble(reader["valeur"]);
                            DateTime dateHeure = Convert.ToDateTime(reader["dateHeure"]);

                            if (dateHeure.Date == currentDate)
                            {
                                // Agréger les valeurs par heure
                                int heureClé = dateHeure.Hour;
                                if (valeursAgrégéesParHeure.ContainsKey(heureClé))
                                {
                                    valeursAgrégéesParHeure[heureClé] += valeur;
                                }
                                else
                                {
                                    valeursAgrégéesParHeure[heureClé] = valeur;
                                }
                            }
                        }
                        return valeursAgrégéesParHeure;
                    }
                }
            }

        }

        public double[] GetValeurminutes(int numbchannel, DateTime day)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                // Initialiser un tableau pour stocker les valeurs par minute
                double[] valeursParMinute = new double[1440 + 1];

                string sql_Text = $"SELECT valeur, dateHeure FROM Mesure WHERE IdChannel = '{numbchannel}' AND CONVERT(date, dateHeure) = '{day.ToString("yyyy-MM-dd")}' ORDER BY dateHeure ASC";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Utiliser la colonne correspondante pour récupérer les données
                            double valeur = Convert.ToDouble(reader["valeur"]);
                            DateTime dateHeure = Convert.ToDateTime(reader["dateHeure"]);

                            // Calculer l'index de la minute dans la journée
                            int minuteIndex = dateHeure.Hour * 60 + dateHeure.Minute;

                            // Stocker la valeur dans le tableau
                            valeursParMinute[minuteIndex] = valeur;
                        }
                        return valeursParMinute;
                    }
                }
            }
        }

        public List<DateTime> GetSortedDays(int numbchannel)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            List<DateTime> joursDifferents = new List<DateTime>();

            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();
                string sql_Text = $"SELECT dateHeure FROM Mesure WHERE IdChannel = '{numbchannel}' ORDER BY dateHeure ASC";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["dateHeure"] != DBNull.Value)
                            {
                                DateTime dateHeure = (DateTime)reader["dateHeure"];
                                DateTime jourUnique = dateHeure.Date;
                                if (!joursDifferents.Contains(jourUnique))
                                {
                                    joursDifferents.Add(jourUnique);
                                }
                            }
                        }
                    }
                }
            }

            // Trier les jours de manière ascendante
            joursDifferents.Sort();

            return joursDifferents;
        }

        public List<int> GetUniqueChannelIds()
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            List<int> uniqueChannelIds = new List<int>();

            // Ouvrir la connexion à la base de données
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();
                // Sélectionner les identifiants de canal distincts
                string sql_Text = "SELECT DISTINCT IdChannel FROM Mesure";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Parcourir les résultats et ajouter les identifiants de canal à la liste
                        while (reader.Read())
                        {
                            if (reader["IdChannel"] != DBNull.Value)
                            {
                                int channelId = (int)reader["IdChannel"];
                                uniqueChannelIds.Add(channelId);
                            }
                        }
                    }
                }
            }

            // Retourner la liste des identifiants de canal uniques
            return uniqueChannelIds;
        }

        public void AddValueToChannel(int channelId, double value)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;

            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                // Get the current date and time
                DateTime currentDate = DateTime.Now;

                // Create the SQL command to insert a new record
                string sql_Text = "INSERT INTO Mesure (IdChannel, valeur, dateHeure) VALUES (@IdChannel, @Value, @DateHeure)";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    // Add parameters to the command to prevent SQL injection
                    cmd.Parameters.AddWithValue("@IdChannel", channelId);
                    cmd.Parameters.AddWithValue("@Value", value);
                    cmd.Parameters.AddWithValue("@DateHeure", currentDate);

                    // Execute the SQL command
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}

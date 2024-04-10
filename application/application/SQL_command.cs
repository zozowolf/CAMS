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
        public Dictionary<int, double> GetValeurheure(int idChannel, int idEnregistrement)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                // Récupérer la date actuelle pour filtrer les mesures du jour actuel
                DateTime currentDate = DateTime.Now.Date;

                string sql_Text = $"SELECT valeur, dateHeure FROM Mesure WHERE Id = '{idChannel}' AND IdEnregistrement ='{idEnregistrement}' AND type = 'Num' ";

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

        public double[] GetValeurminutes(int idChannel, int idEnregistrement, DateTime day)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                // Initialiser un tableau pour stocker les valeurs par minute
                double[] valeursParMinute = new double[1440 + 1];

                string sql_Text = $"SELECT valeur, dateHeure FROM Mesure WHERE Id = '{idChannel}' AND IdEnregistrement = '{idEnregistrement}' AND type = 'Num' AND CONVERT(date, dateHeure) = '{day.ToString("yyyy-MM-dd")}' ORDER BY dateHeure ASC";

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

        public List<DateTime> GetSortedDays(int idChannel, int idEnregistrement)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            List<DateTime> joursDifferents = new List<DateTime>();

            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();
                string sql_Text = $"SELECT dateHeure FROM Mesure WHERE Id = '{idChannel}' AND IdEnregistrement = '{idEnregistrement}' ORDER BY dateHeure ASC";

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

        public List<int> GetUniqueChannelIds(int idEnregistrement)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            List<int> uniqueChannelIds = new List<int>();

            // Ouvrir la connexion à la base de données
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();
                // Sélectionner les identifiants de canal distincts
                string sql_Text = $"SELECT DISTINCT Id FROM Mesure WHERE IdEnregistrement = '{idEnregistrement}' ";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Parcourir les résultats et ajouter les identifiants de canal à la liste
                        while (reader.Read())
                        {
                            if (reader["Id"] != DBNull.Value)
                            {
                                int idChannel = (int)reader["Id"];
                                uniqueChannelIds.Add(idChannel);
                            }
                        }
                    }
                }
            }

            // Retourner la liste des identifiants de canal uniques
            return uniqueChannelIds;
        }

        public void AddNumValueToChannel(int idChannel, double value, int idEnregistrement)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;

            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                // Get the current date and time
                DateTime currentDate = DateTime.Now;

                // Create the SQL command to insert a new record
                string sql_Text = "INSERT INTO Mesure (IdEnregistrement, Id, type, valeur, dateHeure) VALUES (@IdEnregistrement, @Id, 'Num', @Value, @DateHeure)";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    // Add parameters to the command to prevent SQL injection
                    cmd.Parameters.AddWithValue("@IdEnregistrement", idEnregistrement);
                    cmd.Parameters.AddWithValue("@Id", idChannel);
                    cmd.Parameters.AddWithValue("@Value", value);
                    cmd.Parameters.AddWithValue("@DateHeure", currentDate);

                    // Execute the SQL command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public double GetTotalValeur(int idChannel, int idEnregistrement)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                double totalValeurs = 0;

                string sql_Text = $"SELECT SUM(valeur) AS TotalValeurs FROM Mesure WHERE Id = '{idChannel}' AND IdEnregistrement = '{idEnregistrement}' AND type = 'Num' AND valeur IS NOT NULL";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("TotalValeurs")))
                        {
                            // Utiliser la colonne correspondante pour récupérer la somme des valeurs
                            totalValeurs = Convert.ToDouble(reader["TotalValeurs"]);
                        }
                    }
                }

                return totalValeurs;
            }
        }

        public int GetLastValeurmin(int idChannel, int idEnregistrement)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                int lastValeurMin = 0;

                string sql_Text = $"SELECT TOP 1 valeur FROM Mesure WHERE Id = '{idChannel}' AND IdEnregistrement = '{idEnregistrement}' AND type = 'Num' ORDER BY dateHeure DESC";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("valeur")))
                        {
                            lastValeurMin = Convert.ToInt32(reader["valeur"]);
                        }
                    }
                }

                return lastValeurMin;
            }
        }

        public int GetLastValeurheure(int idChannel, int idEnregistrement)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                int totalValeurs = 0;

                // Sélectionner la somme de toutes les valeurs pour l'heure actuelle du jour actuel
                string sql_Text = $"SELECT SUM(valeur) AS TotalValeurs FROM Mesure WHERE Id = '{idChannel}' AND IdEnregistrement = '{idEnregistrement}' AND type = 'Num' AND DATEPART(hour, dateHeure) = DATEPART(hour, GETDATE()) AND CONVERT(date, dateHeure) = CONVERT(date, GETDATE())";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("TotalValeurs")))
                        {
                            totalValeurs = Convert.ToInt32(reader["TotalValeurs"]);
                        }
                    }
                }

                return totalValeurs;
            }
        }


        public int GetLastValeurjour(int idChannel, int idEnregistrement)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                int totalValeurs = 0;

                // Sélectionner la somme de toutes les valeurs pour le jour actuel
                string sql_Text = $"SELECT SUM(valeur) AS TotalValeurs FROM Mesure WHERE Id = '{idChannel}' AND IdEnregistrement = '{idEnregistrement}' AND type = 'Num' AND CONVERT(date, dateHeure) = CONVERT(date, GETDATE())";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("TotalValeurs")))
                        {
                            totalValeurs = Convert.ToInt32(reader["TotalValeurs"]);
                        }
                    }
                }

                return totalValeurs;
            }
        }


        public double GetLastTemp(int idChannel, int idEnregistrement)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                double lastTemp = 0;

                string sql_Text = $"SELECT TOP 1 valeur FROM Mesure WHERE Id = '{idChannel}' AND IdEnregistrement = '{idEnregistrement}' AND type = 'Temp' ORDER BY dateHeure DESC";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("valeur")))
                        {
                            lastTemp = Convert.ToDouble(reader["valeur"]);
                        }
                    }
                }

                return lastTemp;
            }
        }

        public double GetLastLux(int idChannel, int idEnregistrement)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                double lastLux = 0;

                string sql_Text = $"SELECT TOP 1 valeur FROM Mesure WHERE Id = '{idChannel}' AND IdEnregistrement = '{idEnregistrement}' AND type = 'Lux' ORDER BY dateHeure DESC";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("valeur")))
                        {
                            lastLux = Convert.ToDouble(reader["valeur"]);
                        }
                    }
                }

                return lastLux;
            }
        }

        public int Getheuredown(int idChannel, int idEnregistrement)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                int hoursWithZeroValue = 0;

                // Sélectionner les heures où la valeur est zéro
                string sql_Text = $"SELECT COUNT(DISTINCT DATEPART(hour, dateHeure)) AS HoursWithZeroValue FROM Mesure WHERE Id = '{idChannel}' AND IdEnregistrement = '{idEnregistrement}' AND type = 'Num' AND valeur = 0";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("HoursWithZeroValue")))
                        {
                            hoursWithZeroValue = Convert.ToInt32(reader["HoursWithZeroValue"]);
                        }
                    }
                }

                return hoursWithZeroValue;
            }
        }

        public bool GetActivity(int idChannel, int idEnregistrement)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                // Date et heure actuelles moins 24 heures
                DateTime twentyFourHoursAgo = DateTime.Now.AddHours(-24);

                // Vérifier s'il y a des valeurs différentes de zéro dans les 24 dernières heures
                string sql_Text = $"SELECT COUNT(*) FROM Mesure WHERE Id = '{idChannel}' AND IdEnregistrement = '{idEnregistrement}' AND type = 'Num' AND dateHeure >= @TwentyFourHoursAgo AND valeur <> 0";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    cmd.Parameters.AddWithValue("@TwentyFourHoursAgo", twentyFourHoursAgo);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // Si le nombre de valeurs différentes de zéro est supérieur à zéro, il y a eu de l'activité
                    if (count != 0)
                        return false;
                    else
                        return true;
                }
            }
        }

        public string GetType(int idChannel, int idEnregistrement)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                string type = null;

                string sql_Text = $"SELECT DISTINCT type FROM Mesure WHERE Id = '{idChannel}' AND IdEnregistrement = '{idEnregistrement}'";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("type")))
                        {
                            type = reader["type"].ToString();
                        }
                    }
                }

                return type;
            }
        }

    }
}
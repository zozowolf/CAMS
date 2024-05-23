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

        public double GetTotalValeur(int idChannel, int idEnregistrement, string type)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                double totalValeurs = 0;

                string sql_Text = $"SELECT SUM(valeur) AS TotalValeurs FROM Mesure WHERE Id = '{idChannel}' AND IdEnregistrement = '{idEnregistrement}' AND type = '{type}' AND valeur IS NOT NULL";

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
                string sql_Text = $"SELECT COUNT(*) FROM Mesure WHERE Id = '{idChannel}' AND IdEnregistrement = '{idEnregistrement}' AND dateHeure >= @TwentyFourHoursAgo AND valeur <> 0";

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

        public string GetTypeCapteur(int idChannel)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                string type = null;

                string sql_Text = $"SELECT TypeCapteur FROM Channel WHERE Id = '{idChannel}'";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("TypeCapteur")))
                        {
                            type = reader["TypeCapteur"].ToString();
                        }
                    }
                }

                return type;
            }
        }

        public int GetMaxValeur(int idChannel, int idEnregistrement)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                int Maxvaleur = 0;

                string sql_Text = $"SELECT MAX(valeur) AS max_valeur FROM Mesure WHERE Id = '{idChannel}' AND IdEnregistrement = '{idEnregistrement}'";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("max_valeur")))
                        {
                            Maxvaleur = Convert.ToInt32(reader["max_valeur"]);
                        }
                    }
                }

                return Maxvaleur;
            }
        }

        public void AddValueToEvent(string message, DateTime currentDate, string nomChercheur)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            int newEventId;

            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                // Create the SQL command to insert a new record
                string sql_Text = "INSERT INTO Event (Id, DateHeure, nomChercheur, Description) VALUES ((SELECT ISNULL(MAX(Id), 0) + 1 FROM Event), @currentDate, @nomChercheur, @message);";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    // Add parameters to the command to prevent SQL injection
                    cmd.Parameters.AddWithValue("@currentDate", currentDate);
                    cmd.Parameters.AddWithValue("@nomChercheur", nomChercheur);
                    cmd.Parameters.AddWithValue("@message", message);

                    // Execute the SQL command to insert the event
                    cmd.ExecuteNonQuery();

                    // Get the newly inserted event ID
                    string getIdQuery = "SELECT TOP 1 Id FROM Event ORDER BY Id DESC;"; // Retrieve the last identity value generated in the current scope
                    using (SqlCommand getIdCmd = new SqlCommand(getIdQuery, cn_connection))
                    {
                        newEventId = Convert.ToInt32(getIdCmd.ExecuteScalar());
                    }
                }

                // Create the SQL command to insert a new record into the AssociationENR_EV table
                string associationSql_Text = "INSERT INTO AssociationENR_EV (IdEnregistrement, IdEvent) VALUES (@idEnregistrement, @newEventId);";

                using (SqlCommand associationCmd = new SqlCommand(associationSql_Text, cn_connection))
                {
                    // Add parameters to the command
                    associationCmd.Parameters.AddWithValue("@idEnregistrement", 1); // ATTENTION : CODE STATIQUE POUR LE MOMENT
                    associationCmd.Parameters.AddWithValue("@newEventId", newEventId);

                    // Execute the SQL command to create the association
                    associationCmd.ExecuteNonQuery();
                }
            }
        }

        public void AddValueToAlerte(int idChannel, string message, DateTime currentDate, string nomChercheur)
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            int newAlertId;

            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                // commande sql 
                string sql_Text = "INSERT INTO Alerte (Id, DateHeure, nomChercheur, Description) VALUES ((SELECT ISNULL(MAX(Id), 0) + 1 FROM Alerte), @currentDate, @nomChercheur, @message);";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    // ajout paramatres
                    cmd.Parameters.AddWithValue("@currentDate", currentDate);
                    cmd.Parameters.AddWithValue("@nomChercheur", nomChercheur);
                    cmd.Parameters.AddWithValue("@message", message);

                    // on exec la commande
                    cmd.ExecuteNonQuery();

                    // on recupere l'id qu'on vient de créer
                    string getIdQuery = "SELECT TOP 1 Id FROM Alerte ORDER BY Id DESC;"; // on récupère l'id de la derniere ligne ajoutée (qu'on vient de créer)

                    using (SqlCommand getIdCmd = new SqlCommand(getIdQuery, cn_connection))
                    {
                        newAlertId = Convert.ToInt32(getIdCmd.ExecuteScalar());
                    }
                }

                // commande sql pour AssociationENR_EV table
                string associationSql_Text = "INSERT INTO AssociationCH_A (idChannel, idAlerte) VALUES (@idChannel, @newAlertId);";

                using (SqlCommand associationCmd = new SqlCommand(associationSql_Text, cn_connection))
                {
                    // ajout parametres pour la commande
                    associationCmd.Parameters.AddWithValue("@idChannel", idChannel);
                    associationCmd.Parameters.AddWithValue("@newAlertId", newAlertId);

                    // execution de la commande
                    associationCmd.ExecuteNonQuery();
                }
            }
        }


    }
}
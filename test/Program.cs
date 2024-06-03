using System;
using System.IO;

namespace WriteBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            // Spécifiez le chemin du fichier .dat à créer
            string filePath = @"C:\Users\cdf\source\repos\test\test\exemple.dat";

            try
            {
                // Créer un FileStream pour écrire des données en binaire
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter writer = new BinaryWriter(fs))
                    {
                        // Écrire quelques données de test dans le fichier
                        writer.Write(123); // Écrit un entier
                        writer.Write(45.67); // Écrit un double
                        writer.Write("Hello World"); // Écrit une chaîne de caractères

                        // Vous pouvez adapter cette partie pour écrire les données de votre base de données
                    }
                }

                Console.WriteLine("Le fichier .dat a été créé avec succès.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur est survenue lors de la création du fichier: " + ex.Message);
            }
        }
    }
}

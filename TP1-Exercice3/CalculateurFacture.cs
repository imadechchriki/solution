// CalculateurFacture.cs - Logique de calcul de la facture
using System;

namespace MagasinReprographie
{
    public class CalculateurFacture
    {
        // Prix unitaires
        private const double PRIX_PREMIERE_TRANCHE = 0.5;   // 0-10 photocopies
        private const double PRIX_DEUXIEME_TRANCHE = 0.25;  // 11-30 photocopies
        private const double PRIX_TROISIEME_TRANCHE = 0.1;  // 31+ photocopies
        
        // Limites des tranches
        private const int LIMITE_PREMIERE_TRANCHE = 10;
        private const int LIMITE_DEUXIEME_TRANCHE = 30;

        public double CalculerMontant(int nombrePhotocopies)
        {
            if (nombrePhotocopies < 0)
            {
                throw new ArgumentException("Le nombre de photocopies ne peut pas être négatif.");
            }

            double montant = 0.0;

            // Première tranche : 0-10 photocopies à 0.5 Dhs
            if (nombrePhotocopies <= LIMITE_PREMIERE_TRANCHE)
            {
                montant = nombrePhotocopies * PRIX_PREMIERE_TRANCHE;
            }
            else
            {
                // Calcul pour les 10 premières photocopies
                montant = LIMITE_PREMIERE_TRANCHE * PRIX_PREMIERE_TRANCHE;

                // Deuxième tranche : 11-30 photocopies à 0.25 Dhs
                if (nombrePhotocopies <= LIMITE_DEUXIEME_TRANCHE)
                {
                    montant += (nombrePhotocopies - LIMITE_PREMIERE_TRANCHE) * PRIX_DEUXIEME_TRANCHE;
                }
                else
                {
                    // Calcul pour les photocopies 11 à 30
                    montant += (LIMITE_DEUXIEME_TRANCHE - LIMITE_PREMIERE_TRANCHE) * PRIX_DEUXIEME_TRANCHE;

                    // Troisième tranche : au-delà de 30 photocopies à 0.1 Dhs
                    montant += (nombrePhotocopies - LIMITE_DEUXIEME_TRANCHE) * PRIX_TROISIEME_TRANCHE;
                }
            }

            return montant;
        }
    }
}
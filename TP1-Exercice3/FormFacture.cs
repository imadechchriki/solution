// FormFacture.cs - Interface utilisateur
using System;
using System.Windows.Forms;

namespace MagasinReprographie
{
    public partial class FormFacture : Form
    {
        private CalculateurFacture calculateur;

        public FormFacture()
        {
            InitializeComponent();
            calculateur = new CalculateurFacture();
        }

        private void btnCalculer_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupérer le nombre de photocopies
                if (!int.TryParse(nbrText.Text, out int nombrePhotocopies) || nombrePhotocopies < 0)
                {
                    MessageBox.Show("Veuillez entrer un nombre valide de photocopies.", "Erreur de saisie", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calculer le montant à payer
                double montant = calculateur.CalculerMontant(nombrePhotocopies);

                // Afficher le montant à payer
                totalText.Text = montant.ToString("0.00") + " Dhs";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message, "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
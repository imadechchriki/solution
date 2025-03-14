namespace Gestion_Ecole
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataEleve.DataSource = new DAOEleve().findAll();
            //DataEleve.DataSource = new DAOEleve().find(new Eleve(0, null, null, "Tanger", null));
            //string res = new DAOEleve().testfind(new Eleve(0, null, null, "Tanger", null));
            //MessageBox.Show(res);
        }

        private void b_Ajouter_Click(object sender, EventArgs e)
        {
            new DAOEleve().insert(new Eleve(0, t_nom.Text, t_prenom.Text, t_ville.Text, t_specialite.Text));
            // DataEleve.Rows.Add(0,t_nom.Text,t_prenom.Text,t_ville.Text,t_specialite.Text);
            //DataEleve.Rows.Clear();
            DataEleve.DataSource = new DAOEleve().findAll();
        }

        private void b_Rechercher_Click(object sender, EventArgs e)
        {
            DataEleve.Rows.Clear();

        }

        private void Modifier_Click(object sender, EventArgs e)
        {
            // Vérifier si un élève est sélectionné
            if (DataEleve.SelectedRows.Count > 0)
            {
                // Récupérer l'ID de l'élève sélectionné
                int id = Convert.ToInt32(DataEleve.SelectedRows[0].Cells[0].Value);

                // Créer un objet Eleve avec les nouvelles valeurs
                Eleve eleveToUpdate = new Eleve(
                    id, // ID de l'élève
                    t_nom.Text,
                    t_prenom.Text,
                    t_ville.Text,
                    t_specialite.Text
                );

                // Mettre à jour l'élève dans la base de données
                int result = new DAOEleve().update(eleveToUpdate);

                // Vérifier si la mise à jour a réussi
                if (result > 0)
                {
                    MessageBox.Show("L'étudiant a été mis à jour avec succès.");
                }
                else
                {
                    MessageBox.Show("La mise à jour a échoué.");
                }

                // Rafraîchir les données dans le DataGridView
                DataEleve.DataSource = new DAOEleve().findAll();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un étudiant à modifier.");
            }
        }

        private void DataEleve_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifier si une ligne a été sélectionnée
            if (e.RowIndex >= 0)
            {
                // Récupérer l'ID de l'élève sélectionné
                int id = Convert.ToInt32(DataEleve.Rows[e.RowIndex].Cells[0].Value);
                string nom = DataEleve.Rows[e.RowIndex].Cells[1].Value.ToString();
                string prenom = DataEleve.Rows[e.RowIndex].Cells[2].Value.ToString();
                string ville = DataEleve.Rows[e.RowIndex].Cells[3].Value.ToString();
                string specialite = DataEleve.Rows[e.RowIndex].Cells[4].Value.ToString();

                // Afficher les informations dans les labels
                t_nom.Text = nom;
                t_prenom.Text = prenom;
                t_ville.Text = ville;
                t_specialite.Text = specialite;
            }
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            // Vérifier si une ligne a été sélectionnée dans le DataGridView
            if (DataEleve.SelectedRows.Count > 0)
            {
                // Récupérer l'ID de l'élève sélectionné
                int id = Convert.ToInt32(DataEleve.SelectedRows[0].Cells[0].Value);

                // Demander à l'utilisateur de confirmer la suppression
                var confirmResult = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élève ?",
                                                     "Confirmer la suppression",
                                                     MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    // Appeler la méthode delete de DAOEleve pour supprimer l'élève
                    int result = new DAOEleve().delete(id);

                    // Vérifier si la suppression a réussi
                    if (result > 0)
                    {
                        MessageBox.Show("L'élève a été supprimé avec succès.");
                    }
                    else
                    {
                        MessageBox.Show("La suppression a échoué.");
                    }

                    // Rafraîchir les données dans le DataGridView après suppression
                    DataEleve.DataSource = new DAOEleve().findAll();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un élève à supprimer.");
            }
        }

        private void DataEleve_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void t_nom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

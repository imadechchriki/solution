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
            // V�rifier si un �l�ve est s�lectionn�
            if (DataEleve.SelectedRows.Count > 0)
            {
                // R�cup�rer l'ID de l'�l�ve s�lectionn�
                int id = Convert.ToInt32(DataEleve.SelectedRows[0].Cells[0].Value);

                // Cr�er un objet Eleve avec les nouvelles valeurs
                Eleve eleveToUpdate = new Eleve(
                    id, // ID de l'�l�ve
                    t_nom.Text,
                    t_prenom.Text,
                    t_ville.Text,
                    t_specialite.Text
                );

                // Mettre � jour l'�l�ve dans la base de donn�es
                int result = new DAOEleve().update(eleveToUpdate);

                // V�rifier si la mise � jour a r�ussi
                if (result > 0)
                {
                    MessageBox.Show("L'�tudiant a �t� mis � jour avec succ�s.");
                }
                else
                {
                    MessageBox.Show("La mise � jour a �chou�.");
                }

                // Rafra�chir les donn�es dans le DataGridView
                DataEleve.DataSource = new DAOEleve().findAll();
            }
            else
            {
                MessageBox.Show("Veuillez s�lectionner un �tudiant � modifier.");
            }
        }

        private void DataEleve_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // V�rifier si une ligne a �t� s�lectionn�e
            if (e.RowIndex >= 0)
            {
                // R�cup�rer l'ID de l'�l�ve s�lectionn�
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
            // V�rifier si une ligne a �t� s�lectionn�e dans le DataGridView
            if (DataEleve.SelectedRows.Count > 0)
            {
                // R�cup�rer l'ID de l'�l�ve s�lectionn�
                int id = Convert.ToInt32(DataEleve.SelectedRows[0].Cells[0].Value);

                // Demander � l'utilisateur de confirmer la suppression
                var confirmResult = MessageBox.Show("�tes-vous s�r de vouloir supprimer cet �l�ve ?",
                                                     "Confirmer la suppression",
                                                     MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    // Appeler la m�thode delete de DAOEleve pour supprimer l'�l�ve
                    int result = new DAOEleve().delete(id);

                    // V�rifier si la suppression a r�ussi
                    if (result > 0)
                    {
                        MessageBox.Show("L'�l�ve a �t� supprim� avec succ�s.");
                    }
                    else
                    {
                        MessageBox.Show("La suppression a �chou�.");
                    }

                    // Rafra�chir les donn�es dans le DataGridView apr�s suppression
                    DataEleve.DataSource = new DAOEleve().findAll();
                }
            }
            else
            {
                MessageBox.Show("Veuillez s�lectionner un �l�ve � supprimer.");
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

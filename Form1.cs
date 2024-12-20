using MySqlConnector;
using System;
using System.Data;


namespace CRUD_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectString = "Server=localhost;User ID=root;Password='';Database=crud-cshap;AllowZeroDatetime=true;";
            try
            {
                using (MySqlConnection connect = new MySqlConnection(connectString))
                {
                    connect.Open();

                    // Préparez la commande SQL pour l'insertion
                    MySqlCommand command = new MySqlCommand("INSERT INTO users (id, name, userName, email, password) VALUES (@id, @name, @userName, @email, @password)", connect);

                    // Ajoutez les paramètres à la commande
                    command.Parameters.AddWithValue("@id", int.Parse(textBox1.Text)); // ID depuis textBox1
                    command.Parameters.AddWithValue("@name", textBox2.Text); // Nom depuis textBox2
                    command.Parameters.AddWithValue("@userName", textBox3.Text); // Nom d'utilisateur depuis textBox3
                    command.Parameters.AddWithValue("@email", textBox4.Text); // E-mail depuis textBox4
                    command.Parameters.AddWithValue("@password", textBox5.Text); // Mot de passe depuis textBox5

                    // Exécutez la commande
                    command.ExecuteNonQuery();

                    // Optionnel : Afficher un message de succès
                    MessageBox.Show("Utilisateur ajouté avec succès.");
                }
            }
            catch (Exception ex)
            {
                // Gérer les erreurs
                MessageBox.Show("Une erreur est survenue : " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectString = "Server=localhost;User ID=root;Password='';Database=crud-cshap;AllowZeroDatetime=true;";
            try
            {
                using (MySqlConnection connect = new MySqlConnection(connectString))
                {
                    connect.Open();

                    // Préparez la commande SQL pour la mise à jour
                    MySqlCommand command = new MySqlCommand("UPDATE users SET name = @name, userName = @userName, email = @email, password = @password WHERE id = @id", connect);

                    // Ajoutez les paramètres à la commande
                    command.Parameters.AddWithValue("@id", int.Parse(textBox1.Text)); // ID depuis textBox1
                    command.Parameters.AddWithValue("@name", textBox2.Text); // Nom depuis textBox2
                    command.Parameters.AddWithValue("@userName", textBox3.Text); // Nom d'utilisateur depuis textBox3
                    command.Parameters.AddWithValue("@email", textBox4.Text); // E-mail depuis textBox4
                    command.Parameters.AddWithValue("@password", textBox5.Text); // Mot de passe depuis textBox5

                    // Exécutez la commande
                    int rowsAffected = command.ExecuteNonQuery();

                    // Vérifiez si une ligne a été mise à jour
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Utilisateur mis à jour avec succès.");
                    }
                    else
                    {
                        MessageBox.Show("Aucun utilisateur trouvé avec cet ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer les erreurs
                MessageBox.Show("Une erreur est survenue : " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectString = "Server=localhost;User ID=root;Password='';Database=crud-cshap;AllowZeroDatetime=true;";
            try
            {
                using (MySqlConnection connect = new MySqlConnection(connectString))
                {
                    connect.Open();

                    // Préparez la commande SQL pour la suppression
                    MySqlCommand command = new MySqlCommand("DELETE FROM users WHERE id = @id", connect);

                    // Ajoutez le paramètre à la commande
                    command.Parameters.AddWithValue("@id", int.Parse(textBox1.Text)); // ID depuis textBox1

                    // Exécutez la commande
                    int rowsAffected = command.ExecuteNonQuery();

                    // Vérifiez si une ligne a été supprimée
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Utilisateur supprimé avec succès.");
                    }
                    else
                    {
                        MessageBox.Show("Aucun utilisateur trouvé avec cet ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer les erreurs
                MessageBox.Show("Une erreur est survenue : " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectString = "Server=localhost;User ID=root;Password='';Database=crud-cshap;AllowZeroDatetime=true;";
            try
            {
                using (MySqlConnection connect = new MySqlConnection(connectString))
                {
                    connect.Open();

                    // Préparez la commande SQL pour récupérer tous les utilisateurs
                    MySqlCommand command = new MySqlCommand("SELECT * FROM users", connect);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Assignez la source de données au DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Rendre le DataGridView visible
                    dataGridView1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Cachez le DataGridView s'il est visible
            dataGridView1.Visible = false;

            // Réinitialiser les TextBox pour la création d'un nouvel utilisateur
            textBox1.Clear(); // ID
            textBox2.Clear(); // Nom
            textBox3.Clear(); // Nom d'utilisateur
            textBox4.Clear(); // E-mail
            textBox5.Clear(); // Mot de passe

            // Optionnel : Si vous souhaitez désactiver le TextBox pour l'ID
            textBox1.Enabled = false; // Empêche la modification manuelle

            // Mettre le focus sur le premier champ
            textBox2.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifiez que la cellule cliquée est valide
            if (e.RowIndex >= 0)
            {
                // Récupérez la ligne sélectionnée
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Remplissez les TextBox avec les données de la ligne sélectionnée
                textBox1.Text = row.Cells["id"].Value.ToString(); // ID
                textBox2.Text = row.Cells["name"].Value.ToString(); // Nom
                textBox3.Text = row.Cells["userName"].Value.ToString(); // Nom d'utilisateur
                textBox4.Text = row.Cells["email"].Value.ToString(); // E-mail
                textBox5.Text = row.Cells["password"].Value.ToString(); // Mot de passe
            }
        }
    }
}

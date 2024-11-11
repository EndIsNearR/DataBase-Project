using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SimpleTeamViewer
{
    public partial class ViewPlayersForm : Form
    {
        private string connectionString = "Data Source=20RK-ASUS;Initial Catalog=Project;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public ViewPlayersForm()
        {
            InitializeComponent();
            LoadPlayers();
        }

        private void LoadPlayers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Player_ID, Name, Age, Position, Nationality, Team_Id FROM Player";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridViewPlayers.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void InitializeComponent()
        {
            this.dataGridViewPlayers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPlayers
            // 
            this.dataGridViewPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlayers.Location = new System.Drawing.Point(50, 50);
            this.dataGridViewPlayers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewPlayers.Name = "dataGridViewPlayers";
            this.dataGridViewPlayers.RowHeadersWidth = 51;
            this.dataGridViewPlayers.RowTemplate.Height = 29;
            this.dataGridViewPlayers.Size = new System.Drawing.Size(900, 400);
            this.dataGridViewPlayers.TabIndex = 0;
            // 
            // ViewPlayersForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.dataGridViewPlayers);
            this.Name = "ViewPlayersForm";
            this.Text = "Players Information";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridViewPlayers;
    }
}

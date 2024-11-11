using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SimpleTeamViewer
{
    public partial class ViewCoachesForm : Form
    {
        private string connectionString = "Data Source=20RK-ASUS;Initial Catalog=Project;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public ViewCoachesForm()
        {
            InitializeComponent();
            LoadCoaches();
        }

        private void LoadCoaches()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Coach_ID, Name, Nationality, Team_Id FROM Coach";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridViewCoaches.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void InitializeComponent()
        {
            this.dataGridViewCoaches = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoaches)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCoaches
            // 
            this.dataGridViewCoaches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCoaches.Location = new System.Drawing.Point(50, 50);
            this.dataGridViewCoaches.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewCoaches.Name = "dataGridViewCoaches";
            this.dataGridViewCoaches.RowHeadersWidth = 51;
            this.dataGridViewCoaches.RowTemplate.Height = 29;
            this.dataGridViewCoaches.Size = new System.Drawing.Size(900, 400);
            this.dataGridViewCoaches.TabIndex = 0;
            // 
            // ViewCoachesForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.dataGridViewCoaches);
            this.Name = "ViewCoachesForm";
            this.Text = "Coaches Information";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoaches)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridViewCoaches;
    }
}

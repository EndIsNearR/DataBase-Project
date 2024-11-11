using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimpleTeamViewer
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=20RK-ASUS;Initial Catalog=Project;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public Form1()
        {
            InitializeComponent();
            LoadTeams();
        }

        private void LoadTeams()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Team_Name FROM Team";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    listViewTeams.Items.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["Team_Name"].ToString());
                        item.BackColor = Color.LightCyan;
                        item.ForeColor = Color.DarkSlateBlue;
                        listViewTeams.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void listViewTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTeams.SelectedItems.Count > 0)
            {
                string selectedTeamName = listViewTeams.SelectedItems[0].Text;
                LoadTeamDetails(selectedTeamName);
            }
        }

        private void LoadTeamDetails(string teamName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Team_Name, Country, Manager, Stadium FROM Team WHERE Team_Name = @TeamName";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TeamName", teamName);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblTeamDetails.Text = $"Team: {reader["Team_Name"]}\n" +
                                              $"Country: {reader["Country"]}\n" +
                                              $"Manager: {reader["Manager"]}\n" +
                                              $"Stadium: {reader["Stadium"]}";

                        string backgroundImageName = $"{teamName}.jpg";
                        string imagePath = Path.Combine(Application.StartupPath, "Resources", "Backgrounds", backgroundImageName);

                        if (File.Exists(imagePath))
                        {
                            this.BackgroundImage = Image.FromFile(imagePath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void InitializeComponent()
        {
            this.listViewTeams = new System.Windows.Forms.ListView();
            this.lblTeamDetails = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewTeams
            // 
            this.listViewTeams.BackColor = System.Drawing.Color.White;
            this.listViewTeams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewTeams.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.listViewTeams.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.listViewTeams.HideSelection = false;
            this.listViewTeams.Location = new System.Drawing.Point(30, 30);
            this.listViewTeams.Name = "listViewTeams";
            this.listViewTeams.Size = new System.Drawing.Size(300, 500);
            this.listViewTeams.TabIndex = 1;
            this.listViewTeams.UseCompatibleStateImageBehavior = false;
            this.listViewTeams.View = System.Windows.Forms.View.List;
            this.listViewTeams.SelectedIndexChanged += new System.EventHandler(this.listViewTeams_SelectedIndexChanged);
            // 
            // lblTeamDetails
            // 
            this.lblTeamDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblTeamDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTeamDetails.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTeamDetails.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTeamDetails.Location = new System.Drawing.Point(350, 30);
            this.lblTeamDetails.Name = "lblTeamDetails";
            this.lblTeamDetails.Padding = new System.Windows.Forms.Padding(10);
            this.lblTeamDetails.Size = new System.Drawing.Size(400, 200);
            this.lblTeamDetails.TabIndex = 0;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.BackgroundImage = global::Project2.Properties.Resources.WhatsApp_Image_2024_11_08_at_15_05_03_0c51af6a;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblTeamDetails);
            this.Controls.Add(this.listViewTeams);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Team Viewer";
            this.ResumeLayout(false);

        }

        private ListView listViewTeams;
        private Label lblTeamDetails;
    }
}

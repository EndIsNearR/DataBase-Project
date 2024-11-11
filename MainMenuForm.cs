using System;
using System.Windows.Forms;

namespace SimpleTeamViewer
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.btnViewTeams = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnViewPlayers = new System.Windows.Forms.Button();
            this.btnViewCoaches = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.labelWelcome.Location = new System.Drawing.Point(377, 34);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(349, 32);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome to the Program!";
            // 
            // btnViewTeams
            // 
            this.btnViewTeams.BackColor = System.Drawing.Color.Blue;
            this.btnViewTeams.Location = new System.Drawing.Point(456, 119);
            this.btnViewTeams.Name = "btnViewTeams";
            this.btnViewTeams.Size = new System.Drawing.Size(200, 50);
            this.btnViewTeams.TabIndex = 1;
            this.btnViewTeams.Text = "View Teams";
            this.toolTip.SetToolTip(this.btnViewTeams, "Click to view team details.");
            this.btnViewTeams.UseVisualStyleBackColor = false;
            this.btnViewTeams.Click += new System.EventHandler(this.BtnViewTeams_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnExit.Location = new System.Drawing.Point(456, 384);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(200, 50);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.toolTip.SetToolTip(this.btnExit, "Click to exit the application.");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnViewPlayers
            // 
            this.btnViewPlayers.BackColor = System.Drawing.Color.Green;
            this.btnViewPlayers.Location = new System.Drawing.Point(456, 207);
            this.btnViewPlayers.Name = "btnViewPlayers";
            this.btnViewPlayers.Size = new System.Drawing.Size(200, 50);
            this.btnViewPlayers.TabIndex = 3;
            this.btnViewPlayers.Text = "View Players";
            this.toolTip.SetToolTip(this.btnViewPlayers, "Click to view player details.");
            this.btnViewPlayers.UseVisualStyleBackColor = false;
            this.btnViewPlayers.Click += new System.EventHandler(this.BtnViewPlayers_Click);
            // 
            // btnViewCoaches
            // 
            this.btnViewCoaches.BackColor = System.Drawing.Color.Orange;
            this.btnViewCoaches.Location = new System.Drawing.Point(456, 293);
            this.btnViewCoaches.Name = "btnViewCoaches";
            this.btnViewCoaches.Size = new System.Drawing.Size(200, 50);
            this.btnViewCoaches.TabIndex = 4;
            this.btnViewCoaches.Text = "View Coaches";
            this.toolTip.SetToolTip(this.btnViewCoaches, "Click to view coach details.");
            this.btnViewCoaches.UseVisualStyleBackColor = false;
            this.btnViewCoaches.Click += new System.EventHandler(this.BtnViewCoaches_Click);
            // 
            // MainMenuForm
            // 
            this.BackgroundImage = global::Project2.Properties.Resources.WhatsApp_Image_2024_11_08_at_15_05_03_0c51af6a;
            this.ClientSize = new System.Drawing.Size(1035, 595);
            this.Controls.Add(this.btnViewPlayers);
            this.Controls.Add(this.btnViewCoaches);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.btnViewTeams);
            this.Controls.Add(this.btnExit);
            this.Name = "MainMenuForm";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void BtnViewTeams_Click(object sender, EventArgs e)
        {
            // Open the Form1 to view teams
            Form1 formTeams = new Form1();
            formTeams.Show();
        }

        private void BtnViewPlayers_Click(object sender, EventArgs e)
        {
            // Open the ViewPlayersForm to view players
            ViewPlayersForm formPlayers = new ViewPlayersForm();
            formPlayers.Show();
        }

        private void BtnViewCoaches_Click(object sender, EventArgs e)
        {
            // Open the ViewCoachesForm to view coaches
            ViewCoachesForm formCoaches = new ViewCoachesForm();
            formCoaches.Show();
        }

        private void BtnClickHandler(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton == btnViewTeams)
            {
                // Open the Form1 to view teams
                Form1 formTeams = new Form1();
                formTeams.Show();
            }
            else if (clickedButton == btnViewPlayers)
            {
                // Open the ViewPlayersForm to view players
                ViewPlayersForm formPlayers = new ViewPlayersForm();
                formPlayers.Show();
            }
            else if (clickedButton == btnViewCoaches)
            {
                // Open the ViewCoachesForm to view coaches
                ViewCoachesForm formCoaches = new ViewCoachesForm();
                formCoaches.Show();
            }
            else if (clickedButton == btnExit)
            {
                Application.Exit();
            }
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button btnViewTeams;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnViewPlayers;
        private System.Windows.Forms.Button btnViewCoaches;

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

        private ToolTip toolTip;
        private System.ComponentModel.IContainer components;
    }
}

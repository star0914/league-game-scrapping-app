namespace League
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.img_logo = new System.Windows.Forms.PictureBox();
            this.lb_logoTxt = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.lb_leagues = new System.Windows.Forms.Label();
            this.lb_year = new System.Windows.Forms.Label();
            this.lb_round = new System.Windows.Forms.Label();
            this.li_league = new System.Windows.Forms.ComboBox();
            this.li_year = new System.Windows.Forms.ComboBox();
            this.li_round = new System.Windows.Forms.ComboBox();
            this.btnFetchResult = new System.Windows.Forms.Button();
            this.la_cu_state = new System.Windows.Forms.Label();
            this.la_slash = new System.Windows.Forms.Label();
            this.la_total = new System.Windows.Forms.Label();
            this.la_team = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.img_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // img_logo
            // 
            this.img_logo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.img_logo.Image = ((System.Drawing.Image)(resources.GetObject("img_logo.Image")));
            this.img_logo.InitialImage = ((System.Drawing.Image)(resources.GetObject("img_logo.InitialImage")));
            this.img_logo.Location = new System.Drawing.Point(56, 43);
            this.img_logo.Name = "img_logo";
            this.img_logo.Size = new System.Drawing.Size(50, 52);
            this.img_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_logo.TabIndex = 0;
            this.img_logo.TabStop = false;
            // 
            // lb_logoTxt
            // 
            this.lb_logoTxt.AutoSize = true;
            this.lb_logoTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_logoTxt.Location = new System.Drawing.Point(112, 57);
            this.lb_logoTxt.Name = "lb_logoTxt";
            this.lb_logoTxt.Size = new System.Drawing.Size(189, 24);
            this.lb_logoTxt.TabIndex = 8;
            this.lb_logoTxt.Text = "MATCH SELECTION";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_refresh.Image")));
            this.btn_refresh.Location = new System.Drawing.Point(695, 54);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(35, 35);
            this.btn_refresh.TabIndex = 9;
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.Btn_refresh_Click);
            // 
            // lb_leagues
            // 
            this.lb_leagues.AutoSize = true;
            this.lb_leagues.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_leagues.Location = new System.Drawing.Point(62, 161);
            this.lb_leagues.Name = "lb_leagues";
            this.lb_leagues.Size = new System.Drawing.Size(75, 20);
            this.lb_leagues.TabIndex = 10;
            this.lb_leagues.Text = "League : ";
            // 
            // lb_year
            // 
            this.lb_year.AutoSize = true;
            this.lb_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_year.Location = new System.Drawing.Point(402, 161);
            this.lb_year.Name = "lb_year";
            this.lb_year.Size = new System.Drawing.Size(55, 20);
            this.lb_year.TabIndex = 11;
            this.lb_year.Text = "Year : ";
            // 
            // lb_round
            // 
            this.lb_round.AutoSize = true;
            this.lb_round.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_round.Location = new System.Drawing.Point(583, 161);
            this.lb_round.Name = "lb_round";
            this.lb_round.Size = new System.Drawing.Size(69, 20);
            this.lb_round.TabIndex = 12;
            this.lb_round.Text = "Round : ";
            // 
            // li_league
            // 
            this.li_league.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.li_league.FormattingEnabled = true;
            this.li_league.Location = new System.Drawing.Point(56, 184);
            this.li_league.Name = "li_league";
            this.li_league.Size = new System.Drawing.Size(267, 28);
            this.li_league.TabIndex = 13;
            this.li_league.SelectedIndexChanged += new System.EventHandler(this.Li_league_SelectedIndexChanged);
            // 
            // li_year
            // 
            this.li_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.li_year.FormattingEnabled = true;
            this.li_year.Location = new System.Drawing.Point(393, 184);
            this.li_year.Name = "li_year";
            this.li_year.Size = new System.Drawing.Size(131, 28);
            this.li_year.TabIndex = 14;
            this.li_year.SelectedIndexChanged += new System.EventHandler(this.Li_year_SelectedIndexChanged);
            // 
            // li_round
            // 
            this.li_round.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.li_round.FormattingEnabled = true;
            this.li_round.Location = new System.Drawing.Point(578, 184);
            this.li_round.Name = "li_round";
            this.li_round.Size = new System.Drawing.Size(152, 28);
            this.li_round.TabIndex = 15;
            this.li_round.SelectedIndexChanged += new System.EventHandler(this.Li_round_SelectedIndexChanged);
            // 
            // btnFetchResult
            // 
            this.btnFetchResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFetchResult.Location = new System.Drawing.Point(568, 354);
            this.btnFetchResult.Name = "btnFetchResult";
            this.btnFetchResult.Size = new System.Drawing.Size(162, 40);
            this.btnFetchResult.TabIndex = 16;
            this.btnFetchResult.Text = "Fetch Results";
            this.btnFetchResult.UseVisualStyleBackColor = true;
            this.btnFetchResult.Click += new System.EventHandler(this.BtnFetchResult_Click);
            // 
            // la_cu_state
            // 
            this.la_cu_state.AutoSize = true;
            this.la_cu_state.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.la_cu_state.Location = new System.Drawing.Point(56, 367);
            this.la_cu_state.Name = "la_cu_state";
            this.la_cu_state.Size = new System.Drawing.Size(14, 15);
            this.la_cu_state.TabIndex = 17;
            this.la_cu_state.Text = "0";
            // 
            // la_slash
            // 
            this.la_slash.AutoSize = true;
            this.la_slash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.la_slash.Location = new System.Drawing.Point(82, 367);
            this.la_slash.Name = "la_slash";
            this.la_slash.Size = new System.Drawing.Size(10, 15);
            this.la_slash.TabIndex = 18;
            this.la_slash.Text = "/";
            // 
            // la_total
            // 
            this.la_total.AutoSize = true;
            this.la_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.la_total.Location = new System.Drawing.Point(90, 367);
            this.la_total.Name = "la_total";
            this.la_total.Size = new System.Drawing.Size(14, 15);
            this.la_total.TabIndex = 19;
            this.la_total.Text = "0";
            // 
            // la_team
            // 
            this.la_team.AutoSize = true;
            this.la_team.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.la_team.Location = new System.Drawing.Point(124, 367);
            this.la_team.Name = "la_team";
            this.la_team.Size = new System.Drawing.Size(41, 15);
            this.la_team.TabIndex = 20;
            this.la_team.Text = "teams";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.la_team);
            this.Controls.Add(this.la_total);
            this.Controls.Add(this.la_slash);
            this.Controls.Add(this.la_cu_state);
            this.Controls.Add(this.btnFetchResult);
            this.Controls.Add(this.li_round);
            this.Controls.Add(this.li_year);
            this.Controls.Add(this.li_league);
            this.Controls.Add(this.lb_round);
            this.Controls.Add(this.lb_year);
            this.Controls.Add(this.lb_leagues);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.lb_logoTxt);
            this.Controls.Add(this.img_logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "League";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox img_logo;
        private System.Windows.Forms.Label lb_logoTxt;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Label lb_leagues;
        private System.Windows.Forms.Label lb_year;
        private System.Windows.Forms.Label lb_round;
        private System.Windows.Forms.ComboBox li_league;
        private System.Windows.Forms.ComboBox li_year;
        private System.Windows.Forms.ComboBox li_round;
        private System.Windows.Forms.Button btnFetchResult;
        private System.Windows.Forms.Label la_cu_state;
        private System.Windows.Forms.Label la_slash;
        private System.Windows.Forms.Label la_total;
        private System.Windows.Forms.Label la_team;
    }
}


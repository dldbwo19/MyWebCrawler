namespace MyWebCrawler
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Select_TeamList = new System.Windows.Forms.Label();
            this.cmbTeams = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSITION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NATIONALITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APPEARANCES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLEANSHEETS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GOALS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASSISTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Select_TeamList
            // 
            this.Select_TeamList.AutoSize = true;
            this.Select_TeamList.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Select_TeamList.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Select_TeamList.Location = new System.Drawing.Point(150, 62);
            this.Select_TeamList.Name = "Select_TeamList";
            this.Select_TeamList.Size = new System.Drawing.Size(98, 28);
            this.Select_TeamList.TabIndex = 0;
            this.Select_TeamList.Text = "구단 선택";
            // 
            // cmbTeams
            // 
            this.cmbTeams.Font = new System.Drawing.Font("문체부 훈민정음체", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbTeams.FormattingEnabled = true;
            this.cmbTeams.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbTeams.Location = new System.Drawing.Point(150, 96);
            this.cmbTeams.Name = "cmbTeams";
            this.cmbTeams.Size = new System.Drawing.Size(309, 30);
            this.cmbTeams.TabIndex = 1;
            this.cmbTeams.Tag = "Teams";
            this.cmbTeams.SelectedValueChanged += new System.EventHandler(this.cmbRanks_SelectedValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NUMBER,
            this.NAME,
            this.POSITION,
            this.NATIONALITY,
            this.APPEARANCES,
            this.CLEANSHEETS,
            this.GOALS,
            this.ASSISTS});
            this.dataGridView1.Location = new System.Drawing.Point(12, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(859, 420);
            this.dataGridView1.TabIndex = 2;
            // 
            // NUMBER
            // 
            this.NUMBER.HeaderText = "NO.";
            this.NUMBER.Name = "NUMBER";
            // 
            // NAME
            // 
            this.NAME.HeaderText = "NAME";
            this.NAME.Name = "NAME";
            // 
            // POSITION
            // 
            this.POSITION.HeaderText = "POSITION";
            this.POSITION.Name = "POSITION";
            // 
            // NATIONALITY
            // 
            this.NATIONALITY.HeaderText = "NATIONALITY";
            this.NATIONALITY.Name = "NATIONALITY";
            // 
            // APPEARANCES
            // 
            this.APPEARANCES.HeaderText = "APPEARANCES";
            this.APPEARANCES.Name = "APPEARANCES";
            // 
            // CLEANSHEETS
            // 
            this.CLEANSHEETS.HeaderText = "CLEANSHEETS";
            this.CLEANSHEETS.Name = "CLEANSHEETS";
            // 
            // GOALS
            // 
            this.GOALS.HeaderText = "GOALS";
            this.GOALS.Name = "GOALS";
            // 
            // ASSISTS
            // 
            this.ASSISTS.HeaderText = "ASSISTS";
            this.ASSISTS.Name = "ASSISTS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 570);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmbTeams);
            this.Controls.Add(this.Select_TeamList);
            this.Name = "Form1";
            this.Text = "MyWebCrawler";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Select_TeamList;
        private System.Windows.Forms.ComboBox cmbTeams;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSITION;
        private System.Windows.Forms.DataGridViewTextBoxColumn NATIONALITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn APPEARANCES;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLEANSHEETS;
        private System.Windows.Forms.DataGridViewTextBoxColumn GOALS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ASSISTS;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


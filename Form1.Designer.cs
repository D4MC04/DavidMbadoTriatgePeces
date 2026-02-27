namespace TriatgePeces
{
    partial class frmTriatge1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbImatge1 = new PictureBox();
            btnCarregar1 = new Button();
            ofdObrir1 = new OpenFileDialog();
            btnGris1 = new Button();
            btnSuavitzat1 = new Button();
            btnSegmentacio1 = new Button();
            btnContorn1 = new Button();
            lblPoligon1 = new Label();
            dataGridView1 = new DataGridView();
            btnAfegir1 = new Button();
            tbCerca1 = new TextBox();
            btnInforme1 = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbImatge1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pbImatge1
            // 
            pbImatge1.BorderStyle = BorderStyle.FixedSingle;
            pbImatge1.Location = new Point(60, 63);
            pbImatge1.Name = "pbImatge1";
            pbImatge1.Size = new Size(525, 363);
            pbImatge1.SizeMode = PictureBoxSizeMode.Zoom;
            pbImatge1.TabIndex = 0;
            pbImatge1.TabStop = false;
            // 
            // btnCarregar1
            // 
            btnCarregar1.Location = new Point(60, 446);
            btnCarregar1.Name = "btnCarregar1";
            btnCarregar1.Size = new Size(123, 65);
            btnCarregar1.TabIndex = 1;
            btnCarregar1.Text = "Carregar Imatge";
            btnCarregar1.UseVisualStyleBackColor = true;
            btnCarregar1.Click += btnCarregar1_Click;
            // 
            // ofdObrir1
            // 
            ofdObrir1.FileName = "openFileDialog1";
            ofdObrir1.Filter = "Imatges|*.jpg;*.png;*.bmp.";
            // 
            // btnGris1
            // 
            btnGris1.AccessibleDescription = "";
            btnGris1.Location = new Point(261, 446);
            btnGris1.Name = "btnGris1";
            btnGris1.Size = new Size(123, 65);
            btnGris1.TabIndex = 2;
            btnGris1.Tag = "";
            btnGris1.Text = "Convertir a Gris";
            btnGris1.UseVisualStyleBackColor = true;
            btnGris1.Click += btnGris1_Click;
            // 
            // btnSuavitzat1
            // 
            btnSuavitzat1.Location = new Point(261, 612);
            btnSuavitzat1.Name = "btnSuavitzat1";
            btnSuavitzat1.Size = new Size(123, 65);
            btnSuavitzat1.TabIndex = 3;
            btnSuavitzat1.Text = "Suavitzat";
            btnSuavitzat1.UseVisualStyleBackColor = true;
            btnSuavitzat1.Click += btnSuavitzat1_Click;
            // 
            // btnSegmentacio1
            // 
            btnSegmentacio1.Location = new Point(261, 529);
            btnSegmentacio1.Name = "btnSegmentacio1";
            btnSegmentacio1.Size = new Size(123, 65);
            btnSegmentacio1.TabIndex = 4;
            btnSegmentacio1.Text = "Segmentació";
            btnSegmentacio1.UseVisualStyleBackColor = true;
            btnSegmentacio1.Click += btnSegmentacio1_Click;
            // 
            // btnContorn1
            // 
            btnContorn1.Location = new Point(462, 529);
            btnContorn1.Name = "btnContorn1";
            btnContorn1.Size = new Size(123, 65);
            btnContorn1.TabIndex = 5;
            btnContorn1.Text = "Contorn";
            btnContorn1.UseVisualStyleBackColor = true;
            btnContorn1.Click += btnContorn1_Click;
            // 
            // lblPoligon1
            // 
            lblPoligon1.AutoSize = true;
            lblPoligon1.BorderStyle = BorderStyle.FixedSingle;
            lblPoligon1.Location = new Point(490, 599);
            lblPoligon1.Margin = new Padding(2);
            lblPoligon1.MaximumSize = new Size(200, 200);
            lblPoligon1.Name = "lblPoligon1";
            lblPoligon1.Padding = new Padding(2);
            lblPoligon1.RightToLeft = RightToLeft.No;
            lblPoligon1.Size = new Size(65, 31);
            lblPoligon1.TabIndex = 6;
            lblPoligon1.Text = "label1";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(715, 63);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(498, 363);
            dataGridView1.TabIndex = 7;
            // 
            // btnAfegir1
            // 
            btnAfegir1.Location = new Point(721, 529);
            btnAfegir1.Name = "btnAfegir1";
            btnAfegir1.Size = new Size(123, 65);
            btnAfegir1.TabIndex = 8;
            btnAfegir1.Text = "Afegir Polígon";
            btnAfegir1.UseVisualStyleBackColor = true;
            btnAfegir1.Click += btnAfegir1_Click;
            // 
            // tbCerca1
            // 
            tbCerca1.BorderStyle = BorderStyle.FixedSingle;
            tbCerca1.Location = new Point(899, 547);
            tbCerca1.Name = "tbCerca1";
            tbCerca1.Size = new Size(150, 31);
            tbCerca1.TabIndex = 10;
            tbCerca1.TextChanged += tbCerca1_TextChanged;
            // 
            // btnInforme1
            // 
            btnInforme1.Location = new Point(1090, 529);
            btnInforme1.Name = "btnInforme1";
            btnInforme1.Size = new Size(123, 65);
            btnInforme1.TabIndex = 11;
            btnInforme1.Text = "Informe PDF";
            btnInforme1.UseVisualStyleBackColor = true;
            btnInforme1.Click += btnInforme1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 9);
            label1.Name = "label1";
            label1.Size = new Size(620, 38);
            label1.TabIndex = 12;
            label1.Text = "Sistema de Triatge de Peces - Hobby Mania";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(947, 519);
            label2.Name = "label2";
            label2.Size = new Size(50, 25);
            label2.TabIndex = 13;
            label2.Text = "Filtre";
            // 
            // frmTriatge1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1277, 706);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnInforme1);
            Controls.Add(tbCerca1);
            Controls.Add(btnAfegir1);
            Controls.Add(dataGridView1);
            Controls.Add(lblPoligon1);
            Controls.Add(btnContorn1);
            Controls.Add(btnSegmentacio1);
            Controls.Add(btnSuavitzat1);
            Controls.Add(btnGris1);
            Controls.Add(btnCarregar1);
            Controls.Add(pbImatge1);
            Name = "frmTriatge1";
            Text = "Sistema de Triatge de Peces - Hobby Mania";
            ((System.ComponentModel.ISupportInitialize)pbImatge1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbImatge1;
        private Button btnCarregar1;
        private OpenFileDialog ofdObrir1;
        private Button btnGris1;
        private Button btnSuavitzat1;
        private Button btnSegmentacio1;
        private Button btnContorn1;
        public Label lblPoligon1;
        private DataGridView dataGridView1;
        private Button btnAfegir1;
        private TextBox tbCerca1;
        private Button btnInforme1;
        private Label label1;
        private Label label2;
    }
}

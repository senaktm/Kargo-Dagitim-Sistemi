
namespace YazLab11
{
    partial class Form2
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
            this.checkBoxTiklama = new System.Windows.Forms.CheckBox();
            this.richTextBoxAdres = new System.Windows.Forms.RichTextBox();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.textBoxKargoSahibi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnNoktaGetir = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxTiklama
            // 
            this.checkBoxTiklama.AutoSize = true;
            this.checkBoxTiklama.Location = new System.Drawing.Point(564, 61);
            this.checkBoxTiklama.Name = "checkBoxTiklama";
            this.checkBoxTiklama.Size = new System.Drawing.Size(109, 17);
            this.checkBoxTiklama.TabIndex = 27;
            this.checkBoxTiklama.Text = "Choose by CLICK";
            this.checkBoxTiklama.UseVisualStyleBackColor = true;
            // 
            // richTextBoxAdres
            // 
            this.richTextBoxAdres.Location = new System.Drawing.Point(376, 88);
            this.richTextBoxAdres.Name = "richTextBoxAdres";
            this.richTextBoxAdres.Size = new System.Drawing.Size(301, 42);
            this.richTextBoxAdres.TabIndex = 26;
            this.richTextBoxAdres.Text = "";
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.Location = new System.Drawing.Point(473, 145);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(89, 26);
            this.btnAddPoint.TabIndex = 21;
            this.btnAddPoint.Text = "ADD POINT";
            this.btnAddPoint.UseVisualStyleBackColor = true;
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(371, 145);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(89, 26);
            this.btnMap.TabIndex = 20;
            this.btnMap.Text = "SHOW MAP";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click_1);
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(460, 62);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(67, 20);
            this.textBoxY.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Coordinat Y:";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(460, 25);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(67, 20);
            this.textBoxX.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Coordinat X :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // map
            // 
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemmory = 5;
            this.map.Location = new System.Drawing.Point(6, -1);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 15;
            this.map.MinZoom = 2;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(357, 344);
            this.map.TabIndex = 15;
            this.map.Zoom = 12D;
            this.map.MouseClick += new System.Windows.Forms.MouseEventHandler(this.map_MouseClick_1);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(357, 342);
            this.splitter1.TabIndex = 14;
            this.splitter1.TabStop = false;
            // 
            // textBoxKargoSahibi
            // 
            this.textBoxKargoSahibi.Location = new System.Drawing.Point(610, 25);
            this.textBoxKargoSahibi.Name = "textBoxKargoSahibi";
            this.textBoxKargoSahibi.Size = new System.Drawing.Size(67, 20);
            this.textBoxKargoSahibi.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(536, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Cargo Owner : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(376, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 144);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(294, 125);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnNoktaGetir
            // 
            this.btnNoktaGetir.Location = new System.Drawing.Point(584, 162);
            this.btnNoktaGetir.Name = "btnNoktaGetir";
            this.btnNoktaGetir.Size = new System.Drawing.Size(89, 26);
            this.btnNoktaGetir.TabIndex = 31;
            this.btnNoktaGetir.Text = "NOKTA GETIR";
            this.btnNoktaGetir.UseVisualStyleBackColor = true;
            this.btnNoktaGetir.Click += new System.EventHandler(this.btnNoktaGetir_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(584, 136);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 20);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "DELETE POINT";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(689, 342);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNoktaGetir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxKargoSahibi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxTiklama);
            this.Controls.Add(this.richTextBoxAdres);
            this.Controls.Add(this.btnAddPoint);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.map);
            this.Controls.Add(this.splitter1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxTiklama;
        private System.Windows.Forms.RichTextBox richTextBoxAdres;
        private System.Windows.Forms.Button btnAddPoint;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Label label1;
        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox textBoxKargoSahibi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNoktaGetir;
        private System.Windows.Forms.Button btnDelete;
    }
}
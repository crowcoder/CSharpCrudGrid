namespace CSharpCrudGrid
{
    partial class Form1
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
            System.Windows.Forms.Button btnSave;
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colFruitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFruitIsYummy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFruitGrownsOnID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnProperties = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFruitName,
            this.colFruitIsYummy,
            this.colFruitGrownsOnID});
            this.dataGridView1.Location = new System.Drawing.Point(22, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(637, 268);
            this.dataGridView1.TabIndex = 0;
            // 
            // colFruitName
            // 
            this.colFruitName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFruitName.DataPropertyName = "FruitName";
            this.colFruitName.HeaderText = "Fruit Name";
            this.colFruitName.Name = "colFruitName";
            // 
            // colFruitIsYummy
            // 
            this.colFruitIsYummy.DataPropertyName = "FruitIsYummy";
            this.colFruitIsYummy.HeaderText = "Is Yummy";
            this.colFruitIsYummy.Name = "colFruitIsYummy";
            // 
            // colFruitGrownsOnID
            // 
            this.colFruitGrownsOnID.DataPropertyName = "FruitGrowsOnID";
            this.colFruitGrownsOnID.HeaderText = "Grows On";
            this.colFruitGrownsOnID.Name = "colFruitGrownsOnID";
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(584, 307);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(75, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnProperties
            // 
            this.btnProperties.Location = new System.Drawing.Point(22, 309);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(139, 23);
            this.btnProperties.TabIndex = 2;
            this.btnProperties.Text = "View Properties";
            this.btnProperties.UseVisualStyleBackColor = true;
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 349);
            this.Controls.Add(this.btnProperties);
            this.Controls.Add(btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFruitName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFruitIsYummy;
        private System.Windows.Forms.DataGridViewComboBoxColumn colFruitGrownsOnID;
        private System.Windows.Forms.Button btnProperties;
    }
}


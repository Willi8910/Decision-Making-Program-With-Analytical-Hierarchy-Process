namespace SPK_AHP
{
    partial class FormHitung
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
            this.dataGridViewInput = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.panIsi = new System.Windows.Forms.Panel();
            this.btnHitung = new System.Windows.Forms.Button();
            this.panHasil = new System.Windows.Forms.Panel();
            this.kesimpulan = new System.Windows.Forms.ListView();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtCost = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).BeginInit();
            this.panHasil.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCost)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInput
            // 
            this.dataGridViewInput.AllowUserToAddRows = false;
            this.dataGridViewInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInput.ColumnHeadersVisible = false;
            this.dataGridViewInput.Location = new System.Drawing.Point(93, 37);
            this.dataGridViewInput.Name = "dataGridViewInput";
            this.dataGridViewInput.RowHeadersVisible = false;
            this.dataGridViewInput.RowTemplate.Height = 25;
            this.dataGridViewInput.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewInput.TabIndex = 1;
            this.dataGridViewInput.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInput_CellEndEdit);
            this.dataGridViewInput.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInput_CellLeave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Perbandingkan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panIsi
            // 
            this.panIsi.AutoScroll = true;
            this.panIsi.Location = new System.Drawing.Point(12, 273);
            this.panIsi.Name = "panIsi";
            this.panIsi.Size = new System.Drawing.Size(1280, 434);
            this.panIsi.TabIndex = 3;
            // 
            // btnHitung
            // 
            this.btnHitung.Enabled = false;
            this.btnHitung.Location = new System.Drawing.Point(191, 244);
            this.btnHitung.Name = "btnHitung";
            this.btnHitung.Size = new System.Drawing.Size(142, 23);
            this.btnHitung.TabIndex = 4;
            this.btnHitung.Text = "Hitung Hasil";
            this.btnHitung.UseVisualStyleBackColor = true;
            this.btnHitung.Click += new System.EventHandler(this.btnHitung_Click);
            // 
            // panHasil
            // 
            this.panHasil.Controls.Add(this.kesimpulan);
            this.panHasil.Location = new System.Drawing.Point(810, 20);
            this.panHasil.Name = "panHasil";
            this.panHasil.Size = new System.Drawing.Size(750, 203);
            this.panHasil.TabIndex = 5;
            // 
            // kesimpulan
            // 
            this.kesimpulan.Location = new System.Drawing.Point(229, 8);
            this.kesimpulan.Name = "kesimpulan";
            this.kesimpulan.Size = new System.Drawing.Size(500, 166);
            this.kesimpulan.TabIndex = 0;
            this.kesimpulan.UseCompatibleStateImageBehavior = false;
            this.kesimpulan.View = System.Windows.Forms.View.List;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(353, 244);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(142, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtCost);
            this.panel1.Location = new System.Drawing.Point(499, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 225);
            this.panel1.TabIndex = 7;
            // 
            // dtCost
            // 
            this.dtCost.AllowUserToAddRows = false;
            this.dtCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtCost.ColumnHeadersVisible = false;
            this.dtCost.Location = new System.Drawing.Point(79, 37);
            this.dtCost.Name = "dtCost";
            this.dtCost.RowHeadersVisible = false;
            this.dtCost.RowTemplate.Height = 25;
            this.dtCost.Size = new System.Drawing.Size(153, 165);
            this.dtCost.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Cost";
            // 
            // FormHitung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 685);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panHasil);
            this.Controls.Add(this.btnHitung);
            this.Controls.Add(this.panIsi);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewInput);
            this.Name = "FormHitung";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).EndInit();
            this.panHasil.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panIsi;
        private System.Windows.Forms.Button btnHitung;
        private System.Windows.Forms.Panel panHasil;
        private System.Windows.Forms.ListView kesimpulan;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtCost;
        private System.Windows.Forms.Label label1;
    }
}


namespace SPK_AHP
{
    partial class DataGridExample
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtExample = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtExample)).BeginInit();
            this.SuspendLayout();
            // 
            // dtExample
            // 
            this.dtExample.AllowUserToAddRows = false;
            this.dtExample.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtExample.ColumnHeadersVisible = false;
            this.dtExample.Location = new System.Drawing.Point(85, 34);
            this.dtExample.Name = "dtExample";
            this.dtExample.RowHeadersVisible = false;
            this.dtExample.RowTemplate.Height = 25;
            this.dtExample.Size = new System.Drawing.Size(303, 150);
            this.dtExample.TabIndex = 2;
            // 
            // DataGridExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtExample);
            this.Name = "DataGridExample";
            this.Size = new System.Drawing.Size(410, 219);
            ((System.ComponentModel.ISupportInitialize)(this.dtExample)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dtExample;
    }
}

namespace App_convertir_prueba
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvImportar = new System.Windows.Forms.DataGridView();
            this.btnannadir = new System.Windows.Forms.Button();
            this.btnImportSQL = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lProceso = new System.Windows.Forms.Label();
            this.cmbTablas = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cargadorschema1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvImportar
            // 
            this.dgvImportar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImportar.Location = new System.Drawing.Point(25, 31);
            this.dgvImportar.Name = "dgvImportar";
            this.dgvImportar.Size = new System.Drawing.Size(886, 461);
            this.dgvImportar.TabIndex = 0;
            // 
            // btnannadir
            // 
            this.btnannadir.Location = new System.Drawing.Point(155, 2);
            this.btnannadir.Name = "btnannadir";
            this.btnannadir.Size = new System.Drawing.Size(107, 23);
            this.btnannadir.TabIndex = 1;
            this.btnannadir.Text = "Añadir archivo";
            this.btnannadir.UseVisualStyleBackColor = true;
            this.btnannadir.Click += new System.EventHandler(this.btnAnnadir_Click);
            // 
            // btnImportSQL
            // 
            this.btnImportSQL.Location = new System.Drawing.Point(268, 2);
            this.btnImportSQL.Name = "btnImportSQL";
            this.btnImportSQL.Size = new System.Drawing.Size(93, 23);
            this.btnImportSQL.TabIndex = 2;
            this.btnImportSQL.Text = "Importar a SQL";
            this.btnImportSQL.UseVisualStyleBackColor = true;
            this.btnImportSQL.Click += new System.EventHandler(this.btnImportSQL_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(25, 521);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(886, 23);
            this.progressBar.TabIndex = 3;
            // 
            // lProceso
            // 
            this.lProceso.AutoSize = true;
            this.lProceso.Location = new System.Drawing.Point(25, 499);
            this.lProceso.Name = "lProceso";
            this.lProceso.Size = new System.Drawing.Size(82, 13);
            this.lProceso.TabIndex = 4;
            this.lProceso.Text = "Processing...0%";
            // 
            // cmbTablas
            // 
            this.cmbTablas.FormattingEnabled = true;
            this.cmbTablas.Location = new System.Drawing.Point(28, 4);
            this.cmbTablas.Name = "cmbTablas";
            this.cmbTablas.Size = new System.Drawing.Size(121, 21);
            this.cmbTablas.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 564);
            this.Controls.Add(this.cmbTablas);
            this.Controls.Add(this.lProceso);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnImportSQL);
            this.Controls.Add(this.btnannadir);
            this.Controls.Add(this.dgvImportar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvImportar;
        private System.Windows.Forms.Button btnannadir;
        private System.Windows.Forms.Button btnImportSQL;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lProceso;
        private System.Windows.Forms.ComboBox cmbTablas;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button cargadorschema1;
    }
}


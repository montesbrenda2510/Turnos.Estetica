namespace Turnos.Estetica.Windows
{
    partial class FormularioMetododePago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioMetododePago));
            this.dataGridViewMetododePago = new System.Windows.Forms.DataGridView();
            this.ColumnIdMetododepago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTipodePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMetododePago)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMetododePago
            // 
            this.dataGridViewMetododePago.AllowUserToAddRows = false;
            this.dataGridViewMetododePago.AllowUserToDeleteRows = false;
            this.dataGridViewMetododePago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMetododePago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIdMetododepago,
            this.ColumnTipodePago});
            this.dataGridViewMetododePago.Location = new System.Drawing.Point(0, 41);
            this.dataGridViewMetododePago.Name = "dataGridViewMetododePago";
            this.dataGridViewMetododePago.ReadOnly = true;
            this.dataGridViewMetododePago.Size = new System.Drawing.Size(335, 266);
            this.dataGridViewMetododePago.TabIndex = 3;
            // 
            // ColumnIdMetododepago
            // 
            this.ColumnIdMetododepago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnIdMetododepago.HeaderText = "IdMetododePago";
            this.ColumnIdMetododepago.Name = "ColumnIdMetododepago";
            this.ColumnIdMetododepago.ReadOnly = true;
            // 
            // ColumnTipodePago
            // 
            this.ColumnTipodePago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTipodePago.HeaderText = "Tipo de Pago";
            this.ColumnTipodePago.Name = "ColumnTipodePago";
            this.ColumnTipodePago.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNuevo,
            this.toolStripButtonBorrar,
            this.toolStripButtonEditar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(335, 38);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonNuevo
            // 
            this.toolStripButtonNuevo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNuevo.Image")));
            this.toolStripButtonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNuevo.Name = "toolStripButtonNuevo";
            this.toolStripButtonNuevo.Size = new System.Drawing.Size(46, 35);
            this.toolStripButtonNuevo.Text = "Nuevo";
            this.toolStripButtonNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButtonBorrar
            // 
            this.toolStripButtonBorrar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBorrar.Image")));
            this.toolStripButtonBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBorrar.Name = "toolStripButtonBorrar";
            this.toolStripButtonBorrar.Size = new System.Drawing.Size(43, 35);
            this.toolStripButtonBorrar.Text = "Borrar";
            this.toolStripButtonBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButtonEditar
            // 
            this.toolStripButtonEditar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditar.Image")));
            this.toolStripButtonEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditar.Name = "toolStripButtonEditar";
            this.toolStripButtonEditar.Size = new System.Drawing.Size(41, 35);
            this.toolStripButtonEditar.Text = "Editar";
            this.toolStripButtonEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // FormularioMetododePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 358);
            this.Controls.Add(this.dataGridViewMetododePago);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormularioMetododePago";
            this.Text = "FormulariMetododePago";
            this.Load += new System.EventHandler(this.FormularioMetododePago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMetododePago)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMetododePago;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNuevo;
        private System.Windows.Forms.ToolStripButton toolStripButtonBorrar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIdMetododepago;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTipodePago;
    }
}
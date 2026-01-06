namespace Turnos.Estetica.Windows
{
    partial class FormularioTintes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioTintes));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditar = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTinte = new System.Windows.Forms.DataGridView();
            this.ColumnIdTinte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTinte)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.RosyBrown;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNuevo,
            this.toolStripButtonBorrar,
            this.toolStripButtonEditar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(335, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButtonNuevo
            // 
            this.toolStripButtonNuevo.BackColor = System.Drawing.Color.DarkViolet;
            this.toolStripButtonNuevo.Image = global::Turnos.Estetica.Windows.Properties.Resources.Nuevo;
            this.toolStripButtonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNuevo.Name = "toolStripButtonNuevo";
            this.toolStripButtonNuevo.Size = new System.Drawing.Size(46, 35);
            this.toolStripButtonNuevo.Text = "Nuevo";
            this.toolStripButtonNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonNuevo.Click += new System.EventHandler(this.toolStripButtonNuevo_Click);
            // 
            // toolStripButtonBorrar
            // 
            this.toolStripButtonBorrar.BackColor = System.Drawing.Color.Yellow;
            this.toolStripButtonBorrar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBorrar.Image")));
            this.toolStripButtonBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBorrar.Name = "toolStripButtonBorrar";
            this.toolStripButtonBorrar.Size = new System.Drawing.Size(43, 35);
            this.toolStripButtonBorrar.Text = "Borrar";
            this.toolStripButtonBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonBorrar.Click += new System.EventHandler(this.toolStripButtonBorrar_Click);
            // 
            // toolStripButtonEditar
            // 
            this.toolStripButtonEditar.BackColor = System.Drawing.Color.LimeGreen;
            this.toolStripButtonEditar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditar.Image")));
            this.toolStripButtonEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditar.Name = "toolStripButtonEditar";
            this.toolStripButtonEditar.Size = new System.Drawing.Size(41, 35);
            this.toolStripButtonEditar.Text = "Editar";
            this.toolStripButtonEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonEditar.Click += new System.EventHandler(this.toolStripButtonEditar_Click);
            // 
            // dataGridViewTinte
            // 
            this.dataGridViewTinte.AllowUserToAddRows = false;
            this.dataGridViewTinte.AllowUserToDeleteRows = false;
            this.dataGridViewTinte.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dataGridViewTinte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTinte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIdTinte,
            this.ColumnColor});
            this.dataGridViewTinte.Location = new System.Drawing.Point(0, 41);
            this.dataGridViewTinte.Name = "dataGridViewTinte";
            this.dataGridViewTinte.ReadOnly = true;
            this.dataGridViewTinte.Size = new System.Drawing.Size(335, 266);
            this.dataGridViewTinte.TabIndex = 1;
            // 
            // ColumnIdTinte
            // 
            this.ColumnIdTinte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnIdTinte.HeaderText = "IdTinte";
            this.ColumnIdTinte.Name = "ColumnIdTinte";
            this.ColumnIdTinte.ReadOnly = true;
            // 
            // ColumnColor
            // 
            this.ColumnColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnColor.HeaderText = "Color";
            this.ColumnColor.Name = "ColumnColor";
            this.ColumnColor.ReadOnly = true;
            // 
            // FormularioTintes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 351);
            this.Controls.Add(this.dataGridViewTinte);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormularioTintes";
            this.Text = "FormularioTintes";
            this.Load += new System.EventHandler(this.FormularioTintes_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTinte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNuevo;
        private System.Windows.Forms.ToolStripButton toolStripButtonBorrar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditar;
        private System.Windows.Forms.DataGridView dataGridViewTinte;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIdTinte;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColor;
    }
}
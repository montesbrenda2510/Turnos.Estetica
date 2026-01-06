namespace Turnos.Estetica.Windows
{
    partial class FormularioPerfilados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioPerfilados));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditar = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewPerfilado = new System.Windows.Forms.DataGridView();
            this.Columntipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTinte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerfilado)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Plum;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNuevo,
            this.toolStripButtonBorrar,
            this.toolStripButtonEditar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(336, 38);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButtonNuevo
            // 
            this.toolStripButtonNuevo.BackColor = System.Drawing.Color.Salmon;
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
            this.toolStripButtonBorrar.BackColor = System.Drawing.Color.Lime;
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
            this.toolStripButtonEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.toolStripButtonEditar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditar.Image")));
            this.toolStripButtonEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditar.Name = "toolStripButtonEditar";
            this.toolStripButtonEditar.Size = new System.Drawing.Size(41, 35);
            this.toolStripButtonEditar.Text = "Editar";
            this.toolStripButtonEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonEditar.Click += new System.EventHandler(this.toolStripButtonEditar_Click);
            // 
            // dataGridViewPerfilado
            // 
            this.dataGridViewPerfilado.AllowUserToAddRows = false;
            this.dataGridViewPerfilado.AllowUserToDeleteRows = false;
            this.dataGridViewPerfilado.BackgroundColor = System.Drawing.Color.Plum;
            this.dataGridViewPerfilado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPerfilado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columntipo,
            this.ColumnTinte,
            this.ColumnTotal});
            this.dataGridViewPerfilado.Location = new System.Drawing.Point(1, 41);
            this.dataGridViewPerfilado.MultiSelect = false;
            this.dataGridViewPerfilado.Name = "dataGridViewPerfilado";
            this.dataGridViewPerfilado.ReadOnly = true;
            this.dataGridViewPerfilado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPerfilado.Size = new System.Drawing.Size(335, 266);
            this.dataGridViewPerfilado.TabIndex = 8;
            // 
            // Columntipo
            // 
            this.Columntipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columntipo.HeaderText = "Tipo de servicio";
            this.Columntipo.Name = "Columntipo";
            this.Columntipo.ReadOnly = true;
            // 
            // ColumnTinte
            // 
            this.ColumnTinte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTinte.HeaderText = "Color del tinte";
            this.ColumnTinte.Name = "ColumnTinte";
            this.ColumnTinte.ReadOnly = true;
            // 
            // ColumnTotal
            // 
            this.ColumnTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTotal.HeaderText = "Total";
            this.ColumnTotal.Name = "ColumnTotal";
            this.ColumnTotal.ReadOnly = true;
            // 
            // FormularioPerfilados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 337);
            this.Controls.Add(this.dataGridViewPerfilado);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormularioPerfilados";
            this.Text = "FormularioPerfilados";
            this.Load += new System.EventHandler(this.FormularioPerfilados_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerfilado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNuevo;
        private System.Windows.Forms.ToolStripButton toolStripButtonBorrar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditar;
        private System.Windows.Forms.DataGridView dataGridViewPerfilado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columntipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTinte;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotal;
    }
}
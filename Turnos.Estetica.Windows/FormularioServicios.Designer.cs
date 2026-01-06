namespace Turnos.Estetica.Windows
{
    partial class FormularioServicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioServicios));
            this.dataGridViewCliente = new System.Windows.Forms.DataGridView();
            this.ColumnDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColorPer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPestania = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColorPes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValoraPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCliente)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewCliente
            // 
            this.dataGridViewCliente.AllowUserToAddRows = false;
            this.dataGridViewCliente.AllowUserToDeleteRows = false;
            this.dataGridViewCliente.BackgroundColor = System.Drawing.Color.LightGreen;
            this.dataGridViewCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDetalle,
            this.ColumnPer,
            this.ColumnColorPer,
            this.ColumnPestania,
            this.ColumnColorPes,
            this.ColumnValoraPagar});
            this.dataGridViewCliente.Location = new System.Drawing.Point(0, 41);
            this.dataGridViewCliente.MultiSelect = false;
            this.dataGridViewCliente.Name = "dataGridViewCliente";
            this.dataGridViewCliente.ReadOnly = true;
            this.dataGridViewCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCliente.Size = new System.Drawing.Size(585, 266);
            this.dataGridViewCliente.TabIndex = 7;
            // 
            // ColumnDetalle
            // 
            this.ColumnDetalle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDetalle.HeaderText = "Tipo de Unia";
            this.ColumnDetalle.Name = "ColumnDetalle";
            this.ColumnDetalle.ReadOnly = true;
            // 
            // ColumnPer
            // 
            this.ColumnPer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPer.HeaderText = "Tipo de perfilado";
            this.ColumnPer.Name = "ColumnPer";
            this.ColumnPer.ReadOnly = true;
            // 
            // ColumnColorPer
            // 
            this.ColumnColorPer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnColorPer.HeaderText = "Color per";
            this.ColumnColorPer.Name = "ColumnColorPer";
            this.ColumnColorPer.ReadOnly = true;
            // 
            // ColumnPestania
            // 
            this.ColumnPestania.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPestania.HeaderText = "Pestania";
            this.ColumnPestania.Name = "ColumnPestania";
            this.ColumnPestania.ReadOnly = true;
            // 
            // ColumnColorPes
            // 
            this.ColumnColorPes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnColorPes.HeaderText = "Color pes";
            this.ColumnColorPes.Name = "ColumnColorPes";
            this.ColumnColorPes.ReadOnly = true;
            // 
            // ColumnValoraPagar
            // 
            this.ColumnValoraPagar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnValoraPagar.HeaderText = "Valor a Pagar";
            this.ColumnValoraPagar.Name = "ColumnValoraPagar";
            this.ColumnValoraPagar.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNuevo,
            this.toolStripButtonBorrar,
            this.toolStripButtonEditar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(585, 38);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButtonNuevo
            // 
            this.toolStripButtonNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
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
            this.toolStripButtonBorrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
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
            this.toolStripButtonEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.toolStripButtonEditar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditar.Image")));
            this.toolStripButtonEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditar.Name = "toolStripButtonEditar";
            this.toolStripButtonEditar.Size = new System.Drawing.Size(41, 35);
            this.toolStripButtonEditar.Text = "Editar";
            this.toolStripButtonEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonEditar.Click += new System.EventHandler(this.toolStripButtonEditar_Click);
            // 
            // FormularioServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 313);
            this.Controls.Add(this.dataGridViewCliente);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormularioServicios";
            this.Text = "FormularioServicios";
            this.Load += new System.EventHandler(this.FormularioServicios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCliente)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCliente;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNuevo;
        private System.Windows.Forms.ToolStripButton toolStripButtonBorrar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColorPer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPestania;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColorPes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValoraPagar;
    }
}
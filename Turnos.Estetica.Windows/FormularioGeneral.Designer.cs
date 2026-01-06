namespace Turnos.Estetica.Windows
{
    partial class FormularioGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioGeneral));
            this.dataGridViewCliente = new System.Windows.Forms.DataGridView();
            this.ColumnDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEgreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNomApe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPerfilado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPestania = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAsit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripButtonNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonFiltrar = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCliente)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewCliente
            // 
            this.dataGridViewCliente.AllowUserToAddRows = false;
            this.dataGridViewCliente.AllowUserToDeleteRows = false;
            this.dataGridViewCliente.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDia,
            this.ColumnIngreso,
            this.ColumnEgreso,
            this.ColumnNomApe,
            this.ColumnApellido,
            this.ColumnTel,
            this.ColumnUnia,
            this.ColumnPerfilado,
            this.ColumnPestania,
            this.ColumnPrecio,
            this.ColumnMtd,
            this.ColumnAsit});
            this.dataGridViewCliente.Location = new System.Drawing.Point(0, 41);
            this.dataGridViewCliente.MultiSelect = false;
            this.dataGridViewCliente.Name = "dataGridViewCliente";
            this.dataGridViewCliente.ReadOnly = true;
            this.dataGridViewCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCliente.Size = new System.Drawing.Size(939, 274);
            this.dataGridViewCliente.TabIndex = 7;
            // 
            // ColumnDia
            // 
            this.ColumnDia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDia.HeaderText = "Dia";
            this.ColumnDia.Name = "ColumnDia";
            this.ColumnDia.ReadOnly = true;
            // 
            // ColumnIngreso
            // 
            this.ColumnIngreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnIngreso.HeaderText = "Ingreso";
            this.ColumnIngreso.Name = "ColumnIngreso";
            this.ColumnIngreso.ReadOnly = true;
            // 
            // ColumnEgreso
            // 
            this.ColumnEgreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnEgreso.HeaderText = "Egreso";
            this.ColumnEgreso.Name = "ColumnEgreso";
            this.ColumnEgreso.ReadOnly = true;
            // 
            // ColumnNomApe
            // 
            this.ColumnNomApe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnNomApe.HeaderText = "Nombre ";
            this.ColumnNomApe.Name = "ColumnNomApe";
            this.ColumnNomApe.ReadOnly = true;
            // 
            // ColumnApellido
            // 
            this.ColumnApellido.HeaderText = "Apellido";
            this.ColumnApellido.Name = "ColumnApellido";
            this.ColumnApellido.ReadOnly = true;
            // 
            // ColumnTel
            // 
            this.ColumnTel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTel.HeaderText = "Telefono";
            this.ColumnTel.Name = "ColumnTel";
            this.ColumnTel.ReadOnly = true;
            // 
            // ColumnUnia
            // 
            this.ColumnUnia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnUnia.HeaderText = "Unia";
            this.ColumnUnia.Name = "ColumnUnia";
            this.ColumnUnia.ReadOnly = true;
            // 
            // ColumnPerfilado
            // 
            this.ColumnPerfilado.HeaderText = "Perfilado";
            this.ColumnPerfilado.Name = "ColumnPerfilado";
            this.ColumnPerfilado.ReadOnly = true;
            // 
            // ColumnPestania
            // 
            this.ColumnPestania.HeaderText = "Pestania";
            this.ColumnPestania.Name = "ColumnPestania";
            this.ColumnPestania.ReadOnly = true;
            // 
            // ColumnPrecio
            // 
            this.ColumnPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPrecio.HeaderText = "Precio";
            this.ColumnPrecio.Name = "ColumnPrecio";
            this.ColumnPrecio.ReadOnly = true;
            // 
            // ColumnMtd
            // 
            this.ColumnMtd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnMtd.HeaderText = "Metodo de pago";
            this.ColumnMtd.Name = "ColumnMtd";
            this.ColumnMtd.ReadOnly = true;
            // 
            // ColumnAsit
            // 
            this.ColumnAsit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnAsit.HeaderText = "Asistencia";
            this.ColumnAsit.Name = "ColumnAsit";
            this.ColumnAsit.ReadOnly = true;
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
            this.toolStripButtonBorrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
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
            this.toolStripButtonEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.toolStripButtonEditar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditar.Image")));
            this.toolStripButtonEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditar.Name = "toolStripButtonEditar";
            this.toolStripButtonEditar.Size = new System.Drawing.Size(41, 35);
            this.toolStripButtonEditar.Text = "Editar";
            this.toolStripButtonEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonEditar.Click += new System.EventHandler(this.toolStripButtonEditar_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNuevo,
            this.toolStripButtonBorrar,
            this.toolStripButtonEditar,
            this.toolStripSeparator1,
            this.ButtonFiltrar,
            this.toolStripSeparator2,
            this.ButtonSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(939, 38);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // ButtonFiltrar
            // 
            this.ButtonFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ButtonFiltrar.Name = "ButtonFiltrar";
            this.ButtonFiltrar.Size = new System.Drawing.Size(200, 38);
            this.ButtonFiltrar.Text = "Filtrar";
            this.ButtonFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonFiltrar.Click += new System.EventHandler(this.ButtonFiltrar_Click);
            this.ButtonFiltrar.TextChanged += new System.EventHandler(this.ButtonFiltrar_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // ButtonSalir
            // 
            this.ButtonSalir.BackColor = System.Drawing.Color.Plum;
            this.ButtonSalir.Image = ((System.Drawing.Image)(resources.GetObject("ButtonSalir.Image")));
            this.ButtonSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSalir.Name = "ButtonSalir";
            this.ButtonSalir.Size = new System.Drawing.Size(33, 35);
            this.ButtonSalir.Text = "Salir";
            this.ButtonSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonSalir.Click += new System.EventHandler(this.ButtonSalir_Click);
            // 
            // FormularioGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 317);
            this.Controls.Add(this.dataGridViewCliente);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormularioGeneral";
            this.Text = "FormularioGeneral";
            this.Load += new System.EventHandler(this.FormularioGeneral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCliente)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNomApe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPerfilado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPestania;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAsit;
        private System.Windows.Forms.ToolStripButton toolStripButtonNuevo;
        private System.Windows.Forms.ToolStripButton toolStripButtonBorrar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ButtonSalir;
        private System.Windows.Forms.ToolStripTextBox ButtonFiltrar;
    }
}
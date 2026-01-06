namespace Turnos.Estetica.Windows
{
    partial class FormularioHorario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioHorario));
            this.dataGridViewHorario = new System.Windows.Forms.DataGridView();
            this.ColumnIdHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEgreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorario)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewHorario
            // 
            this.dataGridViewHorario.AllowUserToAddRows = false;
            this.dataGridViewHorario.AllowUserToDeleteRows = false;
            this.dataGridViewHorario.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridViewHorario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHorario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIdHorario,
            this.ColumnIngreso,
            this.ColumnEgreso});
            this.dataGridViewHorario.Location = new System.Drawing.Point(0, 41);
            this.dataGridViewHorario.Name = "dataGridViewHorario";
            this.dataGridViewHorario.ReadOnly = true;
            this.dataGridViewHorario.Size = new System.Drawing.Size(335, 266);
            this.dataGridViewHorario.TabIndex = 3;
            // 
            // ColumnIdHorario
            // 
            this.ColumnIdHorario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnIdHorario.HeaderText = "IdHorario";
            this.ColumnIdHorario.Name = "ColumnIdHorario";
            this.ColumnIdHorario.ReadOnly = true;
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
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNuevo,
            this.toolStripButtonBorrar,
            this.toolStripButtonEditar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(336, 38);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonNuevo
            // 
            this.toolStripButtonNuevo.BackColor = System.Drawing.Color.Coral;
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
            this.toolStripButtonBorrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
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
            // FormularioHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 342);
            this.Controls.Add(this.dataGridViewHorario);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormularioHorario";
            this.Text = "FormularioHorario";
            this.Load += new System.EventHandler(this.FormularioHorario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorario)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHorario;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNuevo;
        private System.Windows.Forms.ToolStripButton toolStripButtonBorrar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIdHorario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEgreso;
    }
}
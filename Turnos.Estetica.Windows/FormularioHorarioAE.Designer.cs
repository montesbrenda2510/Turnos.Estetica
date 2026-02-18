namespace Turnos.Estetica.Windows
{
    partial class FormularioHorarioAE
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioHorarioAE));
            this.labelIngreso = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.labelEgreso = new System.Windows.Forms.Label();
            this.dateTimePickerIngreso = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEgreso = new System.Windows.Forms.DateTimePicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelIngreso
            // 
            this.labelIngreso.AutoSize = true;
            this.labelIngreso.Location = new System.Drawing.Point(33, 27);
            this.labelIngreso.Name = "labelIngreso";
            this.labelIngreso.Size = new System.Drawing.Size(82, 13);
            this.labelIngreso.TabIndex = 5;
            this.labelIngreso.Text = "Hora de ingreso";
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonOk.Image = ((System.Drawing.Image)(resources.GetObject("buttonOk.Image")));
            this.buttonOk.Location = new System.Drawing.Point(36, 121);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(91, 66);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "OK";
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonCancelar.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancelar.Image")));
            this.buttonCancelar.Location = new System.Drawing.Point(283, 121);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(91, 66);
            this.buttonCancelar.TabIndex = 4;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // labelEgreso
            // 
            this.labelEgreso.AutoSize = true;
            this.labelEgreso.Location = new System.Drawing.Point(33, 75);
            this.labelEgreso.Name = "labelEgreso";
            this.labelEgreso.Size = new System.Drawing.Size(81, 13);
            this.labelEgreso.TabIndex = 5;
            this.labelEgreso.Text = "Hora de Egreso";
            // 
            // dateTimePickerIngreso
            // 
            this.dateTimePickerIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerIngreso.Location = new System.Drawing.Point(121, 27);
            this.dateTimePickerIngreso.MinDate = new System.DateTime(2026, 2, 18, 0, 0, 0, 0);
            this.dateTimePickerIngreso.Name = "dateTimePickerIngreso";
            this.dateTimePickerIngreso.Size = new System.Drawing.Size(240, 20);
            this.dateTimePickerIngreso.TabIndex = 7;
            this.dateTimePickerIngreso.Value = new System.DateTime(2026, 2, 18, 0, 0, 0, 0);
            // 
            // dateTimePickerEgreso
            // 
            this.dateTimePickerEgreso.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerEgreso.Location = new System.Drawing.Point(121, 75);
            this.dateTimePickerEgreso.MinDate = new System.DateTime(2026, 2, 18, 0, 0, 0, 0);
            this.dateTimePickerEgreso.Name = "dateTimePickerEgreso";
            this.dateTimePickerEgreso.Size = new System.Drawing.Size(240, 20);
            this.dateTimePickerEgreso.TabIndex = 7;
            this.dateTimePickerEgreso.Value = new System.DateTime(2026, 2, 18, 0, 0, 0, 0);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormularioHorarioAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(403, 199);
            this.Controls.Add(this.dateTimePickerEgreso);
            this.Controls.Add(this.dateTimePickerIngreso);
            this.Controls.Add(this.labelEgreso);
            this.Controls.Add(this.labelIngreso);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancelar);
            this.Name = "FormularioHorarioAE";
            this.Text = "FormularioHorarioAE";
            this.Load += new System.EventHandler(this.FormularioHorarioAE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelIngreso;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label labelEgreso;
        private System.Windows.Forms.DateTimePicker dateTimePickerIngreso;
        private System.Windows.Forms.DateTimePicker dateTimePickerEgreso;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
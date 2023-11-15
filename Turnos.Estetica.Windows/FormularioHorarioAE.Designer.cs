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
            this.labelIngreso = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.labelEgreso = new System.Windows.Forms.Label();
            this.dateTimePickerIngreso = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEgreso = new System.Windows.Forms.DateTimePicker();
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
            this.buttonOk.Location = new System.Drawing.Point(36, 121);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(91, 66);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(283, 121);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(91, 66);
            this.buttonCancelar.TabIndex = 4;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
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
            this.dateTimePickerIngreso.Location = new System.Drawing.Point(135, 27);
            this.dateTimePickerIngreso.Name = "dateTimePickerIngreso";
            this.dateTimePickerIngreso.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerIngreso.TabIndex = 7;
            this.dateTimePickerIngreso.Value = new System.DateTime(2023, 11, 8, 19, 20, 0, 0);
            // 
            // dateTimePickerEgreso
            // 
            this.dateTimePickerEgreso.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerEgreso.Location = new System.Drawing.Point(135, 75);
            this.dateTimePickerEgreso.Name = "dateTimePickerEgreso";
            this.dateTimePickerEgreso.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEgreso.TabIndex = 7;
            // 
            // FormularioHorarioAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}
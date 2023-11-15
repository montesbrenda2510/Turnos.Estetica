namespace Turnos.Estetica.Windows
{
    partial class FormularioMetododePagoAE
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
            this.textBoxMetododePago = new System.Windows.Forms.TextBox();
            this.labelMetododePago = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxMetododePago
            // 
            this.textBoxMetododePago.Location = new System.Drawing.Point(134, 55);
            this.textBoxMetododePago.Name = "textBoxMetododePago";
            this.textBoxMetododePago.Size = new System.Drawing.Size(168, 20);
            this.textBoxMetododePago.TabIndex = 12;
            // 
            // labelMetododePago
            // 
            this.labelMetododePago.AutoSize = true;
            this.labelMetododePago.Location = new System.Drawing.Point(34, 62);
            this.labelMetododePago.Name = "labelMetododePago";
            this.labelMetododePago.Size = new System.Drawing.Size(85, 13);
            this.labelMetododePago.TabIndex = 10;
            this.labelMetododePago.Text = "Metodo de pago";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(37, 129);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(91, 66);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(284, 129);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(91, 66);
            this.buttonCancelar.TabIndex = 8;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // FormularioMetododePagoAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 223);
            this.Controls.Add(this.textBoxMetododePago);
            this.Controls.Add(this.labelMetododePago);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancelar);
            this.Name = "FormularioMetododePagoAE";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormularioMetododePagoAE_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMetododePago;
        private System.Windows.Forms.Label labelMetododePago;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancelar;
    }
}
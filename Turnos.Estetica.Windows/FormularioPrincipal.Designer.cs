namespace Turnos.Estetica.Windows
{
    partial class FormularioPrincipal
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
            this.buttonTintes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonMdP = new System.Windows.Forms.Button();
            this.buttonHorario = new System.Windows.Forms.Button();
            this.buttonUñas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTintes
            // 
            this.buttonTintes.Location = new System.Drawing.Point(506, 267);
            this.buttonTintes.Name = "buttonTintes";
            this.buttonTintes.Size = new System.Drawing.Size(109, 70);
            this.buttonTintes.TabIndex = 0;
            this.buttonTintes.Text = "Tintes";
            this.buttonTintes.UseVisualStyleBackColor = true;
            this.buttonTintes.Click += new System.EventHandler(this.buttonTintes_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(506, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "Clientes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonMdP
            // 
            this.buttonMdP.Location = new System.Drawing.Point(506, 156);
            this.buttonMdP.Name = "buttonMdP";
            this.buttonMdP.Size = new System.Drawing.Size(109, 70);
            this.buttonMdP.TabIndex = 1;
            this.buttonMdP.Text = "Metodo de Pago";
            this.buttonMdP.UseVisualStyleBackColor = true;
            this.buttonMdP.Click += new System.EventHandler(this.buttonMdP_Click);
            // 
            // buttonHorario
            // 
            this.buttonHorario.Location = new System.Drawing.Point(666, 98);
            this.buttonHorario.Name = "buttonHorario";
            this.buttonHorario.Size = new System.Drawing.Size(109, 70);
            this.buttonHorario.TabIndex = 2;
            this.buttonHorario.Text = "Horarios";
            this.buttonHorario.UseVisualStyleBackColor = true;
            this.buttonHorario.Click += new System.EventHandler(this.buttonHorario_Click);
            // 
            // buttonUñas
            // 
            this.buttonUñas.Location = new System.Drawing.Point(652, 218);
            this.buttonUñas.Name = "buttonUñas";
            this.buttonUñas.Size = new System.Drawing.Size(109, 70);
            this.buttonUñas.TabIndex = 3;
            this.buttonUñas.Text = "Uñas";
            this.buttonUñas.UseVisualStyleBackColor = true;
            this.buttonUñas.Click += new System.EventHandler(this.buttonUñas_Click);
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 358);
            this.Controls.Add(this.buttonUñas);
            this.Controls.Add(this.buttonHorario);
            this.Controls.Add(this.buttonMdP);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonTintes);
            this.Name = "FormularioPrincipal";
            this.Text = "FormularioPrincipal";
            this.Load += new System.EventHandler(this.FormularioPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTintes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonMdP;
        private System.Windows.Forms.Button buttonHorario;
        private System.Windows.Forms.Button buttonUñas;
    }
}
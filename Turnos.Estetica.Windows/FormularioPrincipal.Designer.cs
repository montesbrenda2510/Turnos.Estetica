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
            this.Generalbtn = new System.Windows.Forms.Button();
            this.Serviciosbtn = new System.Windows.Forms.Button();
            this.Perfiladobtn = new System.Windows.Forms.Button();
            this.Pestaniasbtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonTintes
            // 
            this.buttonTintes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonTintes.Location = new System.Drawing.Point(221, 283);
            this.buttonTintes.Name = "buttonTintes";
            this.buttonTintes.Size = new System.Drawing.Size(109, 70);
            this.buttonTintes.TabIndex = 0;
            this.buttonTintes.Text = "Tintes";
            this.buttonTintes.UseVisualStyleBackColor = false;
            this.buttonTintes.Click += new System.EventHandler(this.buttonTintes_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(642, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "Clientes";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonMdP
            // 
            this.buttonMdP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonMdP.Location = new System.Drawing.Point(466, 207);
            this.buttonMdP.Name = "buttonMdP";
            this.buttonMdP.Size = new System.Drawing.Size(109, 70);
            this.buttonMdP.TabIndex = 1;
            this.buttonMdP.Text = "Metodo de Pago";
            this.buttonMdP.UseVisualStyleBackColor = false;
            this.buttonMdP.Click += new System.EventHandler(this.buttonMdP_Click);
            // 
            // buttonHorario
            // 
            this.buttonHorario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonHorario.Location = new System.Drawing.Point(466, 122);
            this.buttonHorario.Name = "buttonHorario";
            this.buttonHorario.Size = new System.Drawing.Size(109, 70);
            this.buttonHorario.TabIndex = 2;
            this.buttonHorario.Text = "Horarios";
            this.buttonHorario.UseVisualStyleBackColor = false;
            this.buttonHorario.Click += new System.EventHandler(this.buttonHorario_Click);
            // 
            // buttonUñas
            // 
            this.buttonUñas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonUñas.Location = new System.Drawing.Point(27, 207);
            this.buttonUñas.Name = "buttonUñas";
            this.buttonUñas.Size = new System.Drawing.Size(109, 70);
            this.buttonUñas.TabIndex = 3;
            this.buttonUñas.Text = "Uñas";
            this.buttonUñas.UseVisualStyleBackColor = false;
            this.buttonUñas.Click += new System.EventHandler(this.buttonUñas_Click);
            // 
            // Generalbtn
            // 
            this.Generalbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Generalbtn.Location = new System.Drawing.Point(254, 33);
            this.Generalbtn.Name = "Generalbtn";
            this.Generalbtn.Size = new System.Drawing.Size(252, 70);
            this.Generalbtn.TabIndex = 4;
            this.Generalbtn.Text = "Cartilla General";
            this.Generalbtn.UseVisualStyleBackColor = false;
            this.Generalbtn.Click += new System.EventHandler(this.Generalbtn_Click);
            // 
            // Serviciosbtn
            // 
            this.Serviciosbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Serviciosbtn.Location = new System.Drawing.Point(139, 122);
            this.Serviciosbtn.Name = "Serviciosbtn";
            this.Serviciosbtn.Size = new System.Drawing.Size(138, 70);
            this.Serviciosbtn.TabIndex = 5;
            this.Serviciosbtn.Text = " Tipos de Servicios";
            this.Serviciosbtn.UseVisualStyleBackColor = false;
            this.Serviciosbtn.Click += new System.EventHandler(this.Serviciosbtn_Click);
            // 
            // Perfiladobtn
            // 
            this.Perfiladobtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Perfiladobtn.Location = new System.Drawing.Point(154, 207);
            this.Perfiladobtn.Name = "Perfiladobtn";
            this.Perfiladobtn.Size = new System.Drawing.Size(111, 70);
            this.Perfiladobtn.TabIndex = 6;
            this.Perfiladobtn.Text = "Perfilado";
            this.Perfiladobtn.UseVisualStyleBackColor = false;
            this.Perfiladobtn.Click += new System.EventHandler(this.Perfiladobtn_Click);
            // 
            // Pestaniasbtn
            // 
            this.Pestaniasbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Pestaniasbtn.Location = new System.Drawing.Point(285, 207);
            this.Pestaniasbtn.Name = "Pestaniasbtn";
            this.Pestaniasbtn.Size = new System.Drawing.Size(103, 70);
            this.Pestaniasbtn.TabIndex = 7;
            this.Pestaniasbtn.Text = "Pestanias";
            this.Pestaniasbtn.UseVisualStyleBackColor = false;
            this.Pestaniasbtn.Click += new System.EventHandler(this.Pestaniasbtn_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(690, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 55);
            this.button2.TabIndex = 8;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Cyan;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(680, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Programa de turnos en cada boton podras ver la informacion , editar, agregar o bo" +
    "rrar contenido  ";
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(811, 358);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Pestaniasbtn);
            this.Controls.Add(this.Perfiladobtn);
            this.Controls.Add(this.Serviciosbtn);
            this.Controls.Add(this.Generalbtn);
            this.Controls.Add(this.buttonUñas);
            this.Controls.Add(this.buttonHorario);
            this.Controls.Add(this.buttonMdP);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonTintes);
            this.Name = "FormularioPrincipal";
            this.Text = "FormularioPrincipal";
            this.Load += new System.EventHandler(this.FormularioPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTintes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonMdP;
        private System.Windows.Forms.Button buttonHorario;
        private System.Windows.Forms.Button buttonUñas;
        private System.Windows.Forms.Button Generalbtn;
        private System.Windows.Forms.Button Serviciosbtn;
        private System.Windows.Forms.Button Perfiladobtn;
        private System.Windows.Forms.Button Pestaniasbtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}
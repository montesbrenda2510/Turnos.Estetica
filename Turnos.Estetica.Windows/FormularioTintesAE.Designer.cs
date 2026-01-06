namespace Turnos.Estetica.Windows
{
    partial class FormularioTintesAE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioTintesAE));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelTintes = new System.Windows.Forms.Label();
            this.textBoxColorTinte = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonCancelar.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancelar.Image")));
            this.buttonCancelar.Location = new System.Drawing.Point(287, 150);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(91, 66);
            this.buttonCancelar.TabIndex = 0;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonOk.Image = ((System.Drawing.Image)(resources.GetObject("buttonOk.Image")));
            this.buttonOk.Location = new System.Drawing.Point(42, 150);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(91, 66);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelTintes
            // 
            this.labelTintes.AutoSize = true;
            this.labelTintes.Location = new System.Drawing.Point(39, 70);
            this.labelTintes.Name = "labelTintes";
            this.labelTintes.Size = new System.Drawing.Size(78, 13);
            this.labelTintes.TabIndex = 1;
            this.labelTintes.Text = "Color del Tinte ";
            this.labelTintes.Click += new System.EventHandler(this.labelTintes_Click);
            // 
            // textBoxColorTinte
            // 
            this.textBoxColorTinte.Location = new System.Drawing.Point(139, 70);
            this.textBoxColorTinte.Name = "textBoxColorTinte";
            this.textBoxColorTinte.Size = new System.Drawing.Size(168, 20);
            this.textBoxColorTinte.TabIndex = 2;
            // 
            // FormularioTintesAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(420, 248);
            this.Controls.Add(this.textBoxColorTinte);
            this.Controls.Add(this.labelTintes);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancelar);
            this.Name = "FormularioTintesAE";
            this.Text = "FormularioTintesAE";
            this.Load += new System.EventHandler(this.FormularioTintesAE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox textBoxColorTinte;
        private System.Windows.Forms.Label labelTintes;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancelar;
    }
}
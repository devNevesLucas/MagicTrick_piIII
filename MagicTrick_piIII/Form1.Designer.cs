namespace MagicTrick_piIII
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblVersao = new System.Windows.Forms.Label();
            this.btnJogar = new System.Windows.Forms.Button();
            this.btnCreditos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(368, 428);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(39, 13);
            this.lblVersao.TabIndex = 0;
            this.lblVersao.Text = "versão";
            // 
            // btnJogar
            // 
            this.btnJogar.Location = new System.Drawing.Point(135, 227);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(146, 46);
            this.btnJogar.TabIndex = 1;
            this.btnJogar.Text = "Jogar";
            this.btnJogar.UseVisualStyleBackColor = true;
            // 
            // btnCreditos
            // 
            this.btnCreditos.Location = new System.Drawing.Point(135, 303);
            this.btnCreditos.Name = "btnCreditos";
            this.btnCreditos.Size = new System.Drawing.Size(146, 46);
            this.btnCreditos.TabIndex = 2;
            this.btnCreditos.Text = "Créditos (do automato)";
            this.btnCreditos.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 450);
            this.Controls.Add(this.btnCreditos);
            this.Controls.Add(this.btnJogar);
            this.Controls.Add(this.lblVersao);
            this.Name = "Form1";
            this.Text = "Magic Trick (Luxemburgo)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Button btnJogar;
        private System.Windows.Forms.Button btnCreditos;
    }
}


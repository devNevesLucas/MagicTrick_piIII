namespace MagicTrick_piIII.telas
{
    partial class frmCriancaoPartida
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
            this.txtNomePartida = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblNomePartida = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.btnCriarPartida = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNomePartida
            // 
            this.txtNomePartida.Location = new System.Drawing.Point(37, 109);
            this.txtNomePartida.Name = "txtNomePartida";
            this.txtNomePartida.Size = new System.Drawing.Size(180, 20);
            this.txtNomePartida.TabIndex = 1;        
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(37, 160);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(180, 20);
            this.txtSenha.TabIndex = 2;
            // 
            // lblNomePartida
            // 
            this.lblNomePartida.AutoSize = true;
            this.lblNomePartida.Location = new System.Drawing.Point(34, 93);
            this.lblNomePartida.Name = "lblNomePartida";
            this.lblNomePartida.Size = new System.Drawing.Size(86, 13);
            this.lblNomePartida.TabIndex = 3;
            this.lblNomePartida.Text = "Nome da Partida";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(34, 144);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(38, 13);
            this.lblSenha.TabIndex = 4;
            this.lblSenha.Text = "Senha";
            // 
            // btnCriarPartida
            // 
            this.btnCriarPartida.Location = new System.Drawing.Point(338, 109);
            this.btnCriarPartida.Name = "btnCriarPartida";
            this.btnCriarPartida.Size = new System.Drawing.Size(75, 71);
            this.btnCriarPartida.TabIndex = 5;
            this.btnCriarPartida.Text = "Criar Partida";
            this.btnCriarPartida.UseVisualStyleBackColor = true;
            this.btnCriarPartida.Click += new System.EventHandler(this.btnCriarPartida_Click);
            // 
            // frmCriancaoPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 337);
            this.Controls.Add(this.btnCriarPartida);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblNomePartida);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtNomePartida);
            this.Name = "frmCriancaoPartida";
            this.Text = "Magic Trick (Luxemburgo) - Criar Partida";
            this.Load += new System.EventHandler(this.CriancaoPartida_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNomePartida;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblNomePartida;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Button btnCriarPartida;
    }
}
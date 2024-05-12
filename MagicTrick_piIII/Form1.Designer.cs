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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblVersao = new System.Windows.Forms.Label();
            this.btnJogar = new System.Windows.Forms.Button();
            this.btnCreditos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblVersao
            // 
            this.lblVersao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersao.AutoSize = true;
            this.lblVersao.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersao.ForeColor = System.Drawing.Color.White;
            this.lblVersao.Location = new System.Drawing.Point(299, 9);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(101, 19);
            this.lblVersao.TabIndex = 0;
            this.lblVersao.Text = "Luxemburgo - ";
            this.lblVersao.Click += new System.EventHandler(this.lblVersao_Click);
            // 
            // btnJogar
            // 
            this.btnJogar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnJogar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(24)))));
            this.btnJogar.FlatAppearance.BorderSize = 0;
            this.btnJogar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogar.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogar.ForeColor = System.Drawing.Color.White;
            this.btnJogar.Location = new System.Drawing.Point(135, 227);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(146, 46);
            this.btnJogar.TabIndex = 1;
            this.btnJogar.Text = "Jogar";
            this.btnJogar.UseVisualStyleBackColor = false;
            this.btnJogar.Click += new System.EventHandler(this.btnJogar_Click);
            // 
            // btnCreditos
            // 
            this.btnCreditos.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCreditos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(24)))));
            this.btnCreditos.FlatAppearance.BorderSize = 0;
            this.btnCreditos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreditos.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreditos.ForeColor = System.Drawing.Color.White;
            this.btnCreditos.Location = new System.Drawing.Point(135, 303);
            this.btnCreditos.MinimumSize = new System.Drawing.Size(146, 46);
            this.btnCreditos.Name = "btnCreditos";
            this.btnCreditos.Size = new System.Drawing.Size(146, 46);
            this.btnCreditos.TabIndex = 2;
            this.btnCreditos.Text = "Créditos\r\n(do automato)";
            this.btnCreditos.UseVisualStyleBackColor = false;
            this.btnCreditos.Click += new System.EventHandler(this.btnCreditos_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(419, 450);
            this.Controls.Add(this.btnCreditos);
            this.Controls.Add(this.btnJogar);
            this.Controls.Add(this.lblVersao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(435, 489);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magic Trick - Luxemburgo";
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


namespace MagicTrick_piIII
{
    partial class frmMenu
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
            this.dgvPartidas = new System.Windows.Forms.DataGridView();
            this.btnListagem = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.btnCriar = new System.Windows.Forms.Button();
            this.lblVersao = new System.Windows.Forms.Label();
            this.gpbJogadores = new System.Windows.Forms.GroupBox();
            this.dgvJogadores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartidas)).BeginInit();
            this.gpbJogadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogadores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPartidas
            // 
            this.dgvPartidas.AllowUserToAddRows = false;
            this.dgvPartidas.AllowUserToDeleteRows = false;
            this.dgvPartidas.AllowUserToResizeColumns = false;
            this.dgvPartidas.AllowUserToResizeRows = false;
            this.dgvPartidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartidas.Location = new System.Drawing.Point(12, 83);
            this.dgvPartidas.MultiSelect = false;
            this.dgvPartidas.Name = "dgvPartidas";
            this.dgvPartidas.ReadOnly = true;
            this.dgvPartidas.Size = new System.Drawing.Size(504, 393);
            this.dgvPartidas.TabIndex = 2;
            this.dgvPartidas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartidas_CellClick);       
            // 
            // btnListagem
            // 
            this.btnListagem.Location = new System.Drawing.Point(12, 12);
            this.btnListagem.Name = "btnListagem";
            this.btnListagem.Size = new System.Drawing.Size(157, 47);
            this.btnListagem.TabIndex = 3;
            this.btnListagem.Text = "Listar partidas";
            this.btnListagem.UseVisualStyleBackColor = true;
            this.btnListagem.Click += new System.EventHandler(this.btnListagem_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(12, 513);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(94, 39);
            this.btnVoltar.TabIndex = 4;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnEntrar
            // 
            this.btnEntrar.Location = new System.Drawing.Point(726, 484);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(224, 68);
            this.btnEntrar.TabIndex = 5;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            // 
            // btnCriar
            // 
            this.btnCriar.Location = new System.Drawing.Point(359, 12);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(157, 47);
            this.btnCriar.TabIndex = 6;
            this.btnCriar.Text = "Criar partida";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersao.Location = new System.Drawing.Point(842, 9);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(91, 16);
            this.lblVersao.TabIndex = 7;
            this.lblVersao.Text = "Luxemburgo - ";
            // 
            // gpbJogadores
            // 
            this.gpbJogadores.Controls.Add(this.dgvJogadores);
            this.gpbJogadores.Location = new System.Drawing.Point(599, 83);
            this.gpbJogadores.Name = "gpbJogadores";
            this.gpbJogadores.Size = new System.Drawing.Size(351, 313);
            this.gpbJogadores.TabIndex = 9;
            this.gpbJogadores.TabStop = false;
            this.gpbJogadores.Text = "Jogadores";
            // 
            // dgvJogadores
            // 
            this.dgvJogadores.AllowUserToAddRows = false;
            this.dgvJogadores.AllowUserToDeleteRows = false;
            this.dgvJogadores.AllowUserToResizeColumns = false;
            this.dgvJogadores.AllowUserToResizeRows = false;
            this.dgvJogadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJogadores.Enabled = false;
            this.dgvJogadores.Location = new System.Drawing.Point(6, 43);
            this.dgvJogadores.Name = "dgvJogadores";
            this.dgvJogadores.Size = new System.Drawing.Size(339, 264);
            this.dgvJogadores.TabIndex = 9;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 564);
            this.Controls.Add(this.gpbJogadores);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.btnCriar);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnListagem);
            this.Controls.Add(this.dgvPartidas);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magic Trick (Luxemburgo) - Menu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartidas)).EndInit();
            this.gpbJogadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPartidas;
        private System.Windows.Forms.Button btnListagem;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Button btnCriar;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.GroupBox gpbJogadores;
        private System.Windows.Forms.DataGridView dgvJogadores;
    }
}
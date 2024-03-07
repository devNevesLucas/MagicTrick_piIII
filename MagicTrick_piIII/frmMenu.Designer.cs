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
            this.grbJogadores = new System.Windows.Forms.GroupBox();
            this.dgvPartidas = new System.Windows.Forms.DataGridView();
            this.btnListagem = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.btnCriar = new System.Windows.Forms.Button();
            this.lblVersao = new System.Windows.Forms.Label();
            this.nomePartida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataCriacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartidas)).BeginInit();
            this.SuspendLayout();
            // 
            // grbJogadores
            // 
            this.grbJogadores.Location = new System.Drawing.Point(725, 83);
            this.grbJogadores.Name = "grbJogadores";
            this.grbJogadores.Size = new System.Drawing.Size(225, 264);
            this.grbJogadores.TabIndex = 1;
            this.grbJogadores.TabStop = false;
            this.grbJogadores.Text = "Jogadores";
            // 
            // dgvPartidas
            // 
            this.dgvPartidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomePartida,
            this.Status,
            this.dataCriacao});
            this.dgvPartidas.Location = new System.Drawing.Point(12, 83);
            this.dgvPartidas.Name = "dgvPartidas";
            this.dgvPartidas.Size = new System.Drawing.Size(504, 393);
            this.dgvPartidas.TabIndex = 2;
            this.dgvPartidas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartidas_CellContentClick);
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
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(928, 9);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(22, 13);
            this.lblVersao.TabIndex = 7;
            this.lblVersao.Text = "1.0";
            this.lblVersao.Click += new System.EventHandler(this.lblVersao_Click);
            // 
            // nomePartida
            // 
            this.nomePartida.HeaderText = "nome";
            this.nomePartida.Name = "nomePartida";
            this.nomePartida.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nomePartida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Status
            // 
            this.Status.HeaderText = "status";
            this.Status.Name = "Status";
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataCriacao
            // 
            this.dataCriacao.HeaderText = "data de criação";
            this.dataCriacao.Name = "dataCriacao";
            this.dataCriacao.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataCriacao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 564);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.btnCriar);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnListagem);
            this.Controls.Add(this.dgvPartidas);
            this.Controls.Add(this.grbJogadores);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magic Trick (Luxemburgo) - Menu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbJogadores;
        private System.Windows.Forms.DataGridView dgvPartidas;
        private System.Windows.Forms.Button btnListagem;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Button btnCriar;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomePartida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataCriacao;
    }
}
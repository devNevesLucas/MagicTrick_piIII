﻿namespace MagicTrick_piIII.telas
{
    partial class frmPartida
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
            this.grpJogo = new System.Windows.Forms.GroupBox();
            this.dgvJogadores = new System.Windows.Forms.DataGridView();
            this.btnIniciarPartida = new System.Windows.Forms.Button();
            this.lblStatusPartida = new System.Windows.Forms.Label();
            this.lblVersao = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblValorCarta = new System.Windows.Forms.Label();
            this.lblValorAposta = new System.Windows.Forms.Label();
            this.grpJogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogadores)).BeginInit();
            this.SuspendLayout();
            // 
            // grpJogo
            // 
            this.grpJogo.Controls.Add(this.lblValorAposta);
            this.grpJogo.Controls.Add(this.lblValorCarta);
            this.grpJogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpJogo.Location = new System.Drawing.Point(12, 55);
            this.grpJogo.Name = "grpJogo";
            this.grpJogo.Size = new System.Drawing.Size(731, 581);
            this.grpJogo.TabIndex = 0;
            this.grpJogo.TabStop = false;
            this.grpJogo.Text = "Joguinho";
            // 
            // dgvJogadores
            // 
            this.dgvJogadores.AllowUserToAddRows = false;
            this.dgvJogadores.AllowUserToDeleteRows = false;
            this.dgvJogadores.AllowUserToResizeColumns = false;
            this.dgvJogadores.AllowUserToResizeRows = false;
            this.dgvJogadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJogadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJogadores.Enabled = false;
            this.dgvJogadores.Location = new System.Drawing.Point(828, 55);
            this.dgvJogadores.Name = "dgvJogadores";
            this.dgvJogadores.RowHeadersVisible = false;
            this.dgvJogadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJogadores.Size = new System.Drawing.Size(336, 253);
            this.dgvJogadores.TabIndex = 1;
            // 
            // btnIniciarPartida
            // 
            this.btnIniciarPartida.Location = new System.Drawing.Point(12, 12);
            this.btnIniciarPartida.Name = "btnIniciarPartida";
            this.btnIniciarPartida.Size = new System.Drawing.Size(119, 37);
            this.btnIniciarPartida.TabIndex = 2;
            this.btnIniciarPartida.Text = "Iniciar Partida";
            this.btnIniciarPartida.UseVisualStyleBackColor = true;
            this.btnIniciarPartida.Click += new System.EventHandler(this.btnIniciarPartida_Click);
            // 
            // lblStatusPartida
            // 
            this.lblStatusPartida.AutoSize = true;
            this.lblStatusPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusPartida.ForeColor = System.Drawing.Color.Red;
            this.lblStatusPartida.Location = new System.Drawing.Point(148, 25);
            this.lblStatusPartida.Name = "lblStatusPartida";
            this.lblStatusPartida.Size = new System.Drawing.Size(267, 24);
            this.lblStatusPartida.TabIndex = 3;
            this.lblStatusPartida.Text = "Aguardando o inicio da partida";
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersao.Location = new System.Drawing.Point(1056, 22);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(91, 16);
            this.lblVersao.TabIndex = 4;
            this.lblVersao.Text = "Luxemburgo - ";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(624, 12);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(119, 37);
            this.btnAtualizar.TabIndex = 5;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(932, 580);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(142, 53);
            this.btnEnviar.TabIndex = 6;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblValorCarta
            // 
            this.lblValorCarta.AutoSize = true;
            this.lblValorCarta.Location = new System.Drawing.Point(300, 301);
            this.lblValorCarta.Name = "lblValorCarta";
            this.lblValorCarta.Size = new System.Drawing.Size(13, 20);
            this.lblValorCarta.TabIndex = 0;
            this.lblValorCarta.Text = " ";
            this.lblValorCarta.Click += new System.EventHandler(this.lblValorCarta_Click);
            // 
            // lblValorAposta
            // 
            this.lblValorAposta.AutoSize = true;
            this.lblValorAposta.Location = new System.Drawing.Point(300, 343);
            this.lblValorAposta.Name = "lblValorAposta";
            this.lblValorAposta.Size = new System.Drawing.Size(0, 20);
            this.lblValorAposta.TabIndex = 1;
            // 
            // frmPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 645);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.lblStatusPartida);
            this.Controls.Add(this.btnIniciarPartida);
            this.Controls.Add(this.dgvJogadores);
            this.Controls.Add(this.grpJogo);
            this.Name = "frmPartida";
            this.Text = "Magic Trick (Luxemburgo) - Partida";
            this.grpJogo.ResumeLayout(false);
            this.grpJogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpJogo;
        private System.Windows.Forms.DataGridView dgvJogadores;
        private System.Windows.Forms.Button btnIniciarPartida;
        private System.Windows.Forms.Label lblStatusPartida;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblValorAposta;
        private System.Windows.Forms.Label lblValorCarta;
    }
}
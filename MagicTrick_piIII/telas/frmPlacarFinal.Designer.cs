namespace MagicTrick_piIII.telas
{
    partial class frmPlacarFinal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlacarFinal));
            this.lblFimDeJogo = new System.Windows.Forms.Label();
            this.lblPontuacao = new System.Windows.Forms.Label();
            this.dgvJogadores = new System.Windows.Forms.DataGridView();
            this.btnFecharPartida = new System.Windows.Forms.Button();
            this.lblVitoria = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogadores)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFimDeJogo
            // 
            this.lblFimDeJogo.AutoSize = true;
            this.lblFimDeJogo.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFimDeJogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.lblFimDeJogo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblFimDeJogo.Location = new System.Drawing.Point(222, 10);
            this.lblFimDeJogo.Name = "lblFimDeJogo";
            this.lblFimDeJogo.Size = new System.Drawing.Size(186, 36);
            this.lblFimDeJogo.TabIndex = 0;
            this.lblFimDeJogo.Text = "Fim de jogo!";
            this.lblFimDeJogo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPontuacao
            // 
            this.lblPontuacao.AutoSize = true;
            this.lblPontuacao.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPontuacao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.lblPontuacao.Location = new System.Drawing.Point(358, 89);
            this.lblPontuacao.Name = "lblPontuacao";
            this.lblPontuacao.Size = new System.Drawing.Size(0, 26);
            this.lblPontuacao.TabIndex = 2;
            // 
            // dgvJogadores
            // 
            this.dgvJogadores.AllowUserToAddRows = false;
            this.dgvJogadores.AllowUserToDeleteRows = false;
            this.dgvJogadores.AllowUserToResizeColumns = false;
            this.dgvJogadores.AllowUserToResizeRows = false;
            this.dgvJogadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvJogadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJogadores.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJogadores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvJogadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvJogadores.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvJogadores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvJogadores.Enabled = false;
            this.dgvJogadores.Location = new System.Drawing.Point(50, 133);
            this.dgvJogadores.MultiSelect = false;
            this.dgvJogadores.Name = "dgvJogadores";
            this.dgvJogadores.ReadOnly = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(70)))), ((int)(((byte)(84)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvJogadores.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvJogadores.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvJogadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJogadores.Size = new System.Drawing.Size(275, 243);
            this.dgvJogadores.TabIndex = 3;
            // 
            // btnFecharPartida
            // 
            this.btnFecharPartida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(24)))));
            this.btnFecharPartida.FlatAppearance.BorderSize = 0;
            this.btnFecharPartida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharPartida.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecharPartida.ForeColor = System.Drawing.Color.White;
            this.btnFecharPartida.Location = new System.Drawing.Point(380, 313);
            this.btnFecharPartida.Name = "btnFecharPartida";
            this.btnFecharPartida.Size = new System.Drawing.Size(217, 63);
            this.btnFecharPartida.TabIndex = 4;
            this.btnFecharPartida.Text = "voltar para o lobby";
            this.btnFecharPartida.UseVisualStyleBackColor = false;
            this.btnFecharPartida.Click += new System.EventHandler(this.btnFecharPartida_Click);
            // 
            // lblVitoria
            // 
            this.lblVitoria.AutoSize = true;
            this.lblVitoria.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVitoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.lblVitoria.Location = new System.Drawing.Point(172, 58);
            this.lblVitoria.Name = "lblVitoria";
            this.lblVitoria.Size = new System.Drawing.Size(0, 31);
            this.lblVitoria.TabIndex = 1;
            // 
            // frmPlacarFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.Controls.Add(this.btnFecharPartida);
            this.Controls.Add(this.dgvJogadores);
            this.Controls.Add(this.lblPontuacao);
            this.Controls.Add(this.lblVitoria);
            this.Controls.Add(this.lblFimDeJogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPlacarFinal";
            this.Text = "Fim de jogo!";
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFimDeJogo;
        private System.Windows.Forms.Label lblPontuacao;
        private System.Windows.Forms.DataGridView dgvJogadores;
        private System.Windows.Forms.Button btnFecharPartida;
        private System.Windows.Forms.Label lblVitoria;
    }
}
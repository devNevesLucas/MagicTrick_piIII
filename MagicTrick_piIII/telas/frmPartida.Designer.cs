namespace MagicTrick_piIII.telas
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogadores)).BeginInit();
            this.SuspendLayout();
            // 
            // grpJogo
            // 
            this.grpJogo.Location = new System.Drawing.Point(12, 55);
            this.grpJogo.Name = "grpJogo";
            this.grpJogo.Size = new System.Drawing.Size(814, 581);
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
            this.dgvJogadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJogadores.Location = new System.Drawing.Point(887, 55);
            this.dgvJogadores.Name = "dgvJogadores";
            this.dgvJogadores.Size = new System.Drawing.Size(277, 581);
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
            // frmPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 645);
            this.Controls.Add(this.lblStatusPartida);
            this.Controls.Add(this.btnIniciarPartida);
            this.Controls.Add(this.dgvJogadores);
            this.Controls.Add(this.grpJogo);
            this.Name = "frmPartida";
            this.Text = "frmPartida";
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpJogo;
        private System.Windows.Forms.DataGridView dgvJogadores;
        private System.Windows.Forms.Button btnIniciarPartida;
        private System.Windows.Forms.Label lblStatusPartida;
    }
}
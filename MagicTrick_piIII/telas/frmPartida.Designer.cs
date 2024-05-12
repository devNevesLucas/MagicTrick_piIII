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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartida));
            this.grpJogo = new System.Windows.Forms.GroupBox();
            this.btnIniciarPartida = new System.Windows.Forms.Button();
            this.lblStatusPartida = new System.Windows.Forms.Label();
            this.lblVersao = new System.Windows.Forms.Label();
            this.tmrAtualizarEstado = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // grpJogo
            // 
            this.grpJogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            this.grpJogo.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpJogo.ForeColor = System.Drawing.Color.White;
            this.grpJogo.Location = new System.Drawing.Point(12, 55);
            this.grpJogo.Name = "grpJogo";
            this.grpJogo.Size = new System.Drawing.Size(1152, 581);
            this.grpJogo.TabIndex = 0;
            this.grpJogo.TabStop = false;
            this.grpJogo.Text = "Joguinho";
            // 
            // btnIniciarPartida
            // 
            this.btnIniciarPartida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(24)))));
            this.btnIniciarPartida.FlatAppearance.BorderSize = 0;
            this.btnIniciarPartida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarPartida.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarPartida.ForeColor = System.Drawing.Color.White;
            this.btnIniciarPartida.Location = new System.Drawing.Point(12, 12);
            this.btnIniciarPartida.Name = "btnIniciarPartida";
            this.btnIniciarPartida.Size = new System.Drawing.Size(119, 37);
            this.btnIniciarPartida.TabIndex = 2;
            this.btnIniciarPartida.Text = "Iniciar Partida";
            this.btnIniciarPartida.UseVisualStyleBackColor = false;
            this.btnIniciarPartida.Click += new System.EventHandler(this.btnIniciarPartida_Click);
            // 
            // lblStatusPartida
            // 
            this.lblStatusPartida.AutoSize = true;
            this.lblStatusPartida.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusPartida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.lblStatusPartida.Location = new System.Drawing.Point(137, 19);
            this.lblStatusPartida.Name = "lblStatusPartida";
            this.lblStatusPartida.Size = new System.Drawing.Size(243, 19);
            this.lblStatusPartida.TabIndex = 3;
            this.lblStatusPartida.Text = "Aguardando o inicio da partida";
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.lblVersao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersao.ForeColor = System.Drawing.Color.White;
            this.lblVersao.Location = new System.Drawing.Point(1056, 22);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(91, 16);
            this.lblVersao.TabIndex = 4;
            this.lblVersao.Text = "Luxemburgo - ";
            // 
            // tmrAtualizarEstado
            // 
            this.tmrAtualizarEstado.Enabled = true;
            this.tmrAtualizarEstado.Interval = 5000;
            this.tmrAtualizarEstado.Tick += new System.EventHandler(this.tmrAtualizarEstado_Tick);
            // 
            // frmPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1187, 645);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.lblStatusPartida);
            this.Controls.Add(this.btnIniciarPartida);
            this.Controls.Add(this.grpJogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPartida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magic Trick (Luxemburgo) - Partida";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpJogo;
        private System.Windows.Forms.Button btnIniciarPartida;
        private System.Windows.Forms.Label lblStatusPartida;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Timer tmrAtualizarEstado;
    }
}
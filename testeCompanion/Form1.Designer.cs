namespace testeCompanion
{
    partial class Form1
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
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblCompanion = new System.Windows.Forms.Label();
            this.txtCompanion = new System.Windows.Forms.TextBox();
            this.lblIPPort = new System.Windows.Forms.Label();
            this.txtHoras = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtMin = new System.Windows.Forms.Label();
            this.txtSec = new System.Windows.Forms.Label();
            this.lblTimeString = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(16, 118);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.Text = "ENVIAR";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblCompanion
            // 
            this.lblCompanion.AutoSize = true;
            this.lblCompanion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanion.Location = new System.Drawing.Point(12, 9);
            this.lblCompanion.Name = "lblCompanion";
            this.lblCompanion.Size = new System.Drawing.Size(133, 20);
            this.lblCompanion.TabIndex = 1;
            this.lblCompanion.Text = "Texto Companion";
            // 
            // txtCompanion
            // 
            this.txtCompanion.Location = new System.Drawing.Point(16, 79);
            this.txtCompanion.Name = "txtCompanion";
            this.txtCompanion.Size = new System.Drawing.Size(100, 20);
            this.txtCompanion.TabIndex = 2;
            // 
            // lblIPPort
            // 
            this.lblIPPort.AutoSize = true;
            this.lblIPPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPPort.Location = new System.Drawing.Point(346, 0);
            this.lblIPPort.Name = "lblIPPort";
            this.lblIPPort.Size = new System.Drawing.Size(82, 20);
            this.lblIPPort.TabIndex = 3;
            this.lblIPPort.Text = "IP PORTA";
            // 
            // txtHoras
            // 
            this.txtHoras.AutoSize = true;
            this.txtHoras.Location = new System.Drawing.Point(296, 123);
            this.txtHoras.Name = "txtHoras";
            this.txtHoras.Size = new System.Drawing.Size(23, 13);
            this.txtHoras.TabIndex = 4;
            this.txtHoras.Text = "HH";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(353, 187);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtMin
            // 
            this.txtMin.AutoSize = true;
            this.txtMin.Location = new System.Drawing.Point(366, 123);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(25, 13);
            this.txtMin.TabIndex = 8;
            this.txtMin.Text = "MM";
            // 
            // txtSec
            // 
            this.txtSec.AutoSize = true;
            this.txtSec.Location = new System.Drawing.Point(436, 123);
            this.txtSec.Name = "txtSec";
            this.txtSec.Size = new System.Drawing.Size(21, 13);
            this.txtSec.TabIndex = 9;
            this.txtSec.Text = "SS";
            // 
            // lblTimeString
            // 
            this.lblTimeString.AutoSize = true;
            this.lblTimeString.Location = new System.Drawing.Point(366, 60);
            this.lblTimeString.Name = "lblTimeString";
            this.lblTimeString.Size = new System.Drawing.Size(45, 13);
            this.lblTimeString.TabIndex = 10;
            this.lblTimeString.Text = "HORAS";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(25, 202);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 11;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblTimeString);
            this.Controls.Add(this.txtSec);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtHoras);
            this.Controls.Add(this.lblIPPort);
            this.Controls.Add(this.txtCompanion);
            this.Controls.Add(this.lblCompanion);
            this.Controls.Add(this.btnEnviar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblCompanion;
        private System.Windows.Forms.TextBox txtCompanion;
        private System.Windows.Forms.Label lblIPPort;
        private System.Windows.Forms.Label txtHoras;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label txtMin;
        private System.Windows.Forms.Label txtSec;
        private System.Windows.Forms.Label lblTimeString;
        private System.Windows.Forms.ListBox listBox1;
    }
}


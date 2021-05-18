namespace NDD.GeradorProva.WinApp.Funcionalidades.SerieModule
{
    partial class SerieCadastroDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.nudSerie = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudSerie)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Série";
            // 
            // nudSerie
            // 
            this.nudSerie.Location = new System.Drawing.Point(99, 51);
            this.nudSerie.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudSerie.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSerie.Name = "nudSerie";
            this.nudSerie.ReadOnly = true;
            this.nudSerie.Size = new System.Drawing.Size(109, 20);
            this.nudSerie.TabIndex = 1;
            this.nudSerie.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudSerie_KeyPress);
            // 
            // SerieCadastroDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 153);
            this.Controls.Add(this.nudSerie);
            this.Controls.Add(this.label1);
            this.Name = "SerieCadastroDialog";
            this.Text = "Cadastro de série";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.nudSerie, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudSerie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudSerie;
    }
}
namespace NDD.GeradorProva.WinApp.Funcionalidades.DisciplinaModule
{
    partial class DisciplinaCadastroDialog
    {
        #region Windows Form Designer generated code

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
                              /// <summary>
                              /// Required method for Designer support - do not modify
                              /// the contents of this method with the code editor.
                              /// </summary>
        private void InitializeComponent()
        #pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            this.lblNome = new System.Windows.Forms.Label();
            this.txtDisciplina = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(13, 36);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome:";
            // 
            // txtDisciplina
            // 
            this.txtDisciplina.Location = new System.Drawing.Point(75, 32);
            this.txtDisciplina.Name = "txtDisciplina";
            this.txtDisciplina.Size = new System.Drawing.Size(228, 20);
            this.txtDisciplina.TabIndex = 1;
            // 
            // DisciplinaCadastroDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(344, 103);
            this.Controls.Add(this.txtDisciplina);
            this.Controls.Add(this.lblNome);
            this.Name = "DisciplinaCadastroDialog";
            this.Text = "Cadastro Disciplina";
            this.Controls.SetChildIndex(this.lblNome, 0);
            this.Controls.SetChildIndex(this.txtDisciplina, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtDisciplina;
    }
}
namespace NDD.GeradorProva.WinApp.Funcionalidades.MateriaModule
{
    partial class MateriaCadastroDialog
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
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.cmbSerie = new System.Windows.Forms.ComboBox();
            this.lbDisciplina = new System.Windows.Forms.Label();
            this.lbSerie = new System.Windows.Forms.Label();
            this.lbNome = new System.Windows.Forms.Label();
            this.txtMateria = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisciplina.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Location = new System.Drawing.Point(92, 50);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(209, 21);
            this.cmbDisciplina.TabIndex = 5;
            this.cmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplina_SelectedIndexChanged);
            // 
            // cmbSerie
            // 
            this.cmbSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerie.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSerie.FormattingEnabled = true;
            this.cmbSerie.Location = new System.Drawing.Point(92, 77);
            this.cmbSerie.Name = "cmbSerie";
            this.cmbSerie.Size = new System.Drawing.Size(209, 21);
            this.cmbSerie.TabIndex = 6;
            // 
            // lbDisciplina
            // 
            this.lbDisciplina.AutoSize = true;
            this.lbDisciplina.Location = new System.Drawing.Point(21, 54);
            this.lbDisciplina.Name = "lbDisciplina";
            this.lbDisciplina.Size = new System.Drawing.Size(55, 13);
            this.lbDisciplina.TabIndex = 8;
            this.lbDisciplina.Text = "Disciplina:";
            // 
            // lbSerie
            // 
            this.lbSerie.AutoSize = true;
            this.lbSerie.Location = new System.Drawing.Point(21, 81);
            this.lbSerie.Name = "lbSerie";
            this.lbSerie.Size = new System.Drawing.Size(31, 13);
            this.lbSerie.TabIndex = 9;
            this.lbSerie.Text = "Série";
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(21, 28);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(35, 13);
            this.lbNome.TabIndex = 11;
            this.lbNome.Text = "Nome";
            // 
            // txtMateria
            // 
            this.txtMateria.Location = new System.Drawing.Point(92, 24);
            this.txtMateria.Name = "txtMateria";
            this.txtMateria.Size = new System.Drawing.Size(209, 20);
            this.txtMateria.TabIndex = 12;
            // 
            // MateriaCadastroDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 157);
            this.Controls.Add(this.txtMateria);
            this.Controls.Add(this.lbNome);
            this.Controls.Add(this.lbSerie);
            this.Controls.Add(this.lbDisciplina);
            this.Controls.Add(this.cmbSerie);
            this.Controls.Add(this.cmbDisciplina);
            this.Name = "MateriaCadastroDialog";
            this.Text = "Cadastro de matéria";
            this.Controls.SetChildIndex(this.cmbDisciplina, 0);
            this.Controls.SetChildIndex(this.cmbSerie, 0);
            this.Controls.SetChildIndex(this.lbDisciplina, 0);
            this.Controls.SetChildIndex(this.lbSerie, 0);
            this.Controls.SetChildIndex(this.lbNome, 0);
            this.Controls.SetChildIndex(this.txtMateria, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.ComboBox cmbSerie;
        private System.Windows.Forms.Label lbDisciplina;
        private System.Windows.Forms.Label lbSerie;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.TextBox txtMateria;
    }
}
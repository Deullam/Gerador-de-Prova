namespace NDD.GeradorProva.WinApp.Funcionalidades.TesteModule
{
    partial class TesteCadastroDialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.numQtdQuestoes = new System.Windows.Forms.NumericUpDown();
            this.ckbRecuperacao = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdQuestoes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Titulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nº de Questões";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Disciplina";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Matéria";
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisciplina.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Location = new System.Drawing.Point(108, 89);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(183, 21);
            this.cmbDisciplina.TabIndex = 3;
            this.cmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplina_SelectedIndexChanged);
            // 
            // cmbMateria
            // 
            this.cmbMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(108, 123);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(183, 21);
            this.cmbMateria.TabIndex = 4;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(108, 23);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(183, 20);
            this.txtTitulo.TabIndex = 1;
            // 
            // numQtdQuestoes
            // 
            this.numQtdQuestoes.Location = new System.Drawing.Point(108, 55);
            this.numQtdQuestoes.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numQtdQuestoes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQtdQuestoes.Name = "numQtdQuestoes";
            this.numQtdQuestoes.ReadOnly = true;
            this.numQtdQuestoes.Size = new System.Drawing.Size(50, 20);
            this.numQtdQuestoes.TabIndex = 2;
            this.numQtdQuestoes.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ckbRecuperacao
            // 
            this.ckbRecuperacao.AutoSize = true;
            this.ckbRecuperacao.Location = new System.Drawing.Point(194, 56);
            this.ckbRecuperacao.Name = "ckbRecuperacao";
            this.ckbRecuperacao.Size = new System.Drawing.Size(97, 17);
            this.ckbRecuperacao.TabIndex = 13;
            this.ckbRecuperacao.Text = "Recuperação?";
            this.ckbRecuperacao.UseVisualStyleBackColor = true;
            this.ckbRecuperacao.Visible = false;
            // 
            // TesteCadastroDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 191);
            this.Controls.Add(this.ckbRecuperacao);
            this.Controls.Add(this.numQtdQuestoes);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.cmbDisciplina);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TesteCadastroDialog";
            this.Text = "Cadastro de teste";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbDisciplina, 0);
            this.Controls.SetChildIndex(this.cmbMateria, 0);
            this.Controls.SetChildIndex(this.txtTitulo, 0);
            this.Controls.SetChildIndex(this.numQtdQuestoes, 0);
            this.Controls.SetChildIndex(this.ckbRecuperacao, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numQtdQuestoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.NumericUpDown numQtdQuestoes;
        private System.Windows.Forms.CheckBox ckbRecuperacao;
    }
}
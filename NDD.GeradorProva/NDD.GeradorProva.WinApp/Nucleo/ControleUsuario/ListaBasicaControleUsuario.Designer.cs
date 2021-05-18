namespace NDD.GeradorProva.WinApp.Nucleo.ControleUsuario
{
    partial class ListaBasicaControleUsuario<E>
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxEntidades = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxEntidades
            // 
            this.listBoxEntidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEntidades.FormattingEnabled = true;
            this.listBoxEntidades.Location = new System.Drawing.Point(0, 0);
            this.listBoxEntidades.Name = "listBoxEntidades";
            this.listBoxEntidades.Size = new System.Drawing.Size(521, 338);
            this.listBoxEntidades.TabIndex = 0;
            // 
            // ListaBasicaControleUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxEntidades);
            this.Name = "ListaBasicaControleUsuario";
            this.Size = new System.Drawing.Size(521, 338);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxEntidades;
    }
}

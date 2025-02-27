// FormFacture.Designer.cs - Code généré par le concepteur de formulaires
using System;
using System.Windows.Forms;

namespace MagasinReprographie
{
    partial class FormFacture
    {
        private TextBox nbrText;
        private TextBox totalText;
        private Button btnCalculer;
        private Label lblNombrePhotocopies;
        private Label lblTotalAPayer;
        
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.nbrText = new TextBox();
            this.totalText = new TextBox();
            this.btnCalculer = new Button();
            this.lblNombrePhotocopies = new Label();
            this.lblTotalAPayer = new Label();
            this.SuspendLayout();
            
            // lblNombrePhotocopies
            this.lblNombrePhotocopies.AutoSize = true;
            this.lblNombrePhotocopies.Location = new System.Drawing.Point(30, 30);
            this.lblNombrePhotocopies.Name = "lblNombrePhotocopies";
            this.lblNombrePhotocopies.Size = new System.Drawing.Size(150, 20);
            this.lblNombrePhotocopies.TabIndex = 0;
            this.lblNombrePhotocopies.Text = "Nombre de photocopies";
            
            // nbrText
            this.nbrText.Location = new System.Drawing.Point(200, 30);
            this.nbrText.Name = "nbrText";
            this.nbrText.Size = new System.Drawing.Size(150, 25);
            this.nbrText.TabIndex = 1;
            
            // lblTotalAPayer
            this.lblTotalAPayer.AutoSize = true;
            this.lblTotalAPayer.Location = new System.Drawing.Point(30, 80);
            this.lblTotalAPayer.Name = "lblTotalAPayer";
            this.lblTotalAPayer.Size = new System.Drawing.Size(150, 20);
            this.lblTotalAPayer.TabIndex = 2;
            this.lblTotalAPayer.Text = "Total à payer";
            
            // totalText
            this.totalText.Location = new System.Drawing.Point(200, 80);
            this.totalText.Name = "totalText";
            this.totalText.ReadOnly = true;
            this.totalText.Size = new System.Drawing.Size(150, 25);
            this.totalText.TabIndex = 3;
            
            // btnCalculer
            this.btnCalculer.Location = new System.Drawing.Point(150, 130);
            this.btnCalculer.Name = "btnCalculer";
            this.btnCalculer.Size = new System.Drawing.Size(100, 30);
            this.btnCalculer.TabIndex = 4;
            this.btnCalculer.Text = "Calculer";
            this.btnCalculer.UseVisualStyleBackColor = true;
            this.btnCalculer.Click += new System.EventHandler(this.btnCalculer_Click);
            
            // FormFacture
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 180);
            this.Controls.Add(this.btnCalculer);
            this.Controls.Add(this.totalText);
            this.Controls.Add(this.lblTotalAPayer);
            this.Controls.Add(this.nbrText);
            this.Controls.Add(this.lblNombrePhotocopies);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormFacture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facture";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
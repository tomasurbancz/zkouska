using System.ComponentModel;

namespace Cviceni.WFA.Form;

partial class PredmetForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        predmetBox = new System.Windows.Forms.TextBox();
        kodBox = new System.Windows.Forms.TextBox();
        rocnikBox = new System.Windows.Forms.TextBox();
        create = new System.Windows.Forms.Button();
        delete = new System.Windows.Forms.Button();
        hodinyBox = new System.Windows.Forms.TextBox();
        SuspendLayout();
        // 
        // predmetBox
        // 
        predmetBox.Location = new System.Drawing.Point(12, 38);
        predmetBox.Name = "predmetBox";
        predmetBox.PlaceholderText = "Předmět";
        predmetBox.Size = new System.Drawing.Size(360, 23);
        predmetBox.TabIndex = 0;
        // 
        // kodBox
        // 
        kodBox.Location = new System.Drawing.Point(12, 79);
        kodBox.Name = "kodBox";
        kodBox.PlaceholderText = "Kód";
        kodBox.Size = new System.Drawing.Size(360, 23);
        kodBox.TabIndex = 1;
        // 
        // rocnikBox
        // 
        rocnikBox.Location = new System.Drawing.Point(12, 119);
        rocnikBox.Name = "rocnikBox";
        rocnikBox.PlaceholderText = "Ročník";
        rocnikBox.Size = new System.Drawing.Size(360, 23);
        rocnikBox.TabIndex = 2;
        // 
        // create
        // 
        create.Location = new System.Drawing.Point(236, 299);
        create.Name = "create";
        create.Size = new System.Drawing.Size(136, 50);
        create.TabIndex = 3;
        create.Text = "Vytvořit";
        create.UseVisualStyleBackColor = true;
        create.Click += create_Click_1;
        // 
        // delete
        // 
        delete.Location = new System.Drawing.Point(94, 299);
        delete.Name = "delete";
        delete.Size = new System.Drawing.Size(136, 50);
        delete.TabIndex = 4;
        delete.Text = "Smazat";
        delete.UseVisualStyleBackColor = true;
        delete.Click += delete_Click;
        // 
        // hodinyBox
        // 
        hodinyBox.Location = new System.Drawing.Point(12, 158);
        hodinyBox.Name = "hodinyBox";
        hodinyBox.PlaceholderText = "Požadované hodiny týdně";
        hodinyBox.Size = new System.Drawing.Size(360, 23);
        hodinyBox.TabIndex = 5;
        // 
        // PredmetForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(384, 361);
        Controls.Add(hodinyBox);
        Controls.Add(delete);
        Controls.Add(create);
        Controls.Add(rocnikBox);
        Controls.Add(kodBox);
        Controls.Add(predmetBox);
        Text = "UserForm";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox hodinyBox;

    private System.Windows.Forms.Button delete;

    private System.Windows.Forms.Button create;

    private System.Windows.Forms.TextBox kodBox;
    private System.Windows.Forms.TextBox rocnikBox;

    private System.Windows.Forms.TextBox predmetBox;

    #endregion
}
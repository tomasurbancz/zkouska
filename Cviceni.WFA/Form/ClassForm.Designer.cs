using System.ComponentModel;

namespace Cviceni.WFA.Form;

partial class ClassForm
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
        rocnikBox = new System.Windows.Forms.TextBox();
        kodBox = new System.Windows.Forms.TextBox();
        kmenovaBox = new System.Windows.Forms.TextBox();
        create = new System.Windows.Forms.Button();
        kmenovaCheck = new System.Windows.Forms.CheckBox();
        delete = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // rocnikBox
        // 
        rocnikBox.Location = new System.Drawing.Point(12, 38);
        rocnikBox.Name = "rocnikBox";
        rocnikBox.PlaceholderText = "Ročník";
        rocnikBox.Size = new System.Drawing.Size(360, 23);
        rocnikBox.TabIndex = 0;
        // 
        // kodBox
        // 
        kodBox.Location = new System.Drawing.Point(12, 79);
        kodBox.Name = "kodBox";
        kodBox.PlaceholderText = "Kód";
        kodBox.Size = new System.Drawing.Size(360, 23);
        kodBox.TabIndex = 1;
        // 
        // kmenovaBox
        // 
        kmenovaBox.Location = new System.Drawing.Point(12, 138);
        kmenovaBox.Name = "kmenovaBox";
        kmenovaBox.PlaceholderText = "Číslo kmenové učebny";
        kmenovaBox.Size = new System.Drawing.Size(360, 23);
        kmenovaBox.TabIndex = 2;
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
        // kmenovaCheck
        // 
        kmenovaCheck.Location = new System.Drawing.Point(12, 108);
        kmenovaCheck.Name = "kmenovaCheck";
        kmenovaCheck.Size = new System.Drawing.Size(147, 24);
        kmenovaCheck.TabIndex = 4;
        kmenovaCheck.Text = "Kmenová učebna";
        kmenovaCheck.UseVisualStyleBackColor = true;
        kmenovaCheck.CheckedChanged += kmenovaCheck_CheckedChanged;
        // 
        // delete
        // 
        delete.Location = new System.Drawing.Point(94, 299);
        delete.Name = "delete";
        delete.Size = new System.Drawing.Size(136, 50);
        delete.TabIndex = 5;
        delete.Text = "Smazat";
        delete.UseVisualStyleBackColor = true;
        delete.Click += delete_Click;
        // 
        // ClassForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(384, 361);
        Controls.Add(delete);
        Controls.Add(kmenovaCheck);
        Controls.Add(create);
        Controls.Add(kmenovaBox);
        Controls.Add(kodBox);
        Controls.Add(rocnikBox);
        Text = "UserForm";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button delete;

    private System.Windows.Forms.CheckBox kmenovaCheck;

    private System.Windows.Forms.TextBox kmenovaBox;

    private System.Windows.Forms.Button create;

    private System.Windows.Forms.TextBox kodBox;

    private System.Windows.Forms.TextBox rocnikBox;

    #endregion
}
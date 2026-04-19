using System.ComponentModel;

namespace Cviceni.WFA.Form;

internal partial class StudentForm
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
        jmenoBox = new System.Windows.Forms.TextBox();
        vekBox = new System.Windows.Forms.TextBox();
        prospechBox = new System.Windows.Forms.TextBox();
        create = new System.Windows.Forms.Button();
        delete = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // jmenoBox
        // 
        jmenoBox.Location = new System.Drawing.Point(12, 38);
        jmenoBox.Name = "jmenoBox";
        jmenoBox.PlaceholderText = "Jméno";
        jmenoBox.Size = new System.Drawing.Size(360, 23);
        jmenoBox.TabIndex = 0;
        // 
        // vekBox
        // 
        vekBox.Location = new System.Drawing.Point(12, 79);
        vekBox.Name = "vekBox";
        vekBox.PlaceholderText = "Věk";
        vekBox.Size = new System.Drawing.Size(360, 23);
        vekBox.TabIndex = 1;
        // 
        // prospechBox
        // 
        prospechBox.Location = new System.Drawing.Point(12, 119);
        prospechBox.Name = "prospechBox";
        prospechBox.PlaceholderText = "Průměrný prospěch";
        prospechBox.Size = new System.Drawing.Size(360, 23);
        prospechBox.TabIndex = 2;
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
        // StudentForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(384, 361);
        Controls.Add(delete);
        Controls.Add(create);
        Controls.Add(prospechBox);
        Controls.Add(vekBox);
        Controls.Add(jmenoBox);
        Text = "UserForm";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button delete;

    private System.Windows.Forms.Button create;

    private System.Windows.Forms.TextBox vekBox;
    private System.Windows.Forms.TextBox prospechBox;

    private System.Windows.Forms.TextBox jmenoBox;

    #endregion
}
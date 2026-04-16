using System.ComponentModel;

namespace Cviceni.WFA.Form;

partial class Form
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
        Title = new System.Windows.Forms.Label();
        tabMain = new System.Windows.Forms.TabControl();
        tabStudent = new System.Windows.Forms.TabPage();
        tabClass = new System.Windows.Forms.TabPage();
        tabTeacher = new System.Windows.Forms.TabPage();
        tabSubject = new System.Windows.Forms.TabPage();
        tabMain.SuspendLayout();
        SuspendLayout();
        // 
        // Title
        // 
        Title.BackColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)30)), ((int)((byte)30)));
        Title.Font = new System.Drawing.Font("Segoe UI", 20F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)));
        Title.ForeColor = System.Drawing.Color.White;
        Title.Location = new System.Drawing.Point(2, 0);
        Title.Name = "Title";
        Title.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
        Title.Size = new System.Drawing.Size(1016, 55);
        Title.TabIndex = 0;
        Title.Text = "Skola";
        // 
        // tabMain
        // 
        tabMain.Controls.Add(tabStudent);
        tabMain.Controls.Add(tabClass);
        tabMain.Controls.Add(tabTeacher);
        tabMain.Controls.Add(tabSubject);
        tabMain.Location = new System.Drawing.Point(2, 58);
        tabMain.Name = "tabMain";
        tabMain.SelectedIndex = 0;
        tabMain.Size = new System.Drawing.Size(1016, 520);
        tabMain.TabIndex = 1;
        // 
        // tabStudent
        // 
        tabStudent.Location = new System.Drawing.Point(4, 34);
        tabStudent.Name = "tabStudent";
        tabStudent.Padding = new System.Windows.Forms.Padding(3);
        tabStudent.Size = new System.Drawing.Size(1008, 482);
        tabStudent.TabIndex = 0;
        tabStudent.Text = "Student";
        tabStudent.UseVisualStyleBackColor = true;
        // 
        // tabClass
        // 
        tabClass.Location = new System.Drawing.Point(4, 34);
        tabClass.Name = "tabClass";
        tabClass.Padding = new System.Windows.Forms.Padding(3);
        tabClass.Size = new System.Drawing.Size(1008, 482);
        tabClass.TabIndex = 1;
        tabClass.Text = "Class";
        tabClass.UseVisualStyleBackColor = true;
        // 
        // tabTeacher
        // 
        tabTeacher.Location = new System.Drawing.Point(4, 34);
        tabTeacher.Name = "tabTeacher";
        tabTeacher.Padding = new System.Windows.Forms.Padding(3);
        tabTeacher.Size = new System.Drawing.Size(1008, 482);
        tabTeacher.TabIndex = 2;
        tabTeacher.Text = "Teacher";
        tabTeacher.UseVisualStyleBackColor = true;
        // 
        // tabSubject
        // 
        tabSubject.Location = new System.Drawing.Point(4, 34);
        tabSubject.Name = "tabSubject";
        tabSubject.Padding = new System.Windows.Forms.Padding(3);
        tabSubject.Size = new System.Drawing.Size(1008, 482);
        tabSubject.TabIndex = 3;
        tabSubject.Text = "Subject";
        tabSubject.UseVisualStyleBackColor = true;
        // 
        // Form
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1018, 574);
        Controls.Add(tabMain);
        Controls.Add(Title);
        Text = "Form";
        tabMain.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.TabPage tabSubject;

    private System.Windows.Forms.TabPage tabTeacher;

    private System.Windows.Forms.TabControl tabMain;
    private System.Windows.Forms.TabPage tabStudent;
    private System.Windows.Forms.TabPage tabClass;

    private System.Windows.Forms.Label Title;

    #endregion
}
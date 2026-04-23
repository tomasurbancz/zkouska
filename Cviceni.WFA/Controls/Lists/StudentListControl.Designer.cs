using System.ComponentModel;

namespace Cviceni.WFA.Controls.Lists;

partial class StudentListControl
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

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        add = new System.Windows.Forms.Button();
        refresh = new System.Windows.Forms.Button();
        autoRefresh = new System.Windows.Forms.CheckBox();
        nextRefresh = new System.Windows.Forms.Label();
        listView1 = new System.Windows.Forms.ListView();
        List = new System.Windows.Forms.ColumnHeader();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // add
        // 
        add.Location = new System.Drawing.Point(20, 29);
        add.Name = "add";
        add.Size = new System.Drawing.Size(75, 37);
        add.TabIndex = 0;
        add.Text = "New";
        add.UseVisualStyleBackColor = true;
        add.Click += add_Click_1;
        // 
        // refresh
        // 
        refresh.Location = new System.Drawing.Point(101, 29);
        refresh.Name = "refresh";
        refresh.Size = new System.Drawing.Size(101, 37);
        refresh.TabIndex = 1;
        refresh.Text = "Refresh";
        refresh.UseVisualStyleBackColor = true;
        refresh.Click += refresh_Click;
        // 
        // autoRefresh
        // 
        autoRefresh.Location = new System.Drawing.Point(208, 36);
        autoRefresh.Name = "autoRefresh";
        autoRefresh.Size = new System.Drawing.Size(149, 24);
        autoRefresh.TabIndex = 2;
        autoRefresh.Text = "Auto Refresh";
        autoRefresh.UseVisualStyleBackColor = true;
        autoRefresh.CheckedChanged += autoRefresh_CheckedChanged;
        // 
        // nextRefresh
        // 
        nextRefresh.ForeColor = System.Drawing.SystemColors.ButtonShadow;
        nextRefresh.Location = new System.Drawing.Point(299, 40);
        nextRefresh.Name = "nextRefresh";
        nextRefresh.Size = new System.Drawing.Size(221, 23);
        nextRefresh.TabIndex = 3;
        nextRefresh.Text = "Next refresh in {TIME}s";
        // 
        // listView1
        // 
        listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { List });
        listView1.Location = new System.Drawing.Point(20, 99);
        listView1.Name = "listView1";
        listView1.Size = new System.Drawing.Size(290, 321);
        listView1.TabIndex = 4;
        listView1.UseCompatibleStateImageBehavior = false;
        listView1.View = System.Windows.Forms.View.Details;
        listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
        // 
        //  List
        // 
        List.Name = " List";
        List.Text = "List";
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(20, 438);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(24, 23);
        label1.TabIndex = 5;
        label1.Text = "<-";
        label1.Click += label1_Click;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(73, 438);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(24, 23);
        label2.TabIndex = 6;
        label2.Text = "->";
        label2.Click += label2_Click;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(39, 438);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(36, 23);
        label3.TabIndex = 7;
        label3.Text = "10/10";
        // 
        // StudentListControl
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(listView1);
        Controls.Add(nextRefresh);
        Controls.Add(autoRefresh);
        Controls.Add(refresh);
        Controls.Add(add);
        Margin = new System.Windows.Forms.Padding(2);
        Size = new System.Drawing.Size(1000, 500);
        Load += StudentListControl_Load;
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.ColumnHeader List;

    private System.Windows.Forms.ListView listView1;

    private System.Windows.Forms.Label nextRefresh;

    private System.Windows.Forms.CheckBox autoRefresh;

    private System.Windows.Forms.Button refresh;

    private System.Windows.Forms.Button add;

    #endregion
}
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
        dataGridView1 = new System.Windows.Forms.DataGridView();
        Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Jmeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Vek = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Prospech = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
        // 
        // refresh
        // 
        refresh.Location = new System.Drawing.Point(101, 29);
        refresh.Name = "refresh";
        refresh.Size = new System.Drawing.Size(101, 37);
        refresh.TabIndex = 1;
        refresh.Text = "Refresh";
        refresh.UseVisualStyleBackColor = true;
        // 
        // autoRefresh
        // 
        autoRefresh.Location = new System.Drawing.Point(208, 36);
        autoRefresh.Name = "autoRefresh";
        autoRefresh.Size = new System.Drawing.Size(149, 24);
        autoRefresh.TabIndex = 2;
        autoRefresh.Text = "Auto Refresh";
        autoRefresh.UseVisualStyleBackColor = true;
        // 
        // nextRefresh
        // 
        nextRefresh.ForeColor = System.Drawing.SystemColors.ButtonShadow;
        nextRefresh.Location = new System.Drawing.Point(341, 37);
        nextRefresh.Name = "nextRefresh";
        nextRefresh.Size = new System.Drawing.Size(221, 23);
        nextRefresh.TabIndex = 3;
        nextRefresh.Text = "Next refresh in {TIME}s";
        // 
        // dataGridView1
        // 
        dataGridView1.BackgroundColor = System.Drawing.Color.White;
        dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Jmeno, Vek, Prospech });
        dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridView1.Location = new System.Drawing.Point(0, 0);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 62;
        dataGridView1.Size = new System.Drawing.Size(553, 324);
        dataGridView1.TabIndex = 4;
        dataGridView1.Text = "dataGridView1";
        // 
        // Name
        // 
        Name.HeaderText = "Name";
        Name.MinimumWidth = 8;
        Name.Name = "Name";
        Name.Width = 150;
        // 
        // Jmeno
        // 
        Jmeno.HeaderText = "Jmeno";
        Jmeno.MinimumWidth = 8;
        Jmeno.Name = "Jmeno";
        Jmeno.Width = 150;
        // 
        // Vek
        // 
        Vek.HeaderText = "Vek";
        Vek.MinimumWidth = 8;
        Vek.Name = "Vek";
        Vek.Width = 150;
        // 
        // Prospech
        // 
        Prospech.HeaderText = "Prumerny prospech";
        Prospech.MinimumWidth = 8;
        Prospech.Name = "Prospech";
        Prospech.Width = 150;
        // 
        // StudentListControl
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(dataGridView1);
        Controls.Add(nextRefresh);
        Controls.Add(autoRefresh);
        Controls.Add(refresh);
        Controls.Add(add);
        Size = new System.Drawing.Size(553, 324);
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.DataGridViewTextBoxColumn Jmeno;
    private System.Windows.Forms.DataGridViewTextBoxColumn Vek;
    private System.Windows.Forms.DataGridViewTextBoxColumn Prospech;

    private System.Windows.Forms.DataGridViewTextBoxColumn Name;

    private System.Windows.Forms.DataGridView dataGridView1;

    private System.Windows.Forms.Label nextRefresh;

    private System.Windows.Forms.CheckBox autoRefresh;

    private System.Windows.Forms.Button refresh;

    private System.Windows.Forms.Button add;

    #endregion
}
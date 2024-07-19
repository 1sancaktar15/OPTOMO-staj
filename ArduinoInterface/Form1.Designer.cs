using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace StepMotorControl;

partial class Form1
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
    private Button btnConnect;
    private Button btnDisconnect;
    private Button btnSolaDon;
    private Button btnSagaDon;
    private TextBox txtAdim;

    private void InitializeComponent()
    {
        this.btnConnect = new System.Windows.Forms.Button();
        this.btnDisconnect = new System.Windows.Forms.Button();
        this.btnSolaDon = new System.Windows.Forms.Button();
        this.btnSagaDon = new System.Windows.Forms.Button();
        this.txtAdim = new System.Windows.Forms.TextBox();
        
        // 
        // btnConnect
        // 
        this.btnConnect.Location = new System.Drawing.Point(12, 12);
        this.btnConnect.Name = "btnConnect";
        this.btnConnect.Size = new System.Drawing.Size(100, 23);
        this.btnConnect.TabIndex = 0;
        this.btnConnect.Text = "Connect";
        this.btnConnect.UseVisualStyleBackColor = true;
        this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
        
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 600);
        this.Text = "Step Motor Control";
        
        // Form ölçülerine göre orantılı boyutlar ve yerleşimler
        int buttonWidth = 120;
        int buttonHeight = 40;
        int spacing = 20;
        int textBoxWidth = 120;
        int textBoxHeight = 30;

        // Connect Button
        Button btnConnect = new Button();
        btnConnect.Text = "Connect";
        btnConnect.Size = new Size(buttonWidth, buttonHeight);
        btnConnect.Click += new System.EventHandler(this.btnConnect_Click);

        // Disconnect Button
        Button btnDisconnect = new Button();
        btnDisconnect.Text = "Disconnect";
        btnDisconnect.Size = new Size(buttonWidth,buttonHeight);
        btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);

        // Sola Dön Button
        Button btnSolaDon = new Button();
        btnSolaDon.Text = "Sola Dön";
        btnSolaDon.Size = new Size(buttonWidth, buttonHeight);
        btnSolaDon.Click += new System.EventHandler(this.btnSolaDon_Click);

        // Sağa Dön Button
        Button btnSagaDon = new Button();
        btnSagaDon.Text = "Sağa Dön";
        btnSagaDon.Size = new Size(buttonWidth, buttonHeight);
        btnSagaDon.Click += new System.EventHandler(this.btnSagaDon_Click);

        // Adım TextBox
        TextBox txtAdim = new TextBox();
        txtAdim.Size = new Size(textBoxWidth, textBoxHeight);

        // Adding controls to the form
        this.Controls.Add(btnConnect);
        this.Controls.Add(btnDisconnect);
        this.Controls.Add(btnSolaDon);
        this.Controls.Add(btnSagaDon);
        this.Controls.Add(txtAdim);
        
        int totalWidth = buttonWidth * 2 + spacing;
        int totalHeight = buttonHeight * 2 + textBoxHeight + spacing * 3;
        int startX = (this.ClientSize.Width - totalWidth) / 2;
        int startY = (this.ClientSize.Height - totalHeight) / 2;

        // Set positions
        btnConnect.Location = new Point(startX, startY);
        btnDisconnect.Location = new Point(startX + buttonWidth + spacing, startY);
        btnSolaDon.Location = new Point(startX, startY + buttonHeight + spacing);
        btnSagaDon.Location = new Point(startX + buttonWidth + spacing, startY + buttonHeight + spacing);
        txtAdim.Location = new Point((this.ClientSize.Width - textBoxWidth) / 2, startY + buttonHeight * 2 + spacing * 2);
        
    }


    #endregion
}
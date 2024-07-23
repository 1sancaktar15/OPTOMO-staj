using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace StepMotorControl
{
    partial class Form1
    {
        private NumericUpDown numericUpDownAdim;
        private Button btnConnect;
        private Button btnDisconnect;
        private Button btnSagaDon;
        private Button btnSolaDon;
        private Label lblSteps;
        private ComboBox comboBoxPorts;
        private Label lblSelectPort;

        private void InitializeComponent()
        {
            this.numericUpDownAdim = new NumericUpDown();
            this.btnConnect = new Button();
            this.btnDisconnect = new Button();
            this.btnSagaDon = new Button();
            this.btnSolaDon = new Button();
            this.lblSteps = new Label();
            this.comboBoxPorts = new ComboBox();
            this.lblSelectPort = new Label();
            ((ISupportInitialize)(this.numericUpDownAdim)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownAdim
            // 
            this.numericUpDownAdim.Name = "numericUpDownAdim";
            this.numericUpDownAdim.Location = new Point(105, 90);
            this.numericUpDownAdim.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numericUpDownAdim.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDownAdim.Size = new Size(180, 40);
            this.numericUpDownAdim.Font = new Font(this.numericUpDownAdim.Font.FontFamily, 18);
            this.numericUpDownAdim.TabIndex = 0;
            this.numericUpDownAdim.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDownAdim.Anchor = AnchorStyles.None;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new Point(30, 150);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new Size(150, 45);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new EventHandler(this.btnConnect_Click);
            this.btnConnect.Anchor = AnchorStyles.None;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new Point(190, 150);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new Size(150, 45);
            this.btnDisconnect.TabIndex = 2;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new EventHandler(this.btnDisconnect_Click);
            this.btnDisconnect.Anchor = AnchorStyles.None;
            // 
            // btnSagaDon
            // 
            this.btnSagaDon.Location = new Point(30, 210);
            this.btnSagaDon.Name = "btnSagaDon";
            this.btnSagaDon.Size = new Size(150, 45);
            this.btnSagaDon.TabIndex = 3;
            this.btnSagaDon.Text = "Turn Right";
            this.btnSagaDon.UseVisualStyleBackColor = true;
            this.btnSagaDon.Click += new EventHandler(this.btnSagaDon_Click);
            this.btnSagaDon.Anchor = AnchorStyles.None;
            // 
            // btnSolaDon
            // 
            this.btnSolaDon.Location = new Point(190, 210);
            this.btnSolaDon.Name = "btnSolaDon";
            this.btnSolaDon.Size = new Size(150, 45);
            this.btnSolaDon.TabIndex = 4;
            this.btnSolaDon.Text = "Turn Left";
            this.btnSolaDon.UseVisualStyleBackColor = true;
            this.btnSolaDon.Click += new EventHandler(this.btnSolaDon_Click);
            this.btnSolaDon.Anchor = AnchorStyles.None;
            // 
            // lblSteps
            // 
            this.lblSteps.AutoSize = true;
            this.lblSteps.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lblSteps.Location = new Point(75, 60);
            this.lblSteps.Name = "lblSteps";
            this.lblSteps.Size = new Size(240, 27);
            this.lblSteps.TabIndex = 5;
            this.lblSteps.Text = "Enter number of steps:";
            this.lblSteps.TextAlign = ContentAlignment.MiddleCenter;
            this.lblSteps.Anchor = AnchorStyles.None;
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new Point(105, 30);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new Size(180, 21);
            this.comboBoxPorts.TabIndex = 6;
            this.comboBoxPorts.Anchor = AnchorStyles.None;
            // 
            // lblSelectPort
            // 
            this.lblSelectPort.AutoSize = true;
            this.lblSelectPort.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectPort.Location = new Point(115, 10);
            this.lblSelectPort.Name = "lblSelectPort";
            this.lblSelectPort.Size = new Size(160, 18);
            this.lblSelectPort.TabIndex = 7;
            this.lblSelectPort.Text = "Select Serial Port:";
            this.lblSelectPort.TextAlign = ContentAlignment.MiddleCenter;
            this.lblSelectPort.Anchor = AnchorStyles.None;
            // 
            // Form1
            // 
            this.ClientSize = new Size(390, 270);
            this.Controls.Add(this.lblSelectPort);
            this.Controls.Add(this.comboBoxPorts);
            this.Controls.Add(this.lblSteps);
            this.Controls.Add(this.btnSolaDon);
            this.Controls.Add(this.btnSagaDon);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.numericUpDownAdim);
            this.Name = "Form1";
            this.Text = "Step Motor Control";
            this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
            ((ISupportInitialize)(this.numericUpDownAdim)).EndInit();
        }
    }
}

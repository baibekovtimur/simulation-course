namespace RandomGames
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl tabControl;
        private TabPage tabYesNo;
        private TabPage tabMagic;
        private Button btnYesNo;
        private Label lblYesNoAnswer;
        private Button btnMagic;
        private Label lblMagicAnswer;
        private Label lblSeed;
        private TextBox txtSeed;
        private Button btnResetSeed;
        private Label lblYesProb;
        private NumericUpDown nudYesProbability;
        private TableLayoutPanel magicTableLayout;
        private Button btnNormalize;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabYesNo = new System.Windows.Forms.TabPage();
            this.lblYesProb = new System.Windows.Forms.Label();
            this.nudYesProbability = new System.Windows.Forms.NumericUpDown();
            this.lblYesNoAnswer = new System.Windows.Forms.Label();
            this.btnYesNo = new System.Windows.Forms.Button();
            this.tabMagic = new System.Windows.Forms.TabPage();
            this.btnNormalize = new System.Windows.Forms.Button();
            this.magicTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblMagicAnswer = new System.Windows.Forms.Label();
            this.btnMagic = new System.Windows.Forms.Button();
            this.lblSeed = new System.Windows.Forms.Label();
            this.txtSeed = new System.Windows.Forms.TextBox();
            this.btnResetSeed = new System.Windows.Forms.Button();

            this.tabControl.SuspendLayout();
            this.tabYesNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYesProbability)).BeginInit();
            this.tabMagic.SuspendLayout();
            this.SuspendLayout();

            // tabControl
            this.tabControl.Controls.Add(this.tabYesNo);
            this.tabControl.Controls.Add(this.tabMagic);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Size = new System.Drawing.Size(900, 600);
            this.tabControl.TabIndex = 0;

            // tabYesNo
            this.tabYesNo.Controls.Add(this.lblYesProb);
            this.tabYesNo.Controls.Add(this.nudYesProbability);
            this.tabYesNo.Controls.Add(this.lblYesNoAnswer);
            this.tabYesNo.Controls.Add(this.btnYesNo);
            this.tabYesNo.Location = new System.Drawing.Point(4, 24);
            this.tabYesNo.Name = "tabYesNo";
            this.tabYesNo.Size = new System.Drawing.Size(892, 572);
            this.tabYesNo.TabIndex = 0;
            this.tabYesNo.Text = "Скажи “да” или “нет”";
            this.tabYesNo.UseVisualStyleBackColor = true;

            // lblYesProb
            this.lblYesProb.AutoSize = true;
            this.lblYesProb.Location = new System.Drawing.Point(250, 350);
            this.lblYesProb.Name = "lblYesProb";
            this.lblYesProb.Size = new System.Drawing.Size(113, 15);
            this.lblYesProb.TabIndex = 3;
            this.lblYesProb.Text = "Вероятность «Да»:";

            // nudYesProbability
            this.nudYesProbability.DecimalPlaces = 3;
            this.nudYesProbability.Increment = 0.05m;
            this.nudYesProbability.Location = new System.Drawing.Point(369, 348);
            this.nudYesProbability.Maximum = 1m;
            this.nudYesProbability.Name = "nudYesProbability";
            this.nudYesProbability.Size = new System.Drawing.Size(70, 23);
            this.nudYesProbability.TabIndex = 2;
            this.nudYesProbability.Value = 0.5m;

            // lblYesNoAnswer
            this.lblYesNoAnswer.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblYesNoAnswer.Location = new System.Drawing.Point(50, 80);
            this.lblYesNoAnswer.Size = new System.Drawing.Size(792, 80);
            this.lblYesNoAnswer.TabIndex = 1;
            this.lblYesNoAnswer.Text = "?";
            this.lblYesNoAnswer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnYesNo
            this.btnYesNo.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnYesNo.Location = new System.Drawing.Point(358, 250);
            this.btnYesNo.Size = new System.Drawing.Size(176, 50);
            this.btnYesNo.TabIndex = 0;
            this.btnYesNo.Text = "Спросить";
            this.btnYesNo.UseVisualStyleBackColor = true;
            this.btnYesNo.Click += new System.EventHandler(this.BtnYesNo_Click);

            // tabMagic
            this.tabMagic.Controls.Add(this.btnNormalize);
            this.tabMagic.Controls.Add(this.magicTableLayout);
            this.tabMagic.Controls.Add(this.lblMagicAnswer);
            this.tabMagic.Controls.Add(this.btnMagic);
            this.tabMagic.Location = new System.Drawing.Point(4, 24);
            this.tabMagic.Name = "tabMagic";
            this.tabMagic.Size = new System.Drawing.Size(892, 572);
            this.tabMagic.TabIndex = 1;
            this.tabMagic.Text = "Шар предсказаний";
            this.tabMagic.UseVisualStyleBackColor = true;

            // btnNormalize
            this.btnNormalize.Location = new System.Drawing.Point(360, 510);
            this.btnNormalize.Name = "btnNormalize";
            this.btnNormalize.Size = new System.Drawing.Size(120, 30);
            this.btnNormalize.TabIndex = 5;
            this.btnNormalize.Text = "Нормализовать";
            this.btnNormalize.UseVisualStyleBackColor = true;
            this.btnNormalize.Click += new System.EventHandler(this.BtnNormalize_Click);

            // magicTableLayout
            this.magicTableLayout.AutoScroll = true;
            this.magicTableLayout.ColumnCount = 4;
            this.magicTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.magicTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.magicTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.magicTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.magicTableLayout.Location = new System.Drawing.Point(20, 20);
            this.magicTableLayout.Name = "magicTableLayout";
            this.magicTableLayout.RowCount = 5;
            this.magicTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.magicTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.magicTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.magicTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.magicTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.magicTableLayout.Size = new System.Drawing.Size(852, 400);
            this.magicTableLayout.TabIndex = 4;

            // lblMagicAnswer
            this.lblMagicAnswer.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblMagicAnswer.Location = new System.Drawing.Point(20, 440);
            this.lblMagicAnswer.Size = new System.Drawing.Size(852, 40);
            this.lblMagicAnswer.TabIndex = 1;
            this.lblMagicAnswer.Text = "?";
            this.lblMagicAnswer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnMagic
            this.btnMagic.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnMagic.Location = new System.Drawing.Point(360, 550);
            this.btnMagic.Size = new System.Drawing.Size(176, 50);
            this.btnMagic.TabIndex = 0;
            this.btnMagic.Text = "Спросить";
            this.btnMagic.UseVisualStyleBackColor = true;
            this.btnMagic.Click += new System.EventHandler(this.BtnMagic_Click);

            // lblSeed
            this.lblSeed.AutoSize = true;
            this.lblSeed.Location = new System.Drawing.Point(12, 610);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(38, 15);
            this.lblSeed.TabIndex = 1;
            this.lblSeed.Text = "Seed:";

            // txtSeed
            this.txtSeed.Location = new System.Drawing.Point(56, 607);
            this.txtSeed.Name = "txtSeed";
            this.txtSeed.Size = new System.Drawing.Size(140, 23);
            this.txtSeed.TabIndex = 2;

            // btnResetSeed
            this.btnResetSeed.Location = new System.Drawing.Point(202, 607);
            this.btnResetSeed.Name = "btnResetSeed";
            this.btnResetSeed.Size = new System.Drawing.Size(100, 23);
            this.btnResetSeed.TabIndex = 3;
            this.btnResetSeed.Text = "Сменить seed";
            this.btnResetSeed.UseVisualStyleBackColor = true;
            this.btnResetSeed.Click += new System.EventHandler(this.BtnResetSeed_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.btnResetSeed);
            this.Controls.Add(this.txtSeed);
            this.Controls.Add(this.lblSeed);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Случайные предсказания с настройкой вероятностей";
            this.tabControl.ResumeLayout(false);
            this.tabYesNo.ResumeLayout(false);
            this.tabYesNo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYesProbability)).EndInit();
            this.tabMagic.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
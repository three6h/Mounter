namespace Mounter
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.listBox = new System.Windows.Forms.ListBox();
            this.listBoxContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listBoxContextCopyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox = new System.Windows.Forms.TextBox();
            this.textBoxContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBoxContextSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.browseBtn = new System.Windows.Forms.Button();
            this.majorBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.versionLb = new System.Windows.Forms.Label();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.textBoxContextSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxContextCut = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxContextCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxContextPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxContext.SuspendLayout();
            this.textBoxContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.ContextMenuStrip = this.listBoxContext;
            this.listBox.Font = new System.Drawing.Font("Leelawadee UI", 9.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(7, 7);
            this.listBox.Margin = new System.Windows.Forms.Padding(0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(415, 244);
            this.listBox.Sorted = true;
            this.listBox.TabIndex = 0;
            this.listBox.TabStop = false;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // listBoxContext
            // 
            this.listBoxContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listBoxContextCopyPath});
            this.listBoxContext.Name = "listBoxContext";
            this.listBoxContext.Size = new System.Drawing.Size(130, 26);
            this.listBoxContext.Opening += new System.ComponentModel.CancelEventHandler(this.ListBoxContext_Opening);
            // 
            // listBoxContextCopyPath
            // 
            this.listBoxContextCopyPath.Image = global::Mounter.Properties.Resources.Copy;
            this.listBoxContextCopyPath.Name = "listBoxContextCopyPath";
            this.listBoxContextCopyPath.Size = new System.Drawing.Size(129, 22);
            this.listBoxContextCopyPath.Text = "Copy Path";
            this.listBoxContextCopyPath.Click += new System.EventHandler(this.ListBoxContextCopyPath_Click);
            // 
            // textBox
            // 
            this.textBox.ContextMenuStrip = this.textBoxContext;
            this.textBox.Font = new System.Drawing.Font("Leelawadee UI", 8.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox.HideSelection = false;
            this.textBox.Location = new System.Drawing.Point(8, 257);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(337, 22);
            this.textBox.TabIndex = 1;
            // 
            // textBoxContext
            // 
            this.textBoxContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textBoxContextSelectAll,
            this.textBoxContextSeparator,
            this.textBoxContextCut,
            this.textBoxContextCopy,
            this.textBoxContextPaste});
            this.textBoxContext.Name = "textBoxContext";
            this.textBoxContext.Size = new System.Drawing.Size(195, 98);
            this.textBoxContext.Opening += new System.ComponentModel.CancelEventHandler(this.TextBoxContext_Opening);
            // 
            // textBoxContextSeparator
            // 
            this.textBoxContextSeparator.Name = "textBoxContextSeparator";
            this.textBoxContextSeparator.Size = new System.Drawing.Size(191, 6);
            // 
            // browseBtn
            // 
            this.browseBtn.Font = new System.Drawing.Font("Leelawadee UI", 8.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.browseBtn.Location = new System.Drawing.Point(350, 256);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(72, 24);
            this.browseBtn.TabIndex = 2;
            this.browseBtn.TabStop = false;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // majorBtn
            // 
            this.majorBtn.Font = new System.Drawing.Font("Leelawadee UI", 8.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.majorBtn.Location = new System.Drawing.Point(6, 284);
            this.majorBtn.Name = "majorBtn";
            this.majorBtn.Size = new System.Drawing.Size(95, 26);
            this.majorBtn.TabIndex = 3;
            this.majorBtn.TabStop = false;
            this.majorBtn.Text = "Mount";
            this.majorBtn.UseVisualStyleBackColor = true;
            this.majorBtn.Click += new System.EventHandler(this.MajorBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Leelawadee UI", 8.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitBtn.Location = new System.Drawing.Point(328, 284);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(95, 26);
            this.exitBtn.TabIndex = 4;
            this.exitBtn.TabStop = false;
            this.exitBtn.Text = "Quit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // versionLb
            // 
            this.versionLb.AutoSize = true;
            this.versionLb.Font = new System.Drawing.Font("Tahoma", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.versionLb.ForeColor = System.Drawing.SystemColors.GrayText;
            this.versionLb.Location = new System.Drawing.Point(180, 290);
            this.versionLb.Name = "versionLb";
            this.versionLb.Size = new System.Drawing.Size(54, 16);
            this.versionLb.TabIndex = 5;
            this.versionLb.Text = "v0.8.2.4";
            // 
            // folderDialog
            // 
            this.folderDialog.Description = "Select the directory to mount. Also, to mount, you must specify a free drive from" +
    " the list.";
            this.folderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderDialog.ShowNewFolderButton = false;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // textBoxContextSelectAll
            // 
            this.textBoxContextSelectAll.Enabled = false;
            this.textBoxContextSelectAll.Image = global::Mounter.Properties.Resources.SelectAll;
            this.textBoxContextSelectAll.Name = "textBoxContextSelectAll";
            this.textBoxContextSelectAll.Size = new System.Drawing.Size(194, 22);
            this.textBoxContextSelectAll.Text = "Select All          Ctrl + A";
            this.textBoxContextSelectAll.Click += new System.EventHandler(this.TextBoxContextSelectAll_Click);
            // 
            // textBoxContextCut
            // 
            this.textBoxContextCut.Image = global::Mounter.Properties.Resources.Cut;
            this.textBoxContextCut.Name = "textBoxContextCut";
            this.textBoxContextCut.Size = new System.Drawing.Size(194, 22);
            this.textBoxContextCut.Text = "Cut                    Ctrl + X";
            this.textBoxContextCut.Click += new System.EventHandler(this.TextBoxContextCut_Click);
            // 
            // textBoxContextCopy
            // 
            this.textBoxContextCopy.Image = global::Mounter.Properties.Resources.Copy;
            this.textBoxContextCopy.Name = "textBoxContextCopy";
            this.textBoxContextCopy.Size = new System.Drawing.Size(194, 22);
            this.textBoxContextCopy.Text = "Copy                 Ctrl + C";
            this.textBoxContextCopy.Click += new System.EventHandler(this.TextBoxContextCopy_Click);
            // 
            // textBoxContextPaste
            // 
            this.textBoxContextPaste.Image = global::Mounter.Properties.Resources.Paste;
            this.textBoxContextPaste.Name = "textBoxContextPaste";
            this.textBoxContextPaste.Size = new System.Drawing.Size(194, 22);
            this.textBoxContextPaste.Text = "Paste                 Ctrl + V";
            this.textBoxContextPaste.Click += new System.EventHandler(this.TextBoxContextPaste_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 315);
            this.Controls.Add(this.versionLb);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.majorBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.listBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "Mounter NE";
            this.Load += new System.EventHandler(this.Form_Load);
            this.listBoxContext.ResumeLayout(false);
            this.textBoxContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Button majorBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Label versionLb;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.ContextMenuStrip textBoxContext;
        private System.Windows.Forms.ToolStripMenuItem textBoxContextSelectAll;
        private System.Windows.Forms.ToolStripSeparator textBoxContextSeparator;
        private System.Windows.Forms.ToolStripMenuItem textBoxContextCut;
        private System.Windows.Forms.ToolStripMenuItem textBoxContextCopy;
        private System.Windows.Forms.ToolStripMenuItem textBoxContextPaste;
        private System.Windows.Forms.ContextMenuStrip listBoxContext;
        private System.Windows.Forms.ToolStripMenuItem listBoxContextCopyPath;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}


using AduLib;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Mounter
{
    public partial class Form : System.Windows.Forms.Form
    {

        public Form()
        {
            InitializeComponent();
            timer.Start();
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
                textBox.Text = folderDialog.SelectedPath;

            textBox.Focus();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Application.Exit();
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
                if (listBox.SelectedItem.ToString().Length > 3)
                    majorBtn.Text = "Unmount"; // Selected " D: C:\Windows" item.

                else
                    majorBtn.Text = "Mount"; // Selected " D:" item.

            else
                majorBtn.Text = "Mount"; // Selected " D:" item.
        }

        private void TextBoxContextSelectAll_Click(object sender, EventArgs e)
        {
            textBox.SelectAll();
        }

        private void TextBoxContextCut_Click(object sender, EventArgs e)
        {
            textBox.Cut();
        }

        private void TextBoxContextCopy_Click(object sender, EventArgs e)
        {
            textBox.Copy();
        }

        private void TextBoxContextPaste_Click(object sender, EventArgs e)
        {
            textBox.Paste();
        }

        private void TextBoxContext_Opening(object sender, CancelEventArgs e)
        {
            if (!textBox.Focused)
            {
                textBoxContextSelectAll.Enabled = false;
                textBoxContextCopy.Enabled = false;
                textBoxContextCut.Enabled = false;
            }
            else
            {
                textBoxContextSelectAll.Enabled = true;
                textBoxContextCopy.Enabled = true;
                textBoxContextCut.Enabled = true;
            }
        }

        private void ListBoxContextCopyPath_Click(object sender, EventArgs e)
        {
            // Error Checking is done in "ListBoxContextMenu_Opening".
            Clipboard.SetText(listBox.SelectedItem.ToString().Substring(4));
        }

        private void ListBoxContext_Opening(object sender, CancelEventArgs e)
        {
            if (listBox.SelectedIndex != -1 && listBox.SelectedItem.ToString().Length == 3)
                // Cancel if an unmounted item is selected.
                e.Cancel = true;
        }

        private void Mount(char drive = ' ', string path = null)
        {
            if (drive == ' ' && path == null)
            {
                if (listBox.SelectedIndex == -1)
                    MessageBox.Show(
                        "Select a free drive to mount and try again.",
                        "No Drive Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                else if (textBox.Text.Length == 0)
                    MessageBox.Show(
                        "Specify the directory path by selecting the directory in" +
                        " the dialog box or enter the path manually.",
                        "Directory Path Not Specified",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                else
                    try { Function.Mount(listBox.SelectedItem.ToString()[1], textBox.Text); }

                    catch (DirectoryNotFoundException)
                    {
                        MessageBox.Show(
                            "Verify the directory path is correct and try again.",
                            "Invalid Directory Path",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    catch (DriveNotFoundException)
                    {
                        MessageBox.Show(
                            "Unmount the directory under this drive or select another free drive and try again.",
                            "Drive is Already in Use",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    catch (UnhandledErrorException e)
                    {
                        MessageBox.Show(
                            $"{ e.InnerException.Message }",
                            "Unhandled Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                textBox.Focus();
            }
            else
            {
                try { Function.Mount(drive, path); }

                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show(
                        "Verify the directory path is correct and try again.",
                        "Invalid Directory Path",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (DriveNotFoundException)
                {
                    MessageBox.Show(
                        "Unmount the directory under this drive or select another free drive and try again.",
                        "Drive is Already in Use",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (UnhandledErrorException e)
                {
                    MessageBox.Show(
                        $"{ e.InnerException.Message }",
                        "Unhandled Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void Unmount(char drive = ' ')
        {
            if (drive == ' ')
            {
                // There is no check if the user has selected the line suitable for the unmount, 
                // since the <Unmount> button can only be pressed when the user has already done this.
                try { Function.Unmount(listBox.SelectedItem.ToString()[1]); }

                catch (DriveNotFoundException) { }

                catch (UnhandledErrorException e)
                {
                    MessageBox.Show(
                        $"{ e.InnerException.Message }",
                        "Unhandled Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                textBox.Focus();
            }
            else
            {
                // There is no check if the user has selected the line suitable for the unmount, 
                // since the <Unmount> button can only be pressed when the user has already done this.
                try { Function.Unmount(listBox.SelectedItem.ToString()[1]); }

                catch (DriveNotFoundException) { }

                catch (UnhandledErrorException e)
                {
                    MessageBox.Show(
                        $"{ e.InnerException.Message }",
                        "Unhandled Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void MajorBtn_Click(object sender, EventArgs e)
        {
            if (majorBtn.Text == "Mount")
                Mount();

            else
                Unmount();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var items = listBox.Items;
            var status = Function.GetDrivesStatus();

            if (items.Count > status.Count)
            {
                foreach (string item in items)
                    if (!status.ContainsKey(item[1]))
                    {
                        listBox.Items.Remove(item);
                        break;
                    }
            }
            else
            {
                foreach (var state in status)
                    if (state.Value.Length != 0)
                    {
                        var add = $" { state.Key }: { state.Value }";
                        if (!items.Contains(add))
                            listBox.Items.Add(add);

                        listBox.Items.Remove($" { state.Key }:");
                    }
                    else
                    {
                        var add = $" { state.Key }:";
                        if (!items.Contains(add))
                            listBox.Items.Add(add);

                        foreach (string item1 in items)
                            if (item1[1] == state.Key && item1.Length > 3)
                            {
                                listBox.Items.Remove(item1);
                                break;
                            }
                    }
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (!Function.IsWorks())
            {
                MessageBox.Show(
                    "The Subst is not supported by this system.",
                    "Fatal Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitap_buoi5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbfont.Text = "Tahoma";
            cmbsize.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                cmbfont.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                cmbsize.Items.Add(s);
            }
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Clear();
            cmbfont.SelectedItem = "Tahoma";
            cmbsize.SelectedItem = 14;
            richText.Font = new Font("Tahoma", 14);
        }

        private void mởToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName.EndsWith(".rtf"))
                {
                    richText.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richText.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
                }
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richText.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                MessageBox.Show("File đã được lưu thành công!", "Thông báo");
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richText.ForeColor = fontDlg.Color;
                richText.Font = fontDlg.Font;
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            string selectedFont = cmbfont.SelectedItem.ToString();
            float currentSize = richText.SelectionFont.Size;
            richText.SelectionFont = new Font(selectedFont, currentSize);
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            richText.Clear();
            cmbfont.SelectedItem = "Tahoma";
            cmbsize.SelectedItem = 14;
            richText.Font = new Font("Tahoma", 14);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richText.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                MessageBox.Show("File đã được lưu thành công!", "Thông báo");
            }
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            Font currentFont = richText.SelectionFont;
            FontStyle newFontStyle = currentFont.Style ^ FontStyle.Bold;
            richText.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
        }

      

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            Font currentFont = richText.SelectionFont;
            FontStyle newFontStyle = currentFont.Style ^ FontStyle.Underline;
            richText.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
        }

        private void cmbsize_Click(object sender, EventArgs e)
        {
            float selectedSize = float.Parse(cmbsize.SelectedItem.ToString());
            string currentFont = richText.SelectionFont.FontFamily.Name;
            richText.SelectionFont = new Font(currentFont, selectedSize);
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            Font currentFont = richText.SelectionFont;
            FontStyle newFontStyle = currentFont.Style ^ FontStyle.Italic;
            richText.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
        }
    }
}
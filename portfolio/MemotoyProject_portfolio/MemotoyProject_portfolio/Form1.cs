﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemotoyProject_portfolio
{
    public partial class Form1 : Form
    {
        private string fileName = "noname.txt";
        bool modifyFlag = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void txtMemo_TextChanged(object sender, EventArgs e)
        {
            modifyFlag = true;
        }

        // 새로 만들기
        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 작업중 파일 처리
            FileProcessBeforeClose();

            txtMemo.Text = "";
            modifyFlag = false;
            fileName = "noname.txt";
        }

        // 수정중인 파일을 닫기 전에 어떻게 처리할 지(저장 or 그냥 닫기)
        private void FileProcessBeforeClose()
        {
            if (modifyFlag == true)
            {
                DialogResult ans = MessageBox.Show("변경된 내용을 저장하시겠습니까?",
                    "저장", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {
                    if (fileName == "noname.txt") // 파일 이름을 지정하지 않았다면
                    {
                        if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter sw = File.CreateText(saveFileDialog1.FileName);
                            sw.WriteLine(txtMemo.Text);
                            sw.Close();
                        }
                    }
                    else // 파일 이름이 지정되어 있으면..
                    {
                        StreamWriter sw = File.CreateText(fileName);
                        sw.WriteLine(txtMemo.Text);
                        sw.Close();
                    }
                }
            }
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 현재 열려있는 파일이 수정되었다면 저장 해야 함
            FileProcessBeforeClose();

            // 열려있던 파일에 대한 저장 처리가 끝남
            // 새로운 파일을 열 수 있도록 다이얼로그 띄움
            openFileDialog1.ShowDialog();
            fileName = openFileDialog1 .FileName;

            try
            {
                StreamReader r = File.OpenText(fileName);
                txtMemo.Text = r.ReadToEnd();

                modifyFlag = false;
                r.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == "noname.txt")
            {
                saveFileDialog1 .ShowDialog();
                fileName = saveFileDialog1.FileName;
            }
            StreamWriter sw = File.CreateText(fileName);
            sw.WriteLine(txtMemo.Text);

            modifyFlag = false;
            sw.Close();
        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 작업 중 파일처리
            FileProcessBeforeClose();
            Close();
        }

        private void 복사하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox contents = (RichTextBox)ActiveControl;
            if (contents != null)
            {
                Clipboard.SetDataObject(contents.SelectedText);
                MessageBox.Show(contents.SelectedText);
            }
        }

        private void 붙여넣기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox contents = (RichTextBox)ActiveControl;
            if ( contents != null)
            {
                IDataObject data = Clipboard.GetDataObject();
                contents.SelectedText = data.GetData(DataFormats.Text).ToString();
                modifyFlag = true;
            }
        }
    }

}

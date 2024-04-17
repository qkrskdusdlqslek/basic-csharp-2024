namespace ex19_asyncs
{
    public partial class FrmMain : Form
    {
        #region "������, �ʱ�ȭ ����"
        public FrmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region "�̺�Ʈ�ڵ鷯 ����"

        // �̺�Ʈ�ڵ鷯. ������ �������� ����
        private void BtnGetSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK )
            {
                TxtSource.Text = dlg.FileName;
            }
        }

        // �̺�Ʈ�ڵ鷯. �ٿ��ֱ��� Ÿ������ ����
        private void BtnSetTarget_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TxtTarget.Text = dlg.FileName;
            }
        }

        // �̺�Ʈ�ڵ鷯. ����ȭ���� ����
        private void BtnSyncCopy_Click(object sender, EventArgs e)
        {
            long result = CopySync(TxtSource.Text, TxtTarget.Text);
        }

        // �̺�Ʈ�ڵ鷯. �񵿱�ȭ���� ����
        // void�� ���ϰ��� �����Ƿ� Task<void> ����. �׳� void..
        private async void BtnAsyncCopy_Click(object sender, EventArgs e)
        {
            long result = await CopyAsync(TxtSource.Text, TxtTarget.Text);
        }

        // ��ưŬ�� �̺�Ʈ�ڵ鷯. ������� ó��
        private void BtnCancle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UI���� �׽�Ʈ �Ϸ�!");
        }
        #endregion

        #region "����ڸ޼ҵ� ����"

        long CopySync(string srcPath, string destPath)
        {
            // ��ư ��� ��Ȱ��ȭ
            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = false;
            long totalCopied = 0;

            // File�� Open()�ϸ� �ݵ�� Close() �ؾ� ��. using()�� ���� Close() C#�� �˾Ƽ� ����
            // ���������
            using (FileStream fromStream = new FileStream(srcPath, FileMode.Open))
            {   // ���� �����ϴ� ������ ���ϱ� FileMode.Open
                using (FileStream toStream = new FileStream(destPath, FileMode.Create))
                {   // �������� �ʴ� ������ ����ϱ� FileMode.Create
                    // 1MByte ���۸� ����
                    byte[] buffer = new byte[1024 * 1024]; // 1024(byte) = 1kbyte, 1024 * 1024 = 1Mbyte
                    // fromStream�� ���� ������ 1MB�� �߶� ���ۿ� ���� ����
                    // toStream�� 1MB�� �ٿ�����
                    int nRead = 0;
                    while ((nRead = fromStream.Read(buffer, 0, buffer.Length)) != 0) 
                    { 
                        toStream.Write(buffer, 0, nRead);
                        totalCopied += nRead; // ��ü ���� ����� ��� ����

                        // ���α׷����ٿ� ��������� ǥ��
                        PrgCopy.Value = (int)((double)(totalCopied / fromStream.Length) * 100);
                    }  
                }
            }

            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = true;
            return totalCopied; // ������ ���ϻ����� ����
        }

        // �񵿱�ó���� async, await Ű���尡 ���� �߿�
        // async ���� �񵿱�޼ҵ�߶�� ����.
        // await �񵿱�޼ҵ尡 ���������� ��ٸ��Զ�� ����
        // �񵿱⸦ ó���ϴ� �޼ҵ�� ...Async()�� ����
        // async�� �޼ҵ� ���ϰ��� �ۼ�. ���ϰ��� Task<���ϰ�>
        async Task<long> CopyAsync(string srcPath, string destPath)
        {
            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = false;
            long totalCopied = 0;

            using (FileStream fromStream = new FileStream(srcPath, FileMode.Open))
            {   
                using (FileStream toStream = new FileStream(destPath, FileMode.Create))
                {   
                    byte[] buffer = new byte[1024 * 1024]; // �׽�Ʈ �� 10���� ����
                    int nRead = 0;
                    while ((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        await toStream.WriteAsync(buffer, 0, nRead);
                        totalCopied += nRead; 

                        PrgCopy.Value = (int)((double)(totalCopied / fromStream.Length) * 100);
                    }
                }
            }

            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = true;
            return totalCopied; 
        }

        #endregion
    }
}

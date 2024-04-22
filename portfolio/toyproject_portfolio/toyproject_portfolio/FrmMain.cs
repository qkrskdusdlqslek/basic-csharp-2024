namespace toyproject_portfolio
{
    public partial class FrmMain : Form
    {
        private DateTime parking1_in;
        private DateTime parking1_out;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            timerMain.Start();
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            lblNowTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        // �԰� �̺�Ʈ
        private void BtnIn_Click(object sender, EventArgs e)
        {
            parking1_in = DateTime.Now;
            lblin1.Text = parking1_in.ToString("HH:mm");
        }

        // ��� �̺�Ʈ
        private void BtnOut_Click(object sender, EventArgs e)
        {
            parking1_out = DateTime.Now.AddMinutes(41);
            lblOut1.Text = parking1_out.ToString("HH:mm");

            // (�����ð�/�����ð�) * �����ݾ�
            TimeSpan ts = parking1_out - parking1_in;
            string parkingFee = CalcSum(ts);
            lblParkingFee.Text = parkingFee;
            CalcSum(ts);

            // ���� �ݾ��� �ٸ� ���� ����ϰų� Ȱ���� �� ����
            // MessageBox.Show("�����ݾ���" + parkingFee + "���Դϴ�.")
        }
        private string CalcSum(TimeSpan ts)
        {
            decimal unitPrice = 100;
            int carNumberPrice = Convert.ToInt32(TxtCarNumber.Text);

            // ���� �ݾ� ���
            decimal parkingFee = Math.Ceiling((decimal)ts.TotalMinutes / unitPrice) * carNumberPrice;

            return parkingFee.ToString(); // ���� ���� �ݾ��� ���ڿ��� ��ȯ
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {

        }
    }
}

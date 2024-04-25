namespace toyproject_portfolio
{
    public partial class FrmMain : Form
    {
        private DateTime parking1_in;
        private DateTime parking1_out;
        private TimeSpan parkingDuration;

        public FrmMain()
        {
            InitializeComponent();

            // ���� ���� �ð��� ���� �ð����� �ʱ�ȭ
            parking1_in = DateTime.Now;
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

            // ���� �ð� ��� �� Ŭ������ ��� ������ ����
            TimeSpan ts = parking1_out - parking1_in;
            // ���� ��� ���
            double parkingFee = CalcSum(parkingDuration);

            // ���� �ݾ��� �ٸ� ���� ����ϰų� Ȱ��
            MessageBox.Show("���������" + parkingFee.ToString("C") + "�Դϴ�.");
        }

        private double CalcSum(TimeSpan ts)
        {
            // ���� �ð� ���
            TimeSpan parkingDuration = parking1_out - parking1_in;

            // 1�ð� �� ��� (1000��)
            int feePerHour = 1000;

            // ���� ��� ���
            double totalFee = parkingDuration.TotalHours * feePerHour;

            return totalFee;
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            double foundParkingFee = CalcSum(parkingDuration);

            // ã�� ������� Ȱ��
            MessageBox.Show("���� �� �ݾ���" + foundParkingFee.ToString("C") + "�Դϴ�.");

            lblParkingFee.Text = foundParkingFee.ToString("0");
        }
    }
}
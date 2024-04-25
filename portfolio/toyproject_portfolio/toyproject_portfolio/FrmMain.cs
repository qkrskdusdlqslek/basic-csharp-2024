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

            // 주차 시작 시간을 현재 시간으로 초기화
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

        // 입고 이벤트
        private void BtnIn_Click(object sender, EventArgs e)
        {
            parking1_in = DateTime.Now;
            lblin1.Text = parking1_in.ToString("HH:mm");
        }

        // 출고 이벤트
        private void BtnOut_Click(object sender, EventArgs e)
        {
            parking1_out = DateTime.Now.AddMinutes(41);
            lblOut1.Text = parking1_out.ToString("HH:mm");

            // 주차 시간 계산 및 클래스의 멤버 변수에 저장
            TimeSpan ts = parking1_out - parking1_in;
            // 주차 요금 계산
            double parkingFee = CalcSum(parkingDuration);

            // 주차 금액을 다른 곳에 출력하거나 활용
            MessageBox.Show("주차요금은" + parkingFee.ToString("C") + "입니다.");
        }

        private double CalcSum(TimeSpan ts)
        {
            // 주차 시간 계산
            TimeSpan parkingDuration = parking1_out - parking1_in;

            // 1시간 당 요금 (1000원)
            int feePerHour = 1000;

            // 주차 요금 계산
            double totalFee = parkingDuration.TotalHours * feePerHour;

            return totalFee;
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            double foundParkingFee = CalcSum(parkingDuration);

            // 찾은 주차요금 활용
            MessageBox.Show("정산 할 금액은" + foundParkingFee.ToString("C") + "입니다.");

            lblParkingFee.Text = foundParkingFee.ToString("0");
        }
    }
}
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

            // (주차시간/단위시간) * 단위금액
            TimeSpan ts = parking1_out - parking1_in;
            string parkingFee = CalcSum(ts);
            lblParkingFee.Text = parkingFee;
            CalcSum(ts);

            // 주차 금액을 다른 곳에 출력하거나 활용할 수 있음
            // MessageBox.Show("주차금액은" + parkingFee + "원입니다.")
        }
        private string CalcSum(TimeSpan ts)
        {
            decimal unitPrice = 100;
            int carNumberPrice = Convert.ToInt32(TxtCarNumber.Text);

            // 주차 금액 계산
            decimal parkingFee = Math.Ceiling((decimal)ts.TotalMinutes / unitPrice) * carNumberPrice;

            return parkingFee.ToString(); // 계산된 주차 금액을 문자열로 변환
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {

        }
    }
}

namespace toyproject_portfolio
{
    public partial class FrmMain : Form
    {
        private DateTime parking1_in;
        private DateTime parking1_out;
        //private double CalcParkingFee;



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

            // 주차 요금 계산 및 표시
           // CalcParkingFee();


            // 주차 금액을 다른 곳에 출력하거나 활용할 수 있음
            // MessageBox.Show("주차금액은" + parkingFee + "원입니다.")
        }
        string CalcParkingFee()
        {
                // 주차 시간 계산
                TimeSpan parkingDuration = parking1_out - parking1_in;

                // 1시간 당 요금 (1000원)
                int feePerHour = 1000;

                // 주차 요금 계산
                double totalFee = (parkingDuration.TotalHours * feePerHour);

                // 주차 요금을 문자열로 변환하여 라벨에 표시
                lblParkingFee.Text = totalFee.ToString("co");
                //decimal unitPrice = 100;
                //int carNumberPrice = Convert.ToInt32(TxtCarNumber.Text);

                // 주차 금액 계산
                //decimal parkingFee = Math.Ceiling((decimal)ts.TotalMinutes / unitPrice) * carNumberPrice;

                //return parkingFee.ToString(); // 계산된 주차 금액을 문자열로 변환
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {

        }
    }
}

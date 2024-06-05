namespace TaskCancellationFormApp
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                Task<HttpResponseMessage> myTask;

                myTask = new HttpClient().GetAsync("https://localhost:7046/api/Home", cancellationTokenSource.Token);

                await myTask;

                var content = await myTask.Result.Content.ReadAsStringAsync();

                richTextBox1.Text = content;
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDurdur_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
        }
    }
}

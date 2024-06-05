namespace ParallelForEachFormApp
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cancellationTokenSource;

        public int Counter { get; set; } = 1;
        public Form1()
        {
            InitializeComponent();
            cancellationTokenSource = new CancellationTokenSource();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();
            List<string> urls = new List<string>()
            {
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
            };

            HttpClient client = new HttpClient();

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cancellationTokenSource.Token;

            Task.Run(() =>
            {
                try
                {
                    Parallel.ForEach<string>(urls, parallelOptions, (url) =>
                    {
                        string content = client.GetStringAsync(url).Result;

                        string data = $"Site: {url} Boyut: {content.Length}";

#if !DEBUG
                        cancellationTokenSource.Token.ThrowIfCancellationRequested();//debug da çalýþtýrýrsan patlar  

                        //parallelOptions.CancellationToken.ThrowIfCancellationRequested();// cancellation tokena eriþemediðimiz zaman paralel option üzerinden token'a ulaþbiliriz
#endif
                        listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add(data); });
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ýþlem iptal edildi: {ex.Message}");
                }

            });



        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
        }

        private void btnArttir_Click(object sender, EventArgs e)
        {
            btnArttir.Text = Counter++.ToString();
        }
    }
}

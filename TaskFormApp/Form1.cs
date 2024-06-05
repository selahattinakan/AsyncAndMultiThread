namespace TaskFormApp
{
    public partial class Form1 : Form
    {
        public int counter { get; set; } = 1;
        public int counter2 { get; set; } = 1;

        public Form1()
        {
            InitializeComponent();
        }

        #region Örnek 1 Async Await
        private async void btnReadFile_Click(object sender, EventArgs e)
        {
            //string data = ReadFile();

            string data = string.Empty;

            Task<string> okumaTask = ReadFileAsync();

            //Task<string> okumaTask = ReadFileAsync2();

            richTextBox2.Text = await new HttpClient().GetStringAsync("https://www.google.com");

            data = await okumaTask;

            richTextBoxDosya.Text = data;
        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            textBoxCounter.Text = counter++.ToString();
        }

        private string ReadFile()
        {
            string data = string.Empty;
            using (StreamReader streamReader = new StreamReader("dosya.txt"))
            {
                Thread.Sleep(5000);
                data = streamReader.ReadToEnd();
            }

            return data;
        }

        private async Task<string> ReadFileAsync()
        {
            string data = string.Empty;
            using (StreamReader streamReader = new StreamReader("dosya.txt"))
            {
                Task<string> task = streamReader.ReadToEndAsync();

                await Task.Delay(5000);

                data = await task;
            }

            return data;
        }

        private Task<string> ReadFileAsync2()
        {
            StreamReader streamReader = new StreamReader("dosya.txt");
            Task<string> task = streamReader.ReadToEndAsync();
            return task;

        }
        #endregion

        #region Örnek 2 Task.Run
        private async void btnStart_Click(object sender, EventArgs e)
        {
            var task1 = Go(progressBar1);
            var task2 = Go(progressBar2);

            await Task.WhenAll(task1, task2);
        }

        private void btnCounter2_Click(object sender, EventArgs e)
        {
            btnCounter2.Text = $"Sayaç : {counter2++}";
        }

        public async Task Go(ProgressBar progressBar)
        {
            //Task.Run ile yeni bir thread'de çalýþýyor
            await Task.Run(() =>
            {
                Enumerable.Range(1, 100).ToList().ForEach(x =>
                {
                    Thread.Sleep(100);

                    progressBar.Invoke((MethodInvoker)delegate { progressBar.Value = x; });
                });
            });

        }
        #endregion
    }
}

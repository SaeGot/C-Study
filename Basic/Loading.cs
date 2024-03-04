public partial class Form1 : Form
{
    private bool _isLoading = false;
    System.Diagnostics.Process _delayRunner = new System.Diagnostics.Process();

    public Form1()
    {
        InitializeComponent();
        RunApp();
    }

    private async void RunApp()
    {
        _isLoading = true;
        ShowLoading();
        Task task = Task.Run(new Action(LoadExternalApp));
        await Task.WhenAll(task);
        _isLoading = false;
    }

    private async void ShowLoading()
    {
        while (true)
        {
            for (int n = 0; n < 3; n++)
            {
                if (_isLoading == false)
                    break;
                lbLoading.Text += ".";
                await Task.Delay(1000);
            }
            if (_isLoading == false)
                break;
            lbLoading.Text = "Loading";
            await Task.Delay(1000);
        }
    }

    private void LoadExternalApp()
    {
        // 경로 알맞게 수정
        string external_ProgramPath = @"D:\DelayRunner.exe";
        _delayRunner = System.Diagnostics.Process.Start(external_ProgramPath);
        while (_delayRunner.WaitForInputIdle() == false)
        {
        }
    }

    private void ThisFormClosed(object sender, FormClosedEventArgs e)
    {
        _delayRunner.Kill();
    }
}
namespace TodoApp.TorneSeUmProgramador.App
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicou uma {count} vez";
            else
                CounterBtn.Text = $"Clicou {count} vezes";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}

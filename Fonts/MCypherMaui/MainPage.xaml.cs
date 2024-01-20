using MCypherMaui.Model;

namespace MCypherMaui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new EncryptModel();
        }

        public void OnEncryptClicked(object sender, EventArgs e)
        {
            var model = (EncryptModel)BindingContext;
        }
    }
}

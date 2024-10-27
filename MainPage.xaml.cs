using Hangman.Libraries.Text;
using Hangman.Models;
using Hangman.Repositories;

namespace Hangman {
    public partial class MainPage : ContentPage {

        WordRepository repository = new WordRepository();
        private Word word = new Word();
        private int errors = 0;

        public MainPage() {
            InitializeComponent();

            StartGame();
        }

        private void StartGame() {

            errors = 0;
            word = repository.GetRandomWord();
            ChangeImageHang();

            ResetVirtualKeyboard();

            LbTip.Text = word.Tips;
            LbWord.Text = new string('_', word.Text.Length);

        }

        private void ResetVirtualKeyboard() {

            ResetVirtualLines((HorizontalStackLayout)SlElements.Children[0]);
            ResetVirtualLines((HorizontalStackLayout)SlElements.Children[1]);
            ResetVirtualLines((HorizontalStackLayout)SlElements.Children[2]);

        }

        private void ResetVirtualLines(HorizontalStackLayout layout) {

            foreach (Button button in layout.Children) {
                button.IsEnabled = true;
                button.Style = null;
            }

        }

        private void ChangeImageHang() {
            ImgHang.Source = ImageSource.FromFile($"forca{errors + 1}.png");
        }

        private void OnButtonClick(object sender, EventArgs e) {

            Button button = ((Button)sender);

            button.IsEnabled = false;
            string letter = button.Text;

            var positions = word.Text.AllIndexesOf(letter);

            if(!positions.Any()) {
                errors++;
                button.Style = App.Current.Resources.MergedDictionaries.ElementAt(1)["Fail"] as Style;

                ChangeImageHang();

                if (errors == 6) {
                    DisplayAlert("Game Over", "You lose!", "OK");
                    StartGame();
                }

                return;

            }

            button.Style = App.Current.Resources.MergedDictionaries.ElementAt(1)["Success"] as Style;

            foreach (int position in positions) {
                LbWord.Text = LbWord.Text.Remove(position, 1).Insert(position, letter);
            }

            if (!LbWord.Text.Contains('_')) {
                DisplayAlert("Winner", "You won!", "OK");
                StartGame();
            }

        }

    }

}

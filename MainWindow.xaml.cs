using System.Windows;

namespace bingo
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        BingoLogic bingologic = new BingoLogic();
        public MainWindow()
        {
            InitializeComponent();
         }

        //イベントハンドラ
        //ボタンをクリックするとディスプレイに番号を表示する
        private void buttonClick(object sender, RoutedEventArgs e)
        {
            if (bingologic.bingocount == bingologic.MAX_NUM)
            {
                MessageBox.Show("番号はすべて出ています", "メッセージ");
                BingodisplayLabel.Content = "";
                BingologsView.Items.Clear();
                bingologic.BingoInit();
            }
            else
            {
                //BingodisplayLabelに番号を表示する
                //番号はBingoLogicクラスのNumdisplay関数で算出
                BingodisplayLabel.Content = bingologic.Numdisplay();
            }

            if(bingologic.bingocount > 0)
            {
                BingologsView.Items.Add(bingologic.numlog[bingologic.bingocount - 1]);
            }
            bingologic.bingocount++;
            BingocounttitleLabel.Content = bingologic.bingocount + "回目のゲームです";
        }
    }
}

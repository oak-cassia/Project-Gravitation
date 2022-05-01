using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Gravitation.Pages
{
    /// <summary>
    /// Option.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Option : Page
    {
        MainWindow _window;
        public Page sourcepage;  //나중에 쓰일 수도 있음, 중간중간에 옵션을 킨다면
        public Option(MainWindow Mwindow)
        {
            InitializeComponent();
            _window=Mwindow;
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(sourcepage);

        }
    }
}

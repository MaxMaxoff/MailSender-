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

namespace MailSender.Controls
{
    /// <summary>
    /// Логика взаимодействия для TabViewManager.xaml
    /// </summary>
    public partial class TabViewManager : UserControl
    {
        public event EventHandler Forward;

        public event EventHandler Backward;

        public TabViewManager()
        {
            InitializeComponent();
        }

        private void BackwardButtonClick(object sender, RoutedEventArgs e)
        {
            Forward?.Invoke(this, EventArgs.Empty);
        }

        private void ForwardButtonClick(object sender, RoutedEventArgs e)
        {
            Backward?.Invoke(this, EventArgs.Empty);
        }
    }
}

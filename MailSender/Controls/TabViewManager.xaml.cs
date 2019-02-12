using System;
using System.Windows;
using System.Windows.Controls;

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

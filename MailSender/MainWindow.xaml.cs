using System;
using System.Windows;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnForward(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex > 0)
            MainTabControl.SelectedIndex--;
        }

        private void OnBackward(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.Items.Count)
            MainTabControl.SelectedIndex++;
        }
    }
}

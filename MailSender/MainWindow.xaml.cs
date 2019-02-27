﻿using System;
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

        private void OpenSchedulerClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedItem = TabScheduler;
        }

        private void SendNowClick(object sender, RoutedEventArgs e)
        {
            //if (IsRichTextBoxEmpty(MessageTextRTB))
            if (string.IsNullOrEmpty(MessageTextRTB.Text))
            {
                MainTabControl.SelectedItem = EditorTab;
                MessageBox.Show("Письмо не заполнено!", "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Письмо отправлено!", "Успех!",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

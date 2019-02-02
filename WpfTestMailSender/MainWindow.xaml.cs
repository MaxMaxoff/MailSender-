using System;
using System.Windows;
using System.Net;
using System.Net.Mail;
using System.Security;

/// <summary>
/// Maxim Toropov
/// HomeWork1
/// </summary>
namespace WpfTestMailSender
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageSettings messageForm = new MessageSettings(tbxUserName.Text, tbxUserName.Text, tbxMessageTo.Text, tbxSubject.Text, tbxMessageBody.Text, false);

            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(messageForm.mailFrom, messageForm.messageFrom);
                message.To.Add(messageForm.messageTo);
                message.Subject = messageForm.messageSubject;
                message.Body = messageForm.messageBody;
                message.IsBodyHtml = messageForm.isMessageBodyHTML;

                try
                {
                    EmailSendServiceClass.SendMessage(message, tbxUserName.Text, pbxPassword.SecurePassword);
                
                    MessageBox.Show("Почта успешно отправилена", "Успех!",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message,
                        "Возникла ошибка в процессе отправки почты",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

using System.Windows;
using System.Windows.Controls;

namespace MailSender.Views
{
    /// <summary>
    /// Interaction logic for RecipientsEditor.xaml
    /// </summary>
    public partial class RecipientsEditor : UserControl
    {
        public RecipientsEditor()
        {
            InitializeComponent();
        }

        private void Validation_OnError(object sender, ValidationErrorEventArgs e)
        {
            if (!(e.Source is FrameworkElement control)) return;
            control.ToolTip = e.Action == ValidationErrorEventAction.Added ? e.Error.ErrorContent.ToString() : null;
        }
    }
}

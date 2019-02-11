using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.MVVM;

namespace MailSender.ViewModels
{
    class TestVeiwModel : lib.MVVM.ViewModel
    {
        private string _Text = "TestValue";

        public string Text
        {
            get => _Text;
            set => Set(ref _Text, value);
        }
    }
}

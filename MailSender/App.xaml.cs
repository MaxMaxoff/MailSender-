using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("MailSender.log")
            {
                TraceOutputOptions = TraceOptions.DateTime
            });

            base.OnStartup(e);
        }
    }
}

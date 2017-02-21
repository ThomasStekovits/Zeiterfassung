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
using System.Windows.Threading;

namespace ProformerStopUhr
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TimeSpan stoppedTime = new TimeSpan();
        DispatcherTimer timer = new DispatcherTimer();
     
            public MainWindow()
        {
            InitializeComponent();

            /// Interval of the stopped time, in my case it´s all second
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Every second is this event called. 
        /// The stopped time is increased by one.
        /// Than it shows on the label the past Time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            stoppedTime += timer.Interval;
            lblTime.Content = stoppedTime.ToString();
        }

        /// <summary>
        /// Check the timer is enabled or not enabled.
        /// Is the timer not enabled then set the stopped Time to a new Timespan of 0, after start the Timer and
        /// change the Content of the Button from "Zeit stoppen" to "Stop".
        /// Else stop the Timer and change the Content of the Button from "Stop" to "Zeit stoppen".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            {
                stoppedTime = new TimeSpan(0, 0, 0);
                timer.Start();
                btnTimerButton.Content = "Stop";
            }
            else
            {
                timer.Stop();
                btnTimerButton.Content = "Zeit stoppen";
            }
        }
    }
}

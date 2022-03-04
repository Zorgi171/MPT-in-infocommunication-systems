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
using System.Windows.Shapes;

namespace WpfHelloT1
{
    /// <summary>
    /// Логика взаимодействия для MyWindow.xaml
    /// </summary>
    /// 

    public partial class MyWindow : Window
    {
       

        private bool _close;
        MainWindow wnd1 = null;

        public MyWindow()
        {
            InitializeComponent();
        }
        public new void Close()
        {
            _close = true;
            base.Close();
        }
        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_close) return;
            e.Cancel = true;
            Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wnd1 = Owner as MainWindow;

            if (wnd1 != null)
            {
                wnd1.txtBlock.Text = textBox.Text + "\n" + listBox1.SelectedItem;
            
            }      
            Close();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            wnd1.myWin = null;
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
           
        }
    }
}

// Author: Yao Zhou; 

using Microsoft.Win32;
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

namespace Driver_s_License_Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly VM vm = new VM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void grade_Click(object sender, RoutedEventArgs e)
        {
            vm.grade();
        }

        private void file_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog answer_text = new OpenFileDialog();
            answer_text.Multiselect = false;
            answer_text.Filter = "Text files|*.txt";
            answer_text.FilterIndex = 1;

            Nullable<bool> dialogok = answer_text.ShowDialog();
            if (dialogok == true)
            {
                filename.Text = answer_text.FileName;
                vm.setFileName(answer_text.FileName);
            }
        }
    }
}

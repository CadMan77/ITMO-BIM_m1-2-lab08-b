using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

// Доработать проект текстового редактора из задания 7,
// добавив словарь ресурсов (в виде файла) со списками названий шрифтов и размеров.

namespace ITMO_BIM_m1_2_lab03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FontNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = (sender as ComboBox).SelectedValue.ToString();
            if (textBox != null)
                textBox.FontFamily = new FontFamily(fontName);
        }

        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = (sender as ComboBox).SelectedValue.ToString();
            if (textBox != null)
                textBox.FontSize = Convert.ToInt32(fontSize);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.FontWeight == FontWeights.Bold)
                    textBox.FontWeight = FontWeights.Normal;
                else
                    textBox.FontWeight = FontWeights.Bold;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.FontStyle == FontStyles.Italic)
                    textBox.FontStyle = FontStyles.Normal;
                else
                    textBox.FontStyle = FontStyles.Italic;
            }        
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.TextDecorations == TextDecorations.Underline)
                {
                    textBox.TextDecorations = null;
                }
                else
                    textBox.TextDecorations = TextDecorations.Underline;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
                textBox.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
                textBox.Foreground = new SolidColorBrush(Colors.Red);
        }

        //private void MenuOpenItem_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.Filter = ("Текстовые документы|*.txt|Все файлы|*.*");
        //    if (ofd.ShowDialog() == true)
        //        textBox.Text = File.ReadAllText(ofd.FileName);
        //}

        private void FileOpenCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ("Текстовые документы|*.txt|Все файлы|*.*");
            if (ofd.ShowDialog() == true)
                textBox.Text = File.ReadAllText(ofd.FileName);
        }

        //private void MenuSaveItem_Click(object sender, RoutedEventArgs e)
        //{
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.Filter = ("Текстовые документы|*.txt|Все файлы|*.*");
        //    if (sfd.ShowDialog() == true)
        //        File.WriteAllText(sfd.FileName, textBox.Text);
        //}

        private void FileSaveCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ("Текстовые документы|*.txt|Все файлы|*.*");
            if (sfd.ShowDialog() == true)
                File.WriteAllText(sfd.FileName, textBox.Text);
        }
        //private void MenuExitItem_Click(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}
        private void ExitCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

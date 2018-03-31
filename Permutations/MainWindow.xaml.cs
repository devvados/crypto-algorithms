using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Permutations.Tools;
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

namespace Permutations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            FillTasks();
        }

        public void FillTasks()
        {
            RBTask1.ToolTip = "Есть множество, второе множество. Найти перестановку.";
            RBTask2.ToolTip = "Найти второе множество по первому множеству и перестановке.";
            RBTask3.ToolTip = "Найти произведение транспозиций множества.";
        }

        public async void ShowMessageBox(string text, string title)
        {
            MetroDialogSettings ms = new MetroDialogSettings()
            {
                ColorScheme = MetroDialogColorScheme.Theme,
                AnimateShow = true,
                AnimateHide = true,
                DialogMessageFontSize = 14,
                DialogTitleFontSize = 30,
            };
            await this.ShowMessageAsync(title, text, MessageDialogStyle.Affirmative, ms);
        }

        private void BStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //найти перестановку множества
                if (RBTask1.IsChecked == true)
                {
                    if ((!String.IsNullOrEmpty(TBFirstSet1.Text)) && (!String.IsNullOrEmpty(TBSecondSet1.Text)))
                    {
                        var valueSet1 = Parser.ParseSetString(TBFirstSet1.Text);
                        var valueSet2 = Parser.ParseSetString(TBSecondSet1.Text);

                        var shuffle = Solver.FindShuffleBySets(valueSet1, valueSet2);

                        TBShuffle1.Text = Printer.PrintSet<int>(shuffle);
                    }
                    else throw new Exception("Заполните 1-е и 2-е множества!");
                }
                //найти второе множество по перестановке
                else if (RBTask2.IsChecked == true)
                {
                    if ((!String.IsNullOrWhiteSpace(TBFirstSet2.Text)) && (!String.IsNullOrWhiteSpace(TBShuffle2.Text)))
                    {
                        var valueSet1 = Parser.ParseSetString(TBFirstSet2.Text);
                        var shuffle = Parser.ParseShuffleString(TBShuffle2.Text);

                        var valueSet2 = Solver.FindSetByShuffle(valueSet1, shuffle);

                        TBSecondSet2.Text = Printer.PrintSet<string>(valueSet2);
                    }
                    else throw new Exception("Заполните 1-е множество и перестановку!");
                }
                //найти произведение транспозиций множества
                else if (RBTask3.IsChecked == true)
                {
                    if (!String.IsNullOrWhiteSpace(TBSet.Text))
                    {
                        Solver.FindTranspositions(null);
                    }
                    else throw new Exception("Заполните множество!");
                }
                else
                {
                    throw new Exception("Выберите одно из заданий, чтобы выполнить!");
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message, "Ошибка");
            }
        }

        private void BAbout_Click(object sender, RoutedEventArgs e)
        {
            ShowMessageBox("Подготовил студент группы М8О-112 Дмитриев Вадим." +
                "\nДля каждого задания выделена вкладка, на каждой вкладке расположены подпункты задания." +
                "\nФормулировка каждого подпункта появляется при наведении мышкой на вариант выбора.", "О программе");
        }
    }
}

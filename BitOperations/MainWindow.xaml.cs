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

namespace BitOperations
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

        private void MIAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Подготовил студент группы М8О-112М Дмитриев Вадим", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #region 1 задание

        /// <summary>
        /// Получить произвольный бит
        /// </summary>
        /// <param name="bit"></param>
        /// <returns></returns>
        private int GetBit(int bit)
        {
            int source = Convert.ToInt32(TBSourceNumber1.Text, 2);
            int res = (source >> bit) & 1;

            return res;
        }

        /// <summary>
        /// Установить\снять бит
        /// </summary>
        /// <param name="bit"></param>
        /// <returns></returns>
        private int SetBit(int bit)
        {
            int source = Convert.ToInt32(TBSourceNumber1.Text, 2);
            int res = source ^ (1 << bit);

            return res;
        }

        /// <summary>
        /// Поменять биты местами
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private int SwapBits(int i, int j)
        {
            int source = Convert.ToInt32(TBSourceNumber1.Text, 2);
            int res = source ^ ((1 << i) | (1 << j));

            return res;
        }

        /// <summary>
        /// Занулить биты
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private int SetNullBits(int m)
        {
            int source = Convert.ToInt32(TBSourceNumber1.Text, 2);
            int res = (source >> m) << m;

            return res;
        }

        #endregion

        #region 2-3 задания

        /// <summary>
        /// Склеить m первые и последние биты
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        private int GlueBits(int bits)
        {
            int source = Convert.ToInt32(TBSourceNumber2.Text, 2);
            int sourceLen = TBSourceNumber2.Text.Length;

            int v1 = ((source >> (sourceLen - bits)) << bits);
            int v2 = source & ((1 << bits) - 1);

            int res = v1 | v2;

            return res;
        }

        /// <summary>
        /// Получить биты между m первыми и последними битами
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        private int BetweenBits(int bits)
        {
            int source = Convert.ToInt32(TBSourceNumber2.Text, 2);
            int sourceLen = TBSourceNumber2.Text.Length;

            int v1 = (source >> bits);
            int v2 = (1 << (sourceLen - bits - bits)) - 1;

            int res = v1 & v2;

            return res;
        }

        /// <summary>
        /// Поменять байты местами
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        private int SwapBytes(int b1, int b2)
        {
            int source = Convert.ToInt32(TBSourceNumber2.Text, 2);

            if (b1 > b2)
            {
                b1 ^= b2 ^= b1 ^= b2;
            }

            //получить байты
            int tempByte1 = ((source >> ((b1 - 1) * 8)) & ((1 << 8) - 1)) << ((b1 - 1) * 8);
            int tempByte2 = ((source >> ((b2 - 1) * 8)) & ((1 << 8) - 1)) << ((b2 - 1) * 8);
            //обнулить байты 
            source &= (~(((1 << 8) - 1) << (b1 - 1) * 8));
            source &= (~(((1 << 8) - 1) << (b2 - 1) * 8));
            //поменять байты
            source |= tempByte1 << ((b2 - b1) * 8); ;
            source |= tempByte2 >> ((b2 - b1) * 8);

            return source;
        }

        #endregion

        #region 4-6 задания

        /// <summary>
        /// Максимальная степень двойки, на которую делится число
        /// </summary>
        /// <returns></returns>
        private int FindMaxPower()
        {
            int source = Convert.ToInt32(TBSourceNumber3.Text, 2);
            int res = source & (-source);

            return res;
        }

        /// <summary>
        /// Найти такое P, что ...
        /// </summary>
        /// <returns></returns>
        private int FindP()
        {
            int source = Convert.ToInt32(TBSourceNumber3.Text, 2);
            int p = 0;

            while (!((1 << p) <= source && source <= 1 << (p + 1)))
                p++;

            return p;
        }

        /// <summary>
        /// Поксорить все биты в числе
        /// </summary>
        /// <returns></returns>
        private int XorAllBits()
        {
            int source = Convert.ToInt32(TBSourceNumber3.Text, 2);
            int sourceLen = Convert.ToInt32(TBSourceNumber3.Text.Length);
            int res = 0;

            while (sourceLen != 0)
            {
                res ^= source & 1;
                source >>= 1;
                sourceLen--;
            }

            return res;
        }

        #endregion

        #region 7-8 задания

        private int LeftCyclicShift(int bits, int p)
        {
            int source = Convert.ToInt32(TBSourceNumber4.Text, 2);
            int sourceLen = TBSourceNumber4.Text.Length;
            int res = (source << bits) | (source >> (int)(Math.Pow(2, p) - bits));

            return res;
        }

        private int RightCyclicShift(int bits, int p)
        {
            int source = Convert.ToInt32(TBSourceNumber4.Text, 2);
            int sourceLen = TBSourceNumber4.Text.Length;
            int res = (source >> bits) | (source << (int)(Math.Pow(2, p) - bits));

            return res;
        }

        private int SwapBitsByArray(int[] array)
        {
            return 0;
        }

        #endregion

        private void BExecute1_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;

            if (RBGetBit.IsChecked == true)
            {
                int bit = Convert.ToInt32(TBGetBit.Text);
                result = GetBit(bit);
            }
            else if (RBSetBit.IsChecked == true)
            {
                int bit = Convert.ToInt32(TBSetBit.Text);
                result = SetBit(bit);
            }
            else if (RBSwapBits.IsChecked == true)
            {
                int i = Convert.ToInt32(TBIBit.Text);
                int j = Convert.ToInt32(TBJBit.Text);

                result = SwapBits(i, j);
            }
            else if (RBSetNullBits.IsChecked == true)
            {
                int m = Convert.ToInt32(TbSetNullBits.Text);
                result = SetNullBits(m);
            }

            TBResultNumber1.Text = Convert.ToString(result, 2);
        }

        private void BExecute2_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;

            if (RBGlueBits.IsChecked == true)
            {
                int bit = Convert.ToInt32(TBGlueBits.Text);
                result = GlueBits(bit);
            }
            else if (RBBetweenBits.IsChecked == true)
            {
                int bit = Convert.ToInt32(TBSetBit.Text);
                result = BetweenBits(bit);
            }
            else if (RBSwapBytes.IsChecked == true)
            {
                int b1 = Convert.ToInt32(TBFirstByte.Text);
                int b2 = Convert.ToInt32(TBSecondByte.Text);
                result = SwapBytes(b1, b2);
            }

            TBResultNumber2.Text = Convert.ToString(result, 2);
        }

        private void BExecute3_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;

            if (RBFindMaxPow.IsChecked == true)
            {
                result = FindMaxPower();
            }
            else if (RBFindP.IsChecked == true)
            {
                result = FindP();
            }
            else if (RBXorAllBits.IsChecked == true)
            {
                result = XorAllBits();
            }

            TBResultNumber3.Text = Convert.ToString(result, 2);
        }

        private void BExecute4_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;

            if (RBCyclicShift.IsChecked == true)
            {
                int bits = Convert.ToInt32(TBCyclicShift.Text);
                int p = Convert.ToInt32(TBP.Text);
                if (CBCyclicShift.SelectedIndex == 0)
                    result = RightCyclicShift(bits, p);
                else
                    result = LeftCyclicShift(bits, p);
            }
            else if (RBSwapBitsByArray.IsChecked == true)
            {
                result = FindP();
            }

            TBResultNumber4.Text = Convert.ToString(result, 2);
        }
    }
}

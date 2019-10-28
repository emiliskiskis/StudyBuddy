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

namespace StudyBuddy.Forms
{
    /// <summary>
    /// Interaction logic for Rating.xaml
    /// </summary>
    public partial class Rating : UserControl
    {
        private SolidColorBrush orange = new SolidColorBrush(Color.FromRgb(255, 210, 0));
        private SolidColorBrush white = new SolidColorBrush(Color.FromRgb(255, 255, 255));

        public Rating()
        {
            InitializeComponent();
            selectedStar = 0;
        }

        public int selectedStar { get; set; }

        private void s1_MouseEnter(object sender, MouseEventArgs e)
        {
            s1.Fill = orange;
            s2.Fill = white;
            s3.Fill = white;
            s4.Fill = white;
            s5.Fill = white;
        }

        private void s1_MouseLeave(object sender, MouseEventArgs e)
        {
            if (selectedStar == 0)
            {
                s1.Fill = white;
            }
        }

        private void s1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectedStar = 1;
            s1.Fill = orange;
            s2.Fill = white;
            s3.Fill = white;
            s4.Fill = white;
            s5.Fill = white;
        }

        private void s2_MouseEnter(object sender, MouseEventArgs e)
        {
            s1.Fill = orange;
            s2.Fill = orange;
            s3.Fill = white;
            s4.Fill = white;
            s5.Fill = white;
        }

        private void s2_MouseLeave(object sender, MouseEventArgs e)
        {
            if (selectedStar == 0)
            {
                s1.Fill = white;
                s2.Fill = white;
            }
        }

        private void s2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectedStar = 2;
            s1.Fill = orange;
            s2.Fill = orange;
            s3.Fill = white;
            s4.Fill = white;
            s5.Fill = white;
        }

        private void s3_MouseEnter(object sender, MouseEventArgs e)
        {
            s1.Fill = orange;
            s2.Fill = orange;
            s3.Fill = orange;
            s4.Fill = white;
            s5.Fill = white;
        }

        private void s3_MouseLeave(object sender, MouseEventArgs e)
        {
            if (selectedStar == 0)
            {
                s1.Fill = white;
                s2.Fill = white;
                s3.Fill = white;
            }
        }

        private void s3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectedStar = 3;
            s1.Fill = orange;
            s2.Fill = orange;
            s3.Fill = orange;
            s4.Fill = white;
            s5.Fill = white;
        }

        private void s4_MouseEnter(object sender, MouseEventArgs e)
        {
            s1.Fill = orange;
            s2.Fill = orange;
            s3.Fill = orange;
            s4.Fill = orange;
            s5.Fill = white;
        }

        private void s4_MouseLeave(object sender, MouseEventArgs e)
        {
            if (selectedStar == 0)
            {
                s1.Fill = white;
                s2.Fill = white;
                s3.Fill = white;
                s4.Fill = white;
            }
        }

        private void s4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectedStar = 4;
            s1.Fill = orange;
            s2.Fill = orange;
            s3.Fill = orange;
            s4.Fill = orange;
            s5.Fill = white;
        }

        private void s5_MouseEnter(object sender, MouseEventArgs e)
        {
            s1.Fill = orange;
            s2.Fill = orange;
            s3.Fill = orange;
            s4.Fill = orange;
            s5.Fill = orange;
        }

        private void s5_MouseLeave(object sender, MouseEventArgs e)
        {
            if (selectedStar == 0)
            {
                s1.Fill = white;
                s2.Fill = white;
                s3.Fill = white;
                s4.Fill = white;
                s5.Fill = white;
            }
        }

        private void s5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectedStar = 5;
            s1.Fill = orange;
            s2.Fill = orange;
            s3.Fill = orange;
            s4.Fill = orange;
            s5.Fill = orange;
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (selectedStar == 1)
            {
                s1.Fill = orange;
                s2.Fill = white;
                s3.Fill = white;
                s4.Fill = white;
                s5.Fill = white;
            }

            if (selectedStar == 2)
            {
                s1.Fill = orange;
                s2.Fill = orange;
                s3.Fill = white;
                s4.Fill = white;
                s5.Fill = white;
            }

            if (selectedStar == 3)
            {
                s1.Fill = orange;
                s2.Fill = orange;
                s3.Fill = orange;
                s4.Fill = white;
                s5.Fill = white;
            }

            if (selectedStar == 4)
            {
                s1.Fill = orange;
                s2.Fill = orange;
                s3.Fill = orange;
                s4.Fill = orange;
                s5.Fill = white;
            }

            if (selectedStar == 5)
            {
                s1.Fill = orange;
                s2.Fill = orange;
                s3.Fill = orange;
                s4.Fill = orange;
                s5.Fill = orange;
            }
        }
    }
}

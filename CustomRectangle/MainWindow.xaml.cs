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

namespace CustomRectangle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int borderThick = 2;
        private LinearGradientBrush linearBrush = new LinearGradientBrush();
        GradientStop topGS = new GradientStop();
        GradientStop bottomGS = new GradientStop();
        Boolean Fill1Selected = false;
        Boolean Fill2Selected = false;
        Boolean showLeftBorder = true;
        Boolean showRightBorder = true;
        Boolean showTopBorder = true;
        Boolean showBottomBorder = true;

        public MainWindow()
        {
            InitializeComponent();
            //initialize gradient stops
            linearBrush.StartPoint = new Point(0.5, 0);
            linearBrush.EndPoint = new Point(0.5, 1);
            topGS = new GradientStop();
            topGS.Color = Colors.White;
            topGS.Offset = 0.0;
            linearBrush.GradientStops.Add(topGS);
            bottomGS = new GradientStop();
            bottomGS.Color = Colors.White;
            bottomGS.Offset = 1.0;
            linearBrush.GradientStops.Add(bottomGS);
            BorderCtrl.Background = linearBrush;
        }

        private void BorderColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            //set border color
            SolidColorBrush brush = new SolidColorBrush((Color)BorderColor.SelectedColor);
            BorderCtrl.BorderBrush = brush;
        }

        private void FillColor1_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            //set top fill color
            topGS.Color = (Color)FillColor1.SelectedColor;
            Fill1Selected = true;
            if (!Fill2Selected)
            {
                //if bottom fill color not set, use top fill color for whole control
                bottomGS.Color = (Color)FillColor1.SelectedColor;
            }
            BorderCtrl.Background = linearBrush;
        }

        private void FillColor2_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            //set bottom fill color
            bottomGS.Color = (Color)FillColor2.SelectedColor;
            Fill2Selected = true;
            if (!Fill1Selected)
            {
                //if top fill color not set, use bottom fill color for whole control
                topGS.Color = (Color)FillColor2.SelectedColor;
            }
            BorderCtrl.Background = linearBrush;
        }

        private void textButton_Click(object sender, RoutedEventArgs e)
        {
            //set border thickness
            int temp = 0;
            if(int.TryParse(thickText.Text, out temp)){
                borderThick = temp;
                BorderCtrl.BorderThickness = new Thickness(borderThick);
            }
        }

        //toggle borders
        private void leftBorderButton_Click(object sender, RoutedEventArgs e)
        {
            showLeftBorder = !showLeftBorder;
            BorderCtrl.BorderThickness = new Thickness(showLeftBorder?borderThick:0, 
                showTopBorder ? borderThick : 0, showRightBorder ? borderThick : 0, showBottomBorder ? borderThick : 0);
        }

        private void rightBorderButton_Click(object sender, RoutedEventArgs e)
        {
            showRightBorder = !showRightBorder;
            BorderCtrl.BorderThickness = new Thickness(showLeftBorder ? borderThick : 0,
                showTopBorder ? borderThick : 0, showRightBorder ? borderThick : 0, showBottomBorder ? borderThick : 0);

        }

        private void topBorderbutton_Click(object sender, RoutedEventArgs e)
        {
            showTopBorder = !showTopBorder;
            BorderCtrl.BorderThickness = new Thickness(showLeftBorder ? borderThick : 0,
                showTopBorder ? borderThick : 0, showRightBorder ? borderThick : 0, showBottomBorder ? borderThick : 0);

        }

        private void bottomBorderButton_Click(object sender, RoutedEventArgs e)
        {
            showBottomBorder = !showBottomBorder;
            BorderCtrl.BorderThickness = new Thickness(showLeftBorder ? borderThick : 0,
                showTopBorder ? borderThick : 0, showRightBorder ? borderThick : 0, showBottomBorder ? borderThick : 0);

        }
        //toggle all 4 borders
        private void toggleAllButton_Click(object sender, RoutedEventArgs e)
        {
            showLeftBorder = !showLeftBorder;
            showRightBorder = !showRightBorder;
            showTopBorder = !showTopBorder;
            showBottomBorder = !showBottomBorder;
            BorderCtrl.BorderThickness = new Thickness(showLeftBorder ? borderThick : 0,
                showTopBorder ? borderThick : 0, showRightBorder ? borderThick : 0, showBottomBorder ? borderThick : 0);
        }

        private void topColorCheck_Click(object sender, RoutedEventArgs e)
        {
            //click to use top color only
            if (Fill1Selected)
            {
                topGS.Color = (Color)FillColor1.SelectedColor;
                bottomGS.Color = (Color)FillColor1.SelectedColor;
            }
            BorderCtrl.Background = linearBrush;
        }
    }
}

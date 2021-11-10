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

namespace MoneYe_WPF.View.Component
{
    /// <summary>
    /// Interaction logic for BindPasswordBox.xaml
    /// </summary>

    //TODO: Сделать все как по гайду 
    //IDEA: https://www.youtube.com/watch?v=G9niOcc5ssw
    public partial class BindPasswordBox : UserControl
    {

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindPasswordBox), new PropertyMetadata(string.Empty));
        public string Password
        {
            get => (string)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }



        public BindPasswordBox()
        {
            InitializeComponent();
        }
    }
}

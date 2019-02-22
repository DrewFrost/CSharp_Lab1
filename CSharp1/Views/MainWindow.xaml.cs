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
using CSharp1.ViewModel;
using FontAwesome.WPF;

namespace CSharp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageAwesome _loader;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new UserViewModel(UpdateResult, ShowLoader);
        }

        private void UpdateResult()
        {
            ((UserViewModel)DataContext).Age = "Wow, your age is " + ((UserViewModel)DataContext).Age;

            ((UserViewModel)DataContext).WesternZodiac =
                "and your Western sign is " + ((UserViewModel)DataContext).WesternZodiac;

            ((UserViewModel)DataContext).ChineseZodiac =
                "and sure, your Chinese sign is " + ((UserViewModel)DataContext).ChineseZodiac;
        }

        public void ShowLoader(bool isShow)
        {
            LoaderHelper.OnRequestLoader(MainGrid, ref _loader, isShow);
        }

    }
}


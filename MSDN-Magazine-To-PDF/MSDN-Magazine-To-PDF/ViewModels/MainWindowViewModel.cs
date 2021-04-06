using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism;
using System.Collections.ObjectModel;
using MSDN_Magazine_To_PDF.Model;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Controls;

namespace MSDN_Magazine_To_PDF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<Magazine> magazineList = new ObservableCollection<Magazine>();
        private ObservableCollection<System.Windows.Controls.Expander> monthList = new ObservableCollection<System.Windows.Controls.Expander>();

        public ObservableCollection<Magazine> MagazineList
        {
            get => magazineList;
            set => SetProperty(ref magazineList, value, "MagazineList");
        }

        public ObservableCollection<System.Windows.Controls.Expander> MonthList
        {
            get => monthList;
            set => SetProperty(ref monthList, value, "MonthList");
        }

        public MainWindowViewModel()
        {
            //Test
            MagazineList.Add(new Magazine() { Title = "Jan", CoverUrl = "https://docs.microsoft.com/en-us/archive/msdn-magazine/images/mt848698.cover_lrg(en-us,msdn.10).jpg" });
            MagazineList.Add(new Magazine() { Title = "Feb", CoverUrl = "https://docs.microsoft.com/en-us/archive/msdn-magazine/images/mt833264.cover_lg(en-us,msdn.10).png" });
            MagazineList.Add(new Magazine() { Title = "Mar", CoverUrl = "https://docs.microsoft.com/en-us/archive/msdn-magazine/images/mt833283.cover_lrg(en-us,msdn.10).jpg" });

            MonthList.Add(new System.Windows.Controls.Expander() { Header = "Test", Style = (System.Windows.Style)System.Windows.Application.Current.FindResource("ExpanderStyle") }) ;
            MonthList.Add(new System.Windows.Controls.Expander() { Header = "Test2", Style = (System.Windows.Style)System.Windows.Application.Current.FindResource("ExpanderStyle") });
        }
    }
}

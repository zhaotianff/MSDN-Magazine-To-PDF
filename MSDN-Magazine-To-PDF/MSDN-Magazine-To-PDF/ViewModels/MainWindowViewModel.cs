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
using MSDN_Magazine_To_PDF.Util;

namespace MSDN_Magazine_To_PDF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<Magazine> magazineList = new ObservableCollection<Magazine>();
        private ObservableCollection<System.Windows.Controls.Expander> yearList = new ObservableCollection<System.Windows.Controls.Expander>();

        public ObservableCollection<Magazine> MagazineList
        {
            get => magazineList;
            set => SetProperty(ref magazineList, value, "MagazineList");
        }

        public ObservableCollection<System.Windows.Controls.Expander> YearList
        {
            get => yearList;
            set => SetProperty(ref yearList, value, "YearList");
        }

        public MainWindowViewModel()
        {
            LoadMagazineList();
        }

        private async void LoadMagazineList()
        {
            var json = await WebUtil.GetHtml(Urls.GetListUrl);
            var magazineRoot = JsonUtil.Deserialize<MagazineRoot>(json);

            foreach (var item in magazineRoot.items.First()?.children)
            {
                YearList.Add(new Expander() { Header = item.toc_title,Height = 50, Style = (Style)Application.Current.FindResource("ExpanderStyle") });
            }

            ////Test
            //MagazineList.Add(new Magazine() { Title = "Jan", CoverUrl = "https://docs.microsoft.com/en-us/archive/msdn-magazine/images/mt848698.cover_lrg(en-us,msdn.10).jpg" });
            //MagazineList.Add(new Magazine() { Title = "Feb", CoverUrl = "https://docs.microsoft.com/en-us/archive/msdn-magazine/images/mt833264.cover_lg(en-us,msdn.10).png" });
            //MagazineList.Add(new Magazine() { Title = "Mar", CoverUrl = "https://docs.microsoft.com/en-us/archive/msdn-magazine/images/mt833283.cover_lrg(en-us,msdn.10).jpg" });

            
            //YearList.Add(new System.Windows.Controls.Expander() { Header = "Test2", Style = (System.Windows.Style)System.Windows.Application.Current.FindResource("ExpanderStyle") });
        }
    }
}

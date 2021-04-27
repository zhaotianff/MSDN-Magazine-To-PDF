using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Controls;

using MSDN_Magazine_To_PDF.Util;
using MSDN_Magazine_To_PDF.Model;

using static MSDN_Magazine_To_PDF.Util.ResourceProc;

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
                ListBox listBox = new ListBox();
                listBox.Style = TryFindLocalResource("ListBoxStyle");
                listBox.SelectionChanged += MonthListBox_SelectionChanged;

                foreach (var month in item.children)
                {
                    listBox.Items.Add(new ListItem() { Title = month.toc_title, Url = month.href });
                }

                YearList.Add(new Expander() { Header = item.toc_title,Style = (Style)Application.Current.FindResource("ExpanderStyle"),Content = listBox });
            }
        }

        private async void MonthListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.AddedItems[0] as ListItem;
            var url = string.Format(Urls.GetYearContent, selectedItem.Url);
            var json = await WebUtil.GetHtml(url);
            var monthDetail = JsonUtil.Deserialize<MagazineRoot>(json);
        }

        private async Task<List<ListItem>> GetMonthDetail(string yearUrl)
        {
            var tempJson = await WebUtil.GetHtml(string.Format(Urls.GetYearContent, yearUrl));
            var tempObj = JsonUtil.Deserialize<MagazineRoot>(tempJson);

            var list = tempObj?.items.First().children.Select(x => new ListItem { Title = x.toc_title }).ToList();
            return list;
        }
    }
}

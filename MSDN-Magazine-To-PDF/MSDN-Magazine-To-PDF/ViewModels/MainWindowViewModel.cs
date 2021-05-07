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
using System.Globalization;

namespace MSDN_Magazine_To_PDF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<Magazine> magazineList = new ObservableCollection<Magazine>();
        private ObservableCollection<System.Windows.Controls.Expander> yearList = new ObservableCollection<System.Windows.Controls.Expander>();
        
        private const string OVERVIEW_KEYWORD = "Overview";
        private const string CONNECT_KEYWORD = "Connect";

        private CultureInfo CurrentCulture { get; set; } = CultureInfo.CurrentCulture;

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
                    if (month.toc_title == OVERVIEW_KEYWORD || month.toc_title == CONNECT_KEYWORD)
                        continue;

                    listBox.Items.Add(new ListItem() { Title = month.toc_title, Url = month.href });
                }

                YearList.Add(new Expander() { Header = item.toc_title,Style = (Style)Application.Current.FindResource("ExpanderStyle"),Content = listBox });
            }
        }

        private async void MonthListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.AddedItems[0] as ListItem;
            var url = Urls.BaseUrl + selectedItem.Url;
            var html = await WebUtil.GetHtml(url);
            ExtractMonthContent(html);
        }

        private async void ExtractMonthContent(string html)
        {
            var main = await AngleSharpHelper.CssSelectorParse("#main td", html);
            var articles = await AngleSharpHelper.CssSelectorParse("td",main?[0].OuterHtml);
        }
    }
}

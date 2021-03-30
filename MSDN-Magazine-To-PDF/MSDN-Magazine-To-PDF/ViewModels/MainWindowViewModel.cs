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

namespace MSDN_Magazine_To_PDF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<Magazine> magazineList = new ObservableCollection<Magazine>();

        public ObservableCollection<Magazine> MagazineList
        {
            get => magazineList;
            set => SetProperty(ref magazineList, value, "MagazineList");
        }

        public MainWindowViewModel()
        {
            //Test
            MagazineList.Add(new Magazine() { Title = "Jan", CoverUrl = "https://docs.microsoft.com/en-us/archive/msdn-magazine/images/mt848698.cover_lrg(en-us,msdn.10).jpg" });
            MagazineList.Add(new Magazine() { Title = "Feb", CoverUrl = "https://docs.microsoft.com/en-us/archive/msdn-magazine/images/mt833264.cover_lg(en-us,msdn.10).png" });
            MagazineList.Add(new Magazine() { Title = "Mar", CoverUrl = "https://docs.microsoft.com/en-us/archive/msdn-magazine/images/mt833283.cover_lrg(en-us,msdn.10).jpg" });
        }
    }
}

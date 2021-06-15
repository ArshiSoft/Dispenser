using Syncfusion.XForms.Buttons;
using System;
using System.Collections.ObjectModel;

namespace Dispenser.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        DateTime date;
        public MainViewModel()
        {
            Date = DateTime.Now;
        }
        public ObservableCollection<SfSegmentItem> Image_textCollection { get; set; }
        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }
    }
}

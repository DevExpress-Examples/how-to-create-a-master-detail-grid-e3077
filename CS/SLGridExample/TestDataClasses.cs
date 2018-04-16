using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.Generic;

namespace SLGridExample {

    public class TestRecordList : List<TestRecord> {
    }

    public class TestRecord : INotifyPropertyChanged {

        public string Description { get; set; }

        public string MasterRecordID { get; set; }

        DetailsList details;
        public DetailsList DetailedInfo {
            get {
                return details;
            }
            set {
                if (details == value)
                    return;
                details = value;
                RaisePropertyChaged("DetailedInfo");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChaged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public class DetailsList : List<Details> {
        public override string ToString() {
            return "Detail (Count = " + Count.ToString() + ")";
        }
    }

    public class Details {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}

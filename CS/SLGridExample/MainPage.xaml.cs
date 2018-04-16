using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Threading;
using DevExpress.Xpf.Grid;
using System.Windows.Data;

namespace SLGridExample {
    public partial class MainPage : UserControl {

        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.RegisterAttached("IsExpanded", typeof(bool), typeof(MainPage), new PropertyMetadata(false));

        public static void SetIsExpanded(DependencyObject element, bool value) {
            element.SetValue(IsExpandedProperty, value);
        }

        public static bool GetIsExpanded(DependencyObject element) {
            return (bool)element.GetValue(IsExpandedProperty);
        }

        public MainPage() {
            InitializeComponent();

            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e) {

            TestRecordList recListMain = new TestRecordList();

            Random rnd = new Random();
            for (int i = 0; i < 50; i++) {
                DetailsList recList = new DetailsList();

                int count = rnd.Next(40) + 10;
                for (int j = 0; j < count; j++) {
                    recList.Add(new Details() { Id = j, Name = "Detail name #" + j } );
                }

                recListMain.Add(new TestRecord() { Description = "The master record #" + i, MasterRecordID = "id " + i, DetailedInfo = recList });
            }

            grid.ItemsSource = recListMain;
        } 
    }
}

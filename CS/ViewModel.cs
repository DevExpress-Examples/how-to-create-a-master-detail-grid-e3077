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
using System.Collections.Generic;

namespace MasterDetail {
    public class ViewModel {
        List<ParentTestData> data;
        public List<ParentTestData> Data {
            get {
                if(data == null) {
                    data = new List<ParentTestData>();
                    for(int i = 0; i < 100; i++) {
                        ParentTestData parentTestData = new ParentTestData() { Text = "Master" + i, Number = i, Data = new List<TestData>() };
                        for(int j = 0; j < 50; j++)
                            parentTestData.Data.Add(new TestData() { Text = "Detail" + j + " Master" + i, Number = j, Ready = j % 2 != 0 });
                        data.Add(parentTestData);
                    }
                }
                return data;
            }
        }
    }

    public class TestData {
        public bool Ready { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
    }
    public class ParentTestData {
        public string Text { get; set; }
        public int Number { get; set; }
        public List<TestData> Data { get; set; }
    }
}

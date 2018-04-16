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
using DevExpress.Xpf.Grid;
using System.Windows.Data;

namespace SLGridExample {
    public class GridDetailContainer : ContentPresenter {

        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.Register("IsVisible", typeof(bool), typeof(GridDetailContainer), new PropertyMetadata(false, new PropertyChangedCallback(GridPropertyChangedCallback)));

        public bool IsVisible {
            get { return (bool)GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }

        public static readonly DependencyProperty GridProperty =
            DependencyProperty.Register("Grid", typeof(GridControl), typeof(GridDetailContainer), new PropertyMetadata(null, new PropertyChangedCallback(GridPropertyChangedCallback)));

        public GridControl Grid {
            get { return (GridControl)GetValue(GridProperty); }
            set { SetValue(GridProperty, value); }
        }

        static void GridPropertyChangedCallback(DependencyObject s, DependencyPropertyChangedEventArgs e) {
            ((GridDetailContainer)s).OnChanged();
        }

        Binding gridItemsSourceBinding;
        public Binding GridItemsSourceBinding {
            get { return gridItemsSourceBinding; }
            set {
                gridItemsSourceBinding = value;
                OnChanged();
            }
        }

        void OnChanged() {
            Content = Grid;
            if (IsVisible) {
                Visibility = Visibility.Visible;
                if (Grid != null && GridItemsSourceBinding != null)
                    Grid.SetBinding(GridControl.DataSourceProperty, GridItemsSourceBinding);
            } else {
                Visibility = Visibility.Collapsed;
                if (Grid != null)
                    Grid.ClearValue(GridControl.DataSourceProperty);
            }
        }

    }
}

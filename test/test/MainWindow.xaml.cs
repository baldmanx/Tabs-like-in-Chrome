using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Style tabItemStyle = new Style();
        public TabItem tabItem;
        public TabItem temp_tabItem;

        public int index = 0;
        public int items_count = 0;

        public double tabs_width_sum = 0.0;
        public double k = 0.99;

        public event PropertyChangedEventHandler PropertyChanged;
        private double myWidth = 150.0;

        public double MyWidth
        {
            get
            {
                return MyWidth;
            }
            set
            {
                myWidth = value;
                OnPropertyChanged("Width");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Add_Tab_Item(TabControl tc)
        {

            if (myWidth < 46)
            {
                add.IsEnabled = false;

                MessageBox.Show("Too many tabs. Try to close someone.");
            }
            else
            {
                tabItem = new TabItem();

                for (int i = 0; i < tc.Items.Count; i++)
                {
                    tabs_width_sum += myWidth;
                }

                if (tc.ActualWidth - tabs_width_sum < myWidth)
                {
                    myWidth = tc.ActualWidth / (tc.Items.Count + 1) * k;
                }

                tabs_width_sum = 0.0;

                for (int i = 0; i < tc.Items.Count; i++)
                {
                    temp_tabItem = (TabItem)tc.Items.GetItemAt(i);
                    temp_tabItem.Width = myWidth;
                    tc.Items.RemoveAt(i);
                    tc.Items.Insert(i, temp_tabItem);
                }

                tabItem.Width = myWidth;
                tabItem.Header = tc.Items.Count + 1;
                tabItem.Style = tabItemStyle;
                tabItem.MouseEnter += item_Captured;
                tc.Items.Add(tabItem);
                tc.SelectedItem = tc.Items.GetItemAt(tc.Items.Count - 1);
                items_count = tc.Items.Count;
            }
        }

        public void Delete_Tab_Item(TabControl tc)
        {
            tc.Items.RemoveAt(index);

            for (int i = 0; i < tc.Items.Count; i++)
            {
                tabs_width_sum += myWidth;
            }

            if (tc.ActualWidth - tabs_width_sum >= myWidth)
            {
                myWidth = tc.ActualWidth / (tc.Items.Count) * k;
            }

            if (myWidth >= 150.0)
            {
                myWidth = 150.0;
            }

                tabs_width_sum = 0.0;

            for (int i = 0; i < tc.Items.Count; i++)
            {
                temp_tabItem = (TabItem)tc.Items.GetItemAt(i);
                temp_tabItem.Width = myWidth;
                tc.Items.RemoveAt(i);
                tc.Items.Insert(i, temp_tabItem);
            }

            add.IsEnabled = true;
        }

            public MainWindow()
        {
            InitializeComponent();
            tabItemStyle = FindResource("tabItemWithButton") as Style;
                 
            items_count = test_tab.Items.Count;

            for (int i = 0; i < items_count; i++)
            {
                tabItem = (TabItem)test_tab.Items.GetItemAt(i);
                tabItem.MouseEnter += item_Captured;
            }
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            Add_Tab_Item(test_tab);
        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            Delete_Tab_Item(test_tab);
            GC.Collect();
        }

        private void item_Captured(object sender, EventArgs e)
        {
            for (int i = 0; i < items_count; i++)
            {             
                tabItem = (TabItem)test_tab.Items.GetItemAt(i);

                if (tabItem.IsMouseOver == true)
                {
                    items_count = test_tab.Items.Count;
                    index = i;
                }

            }
        }

        private void test_tab_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            tabItem = new TabItem();

            for (int i = 0; i < test_tab.Items.Count; i++)
            {
                tabs_width_sum += myWidth;
            }

            if (test_tab.ActualWidth - tabs_width_sum < myWidth)
            {
                myWidth = test_tab.ActualWidth / (test_tab.Items.Count + 1) * k;
            }
            else
            {
                myWidth = test_tab.ActualWidth / (test_tab.Items.Count) * k;
            }

            for (int i = 0; i < test_tab.Items.Count; i++)
            {
                temp_tabItem = (TabItem)test_tab.Items.GetItemAt(i);
                temp_tabItem.Width = myWidth;
                test_tab.Items.RemoveAt(i);
                test_tab.Items.Insert(i, temp_tabItem);
            }

            tabs_width_sum = 0.0;
        }

        private void TabItem_Drag(object sender, MouseEventArgs e)
        {
            var tabItem = e.Source as TabItem;

            if (tabItem == null)
                return;

            if (Mouse.PrimaryDevice.LeftButton == MouseButtonState.Pressed)
                DragDrop.DoDragDrop(tabItem, tabItem, DragDropEffects.All);
        }

        private void TabItem_Drop(object sender, DragEventArgs e)
        {
            var tabItemTarget = e.Source as TabItem;
            var tabItemSource = e.Data.GetData(typeof(TabItem)) as TabItem;

            if (!tabItemTarget.Equals(tabItemSource))
            {
                int sourceIndex = test_tab.Items.IndexOf(tabItemSource);
                int targetIndex = test_tab.Items.IndexOf(tabItemTarget);

                test_tab.Items.Remove(tabItemSource);
                test_tab.Items.Insert(targetIndex, tabItemSource);

                test_tab.Items.Remove(tabItemTarget);
                test_tab.Items.Insert(sourceIndex, tabItemTarget);

                test_tab.SelectedIndex = targetIndex;
            }
        }
    }
}
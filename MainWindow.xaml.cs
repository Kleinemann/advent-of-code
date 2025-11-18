using Advent_of_Code.Elemente;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Advent_of_Code
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitDays();
            DoSelectedDays();
        }

        void InitDays()
        {
            List<DayBase> days = new List<DayBase>();

            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name.Contains("Day"));

            CheckBox cbLast = null;

            foreach (Type type in types)
            {
                if (type.Name.Length != 5)
                    continue;

                DayBase day = Activator.CreateInstance(type) as DayBase;

                int.TryParse(type.Namespace.Substring(type.Namespace.Length - 4), out day.Year);
                int.TryParse(type.Name.Substring(3), out day.Day);

                days.Add(day);

                CheckBox cb = new CheckBox();
                cb.Content = $"{day.Year}__{day.Day}";
                cb.DataContext = day;
                lvDays.Items.Add(cb);

                cbLast = cb;
            }

            cbLast.IsChecked = true;
        }

        void DoSelectedDays()
        {
            List<DayBase> days = new List<DayBase>();
            foreach (CheckBox cb in lvDays.Items)
            {
                if (cb.IsChecked == true)
                {
                    DayBase day = cb.DataContext as DayBase;
                    days.Add(day);
                }
            }


            foreach (DayBase day in days)
            {
                txtLog.Text += $"Tag {day.Day}:" + Environment.NewLine;

                day.DoPart1();
                if(day.Part1.Log != string.Empty)
                txtLog.Text += day.Part1.Log + Environment.NewLine;

                txtLog.Text += day.Part1.Output;
                txtLog.Text += Environment.NewLine;

                day.DoPart2();
                if (day.Part2.Log != string.Empty)
                    txtLog.Text += day.Part2.Log + Environment.NewLine;

                txtLog.Text += day.Part2.Output;

                txtLog.Text += $"{Environment.NewLine}#################{Environment.NewLine}";
            }
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            DoSelectedDays();
            Mouse.OverrideCursor = null;
        }
    }
}
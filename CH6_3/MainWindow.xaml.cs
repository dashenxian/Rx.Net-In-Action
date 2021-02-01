using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
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

namespace CH6_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init2();
        }

        private void Init2()
        {
            var mouseDown = Observable.FromEventPattern<MouseButtonEventArgs>(this, nameof(this.MouseLeftButtonDown));
            var mouseUp = Observable.FromEventPattern<MouseButtonEventArgs>(this, nameof(this.MouseLeftButtonUp));
            var mouseMove = Observable.FromEventPattern<MouseEventArgs>(this, nameof(this.MouseMove));
            Polyline line = null;
            mouseMove.SkipUntil(
                    mouseDown.Do(x =>
                    {
                        line = new Polyline { Stroke = Brushes.Black, StrokeThickness = 3 };
                        canvas.Children.Add(line);
                    })).TakeUntil(mouseUp)
                .Select(i => i.EventArgs.GetPosition(this))
                .Repeat()
                .Subscribe(i => line.Points.Add(i));
        }

        void Init()
        {
            var mouseDowns = Observable.FromEventPattern<MouseButtonEventArgs>(this, "MouseDown");
            var mouseUp = Observable.FromEventPattern<MouseButtonEventArgs>(this, "MouseUp");
            var movements = Observable.FromEventPattern<MouseEventArgs>(this, "MouseMove");




            Polyline line = null;
            movements
                     .SkipUntil(
                         mouseDowns.Do(_ =>
                         {
                             line = new Polyline() { Stroke = Brushes.Black, StrokeThickness = 3 };
                             canvas.Children.Add(line);
                         }))
                     .TakeUntil(mouseUp)
                     .Select(m => m.EventArgs.GetPosition(this))
                     .Repeat()
                     .Subscribe(pos => line.Points.Add(pos));
        }
    }
}

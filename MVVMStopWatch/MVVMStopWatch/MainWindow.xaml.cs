using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MVVMStopWatch
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			AddMarkings();

			DataContext = new StopwatchViewModel(this);
		}

		/// <summary>
		/// Add marks on the clock
		/// </summary>
		private void AddMarkings()
		{
			for (var i = 0; i < 360; i += 3)
			{
				var rectangle = new Rectangle
				{
					Width = (i % 30 == 0) ? 3 : 1,
					Height = 15,
					Fill = new SolidColorBrush(Colors.Black),
					RenderTransformOrigin = new Point(0.5, 0.5)
				};

				var transforms = new TransformGroup();
				transforms.Children.Add(new TranslateTransform() { Y = -140 });
				transforms.Children.Add(new RotateTransform() { Angle = i });
				rectangle.RenderTransform = transforms;
				clockGrid.Children.Add(rectangle);
			}
		}
	}
}

using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using VorText.ViewModels;

namespace VorText.Windows
{
	/// <summary>
	/// Interaction logic for SnakeView.xaml
	/// </summary>
	public partial class SnakeView : Window
	{
		#region Fields
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SnakeView()
		{
			InitializeComponent();

			// Create the View Model.
			SnakeViewModel viewModel = new SnakeViewModel();
			DataContext = viewModel;    // Set the data context for all data binding operations.
		}

		#endregion

		#region Events
		#endregion

		#region Properties
		#endregion

		#region Methods
		#endregion
	}
}

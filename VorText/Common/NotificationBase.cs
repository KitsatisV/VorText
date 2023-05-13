using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VorText.Common
{
	public class NotificationBase : INotifyPropertyChanged
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Events

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region Properties
		#endregion

		#region Methods

		/// <summary>
		/// The RaisePropertyChanged method is called raise a property changed event. 
		/// </summary>
		/// <param name="propertyname"></param>
		protected void RaisePropertyChanged([CallerMemberName] string propertyname = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
		}

		#endregion
	}
}

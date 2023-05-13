using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.Reflection.UninterpretedOption.Types;

namespace VorText.Models
{
	public class SnakeEye : SnakePart
	{
		#region Fields
		#endregion

		#region Constructors

		/// <summary>
		/// Constructor.
		/// </summary>
		public SnakeEye(double gameBoardWidthPixels, double gameBoardHeightPixels, double initialXPosition, double initialYPosition, Direction direction)
			: base(gameBoardWidthPixels, gameBoardHeightPixels, direction)
		{
			_xPosition = initialXPosition;
			_yPosition = initialYPosition - Constants.EyeOffet;
			_width = Constants.EyeWidth;
			_height = Constants.EyeHeight;
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

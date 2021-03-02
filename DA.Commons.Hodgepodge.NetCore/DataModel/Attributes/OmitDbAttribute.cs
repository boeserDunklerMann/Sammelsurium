using System;

namespace DA.Commons.Hodgepodge.NetCore.DataModel.Attributes
{
	/// <summary>
	/// Damit wird eine Property im Model markiert, die nicht in der DB serialisiert werden soll (weil sie z.B. berechnet wird).
	/// </summary>
	public sealed class OmitDbAttribute : Attribute
	{
		public OmitDbAttribute()
		{
		}
	}
}

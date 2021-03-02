using System;
using System.Collections.Generic;
using System.Text;

namespace DA.Commons.Hodgepodge.NetCore.DataModel.Attributes
{
	/// <summary>
	/// Mappt eine Property zu einer Spalte in der Database-Tabelle
	/// </summary>
	public sealed class DbField : Attribute
	{
		public string DbFieldName { get; private set; }

		public DbField(string fieldName)
		{
			DbFieldName = fieldName;
		}
	}
}

using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DA.Commons.Hodgepodge.NetCore.DataModel
{
	/// <ChangeLog>
	/// <Create Datum="01.03.2021" Entwickler="DA" />
	/// </ChangeLog>
	public class DataModelBase
	{
		public string rev { get; set; }

		public virtual string ID { get; set; } = string.Empty;
		public bool IsNew => string.IsNullOrWhiteSpace(ID);
		public virtual bool DeleteMe { get; set; } = false;

		[Obsolete("Use CouchDb to avoid nasty OR-Mapping", true)]
		public virtual void FromDataRow(DataRow row)
		{
			Type myType = this.GetType();
			PropertyInfo[] properties = myType.GetProperties();
			properties.ToList().ForEach(pi =>
			{
				string colName = pi.Name;
				Attribute a = pi.GetCustomAttribute(typeof(Attributes.DbField));
				Attribute omitDb = pi.GetCustomAttribute(typeof(Attributes.OmitDbAttribute));
				if ((null != a) && (null == omitDb))
					colName = ((Attributes.DbField)a).DbFieldName;

				if (row.Table.Columns.Contains(colName) && row[colName] != DBNull.Value && omitDb == null)
				{
					if (pi.Name == "ID")    // IDs speichern wir intern als string
						pi.SetValue(this, row[colName].ToString());
					else
						pi.SetValue(this, row[colName]);
				}
			});
		}
	}
}
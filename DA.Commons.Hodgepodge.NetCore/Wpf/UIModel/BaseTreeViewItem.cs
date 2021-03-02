using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DA.Commons.Hodgepodge.NetCore.Wpf.UIModel
{
	/// <ChangeLog>
	/// <Create Datum="01.03.2021" Entwickler="DA" />
	/// </ChangeLog>
	/// <summary>base item for treeview-items</summary>
	public class BaseTreeViewItem
	{
		private readonly DataModel.DataModelBase _baseModel;
		public DataModel.DataModelBase Data => _baseModel;

		public virtual string Bezeichnung
		{
			get => _baseModel?.ID;
			private set
			{
				if (_baseModel != null)
					_baseModel.ID = value;
			}
		}

		public ObservableCollection<BaseTreeViewItem> Children { get; private set; } = new ObservableCollection<BaseTreeViewItem>();

		public BaseTreeViewItem(DataModel.DataModelBase dataModel)
		{
			_baseModel = dataModel;
		}
	}
}
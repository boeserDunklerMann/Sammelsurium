using System.ComponentModel;

namespace DA.Commons.Hodgepodge.NetCore.Wpf.MVVM
{
	/// <ChangeLog>
	/// <Create Datum="01.03.2021" Entwickler="DA" />
	/// </ChangeLog>
	/// <summary>
	/// ViewModel base class
	/// </summary>
	public class ObservableObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChangedEvent(string propertyName = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
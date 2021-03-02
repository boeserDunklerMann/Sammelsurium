using System.Security;

namespace DA.Commons.Hodgepodge.NetCore.Encryption.Interfaces
{
	/// <summary>
	/// Die implentierende Klasse erzeugt einen Hash aus einem Input-String (mittels MD5, CRC, etc.)
	/// </summary>
	/// <Change Datum="18.02.2021" Entwickler="DA">HashUserSecurePassword added</Change>
	public interface IEncHasher
	{
		byte[] HashUserPassword(string username, string plainPassword);
		byte[] HashUserSecurePassword(string username, SecureString securePassword);
	}
}

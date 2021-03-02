using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace DA.Commons.Hodgepodge.NetCore.Encryption
{
	/// <ChangeLog>
	/// <Create Datum="01.03.2021" Entwickler="DA" />
	/// </ChangeLog>
	class Md5Hasher : Interfaces.IEncHasher
	{
		private MD5CryptoServiceProvider md5CSP;
		public Md5Hasher()
		{
			md5CSP = new MD5CryptoServiceProvider();
		}

		public byte[] HashUserPassword(string username, string plainPassword)
		{
			string input = $"{username}:{plainPassword}";
			return md5CSP.ComputeHash(UnicodeEncoding.Unicode.GetBytes(input));
		}

		public byte[] HashUserSecurePassword(string username, SecureString securePassword)
		{
			byte[] userBytes = UnicodeEncoding.Unicode.GetBytes(username + ":");
			byte[] passBytes = SecureStringToByteArray(securePassword);
			byte[] allBytes = new byte[userBytes.Length + passBytes.Length];
			Array.Copy(userBytes, allBytes, userBytes.Length);
			Array.Copy(passBytes, 0, allBytes, userBytes.Length, passBytes.Length);
			return md5CSP.ComputeHash(allBytes);
		}
		private byte[] SecureStringToByteArray(SecureString ss)
		{
			IntPtr bstr = IntPtr.Zero;
			byte[] retval;
			try
			{
				bstr = Marshal.SecureStringToBSTR(ss);
				int len = Marshal.ReadInt32(bstr, -4);
				retval = new byte[len];
				for (int i = 0; i < len; i++)
				{
					retval[i] = Marshal.ReadByte(bstr, i);
				}
				return retval;
			}
			finally
			{
				if (bstr != IntPtr.Zero)
					Marshal.ZeroFreeBSTR(bstr);
			}
		}
	}
}

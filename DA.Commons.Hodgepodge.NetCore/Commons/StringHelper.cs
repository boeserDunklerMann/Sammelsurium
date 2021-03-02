using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace DA.Commons.Hodgepodge.NetCore.Commons
{
	/// <ChangeLog>
	/// <Create Datum="18.02.2021" Entwickler="DA" />
	/// </ChangeLog>
	/// <remarks>https://stackoverflow.com/a/23183092/12445867</remarks>
	public static class StringHelper
	{
		public static bool IsEqualTo(this SecureString ss1, SecureString ss2)
		{
			if (ss1 == null || ss2 == null)
				return ss1 == ss2;
			IntPtr bstr1 = IntPtr.Zero;
			IntPtr bstr2 = IntPtr.Zero;
			try
			{
				bstr1 = Marshal.SecureStringToBSTR(ss1);
				bstr2 = Marshal.SecureStringToBSTR(ss2);
				int length1 = Marshal.ReadInt32(bstr1, -4);
				int length2 = Marshal.ReadInt32(bstr2, -4);
				if (length1 == length2)
				{
					for (int x = 0; x < length1; ++x)
					{
						byte b1 = Marshal.ReadByte(bstr1, x);
						byte b2 = Marshal.ReadByte(bstr2, x);
						if (b1 != b2) return false;
					}
				}
				else return false;
				return true;
			}
			finally
			{
				if (bstr2 != IntPtr.Zero) Marshal.ZeroFreeBSTR(bstr2);
				if (bstr1 != IntPtr.Zero) Marshal.ZeroFreeBSTR(bstr1);
			}
		}
		public static byte[] ToByteArray(this SecureString ss)
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

		private static byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
		private static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
		/// <ChangeLog>
		/// <Create Datum="19.12.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Encrypts an input string using DES algorithm
		/// </summary>
		public static string Crypt(this string text)
		{
			SymmetricAlgorithm algorithm = DES.Create();
			ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
			byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
			byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
			return Convert.ToBase64String(outputBuffer);
		}

		/// <ChangeLog>
		/// <Create Datum="19.12.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Decrypts an input string using DES algorithm
		/// </summary>
		public static string Decrypt(this string text)
		{
			SymmetricAlgorithm algorithm = DES.Create();
			ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
			byte[] inputbuffer = Convert.FromBase64String(text);
			byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
			return Encoding.Unicode.GetString(outputBuffer);
		}
	}
}

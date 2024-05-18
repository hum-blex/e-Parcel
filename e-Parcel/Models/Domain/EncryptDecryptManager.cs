﻿using System.Security.Cryptography;
using System.Text;

namespace e_Parcel.Models.Domain
{
	public class EncryptDecryptManager
	{
		private readonly static string key = "4zC8jp0TFOTEgj0rTyhq3nYCraCtkaUC";
		public static string Encrypt(string text)
		{
			byte[] iv = new byte[16];
			byte[] array;
			using (Aes aes = Aes.Create())
			{
				aes.Key = Encoding.UTF8.GetBytes(key);
				aes.IV = iv;
				ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
				using (MemoryStream ms = new MemoryStream())
				{
					using (CryptoStream cryptostream = new CryptoStream((Stream)ms, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter streamwriter = new StreamWriter((Stream)cryptostream))
						{
							streamwriter.Write(text);
						}
						array = ms.ToArray();
					}
				}

			}
			return Convert.ToBase64String(array);
		}

		public static string Decrypt(string text)
		{
			byte[] iv = new byte[16];
			byte[] buffer = Convert.FromBase64String(text);
			using (Aes aes = Aes.Create())
			{
				aes.Key = Encoding.UTF8.GetBytes(key);
				aes.IV = iv;
				ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
				using (MemoryStream ms = new MemoryStream(buffer))
				{
					using (CryptoStream cryptoStream = new CryptoStream((Stream)ms, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader sr = new StreamReader(cryptoStream))
						{
							return sr.ReadToEnd();
						}
					}
				}
			}
		}
	}
}

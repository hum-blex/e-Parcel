using e_Parcel.Models.Domain;

namespace e_Parcel.Service
{
	public class EDService : IEDService
	{
		public string Encrypt(string text)
		{
			var encryptString = EncryptDecryptManager.Encrypt(text);
			return encryptString;
		}
		public string Decrypt(string text)
		{
			var decryptString = EncryptDecryptManager.Decrypt(text);
			return decryptString;
		}
	}
}

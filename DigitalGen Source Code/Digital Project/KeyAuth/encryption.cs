using System;
using System.Security.Cryptography;
using System.Text;

namespace KeyAuth
{
	// Token: 0x02000003 RID: 3
	public static class encryption
	{
		// Token: 0x06000021 RID: 33 RVA: 0x0000371C File Offset: 0x0000191C
		public static string HashHMAC(string enckey, string resp)
		{
			byte[] key = Encoding.ASCII.GetBytes(enckey);
			byte[] message = Encoding.ASCII.GetBytes(resp);
			HMACSHA256 hash = new HMACSHA256(key);
			return encryption.byte_arr_to_str(hash.ComputeHash(message));
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000375C File Offset: 0x0000195C
		public static string byte_arr_to_str(byte[] ba)
		{
			StringBuilder hex = new StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
			{
				hex.AppendFormat("{0:x2}", b);
			}
			return hex.ToString();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000037A8 File Offset: 0x000019A8
		public static byte[] str_to_byte_arr(string hex)
		{
			byte[] result;
			try
			{
				int NumberChars = hex.Length;
				byte[] bytes = new byte[NumberChars / 2];
				for (int i = 0; i < NumberChars; i += 2)
				{
					bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
				}
				result = bytes;
			}
			catch
			{
				api.error("The session has ended, open program again.");
				Environment.Exit(0);
				result = null;
			}
			return result;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000381C File Offset: 0x00001A1C
		public static string iv_key()
		{
			return Guid.NewGuid().ToString().Substring(0, 16);
		}
	}
}

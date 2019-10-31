using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WoT_CH {
	public static class DVPL {
		public static string Parse(string data) {
			data = data.Replace("\r\n", "\n");
			if(data.Length < 20 || !data.Contains("DVPL")) throw new Exception();
			
			return (data.Substring(0, data.Length - 20));
		}
		public static byte[] ToDVPL(string origin) {
			int len = origin.Length;
			List<byte> data = new List<byte>(0);

			for(int i = 0; i < len; ++i) {
				data.Add(Convert.ToByte(origin[i]));
			}
			
			byte[] size = GetSize(len);
			byte[] crc32 = CRC32.Calculate(data.ToArray()).Reverse().ToArray();
			byte[] zero = { 0x00, 0x00, 0x00, 0x00 };
			byte[] magic = { 0x44, 0x56, 0x50, 0x4c };
			
			data.AddRange(size);
			data.AddRange(size);
			data.AddRange(crc32);
			data.AddRange(zero);
			data.AddRange(magic);
	
			return data.ToArray();
		}
		 
		static byte[] GetSize(int size) {
			// in 265 out 09 01 00 00
			byte[] data = new byte[4];

			string result = size.ToString("X").PadLeft(8, '0');
			string[] b = new string[4];
			for(int i = 0; i < result.Length; i += 2) {
				b[i / 2] += result[i];
				b[i / 2] += result[i + 1];
			}
			
			data[3] += (byte)(Convert.ToInt32(b[0], 16));
			data[2] += (byte)(Convert.ToInt32(b[1], 16));
			data[1] += (byte)(Convert.ToInt32(b[2], 16));
			data[0] += (byte)(Convert.ToInt32(b[3], 16));
			
			return data;
		}
	}
}

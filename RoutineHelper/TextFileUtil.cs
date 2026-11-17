using System.IO;
using System.Text;

namespace RoutineHelper;

internal static class TextFileUtil
{
	private static readonly UTF8Encoding StrictUtf8 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

	private static readonly Encoding Gb18030 = Encoding.GetEncoding("GB18030");

	public static string ReadAllTextPreferUtf8(string path)
	{
		byte[] array = File.ReadAllBytes(path);
		if (array.Length >= 3 && array[0] == 239 && array[1] == 187 && array[2] == 191)
		{
			return Encoding.UTF8.GetString(array, 3, array.Length - 3);
		}
		try
		{
			return StrictUtf8.GetString(array);
		}
		catch
		{
			return Gb18030.GetString(array);
		}
	}
}

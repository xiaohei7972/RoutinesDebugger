using System.IO;

namespace RoutineHelper;

internal static class VarInt
{
	public static byte[] GetBytes(ulong value)
	{
		using MemoryStream memoryStream = new MemoryStream();
		while (value != 0)
		{
			ulong num = value & 0x7F;
			value >>= 7;
			if (value != 0)
			{
				num |= 0x80;
			}
			memoryStream.WriteByte((byte)num);
		}
		return memoryStream.ToArray();
	}

	public static ulong ReadNext(byte[] bytes, out int length)
	{
		length = 0;
		ulong num = 0uL;
		foreach (byte b in bytes)
		{
			ulong num2 = (ulong)b & 0x7FuL;
			num |= num2 << length * 7;
			if ((b & 0x80) != 128)
			{
				break;
			}
			length++;
		}
		length++;
		return num;
	}
}

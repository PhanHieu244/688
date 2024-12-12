using System;
using UnityEngine;

namespace PreviewLabs
{
	public static class PlayerPrefs
	{
		public const string STR_COLOR_R = "STR_COLOR_R";

		public const string STR_COLOR_G = "STR_COLOR_G";

		public const string STR_COLOR_B = "STR_COLOR_B";

		public const string STR_COLOR_A = "STR_COLOR_A";

		public static bool HasKey(string key)
		{
			return UnityEngine.PlayerPrefs.HasKey(key);
		}

		public static void SetString(string key, string value)
		{
			UnityEngine.PlayerPrefs.SetString(key, value);
		}

		public static void SetInt(string key, int value)
		{
			UnityEngine.PlayerPrefs.SetInt(key, value);
		}

		public static void SetLong(string key, long value)
		{
			UnityEngine.PlayerPrefs.SetFloat(key, (float)value);
		}

		public static void SetFloat(string key, float value)
		{
			UnityEngine.PlayerPrefs.SetFloat(key, value);
		}

		public static void SetBool(string key, bool value)
		{
			UnityEngine.PlayerPrefs.SetString(key, (!value) ? "false" : "true");
		}

		public static string GetString(string key)
		{
			return UnityEngine.PlayerPrefs.GetString(key);
		}

		public static string GetString(string key, string defaultValue)
		{
			return UnityEngine.PlayerPrefs.GetString(key, defaultValue);
		}

		public static int GetInt(string key)
		{
			return UnityEngine.PlayerPrefs.GetInt(key);
		}

		public static long GetLong(string key, long defaultValue)
		{
			return (long)UnityEngine.PlayerPrefs.GetFloat(key, (float)defaultValue);
		}

		public static int GetInt(string key, int defaultValue)
		{
			return UnityEngine.PlayerPrefs.GetInt(key, defaultValue);
		}

		public static float GetFloat(string key)
		{
			return UnityEngine.PlayerPrefs.GetFloat(key);
		}

		public static float GetFloat(string key, float defaultValue)
		{
			return UnityEngine.PlayerPrefs.GetFloat(key, defaultValue);
		}

		public static bool GetBool(string key)
		{
			return UnityEngine.PlayerPrefs.GetString(key) == "true";
		}

		public static bool GetBool(string key, bool defaultValue)
		{
			string @string = UnityEngine.PlayerPrefs.GetString(key, (!defaultValue) ? "false" : "true");
			return @string == "true";
		}

		public static Color GetColor(string key, Color co)
		{
			float @float = PlayerPrefs.GetFloat(key + "STR_COLOR_R", co.r);
			float float2 = PlayerPrefs.GetFloat(key + "STR_COLOR_G", co.g);
			float float3 = PlayerPrefs.GetFloat(key + "STR_COLOR_B", co.b);
			float float4 = PlayerPrefs.GetFloat(key + "STR_COLOR_A", co.a);
			return new Color(@float, float2, float3, float4);
		}

		public static void SetColor(string key, Color co)
		{
			PlayerPrefs.SetFloat(key + "STR_COLOR_R", co.r);
			PlayerPrefs.SetFloat(key + "STR_COLOR_G", co.g);
			PlayerPrefs.SetFloat(key + "STR_COLOR_B", co.b);
			PlayerPrefs.SetFloat(key + "STR_COLOR_A", co.a);
		}

		public static void DeleteKey(string key)
		{
			UnityEngine.PlayerPrefs.DeleteKey(key);
		}

		public static void DeleteAll()
		{
			UnityEngine.PlayerPrefs.DeleteAll();
		}

		public static void Flush()
		{
			UnityEngine.PlayerPrefs.Save();
		}

		private static void Serialize()
		{
		}

		private static void Deserialize()
		{
		}

		private static string EscapeNonSeperators(string inputToEscape)
		{
			return null;
		}

		private static string DeEscapeNonSeperators(string inputToDeEscape)
		{
			return null;
		}

		public static object GetTypeValue(string typeName, string value)
		{
			return null;
		}
	}
}

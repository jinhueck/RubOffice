using System;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalDefine
{
	static public class Define
	{
		public const int RANDOM_POOL_COUNT = 1024;

		public static T ParserJsonToObject<T>(string strJson)
		{
			return JsonUtility.FromJson<T>(strJson);
		}

		public static List<Dictionary<string, string>> CSVRead(string strFileName)
		{
			List<Dictionary<string, string>> listData = new List<Dictionary<string, string>>();

			TextAsset resourceText = Resources.Load<TextAsset>(strFileName);
			if (resourceText == null)
			{
				return listData;
			}

			// 한 라인 씩 저장
			string[] strLines = resourceText.text.Split(new[] { Environment.NewLine, "\n", "\r" }, StringSplitOptions.None);
			if (strLines.Length <= 1)
				return listData;

			// 키 값 정보
			string[] strKeyTable = strLines[0].Split(',');

			for (int i = 1; i < strLines.Length; ++i)
			{
				if (strLines[i] == "" || strLines[i] == " ")
					continue;

				string[] strElementTable = strLines[i].Split(',');

				Dictionary<string, string> element = new Dictionary<string, string>();

				for (int k = 0; k < strElementTable.Length; ++k)
				{
					element.Add(strKeyTable[k], strElementTable[k]);
				}

				listData.Add(element);
			}

			return listData;
		}
	}
	static public class Rand // 만분율 기준 0~9999까지 저장
	{
		private static int _index = 0;
		private static int[] _randomArr = new int[Define.RANDOM_POOL_COUNT];

		static Rand()
		{
			for (int i = 0; i < Define.RANDOM_POOL_COUNT; ++i)
			{
				_randomArr[i] = UnityEngine.Random.Range(0, 10000);
			}
		}

		private static int nIndex
		{
			get
			{
				int nTemp = _index++;

				if (_index >= Define.RANDOM_POOL_COUNT) { _index = 0; }

				return nTemp;
			}
		}

		public static int Random() { return _randomArr[nIndex]; }

		public static bool Percent(float a_nPercent) { return _randomArr[nIndex] <= (a_nPercent * 100); }
		public static bool Permile(float a_nPermile) { return _randomArr[nIndex] <= (a_nPermile * 10); }
		public static bool Permilad(int a_nPermilad) { return _randomArr[nIndex] <= a_nPermilad; }
		public static int Range(int a_nStart, int a_nEnd)
		{
			if (a_nStart > a_nEnd)
			{
				int nTemp = a_nStart;
				a_nStart = a_nEnd;
				a_nEnd = nTemp;
			}

			return (Random() % (a_nEnd - a_nStart)) + a_nStart;
		}
	}
}
using UnityEngine;

public class UIManager_InGame : MonoBehaviour
{
	#region SINGLETON
	static private UIManager_InGame _instance = null;

	public static UIManager_InGame Ins
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(UIManager_InGame)) as UIManager_InGame;
				if (_instance == null)
				{
					_instance = new GameObject("UIManager_InGame", typeof(UIManager_InGame)).GetComponent<UIManager_InGame>();
				}
			}

			return _instance;
		}
	}
	#endregion
	public DamageTextPool _damageTextPool;
	public HealthPointPool _healthPointPool;
}

using UnityEngine;
using UnityEngine.UI;
public class HealthPointUI : MonoBehaviour
{
	private Monster _monster;
	public Image hpImage;
	public Image hpBG;
	public Text hpText;
	public void Setting(Monster monster)
	{
		_monster = monster;
		gameObject.SetActive(true);
	}
	public void SetOff()
	{
		_monster = null;
		gameObject.SetActive(false);
	}
	private void Update()
	{
		float cHp = _monster.GetMonsterData().healthPoint;
		if (cHp <= 0)
		{
			SetOff();
			return;
		}
		gameObject.transform.position = _monster.gameObject.transform.position + (Vector3.down * 5);
		hpText.text = cHp.ToString();
		hpImage.fillAmount = cHp / _monster._fullHP;
	}
}

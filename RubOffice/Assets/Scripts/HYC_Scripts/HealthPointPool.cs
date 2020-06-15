using UnityEngine;
using System.Collections.Generic;
public class HealthPointPool : MonoBehaviour
{
	public List<HealthPointUI> hpUIList = new List<HealthPointUI>();
	public void Setting(Monster monster)
	{
		GetActiveUI().Setting(monster);
	}
	public HealthPointUI GetActiveUI()
	{
		for (int i = 0; i < hpUIList.Count; ++i)
		{
			if (hpUIList[i].gameObject.activeSelf == false)
			{
				return hpUIList[i];
			}
		}
		GameObject o = Instantiate(hpUIList[0].gameObject, gameObject.transform);
		hpUIList.Add(o.GetComponent<HealthPointUI>());
		return hpUIList[hpUIList.Count - 1];
	}
	public void OffAllHPUI()
	{
		for (int i = 0; i < hpUIList.Count; ++i)
		{
			hpUIList[i].SetOff();
		}
	}
}

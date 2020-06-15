﻿using UnityEngine;
using DG.Tweening;
using TMPro;
public class DamageText : MonoBehaviour
{
	public TextMeshProUGUI textMesh;
	public void ActiveDamageText(int damage, Vector3 pos)
	{
		gameObject.SetActive(true);
		textMesh.text = damage.ToString();
		gameObject.transform.position = pos + new Vector3(0, 10, 0);
		gameObject.transform.DOMoveY(gameObject.transform.position.y + 15, 1f).OnComplete(() => { gameObject.SetActive(false); });
	}
}

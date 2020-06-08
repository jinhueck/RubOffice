using GlobalDefine;
using UnityEngine;

public class Monster : MonoBehaviour
{
	[SerializeField] private MonsterStateMachine _stateMachine;
	[SerializeField] private Animator _monsterAnimation;
	[SerializeField] private CircleCollider2D _monsterColider;
	private MonsterData _monsterData = null;
	private float _angle = 0;
	private int _monsterID = 0;
	public void ResetData()
	{
		gameObject.SetActive(true);
	}
	public void SettingMonsterData(MonsterData monsterData)
	{
		_monsterData = monsterData;
	}
	public void Damage(float damage)
	{
	}
	public virtual void Dead()
	{
		SetColiderActive(false);
	}
	public void SetColiderActive(bool isActive)
	{
		if (_monsterColider)
			_monsterColider.enabled = isActive;
	}

	public void ChangeAnimation(eMonsterState monsterState)
	{
		_monsterAnimation.SetInteger("Action", (int)monsterState);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
	}
	/* 계산용 */
	public Vector3 GetForward()
	{
		return new Vector3(Mathf.Cos(_angle * Mathf.Deg2Rad), Mathf.Sin(_angle * Mathf.Deg2Rad), 0);
	}
}

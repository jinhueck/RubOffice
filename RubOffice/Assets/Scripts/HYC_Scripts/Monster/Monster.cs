using GlobalDefine;
using UnityEngine;

public class Monster : MonoBehaviour
{
	[SerializeField] protected MonsterStateMachine _stateMachine;
	[SerializeField] protected Animator _monsterAnimation;
	[SerializeField] protected CircleCollider2D _monsterColider;
	[SerializeField] protected Rigidbody2D _monsterRigidbody;
	protected MonsterData _monsterData;
	protected float _angle = 0;
	protected int _monsterID = 0;
	//TEST
	public int _fullHP;
	//
	private void Awake()
	{
		ResetData();
	}
	public void ResetData()
	{
		gameObject.SetActive(true);
		_stateMachine.Setting();
		_monsterData = new MonsterData();
		UIManager_InGame.Ins._healthPointPool.Setting(GetComponent<Monster>());
		//TEST
		_monsterData.healthPoint = 100;
		_fullHP = 100;
		//
	}
	public void SettingMonsterData(MonsterData monsterData)
	{
		_monsterData = monsterData;
	}
	public void Damage(int hitDamage)
	{
		if (hitDamage < 1)
		{
			hitDamage = 1;
		}
		_monsterData.healthPoint -= hitDamage;
		UIManager_InGame.Ins._damageTextPool.ShowDamage(hitDamage, transform.position);
		if (_monsterRigidbody)
		{
			_monsterRigidbody.velocity = Vector2.zero;
			_monsterRigidbody.AddForce(Vector2.left * 2000);
		}
		if (_monsterData.healthPoint <= 0)
		{
			Dead();
		}
	}
	public virtual void Dead()
	{
		ChangeAnimation(eMonsterState.Dead);
		//SetColiderActive(false);
	}
	public void SetColiderActive(bool isActive)
	{
		if (_monsterColider)
			_monsterColider.enabled = isActive;
	}
	#region State
	public bool IsIdle()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			ChangeAnimation(eMonsterState.Idle);
			return true;
		}
		return false;
	}
	public bool IsMove()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			ChangeAnimation(eMonsterState.Move);
			return true;
		}
		return false;
	}
	public virtual bool IsAttack()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			ChangeAnimation(eMonsterState.Attack);
			return true;
		}
		return false;
	}
	public void TestCode()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			Dead();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			Damage(1);
		}
	}
	public void ChangeAnimation(eMonsterState monsterState)
	{
		if (_monsterAnimation)
		{
			_monsterAnimation.SetInteger("Action", (int)monsterState);
		}
		_stateMachine.ChangeState(monsterState);
	}
	#endregion
	private void OnTriggerEnter2D(Collider2D collision)
	{
	}

	public MonsterStateMachine GetStateMachine()
	{
		return _stateMachine;
	}
	public MonsterData GetMonsterData()
	{
		return _monsterData;
	}
	/* 계산용 */
	public Vector3 GetForward()
	{
		return new Vector3(Mathf.Cos(_angle * Mathf.Deg2Rad), Mathf.Sin(_angle * Mathf.Deg2Rad), 0);
	}
}

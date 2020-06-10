using GlobalDefine;
using UnityEngine;

public class Monster : MonoBehaviour
{
	[SerializeField] protected MonsterStateMachine _stateMachine;
	[SerializeField] protected Animator _monsterAnimation;
	[SerializeField] protected CircleCollider2D _monsterColider;
	protected MonsterData _monsterData = null;
	protected float _angle = 0;
	protected int _monsterID = 0;
	private void Awake()
	{
		ResetData();
	}
	public void ResetData()
	{
		gameObject.SetActive(true);
		_stateMachine.Setting();
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
		_stateMachine.ChangeState(eMonsterState.Dead);
		SetColiderActive(false);
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
			_stateMachine.ChangeState(eMonsterState.Idle);
			return true;
		}
		return false;
	}
	public bool IsMove()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			_stateMachine.ChangeState(eMonsterState.Move);
			return true;
		}
		return false;
	}
	public bool IsAttack()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			_stateMachine.ChangeState(eMonsterState.Attack);
			return true;
		}
		return false;
	}
	public bool IsDead()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			_stateMachine.ChangeState(eMonsterState.Dead);
			return true;
		}
		return false;
	}
	public void ChangeAnimation(eMonsterState monsterState)
	{
		_monsterAnimation.SetInteger("Action", (int)monsterState);
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
	/* 계산용 */
	public Vector3 GetForward()
	{
		return new Vector3(Mathf.Cos(_angle * Mathf.Deg2Rad), Mathf.Sin(_angle * Mathf.Deg2Rad), 0);
	}
}

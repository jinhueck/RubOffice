using UnityEngine;
using GlobalDefine;

public class CCTVStateAttack : MonsterStateBase
{
	private float _minRangeZ = -29.0f;
	private float _maxRangeZ = 19.0f;
	private float _moveSpeed = 2.0f;
	private float _attakDelay = 5;
	public CCTVStateAttack(Monster o) : base(o)
	{
	}

	public override void OnStart()
	{
	}

	public override bool OnTransition()
	{
		if (_monsterObject.transform.localRotation.z >= _maxRangeZ || _monsterObject.transform.localRotation.z <= _minRangeZ)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public override void Tick()
	{
		if (OnTransition() == true)
		{
			return;
		}
		LookAtPlayer();
	}
	private void LookAtPlayer()
	{
		GameObject player = GameObject.Find("Player");
		Vector3 dirVec = player.transform.position - _monsterObject.transform.position;
		float degree = Mathf.Atan2(dirVec.y, dirVec.x);
	}
	public override void OnEnd()
	{

	}
}

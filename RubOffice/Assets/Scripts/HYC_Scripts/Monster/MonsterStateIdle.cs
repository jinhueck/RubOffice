﻿using GlobalDefine;
public class MonsterStateIdle : MonsterStateBase
{
	public MonsterStateIdle(Monster o) : base(o)
	{
	}

	public override void OnStart()
	{
	}

	public override bool OnTransition()
	{
		if (_monsterObject.IsAttack())
		{
			_monsterObject.ChangeAnimation(eMonsterState.Attack);
			return true;
		}
		else if (_monsterObject.IsMove())
		{
			_monsterObject.ChangeAnimation(eMonsterState.Move);
			return true;
		}
		return false;
	}

	public override void Tick()
	{
		if (OnTransition() == true)
		{
			return;
		}
	}
	public override void OnEnd()
	{
		
	}
}

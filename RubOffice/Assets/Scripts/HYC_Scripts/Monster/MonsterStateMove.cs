using GlobalDefine;
public class MonsterStateMove : MonsterStateBase
{
	public MonsterStateMove(Monster o) : base(o)
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
		else if (_monsterObject.IsIdle())
		{
			_monsterObject.ChangeAnimation(eMonsterState.Idle);
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

using GlobalDefine;
public class MonsterStateIdle : MonsterStateBase
{
	public MonsterStateIdle(Monster o) : base(o)
	{
	}

	public override void OnStart()
	{
		_monsterObject.ChangeAnimation(eMonsterState.Idle);
	}

	public override bool OnTransition()
	{
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

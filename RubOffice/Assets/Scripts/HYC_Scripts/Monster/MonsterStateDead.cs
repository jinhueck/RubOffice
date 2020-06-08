using GlobalDefine;
public class MonsterStateDead : MonsterStateBase
{
	public MonsterStateDead(Monster o) : base(o)
	{
	}

	public override void OnStart()
	{
		_monsterObject.ChangeAnimation(eMonsterState.Dead);
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

using GlobalDefine;
public class MonsterStateAttack : MonsterStateBase
{
	public MonsterStateAttack(Monster o) : base(o)
	{
	}

	public override void OnStart()
	{
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

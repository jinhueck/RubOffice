using GlobalDefine;
public class CCTVStateIdle : MonsterStateBase
{
	public CCTVStateIdle(Monster o) : base(o)
	{
	}

	public override void OnStart()
	{
	}

	public override bool OnTransition()
	{
		_monsterObject.ChangeAnimation(eMonsterState.Move);
		return true;
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

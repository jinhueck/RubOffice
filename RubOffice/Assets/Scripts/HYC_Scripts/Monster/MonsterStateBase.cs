public abstract class MonsterStateBase
{
	public Monster _monsterObject;
	public MonsterStateBase(Monster o)
	{
		_monsterObject = o;
	}
	public abstract void OnStart();
	public abstract void Tick();
	public abstract void OnEnd();
	public abstract bool OnTransition();
}

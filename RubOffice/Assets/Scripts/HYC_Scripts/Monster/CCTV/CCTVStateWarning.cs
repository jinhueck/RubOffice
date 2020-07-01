using UnityEngine;
public class CCTVStateWarning : MonsterStateBase
{
	private float _skillDelay = 3;
	private float _deltaTime = 0;
	public CCTVStateWarning(Monster o) : base(o)
	{
	}

	public override void OnStart()
	{
		Debug.Log("************CCTV Skill************");
		_deltaTime = 0;
	}
	
	public override bool OnTransition()
	{
		if(_deltaTime >= _skillDelay)
		{
			_monsterObject.ChangeAnimation(GlobalDefine.eMonsterState.Attack);
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
		_deltaTime += Time.deltaTime;
	}

	public override void OnEnd()
	{

	}
}

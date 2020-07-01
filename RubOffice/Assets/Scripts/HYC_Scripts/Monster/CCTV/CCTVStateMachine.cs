using GlobalDefine;

public class CCTVStateMachine : MonsterStateMachine
{
	public override void Setting()
	{
		var monster = GetComponent<CCTVMonster>();
		_stateDict.Add(eMonsterState.Idle, new CCTVStateIdle(monster));
		_stateDict.Add(eMonsterState.Move, new CCTVStateSearch(monster));
		_stateDict.Add(eMonsterState.SkillAttack, new CCTVStateWarning(monster));
		_stateDict.Add(eMonsterState.Attack, new CCTVStateAttack(monster));
		_cState = _stateDict[eMonsterState.Idle];
		_cState._monsterObject.ChangeAnimation(eMonsterState.Idle);
	}
}

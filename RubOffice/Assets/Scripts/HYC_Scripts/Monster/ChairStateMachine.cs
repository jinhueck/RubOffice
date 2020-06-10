using GlobalDefine;

public class ChairStateMachine : MonsterStateMachine
{
	public override void Setting()
	{
		var monster = GetComponent<ChairMonster>();
		_stateDict.Add(eMonsterState.Idle, new MonsterStateIdle(monster));
		_stateDict.Add(eMonsterState.Move, new MonsterStateMove(monster));
		_stateDict.Add(eMonsterState.Attack, new MonsterStateAttack(monster));
		_stateDict.Add(eMonsterState.Dead, new MonsterStateDead(monster));
		_cState = _stateDict[eMonsterState.Idle];
		_cState._monsterObject.ChangeAnimation(eMonsterState.Idle);
	}
}

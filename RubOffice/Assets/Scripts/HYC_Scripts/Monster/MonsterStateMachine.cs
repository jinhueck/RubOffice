using System.Collections.Generic;
using UnityEngine;
using GlobalDefine;
public abstract class MonsterStateMachine : MonoBehaviour
{
	protected Dictionary<eMonsterState, MonsterStateBase> _stateDict = new Dictionary<eMonsterState, MonsterStateBase>();
	protected MonsterStateBase _cState;
	public abstract void Setting();
	public void ChangeState(eMonsterState stateType)
	{
		_cState.OnEnd();
		_cState = _stateDict[stateType];
		_cState.OnStart();
	}
	public void ChangeStateIdle()
	{
		_cState._monsterObject.ChangeAnimation(eMonsterState.Idle);
	}
	private void Update()
	{
		_cState._monsterObject.TestCode();
		_cState.Tick();
	}
}

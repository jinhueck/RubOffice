using System.Collections.Generic;
using UnityEngine;
using GlobalDefine;
public abstract class MonsterStateMachine : MonoBehaviour
{
	private Dictionary<eMonsterState, MonsterStateBase> stateDict = new Dictionary<eMonsterState, MonsterStateBase>();
	private MonsterStateBase cState;
	public void ChangeState(eMonsterState stateType)
	{
		cState.OnEnd();
		cState = stateDict[stateType];
		cState.OnStart();
	}
}

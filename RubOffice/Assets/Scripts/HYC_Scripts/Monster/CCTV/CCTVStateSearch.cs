using DG.Tweening;
using GlobalDefine;
using UnityEngine;
public class CCTVStateSearch : MonsterStateBase
{
	private bool _skillFlag = false;
	private float _minRangeZ = -29.0f;
	private float _maxRangeZ = 19.0f;
	private float _moveSpeed = 2.0f;
	private Tween _searchTween = null;
	[SerializeField] private CCTVSearchLine _searchLine;
	public CCTVStateSearch(Monster o) : base(o)
	{
		_searchLine = _monsterObject.GetComponentInChildren<CCTVSearchLine>();
	}

	public override void OnStart()
	{
		_searchLine.gameObject.SetActive(true);
		SearchLeft();
	}

	public override bool OnTransition()
	{
		if (_searchLine._isSearch)
		{
			if(_skillFlag)
			{
				_monsterObject.ChangeAnimation(eMonsterState.Attack);
			}
			else
			{
				_skillFlag = true;
				_monsterObject.ChangeAnimation(eMonsterState.SkillAttack);
			}
			return true;
		}
		return false;
	}

	public override void Tick()
	{
		if (OnTransition() == true)
		{
			_searchLine.gameObject.SetActive(false);
			return;
		}
	}

	private void SearchLeft()
	{
		_searchTween = _monsterObject.transform.DOLocalRotateQuaternion(Quaternion.Euler(0,180,_maxRangeZ), _moveSpeed)
															.SetEase(Ease.Linear).OnComplete(SearchRight);
	}
	private void SearchRight()
	{
		_searchTween = _monsterObject.transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 180, _minRangeZ), _moveSpeed)
															.SetEase(Ease.Linear).OnComplete(SearchLeft);
	}

	public override void OnEnd()
	{
		_searchTween.Kill();
	}
}

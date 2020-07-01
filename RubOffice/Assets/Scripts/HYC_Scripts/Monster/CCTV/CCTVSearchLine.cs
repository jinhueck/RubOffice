using UnityEngine;

public class CCTVSearchLine : MonoBehaviour
{
	public bool _isSearch = false;
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			_isSearch = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			_isSearch = false;
		}
	}
	private void OnDisable()
	{
		_isSearch = false;
	}
}

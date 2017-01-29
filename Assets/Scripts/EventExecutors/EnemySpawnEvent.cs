using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnEvent : MonoBehaviour, IEventExecutor {

	void Start () {
		foreach (Transform child in transform.GetAllChildren())
			child.gameObject.SetActive(false);
	}

	public void ExecuteEvent()
	{
		foreach (Transform child in transform.GetAllChildren())
			child.gameObject.SetActive(true);
	}
}

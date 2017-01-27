using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public Transform colliderChildren;
	public Transform spawnChildren;

	void Start()
	{
		foreach (Transform child in spawnChildren.GetAllChildren())
			child.gameObject.SetActive(false);
	}

	public void TriggerSpawn()
	{
		foreach (Transform child in spawnChildren.GetAllChildren())
			child.gameObject.SetActive(true);
		foreach (Transform child in colliderChildren.GetAllChildren())
			Destroy(child.gameObject);
	}
}

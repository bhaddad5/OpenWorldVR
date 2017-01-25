using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	void Start()
	{
		foreach (Transform child in transform.GetAllChildren())
			child.gameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.GetComponent<PlayerMovementController>() != null)
		{
			foreach (Transform child in transform.GetAllChildren())
			child.gameObject.SetActive(true);
		}
	}
}

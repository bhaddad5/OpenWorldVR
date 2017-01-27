using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnCollisionDetector : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		if (collider.name == "PlayerBody")
		{
			transform.parent.parent.GetComponent<EnemySpawner>().TriggerSpawn();
		}
	}
}

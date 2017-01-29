using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerCollisionDetector : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		if (collider.name == "PlayerBody")
		{
			transform.parent.parent.GetComponent<EventTrigger>().TriggerExecute();
		}
	}
}

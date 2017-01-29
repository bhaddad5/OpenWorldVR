using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

public interface IEventExecutor
{
	void ExecuteEvent();
}

public class EventTrigger : MonoBehaviour
{
	public GameObject triggerParent;
	private List<IEventExecutor> executors;

	void Start()
	{
		foreach (BoxCollider child in triggerParent.GetComponentsInChildren<BoxCollider>())
		{
			child.gameObject.AddComponent<EventTriggerCollisionDetector>();
		}
		executors = GetComponentsInChildren<IEventExecutor>().ToList();
	}

	public void TriggerExecute()
	{
		foreach (IEventExecutor executor in executors)
		{
			executor.ExecuteEvent();
		}
		Destroy(triggerParent);
	}
}

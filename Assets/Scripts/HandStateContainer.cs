using UnityEngine;
using System.Collections;

public class HandStateContainer : MonoBehaviour {

	public HoldableObject CurrentlyHeldObject;

	private bool triggerDown;
	private GameObject handTracker;
	private bool currentlyInInventory = false;

	void Start()
	{
		handTracker = transform.FindChild("HandTracker").gameObject;
	}

	void Update()
	{
		if (triggerDown)
		{
			Collider[] currentColliders = Physics.OverlapSphere(handTracker.transform.position, .1f);
			foreach (Collider coll in currentColliders)
			{
				if (coll.GetComponent<StatsLoot>() != null)
				{
					Singletons.PlayerStatsContainer().AddStats(coll.GetComponent<StatsLoot>());
					Destroy(coll.gameObject);
				}

				if (coll.GetComponent<HoldableObject>() != null)
				{
					PutItemInHand(coll.GetComponent<HoldableObject>());
				}
			}
		}
	}

	public void PutItemInHand(HoldableObject obj)
	{
		if (CurrentlyHeldObject != null)
			return;

		obj.transform.SetParent(transform);
		obj.gameObject.SetActive(true);
		CurrentlyHeldObject = obj;
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localRotation = Quaternion.identity;
		obj.transform.localScale = Vector3.one;
		obj.GetComponent<BoxCollider>().enabled = false;
	}

	public void TryAddItemToInventory()
	{
		if (currentlyInInventory && CurrentlyHeldObject != null)
		{
			Singletons.InventoryController().InsertItem(CurrentlyHeldObject);
			CurrentlyHeldObject = null;
		}
	}

	public void SetTriggerDown(bool isDown)
	{
		triggerDown = isDown;
	}

	public void CheckWandAndExecuteSpell(VoiceDetector.SpellActions action)
	{
		if (CurrentlyHeldObject != null && CurrentlyHeldObject.GetComponent<WandController>() != null)
		{
			CurrentlyHeldObject.GetComponent<WandController>().ExecuteSpell(action);
		}
	}

	public void SetInInventory(bool inInventory)
	{
		currentlyInInventory = inInventory;
	}
}

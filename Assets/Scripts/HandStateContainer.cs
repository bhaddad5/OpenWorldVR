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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour {

	public enum SummonableItems
	{
		staff,
		sword
	}

	private List<HoldableObject> inventory = new List<HoldableObject>();

	private List<HandStateContainer> currentHands = new List<HandStateContainer>();

	public void InsertItem(HoldableObject obj)
	{
		if (obj == null)
			return;

		obj.gameObject.SetActive(false);
		obj.gameObject.transform.SetParent(transform);
		inventory.Add(obj);

		Debug.Log("after insert " + inventory.ValuesToString());
	}

	public void GrabItem(HoldableObject obj)
	{
		if (currentHands.Count == 0)
			return;

		InsertItem(currentHands[0].CurrentlyHeldObject);
		obj.transform.SetParent(currentHands[0].transform);
		obj.gameObject.SetActive(true);
		currentHands[0].CurrentlyHeldObject = obj;
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localRotation = Quaternion.identity;
		obj.transform.localScale = Vector3.one;
		inventory.Remove(obj);
		Debug.Log("after grab " + inventory.ValuesToString());
	}

	public void SummonItemType(SummonableItems itemType)
	{
		Debug.Log("on summon " + inventory.ValuesToString());
		foreach (HoldableObject holdableObject in inventory)
		{
			if (holdableObject.itemType == itemType)
			{
				GrabItem(holdableObject);
				return;
			}
		}
		Debug.Log("could not find " + itemType + " in Inventory!");
	}

	void OnTriggerEnter(Collider other)
	{
		HandStateContainer stateContainer = other.gameObject.GetComponent<HandStateContainer>();
		if (stateContainer != null)
		{
			currentHands.Remove(stateContainer);
			currentHands.Insert(0, stateContainer);
			stateContainer.SetInInventory(true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		HandStateContainer stateContainer = other.gameObject.GetComponent<HandStateContainer>();
		if (stateContainer != null)
		{
			currentHands.Remove(stateContainer);
			stateContainer.SetInInventory(false);
		}
	}
}

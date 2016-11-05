using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

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
		obj.GetComponent<BoxCollider>().enabled = true;

		GetComponent<SatchelViewController>().DisplaySatchelContents(inventory);
	}

	public void TryGrabItem(HoldableObject obj)
	{
		if (currentHands.Count != 0)
			currentHands[0].PutItemInHand(obj);
	}

	public void TryRemoveItem(HoldableObject holdableObject)
	{
		if(inventory.Contains(holdableObject))
			inventory.Remove(holdableObject);
		GetComponent<SatchelViewController>().DisplaySatchelContents(inventory);
	}

	public void SummonItemType(SummonableItems itemType)
	{
		Debug.Log("Summon " + inventory.ValuesToString());
		foreach (HoldableObject holdableObject in inventory)
		{
			if (holdableObject.itemType == itemType)
			{
				TryGrabItem(holdableObject);
				TryRemoveItem(holdableObject);
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
			if (currentHands.Count == 0)
			{
				GetComponent<SatchelViewController>().DisplaySatchelContents(inventory);
				GetComponent<BoxCollider>().size = new Vector3(1.5f, GetComponent<BoxCollider>().size.y, GetComponent<BoxCollider>().size.z);
			}
			currentHands.Remove(stateContainer);
			currentHands.Insert(0, stateContainer);
		}
	}

	void OnTriggerExit(Collider other)
	{
		HandStateContainer stateContainer = other.gameObject.GetComponent<HandStateContainer>();
		if (stateContainer != null)
		{
			if (currentHands.Count == 1)
			{
				GetComponent<SatchelViewController>().HideSatchelContents(inventory);
				GetComponent<BoxCollider>().size = new Vector3(.7f, GetComponent<BoxCollider>().size.y, GetComponent<BoxCollider>().size.z);
			}

			currentHands.Remove(stateContainer);
		}
	}
}

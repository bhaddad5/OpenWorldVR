using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SatchelViewController : MonoBehaviour {

	public void DisplaySatchelContents(List<HoldableObject> inventoryToDisplay)
	{
		float sidewaysOffsetStep = 0.3f;
		float itemNum = 0f;
		foreach (HoldableObject item in inventoryToDisplay)
		{
			float currentItemOffset = (-((inventoryToDisplay.Count - 1f)/2f) + itemNum) * sidewaysOffsetStep;
			item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			item.transform.localEulerAngles = new Vector3(0, -90f, 0);
			item.transform.localPosition = new Vector3(-0.5f, 0f, currentItemOffset);
			item.gameObject.SetActive(true);
			itemNum++;
		}
	}

	public void HideSatchelContents(List<HoldableObject> inventoryToHide)
	{
		foreach (HoldableObject item in inventoryToHide)
		{
			item.gameObject.SetActive(false);
		}
	}
}

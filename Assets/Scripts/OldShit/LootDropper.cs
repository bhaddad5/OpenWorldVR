using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootDropper : MonoBehaviour {

	[System.Serializable]
	public class LootRange
	{
		public GameObject droppedObject;
		public int minNumber;
		public int maxNumber;
	}

	public List<LootRange> loot = new List<LootRange>();

	public void DropLoot()
	{
		foreach (LootRange lootRange in loot)
		{
			int DropNumber = Random.Range(lootRange.minNumber, lootRange.maxNumber);
			for (int i = 0; i < DropNumber; i++)
			{
				GameObject newLoot = Instantiate(lootRange.droppedObject);
				Vector3 newLocalPos = Helpers.GetRandomPosInBounds(.3f, .3f, .3f);
				newLoot.transform.position = transform.TransformPoint(newLocalPos);
			}
		}
	}

	
}

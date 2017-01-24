using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoldDisplayScript : MonoBehaviour
{
	private int displayedGold = 0;

	// Update is called once per frame
	void Update ()
	{
		if (displayedGold != Singletons.PlayerStatsContainer().GetGold())
		{
			GetComponent<Text>().text = "" + Singletons.PlayerStatsContainer().GetGold();
		}
	}
}

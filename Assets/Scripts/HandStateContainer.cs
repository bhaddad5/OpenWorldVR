using UnityEngine;
using System.Collections;

public class HandStateContainer : MonoBehaviour {

	public GameObject CurrentlyHeldObject;

	public void CheckWandAndExecuteSpell(VoiceDetector.VoiceActions action)
	{
		if (CurrentlyHeldObject != null && CurrentlyHeldObject.GetComponent<WandController>() != null)
		{
			CurrentlyHeldObject.GetComponent<WandController>().ExecuteSpell(action);
		}
	}
}

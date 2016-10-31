using UnityEngine;
using System.Collections;

public class SpellExecutor : MonoBehaviour
{

	public void ExecuteSpell(VoiceDetector.VoiceActions action)
	{
		if(action == VoiceDetector.VoiceActions.Fireball || action == VoiceDetector.VoiceActions.SpellShield)
			ExecuteWandSpell(action);
	}

	private void ExecuteWandSpell(VoiceDetector.VoiceActions action)
	{
		if(Singletons.LeftHand() != null)
			Singletons.LeftHand().GetComponent<HandStateContainer>().CheckWandAndExecuteSpell(action);
		if(Singletons.RightHand() != null)
			Singletons.RightHand().GetComponent<HandStateContainer>().CheckWandAndExecuteSpell(action);
	}
}

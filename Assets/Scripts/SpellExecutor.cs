using UnityEngine;
using System.Collections;

public class SpellExecutor : MonoBehaviour
{

	public void ExecuteSpell(VoiceDetector.SpellActions action)
	{
		if(action == VoiceDetector.SpellActions.Fireball || action == VoiceDetector.SpellActions.SpellShield)
			ExecuteWandSpell(action);
	}

	private void ExecuteWandSpell(VoiceDetector.SpellActions action)
	{
		if(Singletons.LeftHand() != null)
			Singletons.LeftHand().GetComponent<HandStateContainer>().CheckWandAndExecuteSpell(action);
		if(Singletons.RightHand() != null)
			Singletons.RightHand().GetComponent<HandStateContainer>().CheckWandAndExecuteSpell(action);
	}
}

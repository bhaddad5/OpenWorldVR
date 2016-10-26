using UnityEngine;
using System.Collections;

public class SpellExecutor : MonoBehaviour
{
	public HandController leftHand;
	public HandController rightHand;
	public BodyController body;

	public void ExecuteSpell(VoiceDetector.VoiceActions action)
	{
		if(action == VoiceDetector.VoiceActions.Fireball || action == VoiceDetector.VoiceActions.SpellShield)
			ExecuteWandSpell(action);
		if (false)
			ExecuteBodySpell(action);
	}

	private void ExecuteWandSpell(VoiceDetector.VoiceActions action)
	{
		if (leftHand != null)
			leftHand.CheckWandAndExecuteSpell(action);
		if (rightHand != null)
			rightHand.CheckWandAndExecuteSpell(action);
	}

	private void ExecuteBodySpell(VoiceDetector.VoiceActions action)
	{
		body.ExecuteSpell(action);
	}
}

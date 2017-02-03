using UnityEngine;
using System.Collections;

public class SpellExecutor : MonoBehaviour
{
	public WandController wand;

	public void ExecuteSpell(VoiceDetector.SpellActions action)
	{
		if(action == VoiceDetector.SpellActions.Fireball || action == VoiceDetector.SpellActions.SpellShield
			|| action == VoiceDetector.SpellActions.Laser)
			wand.ExecuteSpell(action);
	}
}

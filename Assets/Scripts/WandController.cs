﻿using UnityEngine;
using System.Collections;

public class WandController : MonoBehaviour
{
	public GameObject fireball;
	public GameObject spellShield;

	public void ExecuteSpell(VoiceDetector.VoiceActions action)
	{
		if (action == VoiceDetector.VoiceActions.Fireball)
			ExecuteFireball();
		if (action == VoiceDetector.VoiceActions.SpellShield)
			ExecuteSpellShield();
	}

	private void ExecuteFireball()
	{
		GameObject newFireball = Instantiate(fireball);
		newFireball.transform.position = transform.parent.position + transform.parent.forward;
		newFireball.GetComponent<FireballController>().SetMoveDir(transform.parent.forward);
	}

	private void ExecuteSpellShield()
	{
		GameObject newSpellShield = Instantiate(spellShield);
		newSpellShield.transform.position = transform.parent.position;
		newSpellShield.transform.rotation = transform.parent.rotation;
		newSpellShield.transform.SetParent(transform);
	}
}

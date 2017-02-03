using UnityEngine;
using System.Collections;

public class WandController : MonoBehaviour
{
	public GameObject fireball;
	public GameObject laser;
	public GameObject spellShield;

	public GameObject spellStartPoint;

	public void ExecuteSpell(VoiceDetector.SpellActions action)
	{
		if (action == VoiceDetector.SpellActions.Fireball)
			ExecuteFireball();
		if (action == VoiceDetector.SpellActions.Laser)
			ExecuteLaser();
		if (action == VoiceDetector.SpellActions.SpellShield)
			ExecuteSpellShield();
	}

	private void ExecuteFireball()
	{
		GameObject newFireball = Instantiate(fireball);
		newFireball.transform.position = spellStartPoint.transform.position + spellStartPoint.transform.forward;
		newFireball.GetComponent<FireballController>().SetControllingStaff(this.transform);
	}

	private void ExecuteLaser()
	{
		GameObject newLaser = Instantiate(laser);
		newLaser.transform.position = spellStartPoint.transform.position;
		newLaser.transform.rotation = spellStartPoint.transform.rotation;
		newLaser.GetComponent<LaserController>().SetControllingStaff(this.transform);
	}

	private void ExecuteSpellShield()
	{
		GameObject newSpellShield = Instantiate(spellShield);
		newSpellShield.transform.position = transform.parent.position;
		newSpellShield.transform.rotation = transform.parent.rotation;
		newSpellShield.transform.SetParent(transform);
	}
}

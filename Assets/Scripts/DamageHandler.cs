using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageHandler : MonoBehaviour
{
	public int HP;

	public void TakeDamage(int damage)
	{
		GameObject damageText = Instantiate(Singletons.GlobalPrefabs().DamageText);
		damageText.transform.position = transform.position + new Vector3(0, 2f, 0);
		damageText.transform.LookAt(Camera.main.transform.position);
		Text text = damageText.transform.GetChild(0).GetComponent<Text>();

		if (damage == 0)
		{
			text.text = "BLOCKED";
		}
		else text.text = "HIT -" + damage;


		HP -= damage;
		if (HP <= 0)
			Destroy(gameObject);
	}
}

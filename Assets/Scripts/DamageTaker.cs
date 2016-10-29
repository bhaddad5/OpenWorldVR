using UnityEngine;
using System.Collections;

public class DamageTaker : MonoBehaviour
{
	public int HP;

	public void TakeDamage(int damage)
	{
		HP -= damage;
		if(HP <= 0)
			Destroy(gameObject);
	}
}

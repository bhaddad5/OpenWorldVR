using UnityEngine;
using System.Collections;

public class SpellShieldController : MonoBehaviour
{

	private float startTime;
	private float duration = 5f;

	// Use this for initialization
	void Start ()
	{
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (startTime + duration <= Time.time)
		{
			Destroy(gameObject);
		}
	}
}

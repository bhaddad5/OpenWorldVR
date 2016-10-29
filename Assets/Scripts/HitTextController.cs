using UnityEngine;
using System.Collections;

public class HitTextController : MonoBehaviour
{
	private float fadeoutTime = 1f;
	private float startTime;

	// Use this for initialization
	void Start ()
	{
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= startTime + fadeoutTime)
		{
			Destroy(gameObject);
		}
	}
}

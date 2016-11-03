using UnityEngine;
using System.Collections;

public class SatchelViewController : MonoBehaviour {

	private Vector3 satchelOffset = new Vector3(-0.1f, -0.7f, 0f);
	
	// Update is called once per frame
	void Update ()
	{
		transform.localPosition = Camera.main.transform.localPosition + satchelOffset;
	}
}

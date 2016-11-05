using UnityEngine;
using System.Collections;

public class waistlineViewController : MonoBehaviour {

	private Vector3 waistlineOffset = new Vector3(0f, -0.9f, -0.1f);
	private float angleJumpDiff = 90f;
	
	// Update is called once per frame
	void Update ()
	{
		transform.localPosition = Camera.main.transform.localPosition + waistlineOffset;

		Vector3 localAngles = transform.localEulerAngles;
		Vector3 camAngles = Camera.main.transform.localEulerAngles;
		if (Mathf.Abs(localAngles.y - camAngles.y) >= angleJumpDiff)
		{
			transform.localEulerAngles = new Vector3(localAngles.x, camAngles.y, localAngles.z);
		}
	}
}

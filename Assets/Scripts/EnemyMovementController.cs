using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour
{
	private float EnemyMoveSpeed = 0.05f;
	private float EnemyPlayerDetectionRange = 15.0f;
	private Vector3 heightOffset;
	private bool PlayerDetected = false;

	// Use this for initialization
	void Start ()
	{
		RaycastHit hit;
		Physics.Raycast(new Ray(transform.position, Vector3.down), out hit);
		heightOffset = new Vector3(0, hit.distance, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Magnitude(Camera.main.transform.position - transform.position) < EnemyPlayerDetectionRange)
		{
			PlayerDetected = true;
		}

		if (PlayerDetected)
		{
			Vector3 targetXZ = Vector3.MoveTowards(transform.position, Camera.main.transform.position, EnemyMoveSpeed);
			RaycastHit hit;
			if (Physics.Raycast(new Ray(targetXZ, Vector3.down), out hit))
			{
				transform.position = hit.point + heightOffset;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour
{
	private float EnemyMoveSpeed = 0.03f;
	private float EnemyPlayerDetectionRange = 15.0f;
	private float EnemyMinDistance = 1.0f;
	private Vector3 heightOffset;
	private bool PlayerDetected = false;
	private bool MovingToPlayer = false;

	// Use this for initialization
	void Start ()
	{
		RaycastHit hit;
		Physics.Raycast(new Ray(transform.position, Vector3.down), out hit);
		heightOffset = new Vector3(0, hit.distance, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		float DistFromPlayer = Vector3.Magnitude(Camera.main.transform.position - transform.position);
		if (DistFromPlayer < EnemyPlayerDetectionRange)
		{
			PlayerDetected = true;
			MovingToPlayer = true;
		}

		if (DistFromPlayer <= EnemyMinDistance)
		{
			MovingToPlayer = false;
		}

		if (PlayerDetected && MovingToPlayer)
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

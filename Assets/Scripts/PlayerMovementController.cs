using UnityEngine;
using System.Collections;
using Valve.VR;

public class PlayerMovementController : MonoBehaviour
{
	public GameObject MovementTracker;

	private bool projectingMovement = false;
	private float moveSpeed = 0.2f;
	private float maxMoveDist = 20.0f;
	private float baseMoveDist = 0f;
	private float distCanMove = 0f;
	private RaycastHit currentIntendedMovePoint;
	private Vector3 currentActualMovePoint;
	private bool lookingAtValidPoint = false;
	
	// Update is called once per frame
	void Update ()
	{
		distCanMove += moveSpeed;
		distCanMove = Mathf.Clamp(distCanMove, 0, maxMoveDist);

		if (projectingMovement && currentIntendedMovePoint.transform != null &&
		    currentIntendedMovePoint.transform.GetComponent<WalkingSurface>() != null)
		{
			WalkingSurface hitSurface = currentIntendedMovePoint.transform.GetComponent<WalkingSurface>();
			MovementTracker.transform.position = currentIntendedMovePoint.point;
			currentActualMovePoint = hitSurface.GetMovePos(currentIntendedMovePoint.point, transform.position);
			lookingAtValidPoint = true;
			MovementTracker.SetActive(true);
		}
		else
		{
			lookingAtValidPoint = false;
			MovementTracker.SetActive(false);
		}
	}

	public bool TryToBeginMove()
	{
		if (projectingMovement)
			return false;
		projectingMovement = true;
		return true;
	}

	public void UpdateMovePoint(RaycastHit hit)
	{
		currentIntendedMovePoint = hit;
	}

	public void ExecuteMove()
	{
		if (lookingAtValidPoint)
		{
			Vector3 cameraOffset = new Vector3(Camera.main.transform.localPosition.x, 0, Camera.main.transform.localPosition.z);
			Singletons.CameraRig().transform.position = currentActualMovePoint - cameraOffset;
		}
		projectingMovement = false;
		distCanMove = baseMoveDist;
		MovementTracker.SetActive(false);
	}
}

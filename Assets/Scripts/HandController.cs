using UnityEngine;
using System.Collections;
using Valve.VR;

public class HandController : MonoBehaviour
{
	public MovementController movementController;
	public GameObject movementTracker;
	public GameObject CameraRig;

	private SteamVR_Controller.Device input;
	private bool moving = false;
	private float moveSpeed = 0.2f;
	private float maxMoveDist = 20.0f;
	private float maxVerticalJump = 10f;
	private float distMoved = 0f;
	private Vector3 theoreticalMovePos;

	// Use this for initialization
	void Start () {
		CameraRig = GameObject.Find("[CameraRig]");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		GetMoveInput();
		if (moving)
		{
			Vector3 controllerForward = new Vector3(transform.forward.x, 0f, transform.forward.z);
			theoreticalMovePos = Camera.main.transform.position + (controllerForward * distMoved);

			RaycastHit hit;
			if(Physics.Raycast(new Ray(theoreticalMovePos + new Vector3(0, maxVerticalJump, 0), Vector3.down), out hit, 1000f, 1 << 8))
			{
				movementTracker.transform.position = hit.point;
			}

			if (distMoved < maxMoveDist)
				distMoved += moveSpeed;
			else distMoved = maxMoveDist;
		}
	}

	private void GetMoveInput()
	{
		input = SteamVR_Controller.Input((int)GetComponentInParent<SteamVR_TrackedObject>().index);

		if (input.GetPressDown(EVRButtonId.k_EButton_SteamVR_Touchpad))
		{
			movementController.NewMove();
			moving = true;
		}

		if (input.GetPressUp(EVRButtonId.k_EButton_SteamVR_Touchpad) && moving)
		{
			Vector3 cameraOffset = new Vector3(Camera.main.transform.localPosition.x, 0, Camera.main.transform.localPosition.z);
			CameraRig.transform.position = movementTracker.transform.position - cameraOffset;
			moving = false;
			distMoved = 0f;
		}
	}

	public void StopMove()
	{
		if (moving)
		{
			moving = false;
			distMoved = 0f;
		}
	}
}

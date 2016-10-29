using UnityEngine;
using System.Collections;
using Valve.VR;

public class HandController : MonoBehaviour
{
	public MovementController movementController;
	public GameObject movementTracker;
	public GameObject CurrentlyHeldObject;

	private SteamVR_Controller.Device input;
	private bool moving = false;
	private float moveSpeed = 0.2f;
	private float maxMoveDist = 20.0f;
	private float maxVerticalJump = 2f;
	private float distMoved = 1f;
	private Vector3 theoreticalMovePos;
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		GetMoveInput();
		if (moving)
		{
			Vector3 controllerForward = new Vector3(transform.forward.x, 0f, transform.forward.z);
			theoreticalMovePos = Camera.main.transform.position + (controllerForward * distMoved);

			RaycastHit hit;
			if(Physics.Raycast(new Ray(theoreticalMovePos, Vector3.down), out hit, 1000f, 1 << 8))
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
			movementTracker.SetActive(true);
		}

		if (input.GetPressUp(EVRButtonId.k_EButton_SteamVR_Touchpad) && moving)
		{
			Vector3 cameraOffset = new Vector3(Camera.main.transform.localPosition.x, 0, Camera.main.transform.localPosition.z);
			Singletons.CameraRig().transform.position = movementTracker.transform.position - cameraOffset;
			moving = false;
			distMoved = 1f;
			movementTracker.SetActive(false);
		}
	}

	public void StopMove()
	{
		if (moving)
		{
			moving = false;
			distMoved = 1f;
			movementTracker.SetActive(false);
		}
	}

	public void CheckWandAndExecuteSpell(VoiceDetector.VoiceActions action)
	{
		if (CurrentlyHeldObject != null && CurrentlyHeldObject.GetComponent<WandController>() != null)
		{
			CurrentlyHeldObject.GetComponent<WandController>().ExecuteSpell(action);
		}
	}
}

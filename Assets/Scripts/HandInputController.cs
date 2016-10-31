using UnityEngine;
using System.Collections;
using Valve.VR;

public class HandInputController : MonoBehaviour
{
	private SteamVR_Controller.Device input;
	private bool currentlyMovingPlayer = false;
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		GetMoveInput();
	}

	private void GetMoveInput()
	{
		input = SteamVR_Controller.Input((int)GetComponentInParent<SteamVR_TrackedObject>().index);

		if (input.GetPressDown(EVRButtonId.k_EButton_SteamVR_Touchpad))
		{
			currentlyMovingPlayer = Singletons.PlayerMovementController().TryToBeginMove();
		}

		if (currentlyMovingPlayer)
		{
			UpdateCurrentMovePoint();
		}

		if (input.GetPressUp(EVRButtonId.k_EButton_SteamVR_Touchpad))
		{
			if (currentlyMovingPlayer)
			{
				Singletons.PlayerMovementController().ExecuteMove();
				currentlyMovingPlayer = false;
			}
			Singletons.PlayerMovementController().EndMovement();
		}
	}

	private void UpdateCurrentMovePoint()
	{
		RaycastHit hit;
		Physics.Raycast(new Ray(transform.position, transform.forward), out hit, 100f, 1<<8);
		Singletons.PlayerMovementController().UpdateMovePoint(hit);
	}
}

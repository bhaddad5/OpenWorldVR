using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Valve.VR;

public class HandInputController : MonoBehaviour
{
	private SteamVR_Controller.Device input;
	private List<IHandInputReciever> recievers = new List<IHandInputReciever>();
	private bool triggerDown = false;
	private bool touchPadDown = false;

	void Start()
	{
		recievers = GetComponentsInChildren<IHandInputReciever>().ToList();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		input = SteamVR_Controller.Input((int)GetComponentInParent<SteamVR_TrackedObject>().index);

		GetClickInput();
		GetTouchpadInput();
	}

	private void GetClickInput()
	{
		if (input.GetPressDown(EVRButtonId.k_EButton_SteamVR_Trigger))
		{
			triggerDown = true;
			foreach (var reciever in recievers)
				reciever.TriggerDown();
		}
		if (input.GetPressUp(EVRButtonId.k_EButton_SteamVR_Trigger))
		{
			triggerDown = false;
			foreach (var reciever in recievers)
				reciever.TriggerUp();
		}
		if (triggerDown)
		{
			foreach (var reciever in recievers)
				reciever.TriggerHold();
		}
	}

	private void GetTouchpadInput()
	{
		if (input.GetPressDown(EVRButtonId.k_EButton_SteamVR_Touchpad))
		{
			touchPadDown = true;
			foreach (var reciever in recievers)
				reciever.TouchPadDown();
		}
		if (input.GetPressUp(EVRButtonId.k_EButton_SteamVR_Touchpad))
		{
			touchPadDown = false;
			foreach (var reciever in recievers)
				reciever.TouchPadUp();
		}
		if (touchPadDown)
		{
			foreach (var reciever in recievers)
				reciever.TouchPadHold();
		}
	}
}

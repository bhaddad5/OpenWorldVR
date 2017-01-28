using UnityEngine;
using System.Collections;

public static class Singletons
{
	private static GlobalPrefabs globalPrefabs;
	private static Transform cameraRig;
	private static GameObject playerBody;
	private static VoiceDetector voiceDetector;
	private static SpellExecutor spellExecutor;
	private static HandInputController leftHand;
	private static HandInputController rightHand;

	public static GlobalPrefabs GlobalPrefabs()
	{
		if (globalPrefabs == null)
			globalPrefabs = GameObject.Find("GlobalPrefabs").GetComponent<GlobalPrefabs>();
		return globalPrefabs;
	}

	public static Transform CameraRig()
	{
		if (cameraRig == null)
			cameraRig = GameObject.Find("[CameraRig]").transform;
		return cameraRig;
	}

	public static GameObject PlayerBody()
	{
		if (playerBody == null)
			playerBody = CameraRig().FindChild("Camera (eye)").FindChild("PlayerBody").gameObject;
		return playerBody;
	}

	public static VoiceDetector VoiceDetector()
	{
		if (voiceDetector == null)
			voiceDetector = GameObject.Find("VoiceDetector").GetComponent<VoiceDetector>();
		return voiceDetector;
	}

	public static SpellExecutor SpellExecutor()
	{
		if (spellExecutor == null)
			spellExecutor = GameObject.Find("SpellExecutor").GetComponent<SpellExecutor>();
		return spellExecutor;
	}

	public static HandInputController LeftHand()
	{
		if (leftHand == null)
			leftHand = CameraRig().FindChild("Controller (left)").GetComponent<HandInputController>();
		return leftHand;
	}

	public static HandInputController RightHand()
	{
		if (rightHand == null)
			rightHand = CameraRig().FindChild("Controller (right)").GetComponent<HandInputController>();
		return rightHand;
	}
}

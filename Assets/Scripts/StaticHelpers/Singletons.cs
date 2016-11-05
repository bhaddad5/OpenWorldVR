using UnityEngine;
using System.Collections;

public static class Singletons
{
	private static GlobalPrefabs globalPrefabs;
	private static Transform cameraRig;
	private static PlayerMovementController playerMovementController;
	private static VoiceDetector voiceDetector;
	private static SpellExecutor spellExecutor;
	private static HandInputController leftHand;
	private static HandInputController rightHand;
	private static InventoryController inventoryController;
	private static PlayerStatsContainer playerStatsContainer;

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

	public static PlayerMovementController PlayerMovementController()
	{
		if (playerMovementController == null)
			playerMovementController = CameraRig().FindChild("Camera (eye)").FindChild("PlayerBody").GetComponent<PlayerMovementController>();
		return playerMovementController;
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

	public static InventoryController InventoryController()
	{
		if (inventoryController == null)
			inventoryController = CameraRig().FindChild("Inventory").FindChild("satchel").GetComponent<InventoryController>();
		return inventoryController;
	}

	public static PlayerStatsContainer PlayerStatsContainer()
	{
		if (playerStatsContainer == null)
			playerStatsContainer = GameObject.Find("PlayerStatsContainer").GetComponent<PlayerStatsContainer>();
		return playerStatsContainer;
	}
}

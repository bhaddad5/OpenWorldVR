using UnityEngine;
using System.Collections;

public static class Singletons
{
	private static GlobalPrefabs globalPrefabs;
	private static Transform cameraRig;

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

}

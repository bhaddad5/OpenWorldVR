using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorScript {

	[MenuItem("Game/SetUpEnvironments")]
	public static void SetUpEnvironmentObjects()
	{
		EnvironmentSetupHelper[] helpers = GameObject.FindObjectsOfType<EnvironmentSetupHelper>();

		foreach (EnvironmentSetupHelper helper in helpers)
		{
			helper.SetupEnvironment();
		}
	}
}

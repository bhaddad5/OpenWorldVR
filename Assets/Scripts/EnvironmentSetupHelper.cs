using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSetupHelper : MonoBehaviour
{
	public Material environmentMaterial;

	public void SetupEnvironment()
	{
		foreach (var mr in gameObject.GetComponentsInChildren<MeshRenderer>())
		{
			SetupEnvironmentObject(mr);
		}
	}

	private void SetupEnvironmentObject(MeshRenderer objToSetUp)
	{
		if (objToSetUp != null)
		{
			objToSetUp.material = environmentMaterial;
			objToSetUp.gameObject.AddComponent<MeshCollider>();
			objToSetUp.gameObject.AddComponent<DamageReciever>();
			objToSetUp.gameObject.AddComponent<Rigidbody>();
			objToSetUp.gameObject.GetComponent<Rigidbody>().useGravity = false;
			objToSetUp.gameObject.GetComponent<Rigidbody>().isKinematic = true;

			if (objToSetUp.name.ToLowerInvariant().Contains("_w"))
			{
				objToSetUp.gameObject.AddComponent<WalkingSurface>();
				objToSetUp.GetComponent<MeshRenderer>().enabled = false;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public static class Helpers {

	public static T GetComponentInAllParents<T>(this GameObject obj)
		where T : class
	{
		T result = obj.GetComponent<T>();
		if (result != null)
			return result;
		else if (obj.transform.parent == null)
			return null;
		else return GetComponentInAllParents<T>(obj.transform.parent.gameObject);
	}
}

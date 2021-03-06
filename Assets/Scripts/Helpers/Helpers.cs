﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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

	public static Vector3 VectorTo(this Vector3 from, Vector3 to)
	{
		return to - from;
	}

	public static Vector3 setY(this Vector3 readOnly, float newY)
	{
		readOnly = new Vector3(readOnly.x, newY, readOnly.z);
		return readOnly;
	}

	public static string ValuesToString<T>(this List<T> list)
	{
		string result = "";
		foreach (T t in list)
		{
			result = result + t.ToString() + ",";
		}
		return result;
	}

	public static Vector3 GetRandomPosInBounds(float maxX, float maxY, float maxZ)
	{
		return new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), Random.Range(-maxZ, maxZ));
	}

	public static List<Transform> GetAllChildren(this Transform trans)
	{
		List<Transform> allChildren = new List<Transform>();
		for (int i = 0; i < trans.childCount; i++)
		{
			allChildren.Add(trans.GetChild(i));
		}
		return allChildren;
	}
}

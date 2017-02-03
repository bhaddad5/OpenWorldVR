using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointLoader : MonoBehaviour
{

	public int currSavePoint = 0;
	public List<SavePoint> savePoints = new List<SavePoint>();

	// Use this for initialization
	void Start ()
	{
		Singletons.CameraRig().transform.position = savePoints[currSavePoint].transform.position;
	}
}

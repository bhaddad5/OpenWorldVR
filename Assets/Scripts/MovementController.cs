using UnityEngine;
using System.Collections;
using Valve.VR;

public class MovementController : MonoBehaviour
{
	public HandController left;
	public HandController right;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void NewMove()
	{
		left.StopMove();
		right.StopMove();
	}
}

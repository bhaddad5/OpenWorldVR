using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MovementHandler : MonoBehaviour, IHandInputReciever
{
	public GameObject moveIndicatorPrefab;

	private float moveMetersPerSec = 15f;
	private float maxMoveDist = 8.0f;

	private GameObject spawnedMoveIndicator;
	private float currDistToMove = 0f;
	private float distMovedSoFar = 0f;
	private float timeAtStartOfMove = 0f;
	private Vector3 currentMovePoint;

	// Use this for initialization
	void Start ()
	{
		spawnedMoveIndicator = Instantiate(moveIndicatorPrefab);
		spawnedMoveIndicator.GetComponent<ParticleSystem>().startColor = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast(new Ray(transform.position, transform.forward), out hit, maxMoveDist) && hit.transform.GetComponent<WalkingSurface>() != null)
		{
			currentMovePoint = hit.point;
			spawnedMoveIndicator.SetActive(true);
			spawnedMoveIndicator.transform.position = currentMovePoint;
			currDistToMove = hit.distance;
		}
		else
		{
			spawnedMoveIndicator.SetActive(false);
		}
	}

	public void TouchPadDown()
	{
		timeAtStartOfMove = Time.time;
	}

	public void TouchPadHold()
	{
		distMovedSoFar = (Time.time - timeAtStartOfMove)*moveMetersPerSec;
		Color indicatorColor = new Color(0f, 0f, 0f);
		indicatorColor.g = distMovedSoFar/currDistToMove;
		indicatorColor.b = 1f - distMovedSoFar / currDistToMove;
		spawnedMoveIndicator.GetComponent<ParticleSystem>().startColor = indicatorColor;
	}

	public void TouchPadUp()
	{
		if (spawnedMoveIndicator.activeInHierarchy && distMovedSoFar >= currDistToMove)
		{
			ExecuteMove();
		}
		spawnedMoveIndicator.GetComponent<ParticleSystem>().startColor = Color.blue;
	}

	public void ExecuteMove()
	{
		Bounds oldBounds = Singletons.PlayerBody().GetComponent<BoxCollider>().bounds;

		Vector3 cameraOffset = new Vector3(Camera.main.transform.localPosition.x, 0, Camera.main.transform.localPosition.z);
		Singletons.CameraRig().transform.position = currentMovePoint - cameraOffset;

		Bounds newBounds = Singletons.PlayerBody().GetComponent<BoxCollider>().bounds;
		newBounds.Encapsulate(oldBounds);
		GameObject g = new GameObject("PlayerBody");
		g.transform.position = newBounds.center;
		g.AddComponent<Rigidbody>();
		g.GetComponent<Rigidbody>().useGravity = false;
		g.GetComponent<Rigidbody>().isKinematic = true;
		g.AddComponent<BoxCollider>();
		g.GetComponent<BoxCollider>().size = newBounds.extents * 2;

		StartCoroutine(DeleteTempBox(g));
	}

	public IEnumerator DeleteTempBox(GameObject g)
	{
		yield return null;
		Destroy(g);
	}

	public void TriggerDown(){}
	public void TriggerUp(){}
	public void TriggerHold(){}
}

using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour
{
	public Vector3 movementDirection;
	private float movementSpeed = 0.4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = transform.position + movementDirection.normalized*movementSpeed;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour, IDamageController
{
	private float lifespan = 5f;
	private float startTime;
	private float damageTimeout = 0.2f;
	private float lastDamageDealtTime;
	private Transform controllingStaff;
	private GameObject laserVis;
	private GameObject laserDmg;

	// Use this for initialization
	void Start ()
	{
		transform.SetParent(controllingStaff);
		startTime = Time.time;
		laserVis = transform.FindChild("LaserVis").gameObject;
		laserDmg = transform.FindChild("LaserDmg").gameObject;
		laserDmg.GetComponent<DamageDealer>().SetDamageController(this);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, hit.distance / 2 + 0.5f);
		}
		else
		{
			transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1000f);
		}

		if (!laserDmg.activeInHierarchy && Time.time > lastDamageDealtTime + damageTimeout)
		{
			laserDmg.SetActive(true);
		}

		if (startTime + lifespan < Time.time)
		{
			Destroy(gameObject);
		}
	}

	public void SetControllingStaff(Transform staff)
	{
		controllingStaff = staff;
	}

	public void HandleDamageDealt()
	{
		laserDmg.SetActive(false);
		lastDamageDealtTime = Time.time;
	}
}

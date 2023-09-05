using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public int damage;
	public bool splashDamage = false;
	public float splashRadius = 0;


	private Vector3 oldPos;
	private float distanceTraveled = 0;
	
	private Vector3 shootDir;


	private void Start()
	{
		oldPos = transform.position;
	}

	private void Update()
	{				
		transform.position += shootDir * Time.deltaTime * 50f;
		CalculateDistance();
		if(distanceTraveled >= 15)
		{
			Destroy(this.gameObject);
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		var enemy = other.gameObject.GetComponent<Entites>();
		if (other.gameObject.tag == "Enemy")
		{
			if (splashDamage)
			{
				CheckForEnemies();
			}

			else
			{
				enemy.TakeDamage(damage);
			}

			Destroy(this.gameObject);
		}
	}
	public void SetUp(Vector3 shootDir)
	{
		this.shootDir = shootDir;

	}

	private void CheckForEnemies()
	{
		Collider[] colliders = Physics.OverlapSphere(this.transform.position, splashRadius);
		foreach (Collider col in colliders)
		{
			if (col.gameObject.GetComponent<Entites>())
			{
				col.gameObject.GetComponent<Entites>().TakeDamage(damage);
				Debug.Log(col.name);
			}
		}
	}
	private void CalculateDistance()
	{
		Vector3 distanceVector = transform.position -oldPos;
		float distanceThisFrame = distanceVector.magnitude;
		distanceTraveled += distanceThisFrame;
		oldPos = transform.position;
	}
	

}

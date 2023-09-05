using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;

public class Tower : MonoBehaviour,IHealth
{
	[Header("Info")]
	public float range;
	public int cost;
	private int health;
	private List<Entites> entities = new List<Entites>();
	private Entites currentEntity;
	public bool beamTower;

	[Header("Attacking")]
	public float arrackRate;
	public bool canAttack;
	public Transform projectileSpawnpos;
	public GameObject? projectilePrefab;
	public int attackPower;

	public LineRenderer? beamProjectile;


	private float fireCooldown;
	//private Collider collider;

	
	public static event Action TowerDestroyed;

	private void Start()
	{
		canAttack = true;
		health = 100;
		//collider = GetComponent<Collider>();
					 	
	}
	private void Update()
	{

		SetTarget();
		if (beamTower )
		{
			if(currentEntity != null)
			{
				LookAt();
				FireBeam();
				DoDamage();
			}
			else
			ClearBeam();
		}
		else
		{
			LookAt();
			Attack();
		}
		
		
	}


	private void Attack()
	{
		fireCooldown -= Time.deltaTime;
		if (currentEntity != null && fireCooldown <= 0)
		{
			fireCooldown = arrackRate;
			ShootProjectile();
		}
	}
	private void CleanTargets()
	{
		entities.RemoveAll(e => e == null);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			entities.Add(other.GetComponent<Entites>());

		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			entities.Remove(other.GetComponent<Entites>());
		}
	}

	private void LookAt()
	{
		if (currentEntity != null)
		{
			projectileSpawnpos.rotation = Quaternion.LookRotation((projectileSpawnpos.transform.position - currentEntity.transform.position).normalized);
		}
		else
		{
			projectileSpawnpos.rotation = Quaternion.identity;
		}
	}

	private void SetTarget()
	{
		if (entities.Count == 0)
		{
			currentEntity = null;
			return;
		}
		CleanTargets();
		var entity = entities.FirstOrDefault();

		if (entity != null)
		{
			currentEntity = entity;
		}
	}

	private void ShootProjectile()
	{
		
			GameObject projectileTransform = Instantiate(projectilePrefab, projectileSpawnpos.position, Quaternion.identity);

			Vector3 shootDir = (currentEntity.transform.position - projectileSpawnpos.position).normalized;
			projectileTransform.GetComponent<Projectile>().damage = attackPower;

			projectileTransform.GetComponent<Projectile>().SetUp(shootDir);
		
	}

	public void FireBeam()
	{
		beamProjectile.SetPosition(0, projectileSpawnpos.transform.position);
		beamProjectile.SetPosition(1, currentEntity.transform.position);
	}
	public void ClearBeam()
	{
		beamProjectile.SetPosition(0, projectileSpawnpos.transform.position);
		beamProjectile.SetPosition(1, projectileSpawnpos.transform.position);
	}
	public void DoDamage()
	{
		fireCooldown -= Time.deltaTime;
		if (currentEntity != null && fireCooldown <= 0)
		{
			fireCooldown = arrackRate;
			currentEntity.GetComponent<Entites>().TakeDamage(attackPower);
		}
	}

	public void TakeDamage(int damage)
	{
		health -= damage;

		if(health <= 0)
		{		
			Debug.Log(this.name + "Destroyed");
					
			Destroy(this.gameObject);
			return;
		}
	}
	private void OnDisable()
	{
		TowerDestroyed?.Invoke();
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Splines;
using UnityEngine.UI;


public class Entites : MonoBehaviour, IHealth
{
	[Header("Info")]
	public string Name;
	public int Health;
	public int AttackDamage;
	public float AttackRate;
	public int coinsAmount;
	public float speed;

	public Enemy enemyData;
	public bool isSlowed;
	public Canvas hpCanvas;

	public bool isSplined;

	public Image healthBar;
#nullable enable
	public Transform spawnPos;

	public Spline spline;
#nullable enable
	public SplineAnimate splineScript;
#nullable enable
	private NavMeshAgent nav;

	private int healthAmount;

	private Tower[] towers;
#nullable enable
	private Tower attTower;
	private float attackCd;
	private Rigidbody rb;
	private bool arrivedTower;
#nullable enable
	private AudioSource audioSource;
#nullable enable
	private AudioClip audioClip;
#nullable enable
	[SerializeField] Animator animator;
    private void Awake()
	{
		
		if (isSplined)
		{
			splineScript = GetComponent<SplineAnimate>();
			splineScript.Duration = enemyData.timeToComplete;

		}
		else
			nav = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
    }
	private void Start()
	{
		//spline = splineScript.splineContainer.GetComponent<Spline>();
		arrivedTower = false;
		audioSource = GetComponent<AudioSource>();
		Name = enemyData.enemyName;
		Health = enemyData.health;
		AttackDamage = enemyData.attackDamage;
		coinsAmount = enemyData.coinsAmount;
		AttackRate = enemyData.attackRate;
		speed = enemyData.speed;

		healthAmount = Health;

		if (audioSource != null)
		{
			StartCoroutine(PlayAudioIdle(enemyData.DelayBetweenAudios));
		}
        //rb = GetComponent<Rigidbody>();
        Garrison.GarrisonDestroyed += StopMovement;

		//tried to do it with an event but didnt worked worked perfect on the update 
		Tower.TowerDestroyed += ChangeTargetTower;
		//Tower.TowerDestroyed += KillTowerEnemies;

		FindAllTowers();

	}



	private void Update()
	{
		
		ShowHealthBar();
		if (isSplined)
		{
			AttackCastle();
		}
		else
		{
			FindAllTowers();
			arrivedTower = false;
			LookAtTower();
			MoveToAttackTower();
			if (arrivedTower && attTower != null)
			{
				AttackTower(attTower);
			}
			KillTowerEnemies();
		}
		
	}


	public void AttackCastle()
	{
		if (splineScript.IsPlaying == false)
		{
			Debug.Log("Enemies Attack");
			var gar = FindObjectOfType<Garrison>();
			gar.TakeDamage(AttackDamage);
			Destroy(this.gameObject);
		}
	}

	public void TakeDamage(int damage)
	{
		healthAmount -= damage;
		healthBar.fillAmount = ((float)healthAmount) / Health;

		if (healthAmount <= 0)
		{
			
			Destroy(this.gameObject);
			LevelManager.coins += coinsAmount;
			return;
		}
	}

	public void StopMovement()
	{
		if (!isSplined) return;
		splineScript.Duration = 0;
	}

	public Tower? FindTowerToAttack(Tower[] towers) //Finding The Closest Tower in Scene Will be called every time a tower in scene is destroyed
	{
		if (towers == null || towers.Length == 0) return null;
		Tower closetTarget = null;
		float closetDistance = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		foreach (Tower t in towers)
		{
			Vector3 dirToTarget = t.transform.position - currentPos;
			float dSqrToTarget = dirToTarget.sqrMagnitude;
			if (dSqrToTarget < closetDistance)
			{
				closetDistance = dSqrToTarget;
				closetTarget = t;
			}
		}
		return closetTarget;
	}
	public void FindAllTowers() // Finding all Towers in scene will be called when a tower is destroyed insted of update
	{
		towers = FindObjectsOfType<Tower>();

		attTower = FindTowerToAttack(towers);
	}

	public void AttackTower(Tower tower)
	{
		if (tower == null) return;
		attackCd -= Time.deltaTime;
		if (attackCd <= 0)
		{
			attackCd = AttackRate;
			tower.GetComponent<Tower>().TakeDamage(AttackDamage);

		}
	}

	private void LookAtTower()
	{
		if (isSplined) return;
		if (attTower != null)
		{
			this.transform.rotation = Quaternion.LookRotation((this.transform.position - attTower.transform.position).normalized);
		}
		else
		{
			this.transform.rotation = Quaternion.identity;
		}
	}
	public void MoveToAttackTower()
	{
		if (attTower == null) return;
         
		float speed = nav.velocity.magnitude;
        Vector3 dir = attTower.transform.position - this.transform.position;
		float distanceToTarget = dir.magnitude;
		if (distanceToTarget > nav.stoppingDistance  && arrivedTower == false)
		{
			nav.SetDestination(attTower.transform.position);
			Debug.Log(speed);
			animator.SetFloat("Speed", speed);
		}	
		else
		{
			arrivedTower = true;
			
		}
        animator.SetBool("CanAttack", arrivedTower);
    }

	//killing the enemies who attack towers for now
	public void KillTowerEnemies()
	{
		if (isSplined) return;
		if (WaveManager.IsThereTowerRemaining()) return;
		Destroy(this.gameObject);
	}
	
	public void ChangeTargetTower()
	{
		arrivedTower = false;		
		FindAllTowers();
	}
	private void OnDisable()
	{
		Tower.TowerDestroyed -= ChangeTargetTower;
	}
	private void ShowHealthBar()
	{
		var player = FindFirstObjectByType<PlayerController>();
	     hpCanvas.transform.LookAt(player.transform);
		if(healthAmount < Health)
		{
			hpCanvas.enabled = true;
		}
		else { hpCanvas.enabled = false; }
	}
	
	

    IEnumerator PlayAudioIdle(float delay)
    {
		
        yield return new WaitForSeconds(2f); // initial delay before the loop starts

		audioClip = enemyData.idleAudio;
		audioSource.clip = audioClip;
        while (true)
        {
           
            audioSource.Play();

            yield return new WaitForSeconds(delay); // wait for the specified delay
        }
    }
}

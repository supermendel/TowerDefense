using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Lumin;
using UnityEngine.Splines;

public partial class WaveManager : MonoBehaviour
{

	[System.Serializable]
	public class Wave
	{
		//public Transform enemy;
		public Transform[] SplinedEnemies;				
		public float delay = 1f; //between enemy spawns

	}

	public Wave[] waves;
	public float timeBetweenWaves = 5f;
	public Transform nonSplineEnemies;
	public int count;
	public float timeEnemySpawner;
    public CoinsData coinsData;

    private int enemyCounter;
    [SerializeField] int coinsPerWin;
    [SerializeField] private Transform pointA;
	[SerializeField] private Transform pointB;
	private float waveCountDown;
	private int nextWave = 0;
	private float searchCountdown = 1f;


	private float towerEnemyCD;
	public static event Action LevelComplete;

	//private SpawnState state = SpawnState.Counting;

	private void Start()
	{
		waveCountDown = timeBetweenWaves;
		towerEnemyCD = timeEnemySpawner;
	}
	private void Update()
	{
				
		if (LevelManager.state == SpawnState.WAITING)
		{
			towerEnemyCD -= Time.deltaTime;
			if(towerEnemyCD <= 0)
			{
				SpawnTowerEnemies();
				towerEnemyCD = timeEnemySpawner;
			}
			if (!EnemyIsAlive())
			{
				//beging a new round

				WaveCompleted();
			}
			else
			{
				return;
			}
		}

		if (waveCountDown <= 0)
		{

			if (LevelManager.state != SpawnState.SPAWNING && LevelManager.state != SpawnState.Building)
			{
				StartCoroutine(SpawnWave(waves[nextWave]));
			}
		}
		else
		{
			if (LevelManager.state != SpawnState.Counting) return;
			waveCountDown -= Time.deltaTime;
		}
		if(LevelManager.state == SpawnState.WAITING && towerEnemyCD <= 0)
		{
			
		}
	}

	private bool EnemyIsAlive()
	{
		searchCountdown -= Time.deltaTime;

		if (searchCountdown <= 0)
		{
			searchCountdown = 1f;
			if (GameObject.FindGameObjectWithTag("Enemy") == null)
			{
				return false;
			}
		}
		return true;
	}
	private void WaveCompleted()
	{
		Debug.Log("Wave Completed");
		waveCountDown = timeBetweenWaves;
		LevelManager.state = SpawnState.Building;

		if (nextWave + 1 > waves.Length - 1)
		{
			//finished lvl .
			Debug.Log("Finished lvl");

           coinsData.weaponShopCoins += coinsPerWin;

            LevelComplete?.Invoke();

		}
		nextWave++;
	}


	IEnumerator SpawnWave(Wave _wave)
	{
		LevelManager.state = SpawnState.SPAWNING;

		for (int i = 0; i < _wave.SplinedEnemies.Length; i++)
		{
			SpawnEnemy(_wave.SplinedEnemies[i]);
			yield return new WaitForSeconds(_wave.delay);
		}

		LevelManager.state = SpawnState.WAITING;

		yield break;
	}

	void SpawnEnemy(Transform _enemy)
	{

		var spline = _enemy.GetComponent<SplineAnimate>();
		spline.Container = FindObjectOfType<SplineContainer>();
		spline.Loop = SplineAnimate.LoopMode.Once;

		Debug.Log("Spawning Enemy" + _enemy.name);
		Instantiate(_enemy, spline.Container.Spline[0].Position, Quaternion.identity);
	}
	public void SpawnTowerEnemies()
	{
		if (nonSplineEnemies == null) return;
		if (!IsThereTowerRemaining()) return;
		if(enemyCounter < count)
		{
			float randomLerpFactor = UnityEngine.Random.Range(0, 1);
			Vector3 spawnPos = Vector3.Lerp(pointA.position, pointB.position, randomLerpFactor);
			Instantiate(nonSplineEnemies,spawnPos, Quaternion.identity);
		}

	}
	public static bool IsThereTowerRemaining()
	{
		var towers = FindObjectsOfType<Tower>();
		return towers.Length > 0;
	}

}






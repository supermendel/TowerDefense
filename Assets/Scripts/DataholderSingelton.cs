using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataholderSingelton : MonoBehaviour, ISaveable
{
	public  WeaponData FireStaffData;
	public  PlayerData PlayerData;
	private static DataholderSingelton instance;
	public static DataholderSingelton Instance
	{
		get
		{
			if (instance == null)
			{
				Debug.LogError("Game Manager is Null!");

			}
			return instance;
		}
	}
	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(instance.gameObject);
		}
		instance = this;
		DontDestroyOnLoad(this.gameObject);
	}
	private void Start()
	{
		ResetWeaponsStats();
	}
	public void LevelWeapon()
	{
		FireStaffData.LevelUp();
	}
	public void ResetWeaponsStats()
	{
		FireStaffData.ResetData();
	}

	public void Save()
	{
		throw new System.NotImplementedException();
	}

	public void Load()
	{
		throw new System.NotImplementedException();
	}
}

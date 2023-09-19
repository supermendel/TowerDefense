using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataholderSingelton : MonoBehaviour, ISaveable
{
	
	public List<WeaponData> Weapons;
	public  PlayerData PlayerData;
	private static DataholderSingelton instance;
	public static DataholderSingelton Instance
	{
		get
		{
			if (instance == null)
			{
				Debug.LogError("Level Manager is Null!");

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
		ResetWeaponsStats();
	}

	public void LevelWeapon(int id)
	{
		foreach(var weapon in Weapons)
		{
			if (weapon.id == id)
			{
				weapon.LevelUp();
			}
		}
	}
	public void ResetWeaponsStats()
	{
		foreach (var weapon in Weapons)
		{
			weapon.ResetData();
		}
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

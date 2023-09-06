using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataholderSingelton : MonoBehaviour, ISaveable
{
	public WeaponData FireStaffData;
	public PlayerData PlayerData;
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

	public void Save()
	{
		throw new System.NotImplementedException();
	}

	public void Load()
	{
		throw new System.NotImplementedException();
	}
}

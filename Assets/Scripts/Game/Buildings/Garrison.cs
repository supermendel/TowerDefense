using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Garrison : MonoBehaviour,IHealth
{
    [SerializeField] int Health;
    public static event Action GarrisonDestroyed; 
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void TakeDamage(int damage)
	{
		Health -= damage;
        
        if(Health < 0)
        {
            Health = 0;
        }
        if(Health <= 0)
        {
            Debug.Log("Game is LOST");
            LevelManager.state = SpawnState.LevelLoss;
            Debug.Log(LevelManager.state.ToString());
            GarrisonDestroyed?.Invoke();
            
        }
        Debug.Log(Health);
	}
}

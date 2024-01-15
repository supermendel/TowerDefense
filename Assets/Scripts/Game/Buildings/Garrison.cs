using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Garrison : MonoBehaviour, IHealth
{
    [SerializeField] int Health;
    [SerializeField] Canvas hpCanvas;
    [SerializeField] Image healthBar;

    private int currentHealth;
    public static event Action GarrisonDestroyed; 
    void Start()
    {
        currentHealth = Health;
        UpdateUI();     
    }
    private void Update()
    {
        ShowHealthBar();
    }
    // Update is called once per frame


    public void TakeDamage(int damage)
	{
		currentHealth -= damage;
        UpdateUI();
        if(currentHealth < 0)
        {
            Health = 0;

            Debug.Log("Game is LOST");
            LevelManager.state = SpawnState.LevelLoss;
            Debug.Log(LevelManager.state.ToString());
            GarrisonDestroyed?.Invoke();
        }
        //if(currentHealth <= 0)
        //{
            
        //}
        Debug.Log(Health);
	}
    public void UpdateUI()
    {
        healthBar.fillAmount = ((float)currentHealth) / Health;
    }
    private void ShowHealthBar()
    {
        if(LevelManager.state != SpawnState.LevelWon || LevelManager.state != SpawnState.LevelLoss)
        {
            hpCanvas.enabled = true;
        }
        else 
        { 
            hpCanvas.enabled = false;
        }
    }
}

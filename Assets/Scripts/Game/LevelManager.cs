using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
#nullable enable
	[SerializeField] static WaveManager waveManager;
#nullable enable
	[SerializeField] Canvas? canvas;
#nullable enable
	[SerializeField] Canvas lostCanvas;
	[SerializeField] TMP_Text? coinsText;
	
	

	public static SpawnState state;
	public static int coins;
	public static bool GameOn = true;
	public LevelData levelData;


	private  int currentScene;
	private static LevelManager instance;
	public static LevelManager Instance
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
		instance = this;
		currentScene = SceneManager.GetActiveScene().buildIndex;
		WaveManager.LevelComplete += ChangeStateWon;
        WaveManager.LevelComplete += ChangeDataWin;

        Garrison.GarrisonDestroyed += ShowLoseCanvas;
		
	}
	void Start()
	{
		coins = 500;
		
		state = SpawnState.Building;
	}

	// Update is called once per frame
	void Update()
	{
		if (state == SpawnState.LevelWon) return;
		UpdateUI();
		
		
	}

	public void BuildingPhase()
	{
		if (state == SpawnState.Building)
		{
			//Building stuff
		}
	}

	private void UpdateUI()
	{
		coinsText.text = coins.ToString();
		if (state == SpawnState.Building)
		{
			UnHideUi();
		}
		else
		{

			HideUi();
		}
	}
	private void HideUi()
	{
		canvas.enabled = false;
	}
	private void UnHideUi()
	{
		canvas.enabled = true;
	}

	public void ReadyClicked()
	{
		//Moving Camera
		state = SpawnState.Counting;
	}
	public void ChangeStateWon()
	{
		state = SpawnState.LevelWon;
	}
	public void ShowLoseCanvas()
	{
		lostCanvas.GetComponent<Canvas>().enabled = true;
	}
	public void RestartClicked()
	{
		SceneManager.LoadScene(currentScene);
	}
	public void MenuClicked()
	{
		SceneManager.LoadScene(0);
	}
	public void ChangeDataWin()
	{
		levelData.isComplete = true;
	}

}

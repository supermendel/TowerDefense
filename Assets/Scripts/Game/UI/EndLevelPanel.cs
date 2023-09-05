using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevelPanel : MonoBehaviour
{
	private Canvas endGameCanvas;
	private int sceneId;
	[SerializeField] GameObject? nextLvlButton;

	private void Awake()
	{
		endGameCanvas = this.GetComponent<Canvas>();
		sceneId = SceneManager.GetActiveScene().buildIndex;
		WaveManager.LevelComplete += EndGamePanel;
	}
	void Start()
	{
		
			endGameCanvas.enabled = false;
	}
	private void Update()
	{

		if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings-1)
		{
			EnableReadyButton();
		}
		else
		{
			nextLvlButton.GetComponent<Button>().interactable = false;
		}

	}

	public void OnMenuClicked()
	{
		SceneManager.LoadSceneAsync(0);
	}
	public void OnNextLevelClicked()
	{
		SceneManager.LoadSceneAsync(sceneId + 1);
	}

	public void EndGamePanel()
	{
		endGameCanvas.GetComponent<Canvas>().enabled = true;
	}

	public void EnableReadyButton()
	{
		nextLvlButton.GetComponent<Button>().interactable = true;
	}
	private void OnDestroy()
	{
		WaveManager.LevelComplete -= EndGamePanel;
	}

}

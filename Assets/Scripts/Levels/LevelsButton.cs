using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsButton : MonoBehaviour
{
    public LevelData levelData;

    public void OnLevelClicked()
    {
        SceneManager.LoadSceneAsync(levelData.ID);
    }
    public void DisableButton()
    {
        this.GetComponent<Button>().interactable = false;
    }
    public void EnableButton()
    {
        this.GetComponent<Button>().interactable = true;
    }

}

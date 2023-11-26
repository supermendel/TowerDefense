using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContentManager : MonoBehaviour
{
    private List<GameObject> levels = new List<GameObject>();
    private void Awake()
    {
        GetButtons();
    }
    private void Start()
    {
        Debug.Log(levels.Count);
        CheckAviablity();
    }
    public void GetButtons()
    {
        foreach(Transform child in transform)
        {
            levels.Add(child.gameObject);
        }
    }
    public void CheckAviablity()
    {
        for (int i = 0; i < levels.Count-1; i++)
        {
            if (levels[i].GetComponent<LevelsButton>().levelData.isComplete != true)
            {
                levels[i+1].GetComponent<LevelsButton>().DisableButton();
            }
            
        }
    }
}

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
        for (int i = 1; i < levels.Count; i++)
        {
            if (levels[i].GetComponent<LevelsButton>().levelData.isComplete != true)
            {
                //check if buttong need to be interacble
            }
            
        }
    }
}

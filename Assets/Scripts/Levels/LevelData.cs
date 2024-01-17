using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class LevelData : ScriptableObject
{
    public bool isComplete;
    public bool areThereTurretEnemies;
    public int ID;
     
}

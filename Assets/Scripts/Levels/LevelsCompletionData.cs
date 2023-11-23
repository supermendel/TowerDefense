using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelsManager", menuName = "Levels")]

public class LevelsCompletionData : ScriptableObject
{
   public LevelData[] levels;
}

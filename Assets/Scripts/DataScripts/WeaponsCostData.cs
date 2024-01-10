using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponsCost", menuName = "Coins/weaponsCost")]
public class WeaponsCostData : ScriptableObject
{
    public List<int> weaponsCost;
}


using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Weapon")]
public class WeaponData : ScriptableObject
{
	public string weaponName;
	public int baseDamage;
	public int Damage { get; private set; }
	public float FireRate { get; private set; }
	public float baseFireRate;

	public GameObject bulletPrefab;
	public int weaponLvl = 1;

	public int MaxLevel;
#nullable enable
	public AudioClip shootSound;
	public GameObject weaponPrefab;

	
	public void LevelUp()
	{
		if (weaponLvl >= MaxLevel) return;
		weaponLvl++;
		Damage += baseDamage;
		FireRate -= 0.2f;
		Debug.Log($"{weaponName} got upgraded to level :{weaponLvl}");
	}
	public void ResetData()
	{
		weaponLvl = 1;
		Damage = baseDamage;
		FireRate = baseFireRate;
	}
}


using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Weapon")]
public class WeaponData : ScriptableObject
{
	public string weaponName;
	public int damage;
	public float fireRate;
	public GameObject bulletPrefab;
	public int weaponLvl;
#nullable enable
	public AudioClip shootSound;
}


using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Weapon")]
public class WeaponData : ScriptableObject
{
	public string weaponName;
	private int baseDamage;
	public int damage;
	public float fireRate;
	public GameObject bulletPrefab;
	public int weaponLvl = 1;
#nullable enable
	public AudioClip shootSound;


	public void LevelUp()
	{
		weaponLvl++;
		damage += baseDamage;
	}
}

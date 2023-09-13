using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // WeaponData weaponData;
    
    public Transform shootPos;
    private WeaponData weaponData;
    private DataholderSingelton dataholder;
    private float shootCD;
    public int id;
    private const int MAX_LEVEL = 5;


	// Update is called once per frame
	private void Start()
	{
		dataholder = FindAnyObjectByType<DataholderSingelton>();
        GetData();
	}
	void Update()
    {
        shootCD -= Time.deltaTime;
        
    }
    public void GetData()
    {
        foreach(var wData in dataholder.Weapons)
        {
            if (wData.id == id)
            {
                weaponData = wData;
            }
            else continue;
        }
    }
    public void ShootProjectile()
    {
        if (shootCD <= 0)
        {

            GameObject projectileTransform = Instantiate(weaponData.bulletPrefab, shootPos.position, Quaternion.identity);
            projectileTransform.GetComponent<Projectile>().damage = weaponData.Damage;
            projectileTransform.GetComponent<Projectile>().SetUp(transform.forward);
            shootCD = weaponData.FireRate;

        }
        else return;
    }
}

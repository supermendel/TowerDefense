using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // WeaponData weaponData;
    public Transform shootPos;
    private DataholderSingelton dataholder;
    private float shootCD;
    private const int MAX_LEVEL = 5;


	// Update is called once per frame
	private void Start()
	{
		dataholder = FindAnyObjectByType<DataholderSingelton>();
	}
	void Update()
    {
        shootCD -= Time.deltaTime;
        
    }
    public void ShootProjectile()
    {
        if (shootCD <= 0)
        {

            GameObject projectileTransform = Instantiate(dataholder.FireStaffData.bulletPrefab, shootPos.position, Quaternion.identity);
            projectileTransform.GetComponent<Projectile>().damage = dataholder.FireStaffData.Damage;
            projectileTransform.GetComponent<Projectile>().SetUp(transform.forward);
            shootCD = dataholder.FireStaffData.FireRate;

        }
        else return;
    }
}

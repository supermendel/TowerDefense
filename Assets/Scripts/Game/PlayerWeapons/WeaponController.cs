using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponData weaponData;
    public Transform shootPos;
    private float shootCD;
    private const int MAX_LEVEL = 5;
   

    // Update is called once per frame
    void Update()
    {
        shootCD -= Time.deltaTime;
        if (Input.GetMouseButton(0) && (LevelManager.state == SpawnState.WAITING || LevelManager.state == SpawnState.SPAWNING || LevelManager.state == SpawnState.Counting))
        {
            ShootProjectile();
        }
    }
    private void ShootProjectile()
    {
        if (shootCD <= 0)
        {

            GameObject projectileTransform = Instantiate(weaponData.bulletPrefab, shootPos.position, Quaternion.identity);
            projectileTransform.GetComponent<Projectile>().damage = weaponData.damage;
            projectileTransform.GetComponent<Projectile>().SetUp(transform.forward);
            shootCD = weaponData.fireRate;
        }
        else return;
    }
}

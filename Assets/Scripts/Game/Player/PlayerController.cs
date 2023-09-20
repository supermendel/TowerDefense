using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public List<WeaponData> availableWeapons;
	private WeaponController currentWeapon;
	public Transform equipPos;

	private CharacterController cC;

	[Header("Stats")]
	public int speed;
	public int rotateSpeed;
	public int sceneIndex;

	public Vector2 rotation;
	private int currWeaponIndex = 10;

	void Awake()
	{
		cC = gameObject.GetComponent<CharacterController>();
		sceneIndex = SceneManager.GetActiveScene().buildIndex;
	}
	private void Start()
	{
		availableWeapons = new List<WeaponData>();
		foreach(var weapon in DataholderSingelton.Instance.Weapons)
		{
			if(weapon == null) continue;
			else
			availableWeapons.Add(weapon);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (sceneIndex == 0) return; //In Menu
		if (LevelManager.state == SpawnState.LevelLoss) return;

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			EquipWeapon(0);
			currentWeapon.GetData();
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			EquipWeapon(1);
			currentWeapon.GetData();
		}

		if (Input.GetMouseButton(0) && Playable() && currentWeapon != null)
		{
			currentWeapon.ShootProjectile();
		}

		Movement();

	}
	private void LateUpdate()
	{
		if (sceneIndex == 0) return; //In Menu
		if (LevelManager.state == SpawnState.LevelLoss) return;
		Rotate();
	}
	public void Movement()
	{
		if (LevelManager.state == SpawnState.Building || LevelManager.state == SpawnState.LevelWon) return;
		else
		{
			//horizontal = Input.GetAxis("Horizontal");
			//vertical = Input.GetAxis("Vertical");
			if (Input.GetKey(KeyCode.W))
			{
				transform.position += transform.forward * speed * Time.deltaTime;

			}
			if (Input.GetKey(KeyCode.S))
			{
				transform.position -= transform.forward * speed * Time.deltaTime;

			}
			if (Input.GetKey(KeyCode.A))
			{
				transform.position -= transform.right * speed * Time.deltaTime;

			}
			if (Input.GetKey(KeyCode.D))
			{
				transform.position += transform.right * speed * Time.deltaTime;

			}

			//Vector3 moveTo = new Vector3(vertical, 0, -horizontal);
			//cC.Move(moveTo * speed * Time.deltaTime);
		}
	}
	public void Rotate()
	{
		if (LevelManager.state == SpawnState.Building || LevelManager.state == SpawnState.LevelWon) return;
		rotation.x += Input.GetAxis("Mouse X");
		//transform.localRotation = Quaternion.Euler(0, rotation.x, 0);
		Quaternion target = Quaternion.Euler(0, rotation.x, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotateSpeed);
	}
	private void EquipWeapon(int weaponIndex)
	{
		if(currWeaponIndex == weaponIndex) return;	//trying to change the same weapon

		if (weaponIndex >= 0 && weaponIndex < availableWeapons.Count)
		{
			if (currentWeapon != null)
			{ //Disabling previous weapon
				//currentWeapon.gameObject.SetActive(false);
				Destroy(currentWeapon.gameObject);
			}
			GameObject weaponobject = Instantiate(availableWeapons[weaponIndex].weaponPrefab);
			Transform equipLocation = equipPos;
			weaponobject.transform.parent = equipLocation;
			weaponobject.transform.localPosition = Vector3.zero;
			//weaponobject.transform.localRotation = Quaternion.identity;
			currWeaponIndex = weaponIndex;

			currentWeapon = weaponobject.GetComponent<WeaponController>();
		}
		else
			return;
	}
	public bool Playable()
	{
		return (LevelManager.state == SpawnState.WAITING || LevelManager.state == SpawnState.SPAWNING || LevelManager.state == SpawnState.Counting);
	}
	public void GetWeapons()
	{

	}
}

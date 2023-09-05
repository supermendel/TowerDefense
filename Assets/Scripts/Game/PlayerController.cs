using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private CharacterController cC;

    [Header("Stats")]
    public int speed;
    public int rotateSpeed;

    public Vector2 rotation;

    void Awake()
    {
        cC= gameObject.GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
		if (LevelManager.state == SpawnState.LevelLoss) return;
        Movement(); 
      
	}
	private void LateUpdate()
	{
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
        if(LevelManager.state == SpawnState.Building || LevelManager.state == SpawnState.LevelWon) return;
        rotation.x += Input.GetAxis("Mouse X");
        //transform.localRotation = Quaternion.Euler(0, rotation.x, 0);
        Quaternion target = Quaternion.Euler(0, rotation.x, 0);
        transform.rotation=Quaternion.Slerp(transform.rotation,target,Time.deltaTime*rotateSpeed);
	}
}

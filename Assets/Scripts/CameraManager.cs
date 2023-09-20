using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	[SerializeField] private CinemachineVirtualCamera followCamera;
	[SerializeField] private CinemachineVirtualCamera buildingCamera;
   
	void Start()
    {
		SwitchCamera();
        LockCursor();
        
	}

    // Update is called once per frame
    void Update()
    {
        SwitchCamera();
        LockCursor();
    }
    private void SwitchCamera()
    {
        if(LevelManager.state == SpawnState.Building || LevelManager.state == SpawnState.LevelWon)
        {
            buildingCamera.Priority = 1;
            followCamera.Priority = 0;

        }
        else
        {
			buildingCamera.Priority = 0;
			followCamera.Priority = 1;
		}
    }
    public void LockCursor()
    {
        if (LevelManager.state == SpawnState.Building || LevelManager.state == SpawnState.LevelLoss)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
            Cursor.lockState = CursorLockMode.Locked;
    }
    
}

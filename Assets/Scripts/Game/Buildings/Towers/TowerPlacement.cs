using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
	[SerializeField] LayerMask placementCheckMask;
	[SerializeField] LayerMask placeCollideMask;
	[SerializeField] Camera _camera;
	[SerializeField] float placementRadius = 1.0f;
	private GameObject currentPlactingTower;

	private RaycastHit hitinfo;
	private Vector3 currentPLacementPos;
	private GameObject objectTOBuild;

	private void PlaceTower()
	{
		if (objectTOBuild == null) { return; }
		if (objectTOBuild.GetComponent<Tower>().cost <= LevelManager.coins)
		{
			currentPlactingTower = Instantiate(objectTOBuild, currentPLacementPos, Quaternion.identity);
			LevelManager.coins -= objectTOBuild.GetComponent<Tower>().cost;
		}
		else
		{
			objectTOBuild = null;
			return;
		}
	}

	void Update()
	{

		Ray camray = _camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitinfo;
		if (Physics.Raycast(camray, out hitinfo, Mathf.Infinity, placementCheckMask))
		{

			Vector3 toPlace = hitinfo.point;
			currentPLacementPos = toPlace;
		}
		this.hitinfo = hitinfo;


		if (Input.GetMouseButtonDown(0) && CheckPlacemanet())
		{
			PlaceTower();
		}

		HideShop();
		ForceClose();
	}

	private bool CheckPlacemanet()
	{
		if (Physics.CheckSphere(currentPLacementPos, placementRadius, LayerMask.GetMask("Towers")))
		{
			return false;
		}
		return true;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = CheckPlacemanet() ? Color.green : Color.red;
		Gizmos.DrawSphere(currentPLacementPos, placementRadius);
	}
	public  void SetTowerToPlace(GameObject gameObject)
	{		
			objectTOBuild = gameObject;	
	}

	public void HideShop()
	{
		if(objectTOBuild != null)
		{
			TowerShop.Instance.shopPanel.SetActive(false);
		}
	}

	public void ForceClose()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(objectTOBuild != null)
			{
				objectTOBuild = null;
					return;
			}

			if(TowerShop.Instance.shopPanel.activeSelf == true)
			{
				TowerShop.Instance.shopPanel.SetActive(false);
				return;
			}
		}
	}
}

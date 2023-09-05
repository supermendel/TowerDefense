using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Enemy" , menuName = "Enemy") ]
public class Enemy : ScriptableObject
{
	public string enemyName;

	public int health;
	public int attackDamage;
	public int timeToComplete;
	public int coinsAmount;
	public int attackRate;
	public float speed;
	public GameObject model;


	
}

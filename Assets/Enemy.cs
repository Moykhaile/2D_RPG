using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health = 2;
	public int xpValue = 10;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (health <= 0) Die();
	}
	public void TakeDamage(int damage)
	{
		health -= damage;
	}

	void Die()
	{
		FindObjectOfType<Player>().xp = xpValue;

		Destroy(gameObject);
	}
}

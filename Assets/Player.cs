using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int health = 5;
	public int xp = 0;
	public int gems = 0;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (health <= 0)
			Die();
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
	}
	void Die()
	{
		Destroy(gameObject);
	}
}

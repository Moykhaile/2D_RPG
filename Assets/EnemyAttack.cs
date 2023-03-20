using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	bool canAttack = false;
	public int attackDmg = 2;
	public float dmgCooldown = 0.5f;
	public float cooldown;

	private void Update()
	{
		if (cooldown < dmgCooldown)
		{
			cooldown += Time.deltaTime;
			canAttack = false;
		}
		else
		{
			canAttack = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		var hit = collision.GetComponent<Player>();

		if (hit != null && canAttack)
		{
			hit.TakeDamage(attackDmg);
			cooldown = 0;
		}
	}
}

using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	bool canAttack = false;
	public int attackDmg = 1;

	private void OnEnable()
	{
		canAttack = true;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		var hit = collision.GetComponent<Enemy>();

		if (hit != null && canAttack)
		{
			hit.TakeDamage(attackDmg);
			canAttack = false;
		}
	}
}

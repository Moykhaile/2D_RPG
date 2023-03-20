using UnityEngine;

public class Gem : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		var hit = collision.GetComponent<Player>();

		if (hit != null)
		{
			hit.gems++;
			Destroy(gameObject);
		}
	}
}

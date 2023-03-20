using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody2D rb;
	Animator anim;

	public float speed = 2f;

	int horizontal = 0;
	int vertical = 0;
	int lastDirection = 0;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		anim.SetBool("Attacked", false);
		horizontal = (int)Input.GetAxisRaw("Horizontal");
		vertical = (int)Input.GetAxisRaw("Vertical");

		if (Regex.Match(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name, @"Attack.*").Success)
		{
			horizontal = 0;
			vertical = 0;
		}

		Move();

		Attack();
	}

	void Attack()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
			anim.SetBool("Attacked", true);
	}

	void Move()
	{
		if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
			horizontal = 0;
		if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
			vertical = 0;

		if (horizontal != 0 && lastDirection == 1) vertical = 0;
		if (vertical != 0 && lastDirection == -1) horizontal = 0;

		if (horizontal < 0) transform.localScale = new Vector2(-1, 1);
		if (horizontal > 0 || vertical != 0) transform.localScale = Vector2.one;

		// rb.MovePosition(new Vector2(rb.position.x + horizontal * speed, rb.position.y + vertical * speed) * Time.deltaTime);
		transform.Translate(new Vector2(horizontal * speed, vertical * speed) * Time.deltaTime);

		anim.SetInteger("Horizontal", horizontal);
		anim.SetInteger("Vertical", vertical);

		lastDirection = horizontal != 0 ? 1 : vertical != 0 ? -1 : 0;
	}
}

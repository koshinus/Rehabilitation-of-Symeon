using UnityEngine;
using System.Collections;
 
public class Symeon : MonoBehaviour 
{
	public float maxSpeed = 20f;
	public float speed = 50f;
	public float jumpForce = 450f;
	
	public bool grounded;
	
	private Rigidbody2D rb2d;
	private Animator anim;
	
	void Start()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
	}
	
	void Update()
	{
		anim.SetBool("Grounded", grounded);
		anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
		
		if(Input.GetAxis("Horizontal") < -0.1f)
			transform.localScale = new Vector3(-1f, 1f, 1f);
		if(Input.GetAxis("Horizontal") > 0.1f)
			transform.localScale = new Vector3( 1f, 1f, 1f);
		if(Input.GetButtonDown("Jump") && grounded)
			rb2d.AddForce(Vector2.up * jumpForce);
			
	}
	
	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		
		rb2d.AddForce(Vector2.right * speed * h);
		if(rb2d.velocity.x > maxSpeed)
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		if(rb2d.velocity.x < -maxSpeed)
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
	}
}
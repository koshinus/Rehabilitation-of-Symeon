using UnityEngine;
using System.Collections;
 
public class SaimonForDemo : MonoBehaviour 
{
	public float speed = 50f;
	public float jumpForce = 150f;
	
	public bool grounded;
	
	private Rigidbody2D rb2d;
	
	public void Start()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	public void Update(){}
	
	public void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		
		rb2d.AddForce((Vector2.right*speed)*h);
	}
}
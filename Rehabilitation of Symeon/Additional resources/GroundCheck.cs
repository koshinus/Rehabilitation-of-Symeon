using UnityEngine;
using System.Collections;
 
public class GroundCheck : MonoBehaviour 
{
	
	private Symeon symeon;
	
	void Start()
	{
		symeon = gameObject.GetComponentInParent<Symeon>();
	}
	
	void OnTriggerEntered2D(Collider2D col)
	{
		symeon.grounded = true;
	}
	
	void OnTriggerStay2D(Collider2D col)
	{
		symeon.grounded = true;
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		symeon.grounded = false;
	}
}
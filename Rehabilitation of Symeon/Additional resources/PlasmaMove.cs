using UnityEngine;
using System.Collections;
 
public class PlasmaMove : MonoBehaviour 
{
	
	public int speed = 200;
	
	void Update()
	{
		transform.Translate(Vector3.right * Time.deltaTime * speed);
	}
}
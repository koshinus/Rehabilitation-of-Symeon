using UnityEngine;
using System.Collections;
 
public class Mouse : MonoBehaviour 
{
	
	public GameObject mouse;
	
	void Start()
	{
		mouse = GameObject.FindGameObjectWithTag("GameController");
	}
	
	//void Update(){}

	void Update()
	{	
		transform.position = Input.mousePosition;
	}
}
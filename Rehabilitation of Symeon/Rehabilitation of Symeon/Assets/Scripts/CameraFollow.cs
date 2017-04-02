using UnityEngine;
using System.Collections;
 
public class CameraFollow : MonoBehaviour 
{
	
	private Vector2 vec;
	
	public float smoothTimeX;
	public float smoothTimeY;
	
	public GameObject symeon;
	
	void Start()
	{
		symeon = GameObject.FindGameObjectWithTag("Player");
	}
	
	//void Update(){}

	void FixedUpdate()
	{
		float posX = Mathf.SmoothDamp(transform.position.x, symeon.transform.position.x, ref vec.x, smoothTimeX);
		float posY = Mathf.SmoothDamp(transform.position.y, symeon.transform.position.y, ref vec.y, smoothTimeY);
		
		transform.position = new Vector3(posX, posY, transform.position.z);
	}
}
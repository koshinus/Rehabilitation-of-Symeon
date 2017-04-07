using UnityEngine;
using System.Collections;
 
public class Shooting : MonoBehaviour 
{
	public float fireRate;
	public Camera cam;
	public float damage;
	public Transform bulletPre;
	public Transform firePoint;
	public Transform angle;
	public LayerMask hitWhat;
	private float timeToFire;
	
	void Start()
	{
		
	}
	
	void Update()
	{
		if(fireRate == 0)
		{
			if(Input.GetButtonDown("Fire1"))
			{
				Shoot();
			}
		}
		else if(Input.GetButton("Fire1") && Time.deltaTime > timeToFire)
			{
				timeToFire = Time.time + 1f/fireRate;
				Shoot();
			}
	}
	
	void Shoot()
	{
		Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
		Vector2 mousePos = new Vector2(pos.x, pos.y);
		CreateBullet();
		Vector2 firePP = new Vector2(firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast(firePP, mousePos, 100, hitWhat);
	}
	
	void CreateBullet()
	{
		Instantiate(bulletPre, firePoint.position, firePoint.rotation);
	}
}
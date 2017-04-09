using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StakesController : MonoBehaviour
{
    public float DistanceAttack = 1f;


    private GameObject MainCharacter;
    private Animator anim;

    void Start ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 1f);
        MainCharacter = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        //StartCoroutine(Attack());
    }
	
	void Update ()
    {

        if (Vector2.Distance(transform.position, MainCharacter.transform.position) < DistanceAttack)
        {
            anim.SetBool("StateAttack", true);
        }
        else
        {
            anim.SetBool("StateAttack", false);
        }
        
    }

    /*
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(5f);
        anim.Play("Stakes");
        
    }
    */
}

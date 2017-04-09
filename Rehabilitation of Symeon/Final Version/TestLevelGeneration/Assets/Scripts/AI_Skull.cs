using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Skull : MonoBehaviour
{
    public float DistanceBurst = 10f;
    public float DistanceAttack = 100f;

    private bool isFacingRight = true;
    private Animator anim;
    private GameObject MainCharacter;

    void Start ()
    {
        anim = GetComponent<Animator>();
        MainCharacter = GameObject.FindGameObjectWithTag("Player");
    }
	
	void Update ()
    {

        if (Vector2.Distance(transform.position, MainCharacter.transform.position) < DistanceAttack)
        {
            Vector2 direction_fly = (MainCharacter.transform.position - transform.position) * Time.deltaTime;
            if (direction_fly.sqrMagnitude > 1)
                direction_fly.Normalize();
            transform.Translate(direction_fly);
        }

        Vector2 move_direction = MainCharacter.transform.position - transform.position;

        if (move_direction.SqrMagnitude() < DistanceBurst)
        {
            StartCoroutine(Burst());
        }

        if (move_direction.x < 0 && isFacingRight || move_direction.x > 0 && !isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    IEnumerator Burst()
    {
        anim.SetInteger("BehaviorState", 1);
        yield return new WaitForSeconds(0.8f);

        // -----
        MainCharacter.GetComponent<Player2D>().Health -= 2;
        // -----

        gameObject.SetActive(false);
    }
}

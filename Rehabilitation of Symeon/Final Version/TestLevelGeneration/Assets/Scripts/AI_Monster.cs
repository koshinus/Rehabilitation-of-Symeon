using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Monster : MonoBehaviour
{
    public float DistanceRun = 100f;
    public float DistanceAttack = 1f;
    public float DistancePowerJump = 10f;
    public float DistanceEpsJump = 1e-2f;
    public float DistanceFlip = 0f;
    public float DistanceDamage = 10f;

    public Vector2 JumpSpeed;
    public float RunSpeed  = 10f;

    private Animator anim;
    private GameObject MainCharacter;
    private int StateBehavior = 0;
    private bool isFacingRight = true;



    public Transform groundCheck;
    public LayerMask whatIsGround;

    private bool isGrounded = false;
    private float groundRadius = 100f;

    private Vector2 prev_position;

    void Run()
    {
        StateBehavior = 1;
        Vector2 move_direction = MainCharacter.transform.position - transform.position;
        if (move_direction.x + DistanceFlip < 0 && isFacingRight || move_direction.x - DistanceFlip > 0 && !isFacingRight)
        {
            Flip();
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(move_direction.x) * RunSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump(bool power_jump)
    {

        if (power_jump)
        {
            GetComponent<Rigidbody2D>().velocity = MainCharacter.transform.position - transform.position;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, JumpSpeed.y);
        }

        isGrounded = false;
    }

    IEnumerator Attack()
    {
        StateBehavior = 2;
        yield return new WaitForSeconds(2f);

        if (Vector2.Distance(transform.position, MainCharacter.transform.position) < DistanceDamage)
            MainCharacter.GetComponent<Player2D>().Health -= 1;
    }

    void Idle()
    {
        StateBehavior = 0;
    }

    void Start ()
    {
        MainCharacter = GameObject.FindGameObjectWithTag("Player");



        prev_position = transform.position;
        anim = GetComponent<Animator>();
        Flip();
    }
	
	void Update ()
    {        
        float distance = Vector2.Distance(transform.position, MainCharacter.transform.position);
        Vector2 move_direction = MainCharacter.transform.position - transform.position;

        if (StateBehavior == 1 && isGrounded)
            if (Mathf.Abs(move_direction.y) > DistancePowerJump)
                Jump(true);
            else
            if (Mathf.Abs(prev_position.x - transform.position.x) < DistanceEpsJump * Time.deltaTime)
                Jump(false);

        if (distance <= DistanceAttack)
            //Attack();
            StartCoroutine(Attack());
        else
        if (distance <= DistanceRun)
            Run();
        else
            Idle();

        anim.SetInteger("StateBehavior", StateBehavior);
        prev_position = transform.position;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}

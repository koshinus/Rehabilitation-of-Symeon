using UnityEngine;
using System.Collections;

public class Player2D : MonoBehaviour
{

    Rigidbody2D m_rigidbody;
    Vector2 velocity;

    private Animator anim;
    private bool isFacingRight = true;

    // -----
    public int Health;
    public int Crystals;

    //public GameObject Health_Indicator;
    //public GameObject Crystals_Indicator;
    // -----
    public Camera main_camera;


    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // -----
        Health = 100;
        Crystals = 0;
        // -----
    }

    void OnGUI()
    {
        // ~~~~~
        // Shot
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<AudioSource>().Play();

            Ray ray = main_camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                string ObjectName = hit.collider.name;
                Debug.Log(ObjectName);
                //Destroy(GameObject.Find(ObjectName));
            }
        }
        // ~~~~~
    }

    void Update()
    {


        if (Input.GetKey(KeyCode.Space))
            velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 100f).normalized;
        else
            velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0f).normalized;

        // ~~~~~
        // Flipping
        if (velocity.x < 0 && isFacingRight || velocity.x > 0 && !isFacingRight)
        {
            Flip();
        }
        // ~~~~~

        velocity = new Vector2(velocity.x * 50f, velocity.y * 100f);

        if (velocity.x != 0)
            anim.SetBool("StateWalk", true);
        else
            anim.SetBool("StateWalk", false);
        // -----
        if (Health <= 0)
        {
            // Die
            Debug.Log("Die!!!");
        }
        else
        if (Health > 100)
            Health = 100;

        // To draw health and crystals indicators
        //Health_Indicator.transform.localScale();
        // -----
    }

    void FixedUpdate()
    {
        m_rigidbody.MovePosition(m_rigidbody.position + velocity * Time.fixedDeltaTime);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
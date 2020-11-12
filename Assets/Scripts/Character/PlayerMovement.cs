using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public bool flag, jump;
    private float movX, movY;


    private Rigidbody2D rb;
    public float forceMultiplier, jumpMultiplier;

    //Limit Jump
    // OverlapCircle , Raycast (Hitscan Weapons)
    [Header("Jump Mechanic")]
    public bool jumpSelector = false;
    public bool canJump = false;
    public Transform[] checkPoints;
    public float[] checkRadius;
    public LayerMask layers;

    private Collider2D groundCollider;
    private RaycastHit2D[] raycastHits = new RaycastHit2D[2];
 
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.root.gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        jump = Input.GetButtonDown("Jump");

        //Debug.Log(movY);

        anim.SetFloat("Speed_X", Mathf.Abs(movX));

        if (movX < 0)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        //transform.position += new Vector3(movX, movY, 0f) * Time.deltaTime;

        if (!jumpSelector)
        {
            if (groundCollider != null)
            {
                canJump = true;
            }
            else
            {
                canJump = false;
            }
        }
        else
        {
            if (raycastHits[0] || raycastHits[1])
            {
                canJump = true;
            }
            else
            {
                canJump = false;
            }
        }


        
        
        
        
    }

    private void FixedUpdate()
    {
        if (flag)
        {
            Vector2 forceVector = new Vector2(movX, 0f) * forceMultiplier;
            rb.AddForce(forceVector);
        }
        else
        {
            Vector2 forceVector = new Vector2(movX, 0f) * forceMultiplier;
            rb.velocity = forceVector;
        }

        if (canJump && jump)
            rb.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);

        if (!jumpSelector)
        {
            groundCollider = Physics2D.OverlapCircle(checkPoints[0].position, checkRadius[0], layers);
        }
        else
        {
            raycastHits[0] = Physics2D.Raycast(checkPoints[1].position, Vector2.down, checkRadius[1], layers);
            raycastHits[1] = Physics2D.Raycast(checkPoints[2].position, Vector2.down, checkRadius[1], layers);
        }

        
    }
}

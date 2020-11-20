using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public bool flag, jump, xKeyboard;
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

    [Header("Attack Mechanic")]
    public Transform firePoint;
    public GameObject bulletPrefab;


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
        xKeyboard = Input.GetKey(KeyCode.X);

        //Debug.Log(movY);

        anim.SetFloat("Speed_X", Mathf.Abs(movX));

        if (movX < 0)
        {
            transform.root.localScale = new Vector3(-1f, 1f, 1f);
            //GameObject.FindGameObjectWithTag("weapon").transform.Rotate(0f, 180f, 0f);
        }
        else
        {
            transform.root.localScale = new Vector3(1f, 1f, 1f);
            //GameObject.FindGameObjectWithTag("weapon").transform.Rotate(0f, 0, 0f);
        }
        //transform.position += new Vector3(movX, movY, 0f) * Time.deltaTime;

        //if (!jumpSelector)
        //{
        //    if (groundCollider != null)
        //    {
        //        canJump = true;
        //    }
        //    else
        //    {
        //        canJump = false;
        //    }
        //}
        //else
        //{
        //    if (raycastHits[0] || raycastHits[1])
        //    {
        //        canJump = true;
        //    }
        //    else
        //    {
        //        canJump = false;
        //    }
        //}
       


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

       


        if (!jumpSelector)
        {
            groundCollider = Physics2D.OverlapCircle(checkPoints[0].position, checkRadius[0], layers);
        }
        else
        {
            raycastHits[0] = Physics2D.Raycast(checkPoints[1].position, Vector2.down, checkRadius[1], layers);
            raycastHits[1] = Physics2D.Raycast(checkPoints[2].position, Vector2.down, checkRadius[1], layers);
        }

        if (canJump && jump)
        {
            rb.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
            canJump = false;

        }

        if (xKeyboard)
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            anim.SetBool("Jump", false);
            rb.velocity = Vector2.zero;
        }

    }

    void shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void destroyPlayer(){

        Destroy(gameObject.transform.root.gameObject);
    }

    private void OnDestroy()
    {   //Cargar escena de  GAME OVER    
        SceneManager.LoadScene(0); 
    }
}

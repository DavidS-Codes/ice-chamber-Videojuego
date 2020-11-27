using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Physics Variables")]
    public float horizontalForce;
    public float maxHorizontalVelocity;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.AddForce(ForceDirection() * horizontalForce,
            ForceMode2D.Force);
        LimitVelocity();
    }

    private void LimitVelocity()
    {
        if (Mathf.Abs(rb.velocity.x) > maxHorizontalVelocity)
            rb.velocity = rb.velocity.normalized * maxHorizontalVelocity;
    }
    private Vector2 ForceDirection()
    {
        Vector2 vector;
        if (transform.localScale.x > 0)
            vector = Vector2.left;
        else
            vector = Vector2.right;

        return vector;
    }
}

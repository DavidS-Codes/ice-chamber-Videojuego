using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShootUnique : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = transform.right * speed;
        //The direction to shoot the bullet
        Vector3 pos = new Vector3( 1 * speed, 1*speed,0);
        //Shoot
        rb.velocity = pos;
    }

    // Update is called once per frame
  void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);
         Tilemap tilemap = coll.gameObject.GetComponent<Tilemap>();
        //Debug.Log(coll.gameObject);
        foreach (ContactPoint2D hit in coll.contacts)
        {
            Vector2 hitPoint = hit.point;
            //Debug.Log(hit.collider.transform.name);
            Debug.Log(hitPoint);
            //Debug.Log(tilemap.WorldToCell(hitPosition));
            tilemap.SetTile(tilemap.WorldToCell(hitPoint), null);
        }

    }
}

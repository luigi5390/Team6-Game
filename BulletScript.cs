using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 6;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //Vector2 direction = transform.TransformDirection(Vector3.forward * speed * 100);
        //rb2d.velocity = transform.forward.normalized * speed;
        //rb2d.AddForce(transform.up * 5000 * speed);
        rb2d.velocity = new Vector2(0, speed);
        //transform.position += transform.forward * Time.deltaTime * speed;

    }

    // Update is called once per frame
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

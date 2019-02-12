using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 600;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        Vector3 direction = transform.up;
        rb2d.velocity = direction * speed;

        //rb2d.velocity = transform.forward * speed;
        //Vector2 bulletaim = plyerctrl.transform.rotation * Vector3.forward;
        //Vector2 bulletaim = new Vector2(0, speed);
        //rb2d.AddForce(direction * speed);
        //    transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);

        //Vector2 direction = transform.TransformDirection(Vector3.forward * speed * 100);
        //rb2d.velocity = transform.forward.normalized * speed;
        //rb2d.AddForce(transform.up *  speed);
        //plyerctrl.transform.rotation.LookRotation;
        //rb2d.velocity = plyerctrl.movement;
        //transform.position += transform.forward * Time.deltaTime * speed;
        //rb2d.transform.position += transform.forward * Time.deltaTime * speed;
        //rb2d.velocity = new Vector2(direction.x * speed * 100f, direction.y * speed * 100f);
        //rb2d.velocity = bulletaim;
    }


    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision.collider, this.gameObject.GetComponent<Collider2D>());
        */

        this.gameObject.SetActive(false);
        collision.gameObject.SetActive(false);
    }
}

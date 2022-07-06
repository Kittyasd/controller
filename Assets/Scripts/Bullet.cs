using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 70;
    public Score Score;
    // Start is called before the first frame update
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (rb.transform.up * speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Border")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.name == "Box")
        {
            Vector2 reflectDir = Vector2.Reflect(rb.transform.up, collision.GetContact(0).normal);
                float rot = Mathf.Atan2(reflectDir.y, reflectDir.x) * Mathf.Rad2Deg;
                rb.transform.eulerAngles = new Vector3(0, 0, rot);
                rb.velocity = Vector2.Reflect(-collision.relativeVelocity.normalized, collision.contacts[0].normal) * speed;
        }
        if(collision.gameObject.name == "Player")
        {
            Score.GetComponent<Score>().EnemyWin();
        }
        if(collision.gameObject.name == "Enemy")
        {
            Score.GetComponent<Score>().PlayerWin();
        }
    }
}

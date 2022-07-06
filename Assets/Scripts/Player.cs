using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float speedRotate;
    public GameObject bullet;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0){
            if (Input.GetKey(KeyCode.Space))
         {
             Instantiate(bullet, shotPoint.position, rb.transform.rotation);
             timeBtwShots = startTimeBtwShots;
         }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
         {
             rb.transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
         }
         if (Input.GetKey(KeyCode.S))
         {
             rb.transform.Translate(-Vector3.up * speed * Time.fixedDeltaTime);
         }
         if (Input.GetKey(KeyCode.A))
         {
             rb.transform.Rotate(0, 0, speedRotate);
         }
         if (Input.GetKey(KeyCode.D))
         {
             rb.transform.Rotate(0, 0, speedRotate * -1);
         }
    }
}

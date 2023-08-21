using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSaw : MonoBehaviour
{
    float rotation = 0;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public GameObject pointA;
    public GameObject pointB;
    public float speed;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotation++);
        float point = currentPoint.position.x - transform.position.x;
        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Character chatacter = collision.GetComponent<Character>();
            chatacter.decrease(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    public float velocityY;
    public int changeSpeed;
    void Start()
    {
        velocityY = Random.Range(1f, 1.5f);
        rigidbody2D = GetComponent<Rigidbody2D>();
        int[] numbers = { -1, 1 };
        changeSpeed = numbers[Random.Range(0, 2)];
        rigidbody2D.velocity = new Vector2(0, velocityY * changeSpeed);
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y - Time.fixedDeltaTime * changeSpeed);
        if (System.Math.Abs(rigidbody2D.velocity.y) > velocityY)
        {
            changeSpeed *= -1;
        }
    }
}

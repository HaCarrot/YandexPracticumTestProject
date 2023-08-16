using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehavior : MonoBehaviour
{
    public float deformationSpeed;
    public float dampingSpeed;
    new Transform transform;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.localScale.x <= 0)
        {
            Destroy(this);
        }
        transform.localScale = new Vector3(transform.localScale.x - deformationSpeed * Time.fixedDeltaTime,
            transform.localScale.y - deformationSpeed * Time.fixedDeltaTime);
        spriteRenderer.color = new Color(255, 255, 255, spriteRenderer.color.a - dampingSpeed * Time.fixedDeltaTime);
    }
}

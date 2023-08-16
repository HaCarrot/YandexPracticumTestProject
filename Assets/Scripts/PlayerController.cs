using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameIsActive;
    new Rigidbody2D rigidbody2D;
    Rigidbody2D moneyRigidbody2D = null;
    new Transform transform;
    public int counter = 0;
    public float powerRight, powerUp, magnetForce;
    public TMPro.TextMeshPro counterTextMesh;
    public TMPro.TextMeshPro startTextMesh;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.simulated = false;
        transform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (!gameIsActive && (Input.GetButton("Jump") || Input.GetMouseButton(0)))
        {
            gameIsActive = true;
            startTextMesh.text = "";
            rigidbody2D.simulated = true;
        }
        else if(gameIsActive)
        {
            transform.position = new Vector3(transform.position.x + powerRight * Time.fixedDeltaTime, transform.position.y);
            if ((Input.GetButton("Jump") || Input.GetMouseButton(0)))
            {
                rigidbody2D.AddForce(transform.up * powerUp);
            }
            if (moneyRigidbody2D != null)
            {
                moneyRigidbody2D.velocity = (transform.position - moneyRigidbody2D.transform.position) * magnetForce * Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Zone")
        {
            moneyRigidbody2D = collision.GetComponentInChildren<Rigidbody2D>();
        }
        else if(collision.tag == "Finish")
        {
            rigidbody2D.simulated = false;
            rigidbody2D.velocity = new Vector2(0,0);
            transform.position = new Vector3(transform.position.x + 50, 0);
            gameIsActive = false;
            counter = 0;
            counterTextMesh.text = counter.ToString();
            startTextMesh.text = "Press SPACEBAR to start";
        }
        else if (collision.tag == "Money")
        {
            counter++;
            counterTextMesh.text = counter.ToString();
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Zone")
        {
            moneyRigidbody2D = null;
        }
    }
}

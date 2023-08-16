using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrack : MonoBehaviour
{
    public PlayerController playerController;
    float timer;
    public float frequencyTime;
    public float destroyTime;
    public GameObject particle;
    new Transform transform;
    void Start()
    {
        timer = frequencyTime;
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if(timer < 0 && playerController.gameIsActive)
        {
            Object particleObject = Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(particleObject, destroyTime);
            timer = frequencyTime;
        }
    }
}

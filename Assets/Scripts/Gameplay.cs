using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public GameObject money, obstacle;
    public float moneySpawnRate, obstacleSpawnRate;
    public PlayerController playerController;
    float moneyTimer, obstacleTimer;
    new Transform transform;
    void Start()
    {
        moneyTimer = 0;
        obstacleTimer = 0;
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerController.gameIsActive)
        {
            moneyTimer -= Time.fixedDeltaTime;
            obstacleTimer -= Time.fixedDeltaTime;
            if (moneyTimer < 0)
            {
                Vector3 moneyPosition = new Vector3(transform.position.x + Random.Range(9.0f, 15.0f), Random.Range(-3.0f, 3.0f), -1);
                GameObject moneyObject = Instantiate(money, moneyPosition, Quaternion.identity);
                Destroy(moneyObject, 7.0f);
                moneyTimer = moneySpawnRate;
            }
            if (obstacleTimer < 0)
            {
                for (int i = 0; i < 1 + playerController.counter / 2 + playerController.counter % 2; i++)
                {
                    Vector3 obstaclePosition = new Vector3(transform.position.x + Random.Range(9.0f, 13.0f), Random.Range(-3.0f, 3.0f), -1);
                    GameObject obstacleObject = Instantiate(obstacle, obstaclePosition, Quaternion.identity);
                    Destroy(obstacleObject, 5.0f);
                    obstacleTimer = obstacleSpawnRate;
                }
                obstacleTimer = obstacleSpawnRate;
            }
        }
    }
}

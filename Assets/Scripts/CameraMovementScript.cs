using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    public new GameObject camera;
    public GameObject player;
    public float biasX;
    void FixedUpdate()
    {
        float x = player.transform.position.x + biasX;
        float y = camera.transform.position.y;
        float z = camera.transform.position.z;
        camera.transform.position = new Vector3(x, y, z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Range(0.001f, 3)]
    public float moveSpeed = 0.1f;

    void Update()
    {
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed;
        transform.Translate(velocity);

        float rotation = 0;
        if (Input.GetKey(KeyCode.Q))
        {
            rotation -= 1;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotation += 1;
        }

        transform.Rotate(0, rotation, 0);
    }
}

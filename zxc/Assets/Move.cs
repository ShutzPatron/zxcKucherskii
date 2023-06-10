using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 moveVector;
    public float turnInput;
    public float mainSpeed = 10f;

    void FixedUpdate()
    {
        Moving();   
    }

    private void Moving()
    {
        Vector3 p = GetBaseInput();
        if (p.sqrMagnitude > 0)
        {
            p = p * Time.deltaTime * mainSpeed;
            transform.Translate(p);
            Vector3 newPosition = transform.position;
        }
    }
    private Vector3 GetBaseInput()
    {
        Vector3 p_Velocity = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation *= Quaternion.Euler(0, 5f * Time.deltaTime * mainSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation *= Quaternion.Euler(0, -5f * Time.deltaTime * mainSpeed, 0);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            p_Velocity += new Vector3(0, 1 * Input.GetAxis("Mouse ScrollWheel") * 10, 0);
        }
        return p_Velocity;
    }
}

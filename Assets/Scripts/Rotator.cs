using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    float counter;
    public float speed = 3;
    public Vector3 Movement;
    public float angle;

    void Start()
    {
        counter = 0;
    }
    void Update()
    {
        counter += speed*Time.deltaTime;
        transform.Rotate(Vector3.right * angle * Time.deltaTime);
        transform.Translate(Movement * Mathf.Sin(counter), Space.World);
    }

}

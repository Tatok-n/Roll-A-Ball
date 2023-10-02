using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRotate : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;
    public Vector3 Rotationadj;
    public Vector3 Rotation;

    // Start is called before the first frame updat

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target, offset);
        Rotation = transform.eulerAngles;
        transform.eulerAngles = new Vector3(Rotationadj.x, Rotation.y, Rotation.x);
    }
}

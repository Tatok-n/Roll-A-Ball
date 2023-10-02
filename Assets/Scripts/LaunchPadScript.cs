using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadScript : MonoBehaviour
{
    public Transform Target;
    public PlayerController pc;
    public Vector3 direction;
    public Rigidbody ball;
    public float Strength = 30f;
    public CameraController cc;
    public Zone2ADj z2;
    // Start is called before the first frame update
    void Start()
    {
        direction = (Target.position - transform.position);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !(pc.zone1))
        {
            ball.position = Target.position;
            cc.offset = new Vector3(0f, 2f, -2f);
            pc.zone2 = true;
            z2.DisableTurrets();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone2ADj : MonoBehaviour
{
    public CameraController CC;
    public Turret[] TurretList;
    public GameObject[] pickups;

    // Start is called before the first frame update
    void Start()
    {
        //DisableTurrets();
       
    }

    public void DisableTurrets()
    {
        foreach (Turret t2 in TurretList)
        {
            t2.Disable();
        }
    }

    public void EnableTurrets()
    {
        foreach (Turret t2 in TurretList)
        {
            t2.Enable();
        }
    }


    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter(Collider other)
        {
            if (CC.offset == CC.OGoffset)
            {
                return;
            }
            else if (other.gameObject.CompareTag("Player"))
            {
             
                CC.offset = CC.OGoffset;
                
              
            } 
        }
    }
}

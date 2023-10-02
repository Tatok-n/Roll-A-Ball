using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Turret : MonoBehaviour
{
    public Transform Target;
    public Transform Defaultstate;
    public Vector3 defaultrotation;
    public Vector3 Rotationadj;
    private Vector3 Rotation;
    private int counter;
    public Vector3 offset;
    public int interval;
    public Transform rayemmiter;
    public Vector3 rayboy;
    public PlayerController cs;
    public Vector3 NewVector;
    public RaycastHit hit2;
    public Vector3 targetpos;
    public Vector3 ShootingVector;
    public Transform laserOrigin;
    public LineRenderer laserLine;
    public GameObject aimer;
    public bool isActive;



    // Start is called before the first frame update
    void Awake()
    {
        
    }
    
    void Start()
    {
        Defaultstate = transform;
        defaultrotation = Defaultstate.eulerAngles;
        counter = 0;
        laserLine.SetPosition(0, laserOrigin.position);
        isActive = true;

    }

    public void SetUpShot()
    {
          transform.LookAt(Target,offset);
          transform.position = Defaultstate.position;
          Rotation = transform.eulerAngles;
        //Debug.DrawLine(rayboy, NewVector, Color.white, 1.5f);
        laserLine.endColor = Color.white;
        laserLine.startColor = Color.white;



        if (Physics.Raycast(rayboy, NewVector, out hit2))
           {
            targetpos = hit2.point;
            laserLine.SetPosition(1, targetpos);
           }
          
        Vector3 rayOrigin = rayboy;
        laserLine.enabled = true;



    }

    public void Shoot()
    {

        ShootingVector = (targetpos - rayboy) * 50;
        //Debug.DrawLine(rayboy, ShootingVector, Color.red);
        
        RaycastHit hit;
        if (Physics.Raycast(rayboy, ShootingVector, out hit))
        {
            laserLine.endColor = Color.red;
            laserLine.startColor = Color.red;
            laserLine.SetPosition(1, hit.point);
            if (hit.collider.tag == "Player")
            {
                cs.Restart();
            }
        }
    }

    void Update()
    {
       
    }

    public void Disable()
    {
        aimer.SetActive(false);
        isActive = false;
    }

    public void Enable()
    {
        aimer.SetActive(true);
        isActive = true;
        counter = 0;
    }
    void FixedUpdate()
    {
        counter += 1;
        rayboy = rayemmiter.position;
        NewVector = Target.position - rayboy;
        NewVector *= 50;
        if (!isActive)
        {
            return;
        }
        if (counter == interval)
        {
            
            Shoot();
           
            

        } else if (counter == 2*interval)
        {
            counter = 0;
            SetUpShot();
            transform.eulerAngles = new Vector3(Rotationadj.x, Rotation.y, Rotation.z);

        }
    }
}

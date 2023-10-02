using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private Vector3 movement;
    public float speed = 0;
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public float Resetlevel;
    public Vector3 direction;
    public Vector3 pastlocation;
    public Vector3 currentlocation;
    public Turret tr;
    public Vector3 Zone1bounds;
    public bool zone1;
    public int zone1Count;
    public int zone2Count;
    public bool zone2;
    public Transform zone2Tar;
    public CameraController CC;
    public Zone2ADj z2;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        Resetlevel = 0.4f;
        currentlocation = transform.position;
        zone1 = true;
        
    }

    public void Restart()
    {
        if (zone1||!zone2)
        {
            SceneManager.LoadScene("minigame", LoadSceneMode.Single);
        }
        else if (zone2)
        {
            CC.offset = new Vector3(0f, 2f, -2f);
            count = zone1Count;
            transform.position = zone2Tar.position;
            foreach(GameObject gobj in z2.pickups)
            {
                gobj.gameObject.SetActive(false);

            }
            z2.DisableTurrets();
            speed = 10f;
            foreach (GameObject gobj in z2.pickups)
            {
                gobj.gameObject.SetActive(true);

            }
            SetCountText();

        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void SetCountText()
    {
        if (count >= zone2Count)
        {
            winTextObject.SetActive(true);
        }
        countText.text = "Count :" + count.ToString();

    }
    private void FixedUpdate()
    {
        rb.AddForce(movement*speed);
        movement = new Vector3(movementX, 0.0f, movementY);
        if (transform.position.y < Resetlevel)
        {
           
            Restart();
        }
        Vector3 temp;
        temp = currentlocation;
        currentlocation = transform.position;
        pastlocation = temp;
        direction = currentlocation - pastlocation;
        if (count>=zone1Count)
        {
            tr.Disable();
            zone1 = false;
        } 
        if (count>=zone2Count)
        {
            z2.DisableTurrets();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        } else if (other.gameObject.CompareTag("Finish"))
            {
            CC.offset = CC.OGoffset;
            if (!z2.TurretList[0].isActive)
            {
                z2.EnableTurrets();
                
            }
            
        } else if(other.gameObject.CompareTag("SpeedUp"))
        {
            speed *= 1.75f;
            other.gameObject.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

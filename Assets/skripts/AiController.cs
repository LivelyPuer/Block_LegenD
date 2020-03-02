using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class AiController : MonoBehaviour
{
    [SerializeField] public int MyScore = 0;
    private float X;
    private float Y = 1.2f;
    private float Z;
    public Vector3 pos = Vector3.zero; 
    private Rigidbody rb;
    //public GameObject ai;
    public GameObject gunAi;
    private bool fire = true;
    private float timeMove = 1f;
    private float timeFire;
    private int value;
    private float timePer = 1f;
    [SerializeField] public int speed = 5;
    [SerializeField] public int speedRotate = 3;
    // Start is called before the first frame update
    void Start()
    {
        pos.x = UnityEngine.Random.Range(-50f, 20f);
        pos.y = 1.2f;
        pos.z = UnityEngine.Random.Range(-30f, 40f);
        rb = gameObject.GetComponent<Rigidbody>();
        timeFire = gunAi.GetComponent<Gun>().time_fire;
    }

    // Update is called once per frame
    Vector3 vect = new Vector3();
    void Update()
    {
        timeMove -= Time.deltaTime;
        if (fire == false)
        {
            timePer -= Time.deltaTime;
            if (timePer < 0)
            {
                fire = true;
                timeFire = gunAi.GetComponent<Gun>().time_fire;
            }
        }
        if (Math.Abs(gameObject.transform.position.x - pos.x) <= 1 || Math.Abs(gameObject.transform.position.z - pos.z) <= 1)
        {
            //gameObject.Set
        }
        gameObject.transform.Translate(pos * speed * Time.deltaTime);

    }

    private void OnTriggerStay(Collider other)
    {
        fire = true;
        if (other.tag == "Player" || other.tag == "Ground")
        {
            timeFire -= Time.deltaTime;
            if (timeFire > 0)
            {
                value = UnityEngine.Random.Range(1, 6);
                //Move(value);
                //Move(5);
            }
            else
            {
                fire = false;
                timePer = 1f;

            }
        }
        else
        {
            timeFire = gunAi.GetComponent<Gun>().time_fire;
            fire = true;
        }
    }

    public void Move(int move)
    {
        switch (move)
        {
            case 1:
                rb.transform.position
                += rb.transform.forward * speed * Time.deltaTime;
                break;
            case 2:
                rb.transform.position
                -= rb.transform.forward * speed * Time.deltaTime;
                break;
            case 3:
                rb.transform.Rotate(Vector3.down * speed);
                break;
            case 4:
                rb.transform.Rotate(Vector3.up * speed);
                break;
            case 5:
                gunAi.GetComponent<Gun>().Shoot();
                Move(2);
                int varing = UnityEngine.Random.Range(1, 3);
                switch (varing)
                {
                    case 1:
                        Move(3);
                        break;
                    case 2:
                        Move(4);
                        break;
                }
                break;
            default:
                break;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
//using System;

public class AIControllerNavMesh : MonoBehaviour
{
    public GameObject player;
    [SerializeField] public int MyScore = 0;
    public GameObject Gide;
    public int speed = 5;
    public int speedOtd = 25 ;
    private Rigidbody rb;
    public Vector3 pos;
    public GameObject gunAi;
    [SerializeField] float timeFire;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        pos = Gide.transform.position;
        //timeFire = gunAi.GetComponent<Gun>().time_fire;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pos = Gide.transform.position;
        agent.SetDestination(pos);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.transform.LookAt(player.transform.position);
            Move(3);
            int v = Random.Range(1, 601);
            if (v % 200 == 0)
            {
                gunAi.GetComponent<Gun>().ShootForAi();
                rb.transform.position
                    -= rb.transform.forward * speedOtd * Time.deltaTime;
            }
            

        }
    }

    public void Move(int move)
    {
        switch (move)
        {
            case 1:
                rb.transform.Rotate(Vector3.down * speed * UnityEngine.Random.Range(0.1f, 0.6f));
                break;
            case 2:
                rb.transform.Rotate(Vector3.up * speed * UnityEngine.Random.Range(0.1f, 0.6f));
                break;
            case 3:;
                int varing = UnityEngine.Random.Range(1, 3);
                switch (varing)
                {
                    case 1:
                        Move(1);
                        gunAi.GetComponent<Gun>().ShootForAi();
                        break;
                    case 2:
                        Move(2);
                        gunAi.GetComponent<Gun>().ShootForAi();
                        break;
                }
                break;
            case 4:
                rb.transform.position
                -= rb.transform.forward * speed * Time.deltaTime;
                break;
            default:
                break;
        }
    }
}

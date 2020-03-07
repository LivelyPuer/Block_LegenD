using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gide : MonoBehaviour
{
    public Vector3 GidePos;
    public float MaxX = -50f;
    public float MinX = 20f;
    public float MaxZ = -20f;
    public float MinZ = 40f;
    void Start()
    {
        GidePos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GidePos.x = Random.Range(MinX, MaxX);
            GidePos.z = Random.Range(MinZ, MaxZ);
            gameObject.transform.position = GidePos;
        }
        

    }
}

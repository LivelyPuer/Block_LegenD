using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] public GameObject bullet;
    [SerializeField] public Transform shootPoint;
    [SerializeField] public float Impulse;
    [SerializeField] [Range(0.1f, 2f)] public float time_fire;
    [SerializeField] public bool auto;
    void Start()
    {

    }

    public void Shoot()
    {
        GameObject b = GameObject.Instantiate(
                bullet,
                shootPoint.position + shootPoint.forward,
                shootPoint.rotation
                );
        b.GetComponent<Rigidbody>().AddRelativeForce(
            Vector3.forward * Impulse,
            ForceMode.Impulse
            );
    }
}

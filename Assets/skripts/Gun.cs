using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] public GameObject bullet;
    [SerializeField] public Transform shootPoint;
    [SerializeField] public float Impulse;
    public int BulletInMagazineNow;
    [SerializeField] [Range(1, 100)] public int NumBulletInMagazine;
    [SerializeField] public int NumBulletAll;


    [SerializeField] public bool auto;
    void Start()
    {
        BulletInMagazineNow = NumBulletInMagazine;
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

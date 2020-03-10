using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] public GameObject bullet;
    [SerializeField] private GameObject master;
    [SerializeField] public Transform shootPoint;
    [SerializeField] public float Impulse;
    [SerializeField] public bool MeleeWeapons;
    public PlayerController PL;
    private bool DistationForFire;
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
        if (MeleeWeapons)
        {
            MeleeWeaponsShoot();
        }
        else
        {
            WeaponsShoot();
        }
    }
    private void MeleeWeaponsShoot()
    {
        if (DistationForFire)
        {
            Debug.Log("Fire");
            master.GetComponent<PlayerController>().MyScore += 5;
        }
        
    }
    private void WeaponsShoot()
    {
        if(BulletInMagazineNow > 0)
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
            BulletInMagazineNow--;
            PL.Move(-0.3f, 0);
            int varing = Random.Range(1, 3);
            switch (varing)
            {
                case 1:
                    PL.Move(0, -0.6f);
                    break;
                case 2:
                    PL.Move(0, 0.6f);
                    break;
            }
        }
        
    }
    public void ShootForAi()
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
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            DistationForFire = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        DistationForFire = false;
    }
}

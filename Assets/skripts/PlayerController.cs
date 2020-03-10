using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [SerializeField] public int MyScore = 0;
    private Animator anim;
    private ScoreController sc;
    public WeaponGet useGun;
    public List<GameObject> guns = new List<GameObject>();
    private Rigidbody rb;
    public bool fire = true;
    [SerializeField] public int speed = 5;
    [SerializeField] public int speedRotate = 3;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        sc = GameObject.FindWithTag("HUD").GetComponent<ScoreController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        sc.Bullet.text = guns[useGun.IndexGun].GetComponent<Gun>().BulletInMagazineNow + " | " + guns[useGun.IndexGun].GetComponent<Gun>().NumBulletAll;
        if (Input.GetKeyDown(KeyCode.Space) && guns[useGun.IndexGun].GetComponent<Gun>().auto == false)
        {
            anim.SetBool("Fire", true);
            NoAutoShoot();
        }
        if (Input.GetKey(KeyCode.Space) && guns[useGun.IndexGun].GetComponent<Gun>().auto == true)
        {
            anim.SetBool("Fire", true);
            AutoShoot();
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Fire", false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadMagazine();
        }
    }

    public void Move(float v, float h)
    {
        rb.position += v * rb.transform.forward * speed * Time.deltaTime;
        if (v != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        rb.transform.Rotate(h * Vector3.up * speed);
    }

    public void Domage()
    {

    }

    public void Shooting()
    {
        guns[useGun.IndexGun].GetComponent<Gun>().Shoot(); 
    }

    public void AutoShoot()
    {
        
        int y = Random.Range(1, 201);
        if (y % 2 == 0)
        {
            Shooting();
        } 
    }

    public void NoAutoShoot()
    {
        Shooting();
    }

    public void ReloadMagazine()
    {
        if (guns[useGun.IndexGun].GetComponent<Gun>().NumBulletAll < guns[useGun.IndexGun].GetComponent<Gun>().NumBulletInMagazine)
        {
            Debug.Log("If");
            guns[useGun.IndexGun].GetComponent<Gun>().BulletInMagazineNow = guns[useGun.IndexGun].GetComponent<Gun>().NumBulletAll;
            guns[useGun.IndexGun].GetComponent<Gun>().NumBulletAll = guns[useGun.IndexGun].GetComponent<Gun>().NumBulletAll - guns[useGun.IndexGun].GetComponent<Gun>().NumBulletAll;
        }
        else
        {
            guns[useGun.IndexGun].GetComponent<Gun>().BulletInMagazineNow = guns[useGun.IndexGun].GetComponent<Gun>().NumBulletInMagazine;
            guns[useGun.IndexGun].GetComponent<Gun>().NumBulletAll = guns[useGun.IndexGun].GetComponent<Gun>().NumBulletAll - guns[useGun.IndexGun].GetComponent<Gun>().NumBulletInMagazine;
        }
    }
}

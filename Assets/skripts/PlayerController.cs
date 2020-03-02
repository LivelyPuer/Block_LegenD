using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] public int MyScore = 0;
    private Animator anim;
    public WeaponGet useGun;
    public List<GameObject> guns = new List<GameObject>();
    private Rigidbody rb;
    public bool fire = true;
    private float timeFire;
    private float timePer = 1f;
    [SerializeField] public int speed = 5;
    [SerializeField] public int speedRotate = 3;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        timeFire = guns[useGun.IndexGun].GetComponent<Gun>().time_fire;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fire == false)
        {
            timePer -= Time.deltaTime;
            if (timePer < 0)
            {
                fire = true;
                timeFire = guns[useGun.IndexGun].GetComponent<Gun>().time_fire;
            }
        }

        Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Space) && guns[useGun.IndexGun].GetComponent<Gun>().auto == false)
        {
            guns[useGun.IndexGun].GetComponent<Gun>().Shoot();
            Move(-0.3f, 0);
        }
        if (Input.GetKey(KeyCode.Space) && fire == true && guns[useGun.IndexGun].GetComponent<Gun>().auto == true)
        {
            anim.SetBool("Fire", true); 
            timeFire -= Time.deltaTime;
            if (timeFire > 0)
            {
                guns[useGun.IndexGun].GetComponent<Gun>().Shoot();
                Move(-0.3f, 0);
                
                int varing = Random.Range(1, 3);
                switch (varing)
                {
                    case 1:
                        Move(0, -0.6f);
                        break;
                    case 2:
                        Move(0, 0.6f);
                        break;
                }
            }
            else
            {
                fire = false;
                timePer = 1f;
            }
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Fire", false);
            timeFire = guns[useGun.IndexGun].GetComponent<Gun>().time_fire;
            fire = true;
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
}

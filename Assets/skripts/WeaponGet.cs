using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponGet : MonoBehaviour
{
    public List<GameObject> guns = new List<GameObject>();
    public int IndexGun;
    public GameObject player;
    public Animator PlayerAnim;

    void Start()
    {
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseGun(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseGun(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseGun(2);
        }
    }

    public void UseGun(int i)
    {
        
        if (IndexGun == i)
        {
            gameObject.SetActive(false);
            return;
        }
        foreach (GameObject g in guns)
        {
            g.SetActive(false);
        }
        player.GetComponent<PlayerController>().GunIndex = i;
        IndexGun = i;
        if (guns[IndexGun].GetComponent<Gun>().MeleeWeapons)
        {
            PlayerAnim.SetBool("KnifeInArm", true);
        }
        else
        {
            PlayerAnim.SetBool("KnifeInArm", false);
        }
        guns[IndexGun].SetActive(true);
        gameObject.SetActive(false);
    }

}

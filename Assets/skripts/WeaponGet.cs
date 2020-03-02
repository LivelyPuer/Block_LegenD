using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponGet : MonoBehaviour
{
    public List<GameObject> guns = new List<GameObject>();
    public int IndexGun;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").gameObject;
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
        //if (Input.GetKeyDown(KeyCode.Keypad3))
        //{
        //    UseGun(0);
        //}
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
        IndexGun = i;
        guns[IndexGun].SetActive(true);
        gameObject.SetActive(false);
    }

}

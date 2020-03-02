using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{

    Animator animer;
    void Start()
    {
        animer = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        animer.SetBool("Fire", gameObject.GetComponent<PlayerController>().fire);
    }
}

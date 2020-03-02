using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStrela : MonoBehaviour
{
    private Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hit);
        gameObject.transform.LookAt(hit.point);
    }
}

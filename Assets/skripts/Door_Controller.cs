using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Controller : MonoBehaviour
{
    [SerializeField] public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Bullet")
        {
            door.GetComponent<Animator>().SetBool("In", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Bullet")
        {
            door.GetComponent<Animator>().SetBool("In", false);
        }
    }
}

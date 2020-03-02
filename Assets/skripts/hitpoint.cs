using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitpoint : MonoBehaviour
{
    public float MaxTimeHit = 1f;
    public float TimeHit;
    private int last;
    private int now;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (TimeHit > 0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            TimeHit = 0;
            gameObject.SetActive(false);
        }
        if (TimeHit > 0)
        {
            TimeHit = TimeHit - Time.deltaTime;
        }
    }
}

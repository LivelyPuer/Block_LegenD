using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSettings : MonoBehaviour
{
    public List<GameObject> people = new List<GameObject>();
    [SerializeField] private Canvas ES;
    private GameObject bullet;
    public bool player;
    private GameObject master;
    public GameObject enemy;
    void Start()
    {
        bullet = (GameObject)this.gameObject;
        ES = GameObject.FindWithTag("HUD").GetComponent<Canvas>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player)
        {
            master = GameObject.FindWithTag("Player").gameObject;
        }
        else
        {
            master = GameObject.FindWithTag("Enemy").gameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            Bul_Destroy();
        }
        if (other.tag == "Player" && player == false)
        {
            master.GetComponent<AIControllerNavMesh>().MyScore++;
            Bul_Destroy();
        }
        if (other.tag == "Enemy" && player == true)
        {
            master.GetComponent<PlayerController>().MyScore++;
            Bul_Destroy();
        }

        

    }

    public void Bul_Destroy()
    {
        Destroy(bullet);
    }
}

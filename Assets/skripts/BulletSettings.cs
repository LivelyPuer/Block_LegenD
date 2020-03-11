using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSettings : MonoBehaviour
{
    //public List<GameObject> people = new List<GameObject>();
    [SerializeField] private Canvas ES;
    private GameObject bullet;
    public bool player;
    // private GameObject master;
    private GameObject master;

    public GameObject enemy;
    void Start()
    {
        if (player)
        {
            master = GameObject.Find("player").gameObject;
        }
        else
        {
            master = GameObject.Find("bot").gameObject;
        }
        bullet = (GameObject)this.gameObject;
        ES = GameObject.FindWithTag("HUD").GetComponent<Canvas>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (master == null)
        {
            Bul_Destroy();
            return;
        }
        switch (other.tag)
            {
            case "Player":
                Debug.Log(master);
                // Debug.Log(master.GetComponent<AIControllerNavMesh>());
                if (master.tag == "Enemy")
                {
                    master.GetComponent<AIControllerNavMesh>().MyScore++;

                }
                break;
            case "Enemy":
                Debug.Log("Я попал " + master);
                if (master.tag == "Player")
                {
                    master.GetComponent<PlayerController>().MyScore++;
                }                
                break;
            case "Ground":
            case " ":
            case "":
            case "Untagged":
                break;
            default:
                break;
            }
        Bul_Destroy();
    }

    public void Bul_Destroy()
    {
        Destroy(bullet);
    }
}

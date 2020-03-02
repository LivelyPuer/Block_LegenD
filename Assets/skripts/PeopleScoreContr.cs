using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeopleScoreContr : MonoBehaviour
{
    public GameObject prefab;
    private Text Score;
    public bool player;
    void Start()
    {
        Score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == true)
        {
            Score.text = "" + prefab.GetComponent<PlayerController>().MyScore;
        }
        else
        {
            Score.text = "" + prefab.GetComponent<AIControllerNavMesh>().MyScore;
        }
        
    }
}

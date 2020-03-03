using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    [SerializeField] public List<GameObject> redTeam = new List<GameObject>();
    [SerializeField] public List<GameObject> blueTeam = new List<GameObject>();
    public float KP;
    public GameObject Win;
    public int ScoreRed = 0;
    public int ScoreBlue = 0;
    //public GameObject red;
    //public GameObject blue;
    [SerializeField] Text ScoreBlueUI;
    [SerializeField] Text YP;
    [SerializeField] Text ScoreRedUI;
    [SerializeField] public Text Bullet;
    // Start is called before the first frame update
    void Start()
    {
        Win.SetActive(false);
        foreach (GameObject red in redTeam)
        {
            if (red.tag == "Player")
            {
                red.GetComponent<PlayerController>().MyScore = 0;
            }
            else
            {
                red.GetComponent<AIControllerNavMesh>().MyScore = 0;
            }
        }
        foreach (GameObject blue in blueTeam)
        {
            if (blue.tag == "Player")
            {
                blue.GetComponent<PlayerController>().MyScore = 0;
            }
            else
            {
                blue.GetComponent<AIControllerNavMesh>().MyScore = 0;
            }
        }
        //blue.GetComponent<PlayerController>().MyScore = 0;
        //red.GetComponent<AiController>().MyScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        ScoreRed = 0;
        ScoreBlue = 0;
        foreach (GameObject red in redTeam)
        {
            if (red.tag == "Player")
            {
                ScoreRed = ScoreRed + red.GetComponent<PlayerController>().MyScore;
            }
            else
            {
                ScoreRed = ScoreRed + red.GetComponent<AIControllerNavMesh>().MyScore;
            }
        }
        foreach (GameObject blue in blueTeam)
        {
            if (blue.tag == "Player")
            {
                ScoreBlue = ScoreBlue + blue.GetComponent<PlayerController>().MyScore;
            }
            else
            {
                ScoreBlue = ScoreBlue + blue.GetComponent<AIControllerNavMesh>().MyScore;
            }
        }
        ScoreBlueUI.text = "Blue: " + ScoreBlue;
        ScoreRedUI.text = "Red: " + ScoreRed;
        if (ScoreRed + ScoreBlue == 0)
        {
            YP.text = "0";
        }
        else
        {
            YP.text = ((float)ScoreBlue/(ScoreBlue + ScoreRed)).ToString("N") + "/" + ((float)ScoreRed/(ScoreRed + ScoreBlue)).ToString("N");
        }
        if (ScoreBlue+ScoreRed > 300){
            if ((float)ScoreBlue / (ScoreBlue + ScoreRed) > 0.6)
            {
                YP.text = "Blue WIN!";
                Win.SetActive(true);
                Win.GetComponentInChildren<Text>().text = "Blue WIN!";
                Time.timeScale = 0f;
            } else if ((float)ScoreRed / (ScoreRed + ScoreBlue) > 0.6){
                YP.text = "Red WIN!";
                Win.SetActive(true);
                Win.GetComponentInChildren<Text>().text = "Red WIN!";
                Time.timeScale = 0f;
            }
        }
    }

    //public void PlusRed(int num)
    //{
    //    Debug.Log("Obj: " + this.gameObject.GetInstanceID() + " Score red: " + this.redScore);
    //    redScore++;
    //}

    //public void PlusBlue(int num)
    //{
    //    Debug.Log("Obj: " + this.gameObject.GetInstanceID() + " Score red: " + this.redScore);
    //    blueScore++;
    //}

}

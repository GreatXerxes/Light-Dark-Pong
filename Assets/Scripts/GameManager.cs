using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject score;
    Text aiText;
    Text playerText;

    //Score
     int aiScore = 0;
     int playerScore = 0;

    public GameObject ball;
    public GameObject counter;

    //Power-ups
    bool canSpawn;
    public GameObject multiball;

    bool newRound;

    // Use this for initialization
    void Start ()
    {
        score = GameObject.Find("Score UI");
        Transform panel = score.transform.FindChild("Panel");
        aiText = panel.FindChild("AI Score").GetComponent<Text>();
        playerText = panel.FindChild("Player Score").GetComponent<Text>();

        aiText.text = ""+aiScore;
        playerText.text = ""+playerScore;

        //counter = GameObject.Find("Timer UI");
        counter.SetActive(false);
        canSpawn = false;
        nextRound();
    }

    int chan;
    void FixedUpdate()
    {
        GameObject multiObj = GameObject.Find("MultiBall");

        if (!canSpawn)
        {
            StartCoroutine(powerupSpawnTimer());
        }

        if(multiObj == null && !newRound && canSpawn)
        {
            chan = Random.Range(1, 101);

            if (chan > 95)
            {
                Vector3 pos = new Vector3(Random.Range(-2.8f, 2.8f), 0.5f, Random.Range(-5, 5));
                GameObject multi = Instantiate(multiball);
                multi.transform.position = pos;
                multi.name = "MultiBall";
            }
        }

    }
	
	IEnumerator powerupSpawnTimer()
    {
        yield return new WaitForSeconds(10);
        canSpawn = true;
    }

    public void applyScore(int num, bool isMulti)
    {
        if (num == 1)
        {
            playerScore += 1;
            Debug.Log("" + playerScore);
        }
        if(num == 2)
        {
            aiScore += 1;
            Debug.Log("" + aiScore);
        }
        aiText.text = "" + aiScore;
        playerText.text = "" + playerScore;


        if(!isMulti)
        {
            nextRound();
        }

        
    }

    void nextRound()
    {
        newRound = true;

        GameObject oldBall = GameObject.Find("Ball");
        Destroy(oldBall);

        for (int o = 0; o < 2; o++)
        {
            string nam = "multiball" + o;
            GameObject multi = GameObject.Find(nam);
            if(multi != null)
            {
                Destroy(multi);
            }
            
        }

        GameObject multiObj = GameObject.Find("MultiBall");
        if(multiObj != null)
        {
            Destroy(multiObj);
        }

        StartCoroutine(spawnBall());
        
    }

    IEnumerator spawnBall()
    {
        counter.SetActive(true);
        Text counterText = counter.transform.FindChild("Text").GetComponent<Text>();

        for (int i = 3; i>-1; i--)
        {
            
            if(i > 0)
            {
                counterText.text = ""+i;
            }
            else
            {
                counterText.text = "GO";
            }

            yield return new WaitForSeconds(1);
            
        }

        counter.SetActive(false);

        GameObject newBall = Instantiate(ball);
        newBall.name = "Ball";

        newRound = false;
    }

    public void powerupMultiball(GameObject obj)
    {
        Destroy(obj);

        for(int o = 0; o<2; o++)
        {
            GameObject multi = Instantiate(ball);
            multi.name = "multiball"+o;
        }
        canSpawn = false;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject deamon;
    public GameObject player;
    public int killCount = 0;
    private int waveKill = 0;
    public Text killText;
    public Text gameEndText;
    public Text timer;
    private float timeLeft = 30f;
    private int waveSize = 1;
    private bool gameOver1 = false;

    // Start is called before the first frame update
    void Start()
    {
        nextWave();
        killText = GameObject.Find("KillCounter").GetComponent<Text>();
        gameEndText = GameObject.Find("EndText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver1 && Input.GetKeyDown(KeyCode.Space)) {
	    Time.timeScale = 1;
            Application.LoadLevel(0);
        }

	if(Input.GetKeyDown(KeyCode.Space)){
	   Time.timeScale = 1;
	}

        updateTimer();
        if (waveKill == waveSize-1)
            nextWave();
    }

    void nextWave(){
        waveKill = 0;
	for(int i = 0; i < waveSize; i++)
		{
            SpawnOne();
		}
        waveSize++;
	}

    void SpawnOne()
    {


        GameObject newDeamon = Instantiate(deamon);
        newDeamon.transform.position = new Vector3(Random.Range(-85, 85), 100, Random.Range(-85, 85));
        if (Vector2.Distance(newDeamon.transform.position, player.transform.position) < 50)
        {
            Destroy(newDeamon);
            SpawnOne();
        }
    }
    public void addKill()
    {
        killCount++;
        waveKill++;
        killText.text = "Kills: " + killCount.ToString();
    }


        void updateTimer() {
            timeLeft -= Time.deltaTime;
            timer.text = timeLeft.ToString();
            if (timeLeft < 0)
            {
                GameOver(true);
            }


        }

        public void GameOver(bool win) {
	if(win){
	  gameEndText.text = "Succes!";

	}
	else
	gameEndText.text = "Game Over!";
	    

        	Time.timeScale = 0;
		gameOver1 = true;
        }
    }




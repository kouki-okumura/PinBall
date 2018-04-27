using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallController : MonoBehaviour {
    private int score = 0;
    private float visiblePosZ = -6.5f;
    private GameObject gameoverText;
    private GameObject scoreText;
	// Use this for initialization
	void Start () {
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("Score");
        scoreText.GetComponent<Text>().text = "Score" + 0;
    }
	
	// Update is called once per frame
	void Update () {
        
		if(this.transform .position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
	}
    private void OnCollisionEnter(Collision other)
    {
     if(other.gameObject .tag == "SmallStarTag")
        {
            score += 10;
            scoreText.GetComponent<Text>().text = "Score" + score;
        } 
     if(other.gameObject .tag == "LargeStarTag")
        {
            score += 20;
            scoreText.GetComponent<Text>().text = "Score" + score;
        }
     if(other.gameObject .name == "SmallCloudPrefab")
        {
            score += 30;
            scoreText.GetComponent<Text>().text = "Score" + score;
        }
     if(other.gameObject .name == "LargeCloudPrefab")
        {
            score += 40;
            scoreText.GetComponent<Text>().text = "Score" + score;
        }
    }
}

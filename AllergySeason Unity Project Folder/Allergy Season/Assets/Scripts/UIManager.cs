using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text Player1ScoreDisplay;
    public Text Player2ScoreDisplay;
    public int Player1Score;
    public int Player2Score;

    // Use this for initialization
    void Start () {
        Player1ScoreDisplay.text = "Score:" + Player1Score;
        Player2ScoreDisplay.text = "Score:" + Player2Score;
	}
	
	// Update is called once per frame
	void Update () {
        Player1ScoreDisplay.text = "Score:" + Player1Score;
        Player2ScoreDisplay.text = "Score:" + Player2Score;
    }
}

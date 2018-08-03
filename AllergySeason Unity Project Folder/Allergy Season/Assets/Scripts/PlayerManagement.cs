using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManagement : MonoBehaviour {

    public float Player1Power=0;
    public float Player2Power =0;
    public int Player1Score;
    public int Player2Score;
    public int TotalScore;
    public Text Player1ScoreDisplay;
    public Text Player2ScoreDisplay;

    public float riseSpeed;

    private static PlayerManagement instance;
    public static PlayerManagement Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        Player1ScoreDisplay.text = "Score:" + Player1Score;
        Player2ScoreDisplay.text = "Score:" + Player2Score;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Player1ScoreDisplay.text = "Score:" + Player1Score;
        Player2ScoreDisplay.text = "Score:" + Player2Score;

        if (Player1Power < 100)
        {
            Player1Power += Time.fixedDeltaTime * riseSpeed;
        }
        if (Player2Power < 100)
        {
            Player2Power += Time.fixedDeltaTime * riseSpeed;
        }
        if (TotalScore >= 10)
        {
            if (Player1Score > Player2Score)
            {
                print("Player1 wins!");
            }
            if (Player1Score < Player2Score)
            {
                print("Player2 wins!");
            }
            if (Player1Score == Player2Score)
            {
                print("Draw!");
            }
        }
    }
}

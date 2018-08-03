using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour {

    public float Player1Power=0;
    public float Player2Power =0;
    public int Player1Score;
    public int Player2Score;
    public int TotalScore;

    public float riseSpeedP1;
    public float riseSpeedP2;

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
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Player1Power < 100)
        {
            Player1Power += Time.fixedDeltaTime * riseSpeedP1;
        }
        if (Player2Power < 100)
        {
            Player2Power += Time.fixedDeltaTime * riseSpeedP2;
        }
        if (TotalScore == 10)
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

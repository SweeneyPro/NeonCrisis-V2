using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Updater : MonoBehaviour {

    public static Score_Updater score_updater;
    Text score_text;
    int score = 0;

	// Use this for initialization
	void Start () {
        score_updater = this;
        score_text = GetComponent<Text>();
	}
	
    public void Add_Score()
    {
        score++;
        score_text.text = score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public static List<int> scoreList = new List<int>();

    public Text highestscoreText;
    public Text score1txt;
    public Text score2txt;
    public Text score3txt;
    public Text score4txt;
    public Text score5txt;
    public Text score6txt;
    public Text score7txt;
    public Text score8txt;
    public Text score9txt;
    public Text score10txt;

    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreList.Sort((a, b) => b.CompareTo(a));

        for (int i = 0; i < scoreList.Count; i++)
        {
            if (i == 0)
            {
                highestscoreText.text = scoreList[i].ToString();
                score1txt.text = scoreList[i].ToString();
            }
            else if (i == 1)
            {
                score2txt.text = scoreList[i].ToString();
            }
            else if (i == 2)
            {
                score3txt.text = scoreList[i].ToString();
            }
            else if (i == 3)
            {
                score4txt.text = scoreList[i].ToString();
            }
            else if (i == 4)
            {
                score5txt.text = scoreList[i].ToString();
            }
            else if (i == 5)
            {
                score6txt.text = scoreList[i].ToString();
            }
            else if (i == 6)
            {
                score7txt.text = scoreList[i].ToString();
            }
            else if (i == 7)
            {
                score8txt.text = scoreList[i].ToString();
            }
            else if (i == 8)
            {
                score9txt.text = scoreList[i].ToString();
            }
            else if (i == 9)
            {
                score10txt.text = scoreList[i].ToString();
            }
        }
    }

    public void AddPoint()
    {
        score += 1;
        PlayerPrefs.SetInt("highscore", score);
    }

    public void AddScoreToList()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreList.Add(highscore);
    }
}
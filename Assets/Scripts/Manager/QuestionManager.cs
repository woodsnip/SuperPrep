using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public List<Question> questionList;
    public TextAsset textAssetData;
    public int currentQuestion;
    public Text QuestionTXT;
    public GameObject[] answerChoices;

    [System.Serializable]
    public class Question
    {
        public string question;
        public string answerChoice1;
        public string answerChoice2;
        public string answerChoice3;
        public string answerChoice4;
        public string correctAnswer;
    }

    [System.Serializable]
    public class QuestionList
    {
        public Question[] questions;
    }

    public QuestionList myQuestionList = new QuestionList();

    // Start is called before the first frame update
    private void Start()
    {
        readCSV();
        generateQuestion();
    }

    void readCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 6 - 1;

        myQuestionList.questions = new Question[tableSize];


        for (int i = 0; i < tableSize; i++)
        {
            myQuestionList.questions[i] = new Question();
            myQuestionList.questions[i].question = data[6 * (i + 1)];
            myQuestionList.questions[i].answerChoice1 = data[6 * (i + 1) + 1];
            myQuestionList.questions[i].answerChoice2 = data[6 * (i + 1) + 2];
            myQuestionList.questions[i].answerChoice3 = data[6 * (i + 1) + 3];
            myQuestionList.questions[i].answerChoice4 = data[6 * (i + 1) + 4];
            myQuestionList.questions[i].correctAnswer = data[6 * (i + 1) + 5];
        }
    }

    void SetAnswers()
    {

        for (int i = 0; i < answerChoices.Length; i++)
        {
            if (i == 0)
            {
                answerChoices[i].transform.GetChild(0).GetComponent<Text>().text = myQuestionList.questions[currentQuestion].answerChoice1;
            }
            else if (i == 1)
            {
                answerChoices[i].transform.GetChild(0).GetComponent<Text>().text = myQuestionList.questions[currentQuestion].answerChoice2;
            }
            else if (i == 2)
            {
                answerChoices[i].transform.GetChild(0).GetComponent<Text>().text = myQuestionList.questions[currentQuestion].answerChoice3;
            }
            else if (i == 3)
            {
                answerChoices[i].transform.GetChild(0).GetComponent<Text>().text = myQuestionList.questions[currentQuestion].answerChoice4;
            }
        }
    }


    public void generateQuestion()
    {
        currentQuestion = Random.Range(0, myQuestionList.questions.Length);
        QuestionTXT.text = myQuestionList.questions[currentQuestion].question;
        SetAnswers();
    }



}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QuestionManager : MonoBehaviour
{
    public QuestionList myQuestionList;
    private static List<Question> unansweredQuestions;

    public TextAsset textAssetData;
    public GameObject QuestionPanel;

    public int currentQuestionIndex = 0;
    private Question currentQuestion;

    int score = 0;

    [SerializeField]
    private Text QuestionTxt;
    [SerializeField]
    private Text buttonTxt1;
    [SerializeField]
    private Text buttonTxt2;
    [SerializeField]
    private Text buttonTxt3;
    [SerializeField]
    private Text buttonTxt4;
    [SerializeField]
    private Text AnswerTxt;

    // Start is called before the first frame update
    void Start()
    {
        readCSV();

        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = myQuestionList.questions.ToList<Question>();
        }

        GetRandomQuestion();
    }

    void GetRandomQuestion()
    {
        if (unansweredQuestions.Count > 0)
        {
            int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
            currentQuestion = unansweredQuestions[randomQuestionIndex];

            QuestionTxt.text = currentQuestion.question;
            buttonTxt1.text = currentQuestion.answerChoice1;
            buttonTxt2.text = currentQuestion.answerChoice2;
            buttonTxt3.text = currentQuestion.answerChoice3;
            buttonTxt4.text = currentQuestion.answerChoice4;

            String answer = currentQuestion.correctAnswer;
            String trimAnswer = answer.Trim();
            AnswerTxt.text = trimAnswer;
        }
        else
        {
            Debug.Log("Out of questions");
            QuestionPanel.SetActive(false);
        }
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

    public void UserSelectAnswer1()
    {
        if (buttonTxt1.text.Equals(AnswerTxt.text))
        {
            Debug.Log("Correct");
            correct();
        }
        else
        {
            Debug.Log("Wrong");
            wrong();
        }

        GetRandomQuestion();
    }

    public void UserSelectAnswer2()
    {
        if (buttonTxt2.text.Equals(AnswerTxt.text))
        {
            Debug.Log("Correct");
            correct();
        }
        else
        {
            Debug.Log("Wrong");
            wrong();
        }
    }

    public void UserSelectAnswer3()
    {
        if (buttonTxt3.text.Equals(AnswerTxt.text))
        {
            Debug.Log("Correct");
            correct();
        }
        else
        {
            Debug.Log("Wrong");
            wrong();
        }
    }

    public void UserSelectAnswer4()
    {
        if (buttonTxt4.text.Equals(AnswerTxt.text))
        {
            Debug.Log("Correct");
            correct();
        }
        else
        {
            Debug.Log("Wrong");
            wrong();
        }
    }

    public void correct()
    {
        score += 1;
        Debug.Log(score);
        unansweredQuestions.Remove(currentQuestion);
        GetRandomQuestion();
    }

    public void wrong()
    {
        Debug.Log(score);
        unansweredQuestions.Remove(currentQuestion);
        GetRandomQuestion();
    }
}

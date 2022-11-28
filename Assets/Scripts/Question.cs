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
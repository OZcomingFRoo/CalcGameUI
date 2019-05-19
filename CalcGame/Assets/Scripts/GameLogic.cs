using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] Config config;
    [SerializeField] LabelText constTexts;
    [SerializeField] Text TitleTxt;
    [SerializeField] Text QuestionPrefix;
    [SerializeField] Text CorrectAnswerCount;
    [SerializeField] Text WrongAnswerCount;
    [SerializeField] List<Button> AnswerCollection;

    private uint CorrectCount { get; set; }
    private uint InCorrectCount { get; set; }
    private MathTask Task { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        InitText();
        PrepareNextMath();
    }

    private void InitText()
    {
        CorrectCount = 0;
        InCorrectCount = 0;
        DisplayScore();
        TitleTxt.text = constTexts.Title;
        AnswerCollection.ForEach(btn => btn.onClick.AddListener(() => { CheckAnswer(int.Parse(btn.GetComponentInChildren<Text>().text)); }));
        Task = new MathTask();
    }

    // Generates math task
    private void PrepareNextMath()
    {
        Task.MathOperation = (MathOperationEnum)Random.Range(1, 5);
        Task.Number1 = Random.Range(1, config.NumRange + 1);
        Task.Number2 = Random.Range(1, config.NumRange + 1);
        var answerCollection = GetAnswerList(Task.Answer);
        QuestionPrefix.text = constTexts.CalculatePrefix + Task.ToString();
        for (int i = 0; i < AnswerCollection.Count; i++)
        {
            AnswerCollection[i].GetComponentInChildren<Text>().text = answerCollection[i].ToString();
        }
    }

    // Serves as an event listener
    private void CheckAnswer(int answer)
    {
        if(answer == Task.Answer)
        {
            CorrectCount++;
        }
        else
        {
            InCorrectCount++;
        }
        DisplayScore();
        PrepareNextMath();
    }

    private void DisplayScore()
    {
        CorrectAnswerCount.text = CorrectCount.ToString();
        WrongAnswerCount.text = InCorrectCount.ToString();
    }

    private List<int> GetAnswerList(int answer)
    {
        List<int> answerList = new List<int>();
        // Get answers
        answerList.Add(GenerateWrongAnswer(answer, config.WrongAnswerRange1));
        answerList.Add(GenerateWrongAnswer(answer, config.WrongAnswerRange2));
        answerList.Add(GenerateWrongAnswer(answer, config.WrongAnswerRange3));
        answerList.Add(answer);
        // Shuffle answers
        answerList.Shuffle();
        return answerList;
    }

    private static int GenerateWrongAnswer(int answer, int range)
    {
        int min = answer - range;
        int max = answer + range;
        int wrongAnswer = Random.Range(min, max);
        return wrongAnswer != answer ? wrongAnswer : GenerateWrongAnswer(answer, range);
    }
}

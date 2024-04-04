using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class QuizQuestion
{
    public string question;
    public string[] choices;
    public int correctAnswerIndex; // Index of the correct answer in the choices array
}


public class QuizManager : MonoBehaviour
{
   // public GameObject Weapon;
    //public GameObject EnemyWeapon;

    public Text questionText;
    public Button[] answerButtons;
    public Text feedbackText;

    [SerializeField]
    private List<QuizQuestion> quizQuestions = new List<QuizQuestion>();

    private List<int> questionOrder; // Use a list to store the order of questions

    private int currentQuestion = 0;
    private int correctAnswers = 0;

    void Start()
    {
        InitializeQuestionOrder();
        ShowQuestion();
    }

    void InitializeQuestionOrder()
    {
        // Initialize the questionOrder list with shuffled indices
        questionOrder = new List<int>();
        for (int i = 0; i < quizQuestions.Count; i++)
        {
            questionOrder.Add(i);
        }
        ShuffleList(questionOrder);
    }

    // Helper method to shuffle a list
    void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    void ShowQuestion()
    {
        feedbackText.text = ""; // Clear previous feedback

        int questionIndex = questionOrder[currentQuestion];
        questionText.text = quizQuestions[questionIndex].question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = quizQuestions[questionIndex].choices[i];

            int buttonIndex = i; // To capture the correct index in the lambda expression
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => CheckAnswer(buttonIndex));
        }
    }

    void CheckAnswer(int choiceIndex)
    {/*
        Weapon Weapons = Weapon.GetComponent<Weapon>();
        EnemyWeapon Weapons2 = EnemyWeapon.GetComponent<EnemyWeapon>();*/
        int questionIndex = questionOrder[currentQuestion];
        string selectedAnswer = quizQuestions[questionIndex].choices[choiceIndex];

        int correctAnswerIndex = quizQuestions[questionIndex].correctAnswerIndex;
        string correctAnswer = quizQuestions[questionIndex].choices[correctAnswerIndex];

        if (selectedAnswer == correctAnswer)
        {
            feedbackText.text = "Correct!";
            correctAnswers++;
           /* Weapons.Shoot(); // player*/
        }
        else
        {
            feedbackText.text = "Incorrect. The correct answer is: " + correctAnswer;
         /*   Weapons2.Shoot(); // enemy shoots*/
        }

        currentQuestion++;

        if (currentQuestion < quizQuestions.Count)
        {
            ShowQuestion();
        }
        
    }

    void DisplayQuizResults()
    {
       
    }
}

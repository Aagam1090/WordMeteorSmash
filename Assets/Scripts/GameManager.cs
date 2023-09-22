using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int scorePlayer1, scorePlayer2;
    public ScoreText scoreTextLeft, scoreTextRight;
    public BallText ballText;
    public WordGenerator wordGenerator;
    private TextMeshProUGUI textBox;
    public TextMeshProUGUI gameOverText;
    public string word;
    public static bool isGameOver = false;


    private string res1;
    private string res2;

    public void Start()
    {
        textBox = wordGenerator.textBox;
        word = textBox.text;
        Debug.Log(word);
        res1 = "";
        res2 = "";
        for (int i = 0; i < word.Length; i++)
        {
            res1 = res1 + "_";
            res2 = res2 + "_";
        }
        UpdateScores(res1, res2);
    }
    public void OnScoreZoneReached(int id)
    {
        res1 = scoreTextLeft.GetScore();
        res2 = scoreTextRight.GetScore();
        Debug.Log(res1);
        Debug.Log(res2);
        string curr = ballText.getText();
        char currChar = curr[0];
        int pos = word.IndexOf(currChar);

        if (id == 1 && !res1.Contains(curr))
        {
            char[] res1Chars = res1.ToCharArray();
            res1Chars[pos] = currChar;
            res1 = new string(res1Chars);
        }
        else if (id == 2 && !res2.Contains(curr))
        {
            char[] res2Chars = res2.ToCharArray();
            res2Chars[pos] = currChar;
            res2 = new string(res2Chars);
        }
        if (IsWordCompleted(res1, word))
        {
            // Display Game Over message and winner's name
            gameOverText.text = "Game Over\nPlayer 1 Wins!";
            isGameOver = true;
        }
        else if (IsWordCompleted(res2, word))
        {
            // Display Game Over message and winner's name
            gameOverText.text = "Game Over\nPlayer 2 Wins!";
            isGameOver = true;
        }
        UpdateScores(res1, res2);
        if (!isGameOver)
        {
            int idx = Random.Range(0, word.Length);
            ballText.setText(word[idx].ToString());

        }
    }
    public void UpdateScores(string res1, string res2)
    {
        scoreTextLeft.SetScore(res1);
        scoreTextRight.SetScore(res2);
    }
    public bool IsWordCompleted(string playerProgress, string targetWord)
    {
        return playerProgress == targetWord;
    }
}

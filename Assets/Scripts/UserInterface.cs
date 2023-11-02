using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UserInterface : MonoBehaviour
{

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] TMP_Text gameOverText2;
    [SerializeField] Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.transform.localScale = Vector3.zero;
        gameOverText.transform.localScale = Vector3.zero;
        gameOverText2.transform.localScale = Vector3.zero;

    }


    public void IncreaseScore(int points)
    {
        /*scoreText.text = $"Your score is: {points}";*/
        scoreText.text = "Your score is: " + points;
    }

    public void OnGameOver()
    {
        restartButton.transform.localScale = Vector3.one;
        gameOverText.transform.localScale = Vector3.one;
        gameOverText2.transform.localScale = Vector3.one;
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(0);
    }

}

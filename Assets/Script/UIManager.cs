using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private Bucket bucket;

    [SerializeField] GameObject gameWinText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject settingBtn;
    [SerializeField] GameObject resumingBtn;

    private void Awake() {
        bucket = FindObjectOfType<Bucket>().GetComponent<Bucket>();
    }

    private void Update() {
        scoreText.text = "Score: " + bucket.score.ToString();
        if(bucket.isWinGame)
            gameWinText.SetActive(true);
        if(bucket.isGamerOver)
            gameOverText.SetActive(true);
    }


    #region Event Register
    private void OnEnable() {
        GameEvent.scoreInscrease += InscreaseScore;
        GameEvent.scoreDescrease += DescreaseScore;
    }

    private void OnDisable() {
        GameEvent.scoreInscrease -= InscreaseScore;
        GameEvent.scoreDescrease -= DescreaseScore;
    }
    #endregion

    #region Event Methods
    private void DescreaseScore(int scoreToDecrease)
    {
        bucket.score = bucket.score - scoreToDecrease;
    }

    private void InscreaseScore(int scoreToInscrease)
    {
        bucket.score = bucket.score + scoreToInscrease;
    }
    #endregion

    #region Button Events
    public void OnPause(){
        Time.timeScale = 0;
    }

    public void OnResume(){
        Time.timeScale = 1;
    }
    #endregion
}

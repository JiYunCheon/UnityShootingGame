using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text RecordText;
    public Text scoreText;
    public Text RecordScore;

    
    private float bestScore;
    private bool isGAMEover;
    private int score;


    void Start()
    {
        //게임오버의 상태
        isGAMEover = false;
    }

    
    void Update()
    {
       //게임 오버 상태이면 R키를 눌러 재시작
       if(isGAMEover==true)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        //게임오버 상태가 되면
        isGAMEover = true;
        //게임오버 텍스트를 출력
        gameoverText.SetActive(true);
        //bestScore를 저장
        bestScore = PlayerPrefs.GetFloat("BestTime");
        if(bestScore<score)
        {
            //bestScore는 score점수
            bestScore = score;
        }
        //bestScore를 저장
        PlayerPrefs.SetFloat("BestTime", bestScore);

        //저장된 스코어를 출력
        RecordScore.text = "Best Score : " + (int)bestScore;
    }

    public void Score(int score)
    {
        //입력된 점수를 더함
        this.score += score;
        //ui에 출력함 
        scoreText.text = "Score :" + (int)this.score;
    }



}

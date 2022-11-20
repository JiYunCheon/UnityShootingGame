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
        //���ӿ����� ����
        isGAMEover = false;
    }

    
    void Update()
    {
       //���� ���� �����̸� RŰ�� ���� �����
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
        //���ӿ��� ���°� �Ǹ�
        isGAMEover = true;
        //���ӿ��� �ؽ�Ʈ�� ���
        gameoverText.SetActive(true);
        //bestScore�� ����
        bestScore = PlayerPrefs.GetFloat("BestTime");
        if(bestScore<score)
        {
            //bestScore�� score����
            bestScore = score;
        }
        //bestScore�� ����
        PlayerPrefs.SetFloat("BestTime", bestScore);

        //����� ���ھ ���
        RecordScore.text = "Best Score : " + (int)bestScore;
    }

    public void Score(int score)
    {
        //�Էµ� ������ ����
        this.score += score;
        //ui�� ����� 
        scoreText.text = "Score :" + (int)this.score;
    }



}

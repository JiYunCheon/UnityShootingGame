using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private Rigidbody BossRB;
    //보스 스피드
    [SerializeField] float speed = 15f;
    //보스 체력
    private int BossHP=10;
    //보스 톱니의 회전
    Rotate Rspeed;
    //보스의 색깔
    Renderer[] BossColor;
    //보스의 생성 위치
    float randomXmin = -40f;
    float randomXmax = 40f;
    //랜덤 x값을 저장 할 변수
    float R;
    
    void Start()
    {
        BossRB = GetComponent<Rigidbody>();
        //랜덤한 x값을 생성
        R = Random.Range(randomXmin, randomXmax);
        //랜덤한 x값의 보스를 생성
        transform.Translate(R, 0, 0);
        //앞 방향으로 이동
        BossRB.velocity = transform.forward * -speed;
        //보스의 회전을 사용하기 위해 게임오브젝트를 가져옴 
        Rspeed = FindObjectOfType<Rotate>();
        //보스 색 변경을위한 랜더러 컴퍼넌트를 가져오기 
        BossColor = gameObject.GetComponentsInChildren<Renderer>();
    }

    
    void Update()
    {
        //보스가 -22f를 넘어갈 경우 파괴
        if (transform.position.z <= -22f)
            Destroy(gameObject);
    }
   
    public void die()
    {
        //보스 체력을 감소시키고
        --BossHP;
        //보스의 속도를 올릴 변수
        float pulsSpeed=1f;
        //체력이 감소 할때 마다 보스의 속도를 높힘
        pulsSpeed += 1f;
        BossRB.velocity = transform.forward * -speed * pulsSpeed;
        //보스의 회전속도를 높힘 
        Rspeed.SetRotateSpeed(50);

        //보스의 자식객체들의 모든 색깔을 바꿈 
        for (int i =0;i < 9  ; i++)
        {
            BossColor[i].material.color = new Color(255 / 255, 100 / 255, 0 / 255);
        }

        //보스의 피가 0보다 작아질 경우 
        if (BossHP <= 0)
        {
            //점수를 100점 올림
            GameManager GM = FindObjectOfType<GameManager>();
            GM.Score(100);

            gameObject.SetActive(false);
            //보스의 체력과 스피드를 초기화 
            BossHP = 30;
            speed = 1;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //보스의 트리거존으로 들어온게 플레이어일 경우 
        if (other.tag == "Player")
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if (pc != null)
            {
                //플레이어의 die를 호출함 
                pc.Die();
            }
        }
    }

   


}

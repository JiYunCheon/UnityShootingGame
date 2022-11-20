using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    private Rigidbody MonsterRB;

    //몬스터 스피드 
    [SerializeField] float speed = 5f;
    //몬스터 HP
    private int MonsterHP=5;
    //랜더 선언
    Renderer MonsterColor;

    void Start()
    {
        //랜더 컬러 선언
        MonsterColor = gameObject.GetComponent<Renderer>();
        //초기 색은 초록
        MonsterColor.material.color = Color.green;
        //리지드바디 선언
        MonsterRB = GetComponent<Rigidbody>();
        //몬스터의 앞방향으로 이동
        MonsterRB.velocity = transform.forward * -speed;
    }

    
    void Update()
    {
        //몬스터의 Z가 -45가 넘으면 파괴
        if (transform.position.z < -45f)
            Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        //몬스터 트리거에 들어온게 플레이어면 플레이어 die를 실행
        if(other.tag=="Player")
        {
            PlayerController pc =other.GetComponent<PlayerController>();
            if(pc != null)
            {
                pc.Die();
            }
        }
        //몬스터 트리거에 들어온게 총알이면 bulletvisible를 실행
        if (other.tag=="Bullet")
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if(bullet!=null)
            {
                bullet.bulletvisible();
            }
        }
    }

    //몬스터 죽음
    public void die()
    {
        //DIE 함수가 호출 되면 몬스터 HP를 1씩 깎음
        --MonsterHP;
        //피가 깎이면 몬스터의 속도를 늘림
        MonsterRB.velocity = transform.forward * -speed*3f;
        //체력이 깎이면 빨간색으로 변함
        MonsterColor.material.color = Color.red;

        //만약 몬스터 HP가 0보다 작거나 같을 경우
        if (MonsterHP<=0)
        {
            GameManager GM = FindObjectOfType<GameManager>();
            //스코어를 올림
            GM.Score(10);
            //지금 몬스터를 제거
            gameObject.SetActive(false);
            //재생성 시 체력을 초기화
            MonsterHP=5;
            //스피드 초기화
            speed = 5f;
        }
    }


   
}

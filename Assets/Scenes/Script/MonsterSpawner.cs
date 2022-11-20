using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    //사용할 프리팹 선언 
    public GameObject monsterPrefab;
    public GameObject bossprefab;
    public GameObject bulletprefab;
    //몬스터를 배열로 생성하기 위해 선언
    GameObject [] monster;
    //보스를 생성하기위한 게임오브젝트 선언
    GameObject boss;

    //몬스터의 랜덤한 위치를 저장 할 리스트
    List<float> rnd_list;
    //랜덤 값을 저장할 변수
    float random = 0;
    //몬스터의 마리수
    private int count = 5;
    //랜덤값이 중복되는지 확인할 bool 변수
    private bool overlap;

    //몬스터의 생성 주기
    private float monsterSpawnRate=8f;
    //보스의 생성 주기
    private float BossSpawnRate=10f;

    void Start()
    {
        //count만큼 몬스터의 배열 선언
        monster = new GameObject[count];
        //몬스터의 위치를 저장할 리스트 선언
        rnd_list = new List<float>();
        //몬스터의 랜덤값을 확인할 변수 선언 
        overlap = true;
        
        //몬스터와 보스를 자동 생성할 코루틴 스타트
        StartCoroutine(monsterSpawn());
        StartCoroutine("bossSpawn");
    }
    //보스 생성 코루틴
    IEnumerator bossSpawn()
    {
        while(true)
        {
            //보스 생성 주기만큼 기다린 후 
            yield return new WaitForSeconds(BossSpawnRate);
            //보스 생성
            boss = Instantiate(bossprefab, transform.position, bossprefab.transform.rotation);
            
        }
        
    }
    //몬스터 생성 쿠루틴
    IEnumerator monsterSpawn()
    {
        while (true)
        {
            //몬스터를 생성하기 전 x값을 리스트에 넣음
            MakeRndVectorX();

            //몬스터의 마리수 만큼 반복문을 실행 
            for (int i = 0; i < count; i++)
            {
                //몬스터 프리팹을 생성하고 위치는 x값 중복되지 않는 x값을 가짐 
                monster[i] = Instantiate(monsterPrefab, new Vector3(rnd_list[i],3,40), monsterPrefab.transform.rotation);
            }
            //리스트 안 숫자를 없앰
            rnd_list.Clear();
            //몬스터 주기만큼 기다린 후 다시 실행
            yield return new WaitForSeconds(monsterSpawnRate);
        }

    }
    //중복되지않는 보스의 x값을 구함
    private void MakeRndVectorX()
    {
        //리스트의 길이가 count와 같을 때 까지 반복
        while (rnd_list.Count != count)
        {
            //랜덤값을 리스트에 넣음
            overlap = true;
            
            //랜덤 값 생성
            random = Random.Range(-40, 40);
            
            //리스트의 길이 만큼 반복 
            for (int i = 0; i < rnd_list.Count; i++)
            {
                //리스트에 저장된 숫자 +3,-3범위에 
                //새로 생성된 랜덤 값이 포함 된다면
                if (random <= rnd_list[i] + 3
                    && random >= rnd_list[i] - 3)
                {
                    //랜덤값을 리스트에 넣지 않고 반복문 종료
                    overlap = false;
                    break;
                }
            }

            if (overlap == true)
            {
                //리스트에 저장
                rnd_list.Add(random);
            }
        }


    }

    
}

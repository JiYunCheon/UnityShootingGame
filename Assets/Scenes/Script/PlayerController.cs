using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   

    private Rigidbody playerRB;
    //사용 할 프리팹 선언
    public GameObject bulletPrefab;
    private GameManager gamemanager;

    //총알 생성 속도
    private float spawnRate=0.2f;
    private float BossSpawnRate = 3f;
    //플레이어 스피드
    [SerializeField] float speed = 15f;

    //총알 생성 시간 체크
    private float timeAfterSpawn;

    private float timeAfterBossSpawn;

    Boss boss;
    Monster mon;


    void Start()
    {
        //시간 초기화
        timeAfterSpawn = 0;
        //리지드 바디 선언
        playerRB = gameObject.GetComponent<Rigidbody>();
        boss = GetComponentInChildren<Boss>();
        mon = GetComponentInChildren<Monster>();
    }

    
    void Update()
    {
        //시간 갱신
        timeAfterSpawn += Time.deltaTime;
        timeAfterBossSpawn+= Time.deltaTime;

        #region 플레이어 이동

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);

        playerRB.velocity = newVelocity;

        //플레이어 회전 
        if(Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x >= 47) return;

            transform.Rotate(0, Time.deltaTime * -speed,0 );
           
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x <= -47) return;
            transform.Rotate(0, Time.deltaTime * speed, 0);
        }

        #endregion

        //spawnRate을 넘을 경우 총알을 생성
        if (timeAfterSpawn >= spawnRate)
        {
            //시간 초기화
            timeAfterSpawn = 0;

            //총알을 생성할 키
            if (Input.GetKey(KeyCode.Space))
            {
                bulletPrefab.SetActive(true);
                GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            }
        }
    }

    //플레이어 죽음
    public void Die()
    {
        gameObject.SetActive(false);
        //플레이어가 죽을경우 ui실행 
        gamemanager = FindObjectOfType<GameManager>();
        gamemanager.EndGame();
    }

   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   

    private Rigidbody playerRB;
    //��� �� ������ ����
    public GameObject bulletPrefab;
    private GameManager gamemanager;

    //�Ѿ� ���� �ӵ�
    private float spawnRate=0.2f;
    private float BossSpawnRate = 3f;
    //�÷��̾� ���ǵ�
    [SerializeField] float speed = 15f;

    //�Ѿ� ���� �ð� üũ
    private float timeAfterSpawn;

    private float timeAfterBossSpawn;

    Boss boss;
    Monster mon;


    void Start()
    {
        //�ð� �ʱ�ȭ
        timeAfterSpawn = 0;
        //������ �ٵ� ����
        playerRB = gameObject.GetComponent<Rigidbody>();
        boss = GetComponentInChildren<Boss>();
        mon = GetComponentInChildren<Monster>();
    }

    
    void Update()
    {
        //�ð� ����
        timeAfterSpawn += Time.deltaTime;
        timeAfterBossSpawn+= Time.deltaTime;

        #region �÷��̾� �̵�

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);

        playerRB.velocity = newVelocity;

        //�÷��̾� ȸ�� 
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

        //spawnRate�� ���� ��� �Ѿ��� ����
        if (timeAfterSpawn >= spawnRate)
        {
            //�ð� �ʱ�ȭ
            timeAfterSpawn = 0;

            //�Ѿ��� ������ Ű
            if (Input.GetKey(KeyCode.Space))
            {
                bulletPrefab.SetActive(true);
                GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            }
        }
    }

    //�÷��̾� ����
    public void Die()
    {
        gameObject.SetActive(false);
        //�÷��̾ ������� ui���� 
        gamemanager = FindObjectOfType<GameManager>();
        gamemanager.EndGame();
    }

   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    private Rigidbody MonsterRB;

    //���� ���ǵ� 
    [SerializeField] float speed = 5f;
    //���� HP
    private int MonsterHP=5;
    //���� ����
    Renderer MonsterColor;

    void Start()
    {
        //���� �÷� ����
        MonsterColor = gameObject.GetComponent<Renderer>();
        //�ʱ� ���� �ʷ�
        MonsterColor.material.color = Color.green;
        //������ٵ� ����
        MonsterRB = GetComponent<Rigidbody>();
        //������ �չ������� �̵�
        MonsterRB.velocity = transform.forward * -speed;
    }

    
    void Update()
    {
        //������ Z�� -45�� ������ �ı�
        if (transform.position.z < -45f)
            Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        //���� Ʈ���ſ� ���°� �÷��̾�� �÷��̾� die�� ����
        if(other.tag=="Player")
        {
            PlayerController pc =other.GetComponent<PlayerController>();
            if(pc != null)
            {
                pc.Die();
            }
        }
        //���� Ʈ���ſ� ���°� �Ѿ��̸� bulletvisible�� ����
        if (other.tag=="Bullet")
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if(bullet!=null)
            {
                bullet.bulletvisible();
            }
        }
    }

    //���� ����
    public void die()
    {
        //DIE �Լ��� ȣ�� �Ǹ� ���� HP�� 1�� ����
        --MonsterHP;
        //�ǰ� ���̸� ������ �ӵ��� �ø�
        MonsterRB.velocity = transform.forward * -speed*3f;
        //ü���� ���̸� ���������� ����
        MonsterColor.material.color = Color.red;

        //���� ���� HP�� 0���� �۰ų� ���� ���
        if (MonsterHP<=0)
        {
            GameManager GM = FindObjectOfType<GameManager>();
            //���ھ �ø�
            GM.Score(10);
            //���� ���͸� ����
            gameObject.SetActive(false);
            //����� �� ü���� �ʱ�ȭ
            MonsterHP=5;
            //���ǵ� �ʱ�ȭ
            speed = 5f;
        }
    }


   
}

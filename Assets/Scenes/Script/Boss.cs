using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private Rigidbody BossRB;
    //���� ���ǵ�
    [SerializeField] float speed = 15f;
    //���� ü��
    private int BossHP=10;
    //���� ����� ȸ��
    Rotate Rspeed;
    //������ ����
    Renderer[] BossColor;
    //������ ���� ��ġ
    float randomXmin = -40f;
    float randomXmax = 40f;
    //���� x���� ���� �� ����
    float R;
    
    void Start()
    {
        BossRB = GetComponent<Rigidbody>();
        //������ x���� ����
        R = Random.Range(randomXmin, randomXmax);
        //������ x���� ������ ����
        transform.Translate(R, 0, 0);
        //�� �������� �̵�
        BossRB.velocity = transform.forward * -speed;
        //������ ȸ���� ����ϱ� ���� ���ӿ�����Ʈ�� ������ 
        Rspeed = FindObjectOfType<Rotate>();
        //���� �� ���������� ������ ���۳�Ʈ�� �������� 
        BossColor = gameObject.GetComponentsInChildren<Renderer>();
    }

    
    void Update()
    {
        //������ -22f�� �Ѿ ��� �ı�
        if (transform.position.z <= -22f)
            Destroy(gameObject);
    }
   
    public void die()
    {
        //���� ü���� ���ҽ�Ű��
        --BossHP;
        //������ �ӵ��� �ø� ����
        float pulsSpeed=1f;
        //ü���� ���� �Ҷ� ���� ������ �ӵ��� ����
        pulsSpeed += 1f;
        BossRB.velocity = transform.forward * -speed * pulsSpeed;
        //������ ȸ���ӵ��� ���� 
        Rspeed.SetRotateSpeed(50);

        //������ �ڽİ�ü���� ��� ������ �ٲ� 
        for (int i =0;i < 9  ; i++)
        {
            BossColor[i].material.color = new Color(255 / 255, 100 / 255, 0 / 255);
        }

        //������ �ǰ� 0���� �۾��� ��� 
        if (BossHP <= 0)
        {
            //������ 100�� �ø�
            GameManager GM = FindObjectOfType<GameManager>();
            GM.Score(100);

            gameObject.SetActive(false);
            //������ ü�°� ���ǵ带 �ʱ�ȭ 
            BossHP = 30;
            speed = 1;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //������ Ʈ���������� ���°� �÷��̾��� ��� 
        if (other.tag == "Player")
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if (pc != null)
            {
                //�÷��̾��� die�� ȣ���� 
                pc.Die();
            }
        }
    }

   


}

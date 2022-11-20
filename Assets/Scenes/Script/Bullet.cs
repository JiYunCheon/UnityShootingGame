using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRB;
    //�Ѿ� �ӵ�
    [SerializeField] float speed = 25f;
    void Start()
    {
        //������ٵ� ����
        bulletRB =gameObject.GetComponent<Rigidbody>();
        //�Ѿ��� �� �������� �Ѿ��� ����
        bulletRB.velocity = transform.forward*speed;
    }

    
    void Update ()
    {
        //55�� ������� �ҷ� �ı�
        if (transform.position.z >= 52f)
            Destroy(gameObject);
    }

    //�Ѿ� �浹 Ʈ���� 
    private void OnTriggerEnter(Collider other)
    {
        //�Ѿ��� Ʈ���� ���� ���°��� ���� �ױ��ϰ�� 
        if(other.tag =="Monster")
        {
            Monster monster = other.GetComponent<Monster>();

            //���� �Ѿ˿� Ʈ���� ���� ���� �� �´ٸ�
            if(other!=null)
            {
                //���ʹ� �״´�.(ü���� ��´�.)
                monster.die();  
            }
        }

        //�Ѿ��� Ʈ���� ���� ������ ������ ��� 
        if (other.tag == "Boss")
        {
            gameObject.SetActive(false);
            Boss boss = other.GetComponentInParent<Boss>();
            boss.die();
        }
    }

    //�ҷ� ����
    public void bulletvisible()
    {
        gameObject.SetActive(false);
    }


}

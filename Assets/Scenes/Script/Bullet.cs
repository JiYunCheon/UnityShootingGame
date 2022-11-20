using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRB;
    //총알 속도
    [SerializeField] float speed = 25f;
    void Start()
    {
        //리지드바디 생성
        bulletRB =gameObject.GetComponent<Rigidbody>();
        //총알의 앞 방향으로 총알이 나감
        bulletRB.velocity = transform.forward*speed;
    }

    
    void Update ()
    {
        //55가 넘을경우 불렛 파괴
        if (transform.position.z >= 52f)
            Destroy(gameObject);
    }

    //총알 충돌 트리거 
    private void OnTriggerEnter(Collider other)
    {
        //총알의 트리거 존에 들어온것이 몬스터 테그일경우 
        if(other.tag =="Monster")
        {
            Monster monster = other.GetComponent<Monster>();

            //만약 총알에 트리거 존에 들어온 게 맞다면
            if(other!=null)
            {
                //몬스터는 죽는다.(체력을 깎는다.)
                monster.die();  
            }
        }

        //총알의 트리거 존에 보스가 들어왔을 경우 
        if (other.tag == "Boss")
        {
            gameObject.SetActive(false);
            Boss boss = other.GetComponentInParent<Boss>();
            boss.die();
        }
    }

    //불렛 없앰
    public void bulletvisible()
    {
        gameObject.SetActive(false);
    }


}

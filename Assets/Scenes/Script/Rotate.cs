using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Rotate : MonoBehaviour
{
    private float rspeed = 100f;
   
    void Update()
    {
        //������ ��ϸ� ���ǵ常ŭ ȸ����Ŵ
        transform.Rotate(0, 0, Time.deltaTime*rspeed);
    }
    public void SetRotateSpeed(float rspeed)
    {
        //ȸ�� ���ǵ尡 500���� �������� ����
        if (this.rspeed>=500f) return;
        //�� �Լ��� ����Ǹ� ȸ������ �Էµ� ȸ������ ����
        this.rspeed += rspeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Rotate : MonoBehaviour
{
    private float rspeed = 100f;
   
    void Update()
    {
        //보스의 톱니를 스피드만큼 회전시킴
        transform.Rotate(0, 0, Time.deltaTime*rspeed);
    }
    public void SetRotateSpeed(float rspeed)
    {
        //회전 스피드가 500보다 높아지면 리턴
        if (this.rspeed>=500f) return;
        //이 함수가 실행되면 회전수에 입력된 회전수를 더함
        this.rspeed += rspeed;
    }
}

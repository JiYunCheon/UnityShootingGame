using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void change()
    {
        //클릭을하면 적혀있는 신으로 이동
        SceneManager.LoadScene("SampleScene");
    }
}

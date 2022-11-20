using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    //����� ������ ���� 
    public GameObject monsterPrefab;
    public GameObject bossprefab;
    public GameObject bulletprefab;
    //���͸� �迭�� �����ϱ� ���� ����
    GameObject [] monster;
    //������ �����ϱ����� ���ӿ�����Ʈ ����
    GameObject boss;

    //������ ������ ��ġ�� ���� �� ����Ʈ
    List<float> rnd_list;
    //���� ���� ������ ����
    float random = 0;
    //������ ������
    private int count = 5;
    //�������� �ߺ��Ǵ��� Ȯ���� bool ����
    private bool overlap;

    //������ ���� �ֱ�
    private float monsterSpawnRate=8f;
    //������ ���� �ֱ�
    private float BossSpawnRate=10f;

    void Start()
    {
        //count��ŭ ������ �迭 ����
        monster = new GameObject[count];
        //������ ��ġ�� ������ ����Ʈ ����
        rnd_list = new List<float>();
        //������ �������� Ȯ���� ���� ���� 
        overlap = true;
        
        //���Ϳ� ������ �ڵ� ������ �ڷ�ƾ ��ŸƮ
        StartCoroutine(monsterSpawn());
        StartCoroutine("bossSpawn");
    }
    //���� ���� �ڷ�ƾ
    IEnumerator bossSpawn()
    {
        while(true)
        {
            //���� ���� �ֱ⸸ŭ ��ٸ� �� 
            yield return new WaitForSeconds(BossSpawnRate);
            //���� ����
            boss = Instantiate(bossprefab, transform.position, bossprefab.transform.rotation);
            
        }
        
    }
    //���� ���� ���ƾ
    IEnumerator monsterSpawn()
    {
        while (true)
        {
            //���͸� �����ϱ� �� x���� ����Ʈ�� ����
            MakeRndVectorX();

            //������ ������ ��ŭ �ݺ����� ���� 
            for (int i = 0; i < count; i++)
            {
                //���� �������� �����ϰ� ��ġ�� x�� �ߺ����� �ʴ� x���� ���� 
                monster[i] = Instantiate(monsterPrefab, new Vector3(rnd_list[i],3,40), monsterPrefab.transform.rotation);
            }
            //����Ʈ �� ���ڸ� ����
            rnd_list.Clear();
            //���� �ֱ⸸ŭ ��ٸ� �� �ٽ� ����
            yield return new WaitForSeconds(monsterSpawnRate);
        }

    }
    //�ߺ������ʴ� ������ x���� ����
    private void MakeRndVectorX()
    {
        //����Ʈ�� ���̰� count�� ���� �� ���� �ݺ�
        while (rnd_list.Count != count)
        {
            //�������� ����Ʈ�� ����
            overlap = true;
            
            //���� �� ����
            random = Random.Range(-40, 40);
            
            //����Ʈ�� ���� ��ŭ �ݺ� 
            for (int i = 0; i < rnd_list.Count; i++)
            {
                //����Ʈ�� ����� ���� +3,-3������ 
                //���� ������ ���� ���� ���� �ȴٸ�
                if (random <= rnd_list[i] + 3
                    && random >= rnd_list[i] - 3)
                {
                    //�������� ����Ʈ�� ���� �ʰ� �ݺ��� ����
                    overlap = false;
                    break;
                }
            }

            if (overlap == true)
            {
                //����Ʈ�� ����
                rnd_list.Add(random);
            }
        }


    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject gObjectPrefab;
    public float fSpawnTime=3f;
    public Vector2 SpawnAreaMin;
    public Vector2 SpawnAreaMax;
    public int MaxObject;

    private float Timer;
    private List<GameObject> lSpawnObject = new List<GameObject>(); //�x�s�ͦ�������

    private void Update()
    {
        {
            if (lSpawnObject.Count >= MaxObject)
                return;
                Timer += Time.deltaTime;
                if (Timer >= fSpawnTime)
                {
                    SpawnObj();
                    Timer = 0f;
                }
            
        }
    }

    void SpawnObj() //�ͦ�����
    {
        float fRandomX = Random.Range(SpawnAreaMin.x, SpawnAreaMax.x);
        float fRandomY = Random.Range(SpawnAreaMax.y, SpawnAreaMin.y);
        Vector2 vSpawnPosition = new Vector2(fRandomX, fRandomY);


        float fCheckRadius = 3f;

        if(!Physics2D.OverlapCircle(vSpawnPosition,fCheckRadius))//�ˬd�O�_���|
        {
            GameObject newObject = Instantiate(gObjectPrefab, vSpawnPosition, Quaternion.identity);
            lSpawnObject.Add(newObject);
        }

        else
        {
            SpawnObj();
        }

        
    }
}

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
    private List<GameObject> lSpawnObject = new List<GameObject>(); //儲存生成的物件

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

    void SpawnObj() //生成物件
    {
        float fRandomX = Random.Range(SpawnAreaMin.x, SpawnAreaMax.x);
        float fRandomY = Random.Range(SpawnAreaMax.y, SpawnAreaMin.y);
        Vector2 vSpawnPosition = new Vector2(fRandomX, fRandomY);


        float fCheckRadius = 3f;

        if(!Physics2D.OverlapCircle(vSpawnPosition,fCheckRadius))//檢查是否重疊
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

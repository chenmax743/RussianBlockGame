using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject gObjectPrefab;
    public float fSpawnTime = 3f;
    public Vector2 SpawnAreaMin;
    public Vector2 SpawnAreaMax;
    public int MaxObject;
    public float verticalSpacing = 2f; // 控制垂直間距
    public float fCheckRadius = 0.5f; // 檢查重疊的半徑

    private float Timer;
    private List<GameObject> lSpawnObject = new List<GameObject>(); // 儲存生成的物件

    private void Update()
    {
        if (lSpawnObject.Count >= MaxObject)
            return;

        Timer += Time.deltaTime;
        if (Timer >= fSpawnTime)
        {
            SpawnObj();
            Timer = 0f;
        }
        else if(lSpawnObject.Count<MaxObject && Timer>=fSpawnTime)
        {
            SpawnObj();
            Timer = 0f;
        }
    }

    void SpawnObj() // 生成物件
    {
        int MaxAttempts = 10;
        int attempts = 0;
        bool isSpawned = false;

        while (attempts < MaxAttempts && !isSpawned)
        {
            float fRandomX = Random.Range(SpawnAreaMin.x, SpawnAreaMax.x);
            float fRandomY = Random.Range(SpawnAreaMax.y, SpawnAreaMin.y);
            Vector2 vBasePosition = new Vector2(fRandomX, fRandomY);

            // 檢查是否重疊
            bool overlaps = false;

            // 檢查基礎位置
            if (Physics2D.OverlapCircle(vBasePosition, fCheckRadius))
            {
                overlaps = true;
            }

            // 檢查上方位置
            if (Physics2D.OverlapCircle(vBasePosition + Vector2.up * verticalSpacing, fCheckRadius))
            {
                overlaps = true;
            }

            // 檢查下方位置
            if (Physics2D.OverlapCircle(vBasePosition + Vector2.down * verticalSpacing, fCheckRadius))
            {
                overlaps = true;
            }

            if (!overlaps) // 如果沒有重疊，則生成物件
            {
                GameObject obj1 = Instantiate(gObjectPrefab, vBasePosition, Quaternion.identity);
                GameObject obj2 = Instantiate(gObjectPrefab, vBasePosition + Vector2.up * verticalSpacing, Quaternion.identity);
                GameObject obj3 = Instantiate(gObjectPrefab, vBasePosition + Vector2.down * verticalSpacing, Quaternion.identity);

                lSpawnObject.Add(obj1);
                lSpawnObject.Add(obj2);
                lSpawnObject.Add(obj3);

                isSpawned = true; // 設置為已成功生成
            }
            else
            {
                Debug.Log($"Overlap detected. Trying again... (Attempt: {attempts + 1})");
            }

            attempts++;
        }

        if (isSpawned)
        {
            Debug.Log("成功生成");
        }
        else
        {
            Debug.Log("生成失敗");
        }

        if(lSpawnObject.Count<MaxObject)
        {
            Timer = fSpawnTime;
        }
    }
}

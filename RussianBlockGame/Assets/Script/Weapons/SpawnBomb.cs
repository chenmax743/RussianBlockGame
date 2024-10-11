using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{

    public GameObject gBomb;
    public Vector2 vSpawnAreaMin;
    public Vector2 vSpawnAreaMax;
    public float fSpawnInterval = 3f;     //生成間格
    public int iMaxSpawn = 3;   //最大生成數量
    private float fSpawnTimer;

    private List<GameObject> lSpawnPoint = new List<GameObject>();

    void Update()
    {
        if (lSpawnPoint.Count > iMaxSpawn)
            return;

        fSpawnTimer += Time.deltaTime;

        if (fSpawnTimer >= fSpawnTimer)
        {
            SpawnBombe();
            fSpawnTimer = 0;
        }
    }

    void SpawnBombe()
    {
        int maxAttempts = 10; // 最大嘗試次數，避免陷入無限循環
        int attempts = 0;
        bool isSpawned = false;

        while (attempts < maxAttempts && !isSpawned)
        {
            // 隨機生成位置
            float randomX = Random.Range(vSpawnAreaMin.x, vSpawnAreaMax.x);
            float randomY = Random.Range(vSpawnAreaMin.y, vSpawnAreaMax.y);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            // 檢查是否與其他物體重疊
            if (!Physics2D.OverlapCircle(spawnPosition, 0.5f)) // 半徑為0.5的區域內無物體
            {
                GameObject newBomb = Instantiate(gBomb, spawnPosition, Quaternion.identity);
                lSpawnPoint.Add(newBomb);  // 將新炸彈加入列表
                isSpawned = true;

                
            }

            attempts++;
        }
    }
}
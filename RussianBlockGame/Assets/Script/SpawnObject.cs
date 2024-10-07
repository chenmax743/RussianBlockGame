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
    public float verticalSpacing = 2f; // ��������Z
    public float fCheckRadius = 0.5f; // �ˬd���|���b�|

    private float Timer;
    private List<GameObject> lSpawnObject = new List<GameObject>(); // �x�s�ͦ�������

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

    void SpawnObj() // �ͦ�����
    {
        int MaxAttempts = 10;
        int attempts = 0;
        bool isSpawned = false;

        while (attempts < MaxAttempts && !isSpawned)
        {
            float fRandomX = Random.Range(SpawnAreaMin.x, SpawnAreaMax.x);
            float fRandomY = Random.Range(SpawnAreaMax.y, SpawnAreaMin.y);
            Vector2 vBasePosition = new Vector2(fRandomX, fRandomY);

            // �ˬd�O�_���|
            bool overlaps = false;

            // �ˬd��¦��m
            if (Physics2D.OverlapCircle(vBasePosition, fCheckRadius))
            {
                overlaps = true;
            }

            // �ˬd�W���m
            if (Physics2D.OverlapCircle(vBasePosition + Vector2.up * verticalSpacing, fCheckRadius))
            {
                overlaps = true;
            }

            // �ˬd�U���m
            if (Physics2D.OverlapCircle(vBasePosition + Vector2.down * verticalSpacing, fCheckRadius))
            {
                overlaps = true;
            }

            if (!overlaps) // �p�G�S�����|�A�h�ͦ�����
            {
                GameObject obj1 = Instantiate(gObjectPrefab, vBasePosition, Quaternion.identity);
                GameObject obj2 = Instantiate(gObjectPrefab, vBasePosition + Vector2.up * verticalSpacing, Quaternion.identity);
                GameObject obj3 = Instantiate(gObjectPrefab, vBasePosition + Vector2.down * verticalSpacing, Quaternion.identity);

                lSpawnObject.Add(obj1);
                lSpawnObject.Add(obj2);
                lSpawnObject.Add(obj3);

                isSpawned = true; // �]�m���w���\�ͦ�
            }
            else
            {
                Debug.Log($"Overlap detected. Trying again... (Attempt: {attempts + 1})");
            }

            attempts++;
        }

        if (isSpawned)
        {
            Debug.Log("���\�ͦ�");
        }
        else
        {
            Debug.Log("�ͦ�����");
        }

        if(lSpawnObject.Count<MaxObject)
        {
            Timer = fSpawnTime;
        }
    }
}

using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    public int objectCount = 5;
    public GameObject prefabEnemy;
    public List<GameObject> createdEnemy;
    public GameObject spawnpoint;

    private void Awake()
    {
        FillObjectse();
    }

    private void FillObjectse()
    {
        for (int i = 0; i < objectCount; i++)
        {
            GameObject instanceObject = Instantiate(prefabEnemy);
            instanceObject.SetActive(false);
            createdEnemy.Add(instanceObject);
        }
    }

    public void GetObjecte()
    {
        for (int i = 0; i < createdEnemy.Count; i++)
        {
            if (!createdEnemy[i].activeInHierarchy)
            {
                createdEnemy[i].transform.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, spawnpoint.transform.position.z);
                createdEnemy[i].SetActive(true);
                return;
            }
        }
    }

}

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float timeSinceStart = 0;
    private float timeToSpawn = 3f;
    public EnemyPooling[] generatorEnemy;

    void Update()
    {
        timeSinceStart += Time.deltaTime;
        if (timeSinceStart > timeToSpawn)
        {

            timeSinceStart = 0;
            generatorEnemy[Random.Range(0, generatorEnemy.Length)].GetObjecte();

        }
    }
}
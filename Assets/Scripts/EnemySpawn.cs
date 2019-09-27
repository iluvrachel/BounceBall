using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject creeper;
    public GameObject purple;
    //public GameObject enemy;

    private float distance;
    private float distanceUsed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (distance < transform.position.x + 20)
        {
            distance = transform.position.x + 20;
        }

        float distToGo = Mathf.Floor(distance - distanceUsed);

        if (distanceUsed < distance && distToGo > 0.6f)
        {
            distanceUsed = distance;
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject enemyToSpawn = enemyType();
        float yPos = Mathf.Floor(Mathf.Abs(UnityEngine.Random.Range(0f,1f) - UnityEngine.Random.Range(0f,1f)) * (1 + 100 - (-2)) + (-2));
        Vector3 posToSpawnEnemy = new Vector3(distance,yPos,0f);
        Instantiate(enemyToSpawn,posToSpawnEnemy,Quaternion.identity);
    }

    private GameObject enemyType()
    {
        float rand = UnityEngine.Random.Range(0f,1f);
        if(rand>0.2f)
        {
            return enemy;
        }
        else if(rand>0.05f)
        {
            return purple;
        }
        else
        {
            return creeper;
        }
    }
}

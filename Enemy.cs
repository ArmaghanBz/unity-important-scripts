using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float enmInterval = 2f;

    private void Start()
    {
        StartCoroutine(spawnEnemy(enmInterval, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);  

        GameObject newEnem = Instantiate(enemy,new Vector3(Random.Range(-10f,10f),Random.Range(-4f,4f),0),Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}

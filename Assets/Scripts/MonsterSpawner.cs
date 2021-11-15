using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] MonsterReference;

    [SerializeField] private Transform leftPos, rightPos;

    private GameObject spawnedMonster;

    private int randomIndex;
    private int randomSide;
    
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5)); // wait 1-5 seconds
            randomIndex = Random.Range(0, MonsterReference.Length);
            randomSide = Random.Range(0, 2); // 0 or 1

            // creates copy of the gameObject that we passed here as reference
            spawnedMonster = Instantiate(MonsterReference[randomIndex]);

            // left side
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10); // THE MONSTERS SPEEDS WILL NOT BE THE SAME
            }
            // right
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10); // go from right to left (negative)
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f); // changing x scale to negative (make him look to the left)
            }
        }

    }

}

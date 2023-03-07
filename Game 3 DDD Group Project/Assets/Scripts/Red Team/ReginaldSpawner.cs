using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReginaldSpawner : MonoBehaviour
{
    public GameObject Reginald;
    public Vector2 spawnPoint;
    void Start()
    {
        Vector2 offSet = new Vector2(2f, 0f);
        spawnPoint = (Vector2)transform.position + offSet;
        Instantiate(Reginald, spawnPoint, Quaternion.identity);
    }

    public Vector2 GetReginaldSpawnPoint()
    {
        return spawnPoint; 
    }
}

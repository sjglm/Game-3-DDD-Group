using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubertSpawner : MonoBehaviour
{
    public GameObject Hubert;
    public Vector2 spawnPoint;
    void Start()
    {
        Vector2 offSet = new Vector2(-2f, 0f);
        spawnPoint = (Vector2)transform.position + offSet;
        Instantiate(Hubert, spawnPoint, Quaternion.identity);
    }
    Vector2 GetHubertSpawnPoint()
    {
        return spawnPoint;
    }
}

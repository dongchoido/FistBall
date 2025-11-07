using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval;
    [SerializeField] PoolManager poolManager;
    private float timer;
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0f)
        {
            poolManager.TakeItem<Item>(ConstManager.item);
            timer = spawnInterval;
        }
    }
}

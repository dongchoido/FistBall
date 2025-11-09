using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval;
    private float timer;
    void Start()
    {
        PoolManager.instance.SetupPool();
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0f)
        {
            PoolManager.instance.TakeItem<Item>(ConstManager.item);
            timer = spawnInterval;
        }
    }
}

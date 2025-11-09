using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;
    public Item itemPrefab;
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
 
    }
    public  void SetupPool()
    {
        ObjectPooler.SetupPool(itemPrefab, 4, ConstManager.item);
    }
    public void TakeItem<T>(string name) where T : Component
    {
        T instance = ObjectPooler.DequeueObject<T>(name);
        instance.gameObject.SetActive(true);
    }
    public void ReturnItem<T>(T item, string name) where T : Component
    {
        ObjectPooler.EnqueueObject(item, name);
    }
}

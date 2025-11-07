using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public static class ObjectPooler
{
    public static Dictionary<string, Component> poolLookup = new Dictionary<string, Component>();
    public static Dictionary<string, Queue<Component>> poolDictionary = new Dictionary<string, Queue<Component>>();
    public static void EnqueueObject<T>(T item, string name) where T : Component
    {
        if (!item.gameObject.activeSelf) return;
        item.transform.position = Vector2.zero;
        poolDictionary[name].Enqueue(item);
        item.gameObject.SetActive(false);
    }
    public static T EnqueueNewObject<T>(T item, string name) where T : Component
    {
        T instance = Object.Instantiate(item);
        instance.gameObject.SetActive(false);
        instance.transform.position = Vector2.zero;
        //poolDictionary[name].Enqueue(instance);
        return (T)instance;
    }
    public static T DequeueObject<T>(string name) where T: Component
    {
        if (poolDictionary[name].TryDequeue(out var item))
            return (T)item;
        return (T)EnqueueNewObject<T>((T)poolLookup[name], name);
    }
    public static void SetupPool<T>(T prefab,int size,string dictionaryEntry) where T:Component
    {
        poolDictionary.Add(dictionaryEntry, new Queue<Component>());
        poolLookup.Add(dictionaryEntry, prefab);
        for(int i=0;i<size;i++)
        {
            T pooledInstance = Object.Instantiate(prefab);
            pooledInstance.transform.position = Vector2.zero;
            pooledInstance.gameObject.SetActive(false);
            poolDictionary[dictionaryEntry].Enqueue((T)pooledInstance);
        }
    }
}

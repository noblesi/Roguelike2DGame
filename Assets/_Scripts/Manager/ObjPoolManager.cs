using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPoolManager : Singleton<ObjPoolManager>
{
    private Dictionary<System.Type, Queue<object>> ObjContainer
        = new Dictionary<System.Type, Queue<object>>();

    public T SpawnObj<T>() where T : class, new()
    {
        var queue = ObjContainer.GetValueOrDefault(typeof(T)) ?? new Queue<object>();

        var obj = (queue.Count >= 1) ? queue.Dequeue() : new T();

        ObjContainer.TryAdd(typeof(T), queue);
        return obj as T;
    }

    public void DespawnObj<T>(T obj) where T : class, new()
    {
        if(ObjContainer.TryGetValue(typeof(T), out Queue<object> queue))
        {
            queue.Enqueue(obj);
        }
    }
}

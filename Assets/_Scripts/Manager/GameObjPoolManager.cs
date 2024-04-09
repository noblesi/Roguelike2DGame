using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjPoolManager : Component
{
    private Dictionary<string, Queue<GameObject>> ObjContainer
        = new Dictionary<string, Queue<GameObject>>();

    public GameObject SpawnGameObj(string name,
        string path, GameObject parent = null)
    {
        return this.SpawnGameObj(name, path, Vector3.zero, Vector3.one, Vector3.zero);
    }

    public GameObject SpawnGameObj(string name,
        string path, Vector2 pos, Vector2 scale, Vector2 angle, GameObject parent = null)
    {
        var queue = ObjContainer.GetValueOrDefault(path) ?? new Queue<GameObject>();

        var gameObj = (queue.Count >= 1) ? queue.Dequeue() : Factory.CreateCloneObj(name, parent, path);

        gameObj.transform.localPosition = pos;
        gameObj.transform.localScale = scale;
        gameObj.transform.localEulerAngles = angle; 

        gameObj.SetActive(true);
        ObjContainer.TryAdd(path, queue);

        return gameObj;
    }

    public void DespawnGameObj(string path, GameObject gameObj)
    {
        if(ObjContainer.TryGetValue(path, out Queue<GameObject> queue))
        {
            gameObj.SetActive(false);
            queue.Enqueue(gameObj);
        }
    }
}

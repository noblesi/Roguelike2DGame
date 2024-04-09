using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static partial class Factory
{
    public static GameObject CreateObj(string name, GameObject parent)
    {
        return Factory.CreateObj(name, parent, Vector3.zero, Vector3.one, Vector3.zero);
    }

    public static GameObject CreateObj(string name,
        GameObject parent, Vector3 pos, Vector3 scale, Vector3 angle)
    {
        var gameObj = new GameObject(name);
        gameObj.transform.SetParent(parent?.transform, false);

        gameObj.transform.localPosition = pos;
        gameObj.transform.localScale = scale;
        gameObj.transform.localEulerAngles = angle;

        return gameObj;
    }

    public static GameObject CreateCloneObj(string name, GameObject parent, string path)
    {
        return Factory.CreateCloneObj(name, parent, path, Vector3.zero, Vector3.one, Vector3.zero);
    }

    public static GameObject CreateCloneObj(string name, GameObject parent, GameObject origin)
    {
        return Factory.CreateCloneObj(name, parent, origin, Vector3.zero, Vector3.one, Vector3.zero);
    }

    public static GameObject CreateCloneObj(string name, GameObject parent, string path, Vector3 pos, Vector3 scale, Vector3 angle)
    {
        return Factory.CreateCloneObj(name, parent, Resources.Load<GameObject>(path), pos, scale, angle);
    }

    public static GameObject CreateCloneObj(string name,
        GameObject parent, GameObject origin, Vector3 pos, Vector3 scale, Vector3 angle)
    {
        Debug.Assert(origin != null);

        var gameObj = GameObject.Instantiate(origin, Vector3.zero, Quaternion.identity);
        gameObj.name = name;
        gameObj.transform.SetParent(parent?.transform, false);

        gameObj.transform.localPosition = pos;
        gameObj.transform.localScale = scale;
        gameObj.transform.localEulerAngles = angle;

        return gameObj;
    }

    public static T CreateObj<T>(string name, GameObject parent) where T : Component
    {
        return Factory.CreateObj(name, parent).ExAddComponent<T>();
    }

    public static T CreateObj<T>(string name,
        GameObject parent, Vector3 pos, Vector3 scale, Vector3 angle) where T : Component
    {
        return Factory.CreateObj(name, parent, pos, scale, angle).ExAddComponent<T>();
    }

    public static T CreateCloneObj<T>(string name, GameObject parent, string path) where T : Component
    {
        return Factory.CreateCloneObj(name, parent, path).GetComponentInChildren<T>();
    }

    public static T CreateCloneObj<T>(string name, GameObject parent, GameObject origin) where T : Component
    {
        return Factory.CreateCloneObj(name, parent, origin).GetComponentInChildren<T>();
    }

    public static T CreateCloneObj<T>(string name,
        GameObject parent, string path, Vector3 pos, Vector3 scale, Vector3 angle) where T : Component
    {
        return Factory.CreateCloneObj(name, parent, path, pos, scale, angle).GetComponentInChildren<T>();
    }

    public static T CreateCloneObj<T>(string name,
        GameObject parent, GameObject origin, Vector3 pos, Vector3 scale, Vector3 angle) where T : Component
    {
        return Factory.CreateCloneObj(name, parent, origin, pos, scale, angle).GetComponentInChildren<T>();
    }

}

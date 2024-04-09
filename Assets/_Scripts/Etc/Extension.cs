using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Extension
{
    public static T ExAddComponent<T>(this GameObject sender) where T : Component
    {
        Debug.Assert(sender != null);

        return sender.GetComponent<T>() ?? sender.AddComponent<T>();
    }
}

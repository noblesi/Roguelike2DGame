using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    private StateController controller;
    public StateController Controller { get { return controller; } set { controller = value; } }

    public abstract void Init(params object[] datas);
    public abstract void Execute();
    public abstract void Exit();
}

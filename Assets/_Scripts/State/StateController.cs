using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : Singleton<StateController>
{

    [SerializeField] private List<State> stateList;
    private Dictionary<string, State> stateDictionary;

    [SerializeField] private string currentStateName;
    [SerializeField] private string previousStateName;

    public string CurrentStateName { get { return currentStateName; } }
    private State currentState;

    private void Start()
    {
        stateDictionary = new Dictionary<string, State>();

        for(int i=0; i<stateList.Count; i++)
        {
            stateList[i].Controller = this;
            stateDictionary.Add(stateList[i].GetType().Name, stateList[i]);
        }

        if(stateList.Count > 0)
        {
            currentState = stateList[0];
            currentStateName = currentState.GetType().Name;
            currentState.Init();
        }
    }

    private void Update()
    {
        if (currentState != null) currentState.Execute();
    }

    void ChangeState(string name, params object[] datas)
    {
        previousStateName = currentStateName;
        if(currentStateName != null) currentState.Exit();
        currentState = stateDictionary[name];
        currentState.Init(datas);

        currentStateName = currentState.GetType().Name;
    }

    void ChangePreviousState(params object[] datas)
    {
        if(currentState != null) currentState.Exit();
        currentState = stateDictionary[previousStateName];  
        currentState.Init(datas);

        currentStateName = currentState.GetType().Name;
    }
}

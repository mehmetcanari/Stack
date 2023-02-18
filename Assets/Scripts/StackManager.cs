using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : SpawnBase, IStack
{
    public Stack<GameObject> cubes = new Stack<GameObject>();
    private float _yValue;
    [SerializeField] private float _timeValue;
    [SerializeField] private float _maximumValue;

    public PrefabVault vault;
    private bool StackAllow = true;

    public float Height
    {
        get => _yValue;
        set => _yValue = value;
    }

    public float ElapsedTime
    {
        get => _timeValue;
        set => _timeValue = value;
    }

    public float DesiredWaitTime
    {
        get => _maximumValue;
        set => _maximumValue = value;
    }

    public void PushStack(Stack<GameObject> targetStack, GameObject targetObject)
    {
        targetStack.Push(targetObject);
    }

    public void PopStack(Stack<GameObject> targetStack, GameObject targetObject)
    {
        targetStack.Push(targetObject);
    }

    public override void CreateTargetObject(GameObject targetObject, float height)
    {
        base.CreateTargetObject(targetObject, height);
    }

    private void AddStackElements()
    {
        if (StackAllow)
        {
            ElapsedTime += Time.deltaTime;

            if (ElapsedTime >= DesiredWaitTime)
            {
                ElapsedTime = 0;

                CreateTargetObject(vault.cubeObject, Height);
                PushStack(cubes, SpawnedObject);
                Height++;
            }
        }
    }

    private void RemoveStackElements()
    {
        if (!StackAllow)
        {
            ElapsedTime += Time.deltaTime;

            if (ElapsedTime >= DesiredWaitTime)
            {
                ElapsedTime = 0;

                GameObject poppedObject = cubes.Pop();
                Destroy(poppedObject);
            }
        }
    }

    private void CheckProduceCount()
    {
        if (cubes.Count >= 5)
        {
            StackAllow = false;
        }
        else if (cubes.Count <= 0)
        {
            StackAllow = true;
            Height = 0;
        }
    }

    private void Update()
    {
        AddStackElements();
        
        RemoveStackElements();
        
        CheckProduceCount();
    }
}

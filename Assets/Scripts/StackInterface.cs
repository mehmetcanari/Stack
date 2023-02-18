using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStack
{
    void PushStack(Stack<GameObject> targetStack, GameObject targetObject);

    void PopStack(Stack<GameObject> targetStack, GameObject targetObject);
}

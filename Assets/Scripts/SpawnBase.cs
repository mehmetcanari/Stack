using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnBase : MonoBehaviour
{
    protected GameObject SpawnedObject;
    
    public virtual void CreateTargetObject(GameObject targetObject, float height)
    {
        Vector3 desiredPosition = new Vector3(0, Vector3.up.magnitude + height, 0);
        SpawnedObject = Instantiate(targetObject, desiredPosition, Quaternion.identity);
    }
}

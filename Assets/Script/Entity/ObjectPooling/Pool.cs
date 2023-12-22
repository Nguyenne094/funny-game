using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public string poolName;
    [SerializeField] private uint _poolSize = 10;
    [SerializeField] private GameObject pooledObject;
    private Stack<GameObject> stack;

    private void Start() {
        InitPool();
    }

    private void InitPool()
    {
        if(pooledObject == null)
            return;
        
        stack = new Stack<GameObject>();

        GameObject instance = null;
        
        for(int i = 0; i < _poolSize; i++){
            instance = Instantiate(pooledObject);
            instance.gameObject.SetActive(false);
            stack.Push(instance);
            instance.transform.parent = gameObject.transform;
        }
    }

    public GameObject GetObject(){
        if(pooledObject == null)
            return null;
        
        if(stack.Count == 0){
            GameObject newObject = Instantiate(pooledObject);
            stack.Push(newObject);
            return newObject;
        }

        GameObject nextObject = stack.Pop();
        nextObject.gameObject.SetActive(true);
        return nextObject;
    }

    public void ReturnToPool(GameObject pooledObject){
        pooledObject.gameObject.SetActive(false);
        stack.Push(pooledObject);
    }
}

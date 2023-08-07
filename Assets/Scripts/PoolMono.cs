using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    public bool AutoExpand { get; set; } 
    public Transform Container { get; set; } 
    public T _objectPrefab { get; }

    private List<T> _pool; 

    public PoolMono(T _objectPrefab, int count, Transform container)
    {
        this._objectPrefab = _objectPrefab;
        Container = container;
        CreatePool(count); 

    }

    private void CreatePool(int count)
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
            CreateObject(); 
    }

    private T CreateObject(bool IsActiveByDefolt = false) 
    {
        var createdObject = Object.Instantiate(_objectPrefab, Container); 
        createdObject.gameObject.SetActive(IsActiveByDefolt); 
        _pool.Add(createdObject); 
        return createdObject;
    }

    public bool HasFreeElement(out T element)  
    {
        foreach (var mono in _pool)
        {
            if (!mono.gameObject.activeInHierarchy) 
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true; 
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out var element)) 
        {
            return element;
        }

        if (AutoExpand)
        {
            return CreateObject(true); 
        }

        throw new System.Exception($"There is no free elements in pool of type {typeof(T)}"); 
    }
}

















using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    public bool AutoExpand { get; set; } 
    public Transform Container { get; set; } 
    public T _objectPrefab { get; }

    private List<T> _pool;
    private Transform _position;
    private Transform _rotation;

    public PoolMono(T ObjectPrefab, int count, Transform container)
    {
        _objectPrefab = ObjectPrefab;
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
        //var createdObject = Object.Instantiate(_objectPrefab, Container); 
        var createdObject = PhotonNetwork.Instantiate(_objectPrefab.name, Vector3.zero, Quaternion.identity);
        createdObject.transform.parent = Container;
        createdObject.gameObject.SetActive(IsActiveByDefolt);
        T component = createdObject.GetComponent<T>();
        _pool.Add(component);
        return component;
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
            Debug.Log("Вернулом элемент");
            return element;
        }

        if (AutoExpand)
        {
            return CreateObject(true); 
        }

        throw new System.Exception($"There is no free elements in pool of type {typeof(T)}"); 
    }
}

















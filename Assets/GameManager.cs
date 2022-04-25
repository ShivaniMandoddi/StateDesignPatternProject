using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public List<PoolObject> poolItems = new List<PoolObject>();
    private List<GameObject> pool = new List<GameObject>();
    public List<GameObject> Pool { get { return pool; } }
   
    
    private void Awake()
    {
        if(instance==null)
        {
            instance =this;
        }
    }
   
    void Start()
    {
        //CreatePool();
        AddToPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddToPool()
    {
        foreach (PoolObject item in poolItems)
        {
            for(int i=0;i<item.amount;i++)
            {
                GameObject temp = Instantiate(item.prefab);
                temp.SetActive(false);
                pool.Add(temp);
                
            }
        }
    }
    public GameObject GetFromPool(string tagName)
    {
        foreach (GameObject item in pool)
        {
            if(tagName==item.tag && !item.activeInHierarchy)
            {
                return (item);
            }
        }
        return null;
    }
}
[System.Serializable]
public class PoolObject
{
    public GameObject prefab;
    public int amount;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objPrefab;
    
    public int createOnStart;

    private List<GameObject> pooledObjs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < createOnStart; x++)
        {
            CreateNewObject();
        }
    }

    GameObject CreateNewObject()
    {
        // create gameobject
        GameObject obj = Instantiate(objPrefab);
        //Deactivate object
        obj.SetActive(false);
        //add object to the pool of existing objects
        pooledObjs.Add(obj);

        return obj;
    }

    public GameObject GetObject()
    {
        GameObject obj = pooledObjs.Find(x => x.activeInHierarchy == false);

        if(obj == null)
        {
            obj = CreateNewObject();
        }

        obj.SetActive(true);

        return obj;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

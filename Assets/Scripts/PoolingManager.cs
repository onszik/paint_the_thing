using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager instance {
        get;
        private set;
    }

    [System.Serializable]
    public class Pool {
        public string tag;
        public GameObject prefab;
        public int initSize;
    }

    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        InitializePools();
    }

    private void InitializePools() {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool p in pools) {
            Queue<GameObject> objPool = new Queue<GameObject>();

            for (int i = 0; i < p.initSize; i++) {
                GameObject obj = Instantiate(p.prefab);
                obj.SetActive(false);
                objPool.Enqueue(obj);
            }

            poolDictionary.Add(p.tag, objPool);
        }
    }

    public GameObject GetObject(string tag) {
        if (!poolDictionary.ContainsKey(tag)) {
            Debug.LogError($"No pool tagged {tag} exists at the moment");
            return null;
        }

        GameObject obj;
        if (poolDictionary[tag].Count > 0) {
            obj = poolDictionary[tag].Dequeue();
        } else {
            obj = Instantiate(pools.Find(p => p.tag == tag).prefab); //search for p in pools so that p.tag matches tag, then get its object prefab
        }

        obj.SetActive(true);
        return obj;
    }

    public void DiscardObject(string tag, GameObject obj) {
        obj.SetActive(false);
        poolDictionary[tag].Enqueue(obj);
    }
}

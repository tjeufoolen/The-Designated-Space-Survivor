using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Camera cam;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    private int spreadSize = 4;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i=0; i<pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.name += $"[{i}]";
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector2 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"Pool with tag {tag} doesn't exist.");
            return null;
        }

        if (poolDictionary[tag].Count <= 0) return null;

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

        if (!pooledObject.IsVisible(cam) || !objectToSpawn.activeSelf)
        {
            objectToSpawn.SetActive(true);

            Regex regex = new Regex(@"\[(.+?)\]");
            int number = int.Parse(regex.Match(objectToSpawn.name).Value.Replace("[", "").Replace("]", ""));
            position.x += spreadSize * number;

            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            objectToSpawn.transform.localScale = new Vector3(1, 1, 1);
        }

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}

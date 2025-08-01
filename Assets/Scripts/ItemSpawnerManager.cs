using UnityEngine;
using System.Linq;
public class ItemSpawnerManager : MonoBehaviour
{
    [SerializeField] private ItemDrop[] powerUpRates;


    [SerializeField] private GameObject[] powerUps;
    [SerializeField] private float chanceOfSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrySpawnItem(Vector3 spawnPosition)
    {
        if(Random.Range(0, 101) < chanceOfSpawn)
        {
            //SPAWN ITEM
            GameObject randomObject = powerUps[ Random.Range(0, powerUps.Length) ];
            Instantiate( randomObject, spawnPosition, Quaternion.identity );
        }

        /*
        float chance = Random.Range(0, 101);

        ItemDrop[] filteredList = powerUpRates.Where((item) => item.spawnRate > chance).ToArray();

        GameObject randomObjectFromFilter = filteredList[Random.Range(0, filteredList.Length)].item;

        foreach (ItemDrop item in filteredList)
        {
            if(Random.Range(0, 101) < item.spawnRate)
            {
                randomObjectFromFilter = item.item;
            }
        }
        
        
        Instantiate(randomObjectFromFilter, spawnPosition, Quaternion.identity);
        */
    }
}

[System.Serializable]
public class ItemDrop
{
    public GameObject item;
    public float spawnRate;
}


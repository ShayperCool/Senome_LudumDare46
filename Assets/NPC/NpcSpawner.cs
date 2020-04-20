using Game;
using System.Collections;
using System.Collections.Generic;
using Unity.UNetWeaver;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    private int _villagersCountCurrent;
    private int _villagersCountFinal;
    
    
    [SerializeField] private Transform[] _randomSpawnersNpc;  // 1 2 3 4 5 
    [SerializeField] private GameObject NPC;

    private void Start()
    {
        _villagersCountCurrent = VillageController.Singleton.village.villagersCount;
        _villagersCountFinal = _villagersCountCurrent / 10;
        Debug.LogError(_villagersCountFinal);
        SpawnNpc();
    }

    private void SpawnNpc()
    {
        GameObject npc;
        for (int  i = 0; i < _villagersCountFinal; i++)
        {
            npc = Instantiate(NPC);
            npc.transform.position = _randomSpawnersNpc[Random.Range(0, _randomSpawnersNpc.Length)].position;
        }
    }

}

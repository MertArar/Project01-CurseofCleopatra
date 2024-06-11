using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrackManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Tiles;
    [SerializeField] private GameObject player;
    int randomTile;

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerMovement.currentTile == Tiles.Capacity - 1)
        {
            randomTile = Random.Range(0, Tiles.Capacity - 1);
        }
        else
            randomTile = Random.Range(PlayerMovement.currentTile + 1, Tiles.Capacity);

        float defaultHeight = transform.position.y;
        
        Vector3 newPosition = new Vector3(0, -defaultHeight, Tiles[PlayerMovement.currentTile].transform.position.z + 100f);
        Tiles[randomTile].transform.position = newPosition;

        PlayerMovement.currentTile = randomTile;
    }
    
    
}
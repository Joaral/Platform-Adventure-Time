using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KeyTilemapTrigger : MonoBehaviour
{
    public Tilemap tilemapToClear; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (tilemapToClear != null)
            {
                tilemapToClear.ClearAllTiles();
                
            }

            Destroy(gameObject); 
        }
    }
}

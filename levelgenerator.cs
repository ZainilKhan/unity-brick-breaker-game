using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Vector2Int size;  
    public Vector2 offset;
    public GameObject brickPrefab;

   
    private void Awake()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject newBrick = Instantiate(brickPrefab, transform);
                newBrick.transform.position = transform.position + 
                    new Vector3(((size.x - 1) * 0.5f - i) * offset.x, j * offset.y, 0);

                
                if (newBrick.GetComponent<Collider2D>() == null)
                {
                    newBrick.AddComponent<BoxCollider2D>(); 
                }
            }
        }
    }

    
    private void Update()
    {
    }
}

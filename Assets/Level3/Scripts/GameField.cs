using System.Collections.Generic;
using UnityEngine;
public class GameField : MonoBehaviour
{
    public List<Vector3Int> GameFieldPositions = new List<Vector3Int>();
    private void Start()
    {
        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 15; y++)
            {
                GameFieldPositions.Add(new Vector3Int(x, y, 0));
            }
        }
    }
}

using System;
using UnityEngine;

namespace Assets.Level3.Scripts
{
    public class LoseChecker : MonoBehaviour
    {
        private int _loseHeight = 16;
        public event Action OnLose;
        public void CheckLose(TetrisBlock tetrisBlock)
        {
            foreach (Transform children in tetrisBlock.transform)
            {
                if (children.position.y >= _loseHeight)
                {
                    OnLose?.Invoke();
                }
            }
        }
    }
}
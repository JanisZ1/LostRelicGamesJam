using UnityEngine;
namespace Assets.Level3.Scripts
{
    public class TetraminoSpawner : MonoBehaviour
    {

        [SerializeField] private TetrisBlock[] _tetrominos;
        [SerializeField] private GameField _gameField;
       
        private void Start()
        {
            _gameField.GameFieldPositions.Add(Vector3Int.RoundToInt(transform.position));
            NewTetramino();
        }

        public void NewTetramino() =>
            Instantiate(_tetrominos[Random.Range(0, _tetrominos.Length)]);
    }
}

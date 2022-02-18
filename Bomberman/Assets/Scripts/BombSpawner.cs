using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour {

    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private Grid _grid;
    [SerializeField] private ExplosionController _explosionController;

    private bool _isBombUsed;

    private void Start() {
        _isBombUsed = false;
    }

    public void BombPlace() {
        if (!_isBombUsed) {
            Vector3Int bombCellPosition = _grid.WorldToCell(transform.position);
            Vector3 bombPosition = _grid.GetCellCenterWorld(bombCellPosition);

            InstantiateBomb(bombPosition);
            _isBombUsed = true;
        }
    }

    private void InstantiateBomb(Vector3 position) {
        GameObject bomb = Instantiate(_bombPrefab, position, Quaternion.identity);

        Bomb bombScript = bomb.GetComponent<Bomb>();
        bombScript.OnBombExplodedAction += _explosionController.OnBombExploded;
        bombScript.OnBombExplodedAction += OnBombNotUsed;
    }

    private void OnBombNotUsed(Vector3 position) {
        _isBombUsed = false;
    }
}

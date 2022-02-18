using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

    [SerializeField] private Grid _grid;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private int _explosionForce;
    
    
    public void OnBombExploded(Vector3 bombPosition) {
        Vector3Int bombCellPosition = _grid.WorldToCell(bombPosition);

        CreateExplosions(bombCellPosition);
    }

    private void CreateExplosions(Vector3Int epicenterPosition) {
        TryToCreateExplosionsInDirection(epicenterPosition, Vector3Int.left);
        TryToCreateExplosionsInDirection(epicenterPosition, Vector3Int.right);
        TryToCreateExplosionsInDirection(epicenterPosition, Vector3Int.up);
        TryToCreateExplosionsInDirection(epicenterPosition, Vector3Int.down);
        
        InstantiateExplosion(epicenterPosition);
    }
    
    private void TryToCreateExplosionsInDirection(Vector3Int epicenterPosition, Vector3Int direction) {
        Vector3 raycastDirection = direction;

        if(direction.y != 0) {
            raycastDirection = _grid.CellToWorld(direction.y > 0 ? Vector3Int.up : Vector3Int.down)
                               - _grid.CellToWorld(Vector3Int.zero);
        }
        
        CreateExplosionsInDirection(
            epicenterPosition, 
            direction, 
            CountExplosions(
                _grid.GetCellCenterWorld(epicenterPosition),
                raycastDirection,
                3f
            )
        );
    }
    
    private void CreateExplosionsInDirection(Vector3Int epicenterPosition, Vector3Int direction, int count) {
        Vector3Int currentBombCellPosition = epicenterPosition;
            
        for (int step = 0; step < count; step++) {
            currentBombCellPosition += direction;

            InstantiateExplosion(currentBombCellPosition);
        }
    }
    
    private int CountExplosions(Vector3 epicenterPosition, Vector3 direction, float maxDistance) {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(epicenterPosition, direction, maxDistance);

        if (raycastHit2D.collider != null && raycastHit2D.collider.CompareTag("TilemapCollider")) 
            return (int) raycastHit2D.distance;

        return _explosionForce;
    }

    private void InstantiateExplosion(Vector3Int cellPosition) {
        Instantiate(_explosionPrefab, _grid.GetCellCenterWorld(cellPosition), Quaternion.identity);
    }
}

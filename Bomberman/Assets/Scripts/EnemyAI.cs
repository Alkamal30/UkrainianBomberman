using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    
    [SerializeField] private Grid _grid;
    [SerializeField] private EntityMovement _entityMovement;
    [SerializeField] private float _raycastDistance;
    [SerializeField] private float _observerUpdateTime;

    private Vector3[] _movementDirections;
    private Vector3[] _raycastDirections;


    private void Start() {
        Vector3 horizontalRaycastingAxis = _grid.CellToWorld(Vector3Int.right) - _grid.CellToWorld(Vector3Int.zero);
        Vector3 verticalRaycastingAxis = _grid.CellToWorld(Vector3Int.up) - _grid.CellToWorld(Vector3Int.zero);
        
        horizontalRaycastingAxis.Normalize();
        verticalRaycastingAxis.Normalize();
        
        _movementDirections = new Vector3[] {
            Vector3.left, 
            Vector3.up, 
            Vector3.right, 
            Vector3.down
        };

        _raycastDirections = new Vector3[] {
            -horizontalRaycastingAxis,
            verticalRaycastingAxis,
            horizontalRaycastingAxis,
            -verticalRaycastingAxis
        };

        StartCoroutine(ObserverCycle());
    }


    IEnumerator ObserverCycle() {
        while (true) {
            int directionChoice = Random.Range(0, 4);

            RaycastHit2D raycastHit = Physics2D.Raycast(
                transform.position, 
                _raycastDirections[directionChoice], 
                _raycastDistance, LayerMask.NameToLayer("Default")
            );

            if (raycastHit.collider == null || raycastHit.distance > 1f)
                _entityMovement.MovementDirection = _movementDirections[directionChoice];
            
            yield return new WaitForSeconds(_observerUpdateTime);
        }
    }
}

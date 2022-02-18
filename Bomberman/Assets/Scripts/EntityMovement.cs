using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour {

    public Vector3 MovementDirection { get; set; }

    [SerializeField] private Grid _grid;
    [SerializeField] private float _movementSpeed;

    private Rigidbody2D _rigidbody2D;
    private Vector3 _horizontalMovementAxis;
    private Vector3 _verticalMovementAxis;

    private void Start() {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        
        _horizontalMovementAxis = _grid.CellToWorld(Vector3Int.right) - _grid.CellToWorld(Vector3Int.zero);
        _verticalMovementAxis = _grid.CellToWorld(Vector3Int.up) - _grid.CellToWorld(Vector3Int.zero);
    }


    private void FixedUpdate() {
        Vector3 resultVelocity = Vector3.zero;
        resultVelocity += MovementDirection.x * _horizontalMovementAxis * _movementSpeed * Time.deltaTime;
        resultVelocity += MovementDirection.y * _verticalMovementAxis * _movementSpeed * Time.deltaTime;
        
        _rigidbody2D.velocity = resultVelocity;
    }
}

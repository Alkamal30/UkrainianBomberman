using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    [SerializeField] private Joystick _joystick;
    [SerializeField] private EntityMovement _entityMovementScript;
    
    private void Update() {
        _entityMovementScript.MovementDirection = _joystick.Direction;
    }

}

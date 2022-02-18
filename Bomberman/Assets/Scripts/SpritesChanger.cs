using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesChanger : MonoBehaviour {

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private EntityMovement _entityMovement;
    [SerializeField] private Sprite _leftMovementSprite;
    [SerializeField] private Sprite _rightMovementSprite;
    [SerializeField] private Sprite _downMovementSprite;
    [SerializeField] private Sprite _upMovementSprite;

    private void Update() {
        Vector3 direction = _entityMovement.MovementDirection;

        if (Mathf.Max(Mathf.Abs(direction.x), Mathf.Abs(direction.y)) < 0.2f)
            return;
        
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
            if (direction.x > 0f)
                _spriteRenderer.sprite = _rightMovementSprite;
            else _spriteRenderer.sprite = _leftMovementSprite;
        }
        else {
            if (direction.y > 0f)
                _spriteRenderer.sprite = _upMovementSprite;
            else _spriteRenderer.sprite = _downMovementSprite;
        }
        
    }
}

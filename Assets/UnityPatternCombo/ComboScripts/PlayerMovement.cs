using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Simple player character movement based on directional input.
    /// 
    /// Not currently used in the combo system.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _movementSpeed;
        private Vector2 _move;

        [SerializeField]
        private GameplayActionInitializer _actionInitializer;
        
        private SideFighterControls _gameplayControls;

        private void Start()
        {
            _gameplayControls = _actionInitializer.GameplayControls;
        }

        void Update()
        {
            _move = _gameplayControls.gameplay.move.ReadValue<Vector2>();
            Move(_move);
        }
        
        private void Move(Vector2 direction)
        {
            if (direction.sqrMagnitude < 0.01)
                return;
            var scaledMoveSpeed = _movementSpeed * Time.deltaTime;
            var move = new Vector3(direction.x, direction.y, 0);
            transform.position += move * scaledMoveSpeed;
        }
    }
}



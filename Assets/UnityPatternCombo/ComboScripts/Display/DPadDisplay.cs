using System;
using UnityEngine;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Manages the visual representation of D-Pad input as an upward-moving display.
    /// 
    /// The display resets to a starting position when enabled and moves upward at a set speed.
    /// When the D-Pad is released, the line renderer visually indicates the point of release.
    /// The display deactivates itself once it reaches a certain threshold on the screen, 
    /// referred to as the 'ceiling'.
    /// </summary>
    public class DPadDisplay : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 300f;

        [SerializeField]
        private LineRenderer _line;

        private bool _isReleased;
        private RectTransform _rectTransform;
        private Vector3 _newPosition;
        private float _ceiling = 1080f;
        private float _xOffset = -100f;
        private Vector3 _releasedPosition;

        private void OnEnable()
        {
            _rectTransform = gameObject.GetComponent<RectTransform>();
            Reset();
        }

        public void Reset()
        {
            _isReleased = false;
            _rectTransform.localPosition = new Vector3(_xOffset, 0, 0);

            _releasedPosition = Vector3.zero;
            _line.gameObject.SetActive(true);
            _line.SetPosition(0, Vector3.zero);
            _line.SetPosition(1, Vector3.zero);
        }

        public void ReleaseDPad()
        {
            _isReleased = true;
            _releasedPosition = _line.GetPosition(0);
        }

        private void Update()
        {
            MoveDPadDisplay();
            HandleDPadRelease();
            CheckCeilingAndDeactivate();
        }

        private void MoveDPadDisplay()
        {
            _newPosition = Vector3.up * (Time.deltaTime * _speed) + _rectTransform.localPosition;
            _rectTransform.localPosition = _newPosition;
            _line.SetPosition(0, new Vector3(0, _rectTransform.localPosition.y, 0));
        }

        private void HandleDPadRelease()
        {
            if (_isReleased)
            {
                _line.SetPosition(1, _line.GetPosition(0) - _releasedPosition);
            }
        }

        private void CheckCeilingAndDeactivate()
        {
            if (_rectTransform.localPosition.y >= _ceiling)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            _line.SetPosition(0, Vector3.zero);
            _line.SetPosition(1, Vector3.zero);
            _line.gameObject.SetActive(false);
        }
    }
}

using TMPro;
using UnityEngine;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Controls the visual effect of combo text climbing up the screen when a combo is executed.
    /// 
    /// This component listens for combo events and, upon receiving them, animates the combo text
    /// to move upward from a starting position, creating a visual indication of a successful combo.
    /// The text disappears after reaching a certain height, effectively "climbing" out of view.
    /// </summary>
    public class ComboDisplayTextClimber : MonoBehaviour
    {
        [SerializeField] private float _climbSpeed = 1.0f;
        [SerializeField] private TextMeshProUGUI _comboText;
        [SerializeField] private Vector3 _startingOffset;
        [SerializeField] private int _textPositionCeiling = 500;
        private Vector3 _offset;
        private bool _isShowingComboText;
        private Transform _textTransform;
        
        private void Start()
        {
            ComboEventSystem.OnNewCombo += StartComboText;
            _comboText.enabled = false;
            _textTransform = _comboText.transform;
        }
        private void OnDisable()
        {
            ComboEventSystem.OnNewCombo -= StartComboText;
        }

        private void StartComboText()
        {
            _comboText.enabled = true;
            _textTransform.localPosition = Vector3.zero;
            _offset = _textTransform.localPosition + _startingOffset;
            _isShowingComboText = true;
        }
        
        private void Update()
        {
            if (_isShowingComboText)
            {
                _textTransform.localPosition += Vector3.up * (Time.deltaTime * _climbSpeed) + _offset;
            }
            if (_textTransform.localPosition.y > _textPositionCeiling)
            {
                _isShowingComboText = false;
                _comboText.enabled = false;
            }
        }
    }
}

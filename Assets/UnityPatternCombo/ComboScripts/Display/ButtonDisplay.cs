using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Represents the visual component of a gameplay button in the UI.
    /// 
    /// This class manages the display of button prompts as they move upwards on the screen,
    /// similar to the 'notes highway' seen in rhythm games. It handles the setup and
    /// recycling of the button display elements using the provided ButtonDisplayPool.
    /// </summary>
    public class ButtonDisplay : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 300f;
        [SerializeField]
        private TextMeshProUGUI _buttonTMP;
        [SerializeField]
        private Image _gameplayButtonBackground;
    
        private string _gameplayButton;
        private Color _buttonColor;
        private RectTransform _rectTransform;
        private Vector3 _newPosition;
        private float _ceiling = 1080f;
        private ButtonDisplayPool _displayDisplayPool;

        public void Setup(string buttonText, Color buttonColor, ButtonDisplayPool displayDisplayPool)
        {
            _gameplayButton = buttonText;
            _buttonColor = buttonColor;
            _gameplayButtonBackground.color = _buttonColor;
            _buttonTMP.text = _gameplayButton;
            _displayDisplayPool = displayDisplayPool;
        }
    
        private void OnEnable()
        {
            _gameplayButtonBackground.color = _buttonColor;
            _buttonTMP.text = _gameplayButton;
            _rectTransform = gameObject.GetComponent<RectTransform>();
            _rectTransform.localPosition = Vector3.zero;
        }

        private void Update()
        {
            _newPosition = Vector3.up * (Time.deltaTime * _speed) + _rectTransform.localPosition;
            _rectTransform.localPosition = _newPosition;
            if (_rectTransform.localPosition.y >= _ceiling)
            {
                _displayDisplayPool.Release(this);
                gameObject.SetActive(false);
            }
        }
    }
}

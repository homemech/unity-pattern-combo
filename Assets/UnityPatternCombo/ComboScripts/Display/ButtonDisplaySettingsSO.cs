
using UnityEngine;
namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Holds colors for the display of gameplay buttons.
    /// </summary>
    [CreateAssetMenu(fileName = "ButtonDisplaySettings", menuName = "PatternCombo/ButtonDisplaySettings", order = 0)]
    public class ButtonDisplaySettingsSO : ScriptableObject
    {
        [Header("Button Colors")]
        [SerializeField]
        private Color _xButtonColor;
        [SerializeField]
        private Color _yButtonColor;
        [SerializeField]
        private Color _aButtonColor;
        [SerializeField]
        private Color _bButtonColor;
        
        public Color XButtonColor => _xButtonColor;
        public Color YButtonColor => _yButtonColor;
        public Color AButtonColor => _aButtonColor;
        public Color BButtonColor => _bButtonColor;
    }
}

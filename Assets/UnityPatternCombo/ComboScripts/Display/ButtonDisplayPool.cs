using UnityEngine;
using UnityEngine.Pool;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Manages the recycling and reuse of ButtonDisplay objects using the Object Pooling pattern.
    ///
    /// This class maintains a pool of ButtonDisplay objects. 
    /// </summary>
    public class ButtonDisplayPool : MonoBehaviour
    {
        [SerializeField]
        private ButtonDisplay _buttonDisplayPrefab;

        [SerializeField]
        private ButtonDisplaySettingsSO _buttonDisplaySettings;
        
        public ButtonDisplaySettingsSO ButtonDisplaySettings => _buttonDisplaySettings;
        
        [SerializeField]
        private int _spawnAmount;

        [SerializeField]
        private int _defaultCapacity = 30;
        [SerializeField]
        private int _maxSize = 50;
        
        private ObjectPool<ButtonDisplay> _gameplayButtonPool;

        /// <summary>
        /// Retrieves a ButtonDisplay object from the pool. If the pool has an available object, it is returned.
        /// Otherwise, a new object is instantiated (as long as the pool hasn't reached its max size).
        /// </summary>
        /// <returns>A ButtonDisplay object ready for use.</returns>
        public ButtonDisplay GetPooledButtonDisplay()
        {
            return _gameplayButtonPool.Get();
        }

        private void Start()
        {
            //// Initialization of the pool with specified creation, activation, deactivation, and destruction actions.
            _gameplayButtonPool = new ObjectPool<ButtonDisplay>(
                () => Instantiate(_buttonDisplayPrefab, this.transform),
                 button => button.gameObject.SetActive(true), 
                 button => button.gameObject.SetActive(false),
                button => Destroy(button.gameObject),
                false, _defaultCapacity, _maxSize);
        }

        public void Release(ButtonDisplay buttonDisplay)
        {
            _gameplayButtonPool.Release(buttonDisplay);
        }
    }
}

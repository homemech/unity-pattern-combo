using System.Collections.Generic;
using UnityEngine;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Manages a command queue for executing combos, interfacing closely with ComboMatchEngine.
    /// Mimics a traditional fighting game's input buffer, handling command sequences within a dynamic time window for combos.
    /// </summary>
    public class ComboActionQueueManager: MonoBehaviour
    {
        [SerializeField]
        private ComboActionCommandFactory _comboActionCommandFactory;
        [SerializeField]
        private float _maxTimeForComboExecution = 0.5f;
        [SerializeField]
        private float _minimumTimeBetweenComboInputs = 0.5f;
        [SerializeField]
        private float _comboTimeAddedWithNewCommand = 0.5f;
        [SerializeField]
        private int _maxComboLengthBeforeTrim = 6;
    
        private float _timeSinceLastComboInput;
        private float _timeSinceFirstComboInput;
        private Queue<IGameplayActionCommand> _comboSequence;
        private ComboMatchEngine _comboMatchEngine;
        private int _minimumComboLength = 2;
        private int _thresholdToExtendComboTime;

        private void Awake()
        {
            _comboSequence = new Queue<IGameplayActionCommand>();
            _comboMatchEngine = new ComboMatchEngine(this, _comboActionCommandFactory, _minimumComboLength);
        }

        private void Update()
        {
            ProcessComboUpdate(Time.deltaTime);
        }

        // Continuously updates the combo timer, ensuring that combos are time-sensitive.
        private void ProcessComboUpdate(float deltaTime)
        {
            if (_comboSequence.Count == 0) return;

            _timeSinceFirstComboInput += deltaTime;
            _timeSinceLastComboInput += deltaTime;

            if (_timeSinceFirstComboInput > _maxTimeForComboExecution)
            {
                ClearComboSequence();
            }
        }

        // Queues a new command, evaluating its potential to form a combo based on timing and sequence.
        public void AddCommandToComboSequence(IGameplayActionCommand command)
        {
            ClearSequenceIfCannotStartCombo();
            DequeueOldestCommandIfNecessary();
        
            if (IsTooLateForCombo())
            {
                ClearComboSequence();
                return;
            }

            if (ShouldExtendComboTime())
            {
                _timeSinceFirstComboInput -= _comboTimeAddedWithNewCommand;
            }
        
            EnqueueCommandAndResetTimers(command);
            _comboMatchEngine.CheckAndExecuteCombo();
        }

        // Clears the command sequence if the current state does not permit a combo to start.
        // This preemptive check eases the processing load on the ComboMatchEngine by ensuring it only considers viable sequences,
        // which streamlines the combo detection process.
        private void ClearSequenceIfCannotStartCombo()
        {
            if (_comboSequence.Count > 0 && !_comboMatchEngine.CanStartCombo(_comboSequence))
            {
                ClearComboSequence();
                return;
            }
        }

        // Manages the queue size to prevent overflow and maintain a focus on recent player inputs
        // again, reducing the load on the match engine
        private void DequeueOldestCommandIfNecessary()
        {
            if (_comboSequence.Count >= _maxComboLengthBeforeTrim)
            {
                _comboSequence.Dequeue();
            }
        }

        // Determines if the timing between the latest command and the previous one is too delayed to count towards a combo.
        // This enforces a strict timing window for input commands. The check prevents the accidental execution of combos due to delayed 
        // inputs and maintains the right rhythm and feel of combo execution.
        private bool IsTooLateForCombo()
        {
            if (_timeSinceLastComboInput < _minimumTimeBetweenComboInputs)
            {
                return false;
            }
            return true;
        }

        // Enqueues a command and restarts the timers, anchoring the combo sequence to the most recent action.
        private void EnqueueCommandAndResetTimers(IGameplayActionCommand command)
        {
            _comboSequence.Enqueue(command);
        
            if (IsFirstCommandInSequence())
            {
                _timeSinceFirstComboInput = 0;
            }
        
            _timeSinceLastComboInput = 0;
        }

        // Determines if we are at the beginning of a potential combo, setting the stage for a new sequence of actions,
        // this decision point is critical for combo initiation and continuity.
        private bool IsFirstCommandInSequence()
        {
            return _comboSequence.Count == 1;
        }

        /// <summary>
        /// Currently, we always extend the combo time with each new combo-valid input command.
        /// 
        /// This method can be adjusted to add more nuanced control over how and when
        /// the combo time window is extended, such as based on the type of command. 
        /// This allows for fine-tuning the responsiveness of the combo system to achieve the desired gameplay feel. 
        /// 
        /// For example, you could pass in the command like ShouldExtendComboTime(IGameplayActionCommand command)
        /// giving certain commands a stronger window extension by using the strategy pattern with the command.
        /// </summary>
        private bool ShouldExtendComboTime()
        {
            return _comboSequence.Count >= _thresholdToExtendComboTime;
        }

        public Queue<IGameplayActionCommand> GetComboSequence()
        {
            return _comboSequence;
        }

        // Invoked at times when player didn't complete or start a combo--reset and wait for the next sequence of button presses
        public void ClearComboSequence()
        {
            _comboSequence.Clear();
            _timeSinceFirstComboInput = 0;
            _timeSinceLastComboInput = 0;
        }
    }
}

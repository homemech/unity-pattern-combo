using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Implements the ***Strategy Pattern*** to check and execute combo moves within an action/fighting game.
    /// This engine is the central hub for managing the detection of combo sequences and triggering the appropriate combo actions.
    ///
    /// Responsibilities include:
    /// - Checking if a sequence of actions constitutes a valid combo.
    /// - Executing the resulting combo action if a valid combo is detected.
    /// 
    /// It serves as an orchestrator, interacting with the ComboActionQueueManager and the ComboActionCommandFactory
    /// to determine if the player's input sequence matches predefined combo patterns, thus allowing for dynamic
    /// and flexible combo detection.
    /// </summary>
    public class ComboMatchEngine 
    {
        private ComboActionQueueManager _actionQueueManager;
        private ComboActionCommandFactory _comboActionCommandFactory;
        private List<IComboRule> _comboRules;
        private int _minimumComboLength;

        /// <summary>
        /// Initializes a new instance of the ComboMatchEngine class, setting up the infrastructure needed
        /// for combo detection and execution.
        /// </summary>
        /// <param name="manager">The action queue manager that handles the sequences of commands.</param>
        /// <param name="actionCommandFactory">The factory responsible for creating specific combo commands.</param>
        /// <param name="minimumComboLength">The minimum length of a command sequence to be considered a combo.</param>
        public ComboMatchEngine(ComboActionQueueManager manager, ComboActionCommandFactory actionCommandFactory, int minimumComboLength)
        {
            _actionQueueManager = manager;
            _comboActionCommandFactory = actionCommandFactory;
            _minimumComboLength = minimumComboLength;
            InitializeComboRules();
        }

        private void InitializeComboRules()
        {
            // Define the specific combo rules that this engine will recognize.
            // This setup allows for easy extension of the game's combo system by adding new rules.
            _comboRules = new List<IComboRule>()
            {
                new ComboXXY(_comboActionCommandFactory),
                new ComboUpB(_comboActionCommandFactory)
            };
        }

        // Determines if the current state of the combo sequence allows for a new combo to start.
        // This function serves as a gatekeeper, ensuring that the engine only processes sequences
        // that have the potential to form a valid combo, thus optimizing performance.
        // The "internal" access modifier restricts access to the current assembly, i.e. Tutorial.PatternCombo
        internal bool CanStartCombo(Queue<IGameplayActionCommand> comboSequence)
        {
            return DoesFirstActionStartCombo(comboSequence);
        }

        // Checks the current sequence for combos and executes the command if a valid combo is found.
        // This method is the core of the combo detection logic, tying together the sequence checking
        // and the command execution in one operation, centralizing the combo execution logic.
        public void CheckAndExecuteCombo()
        {
            var comboSequence = _actionQueueManager.GetComboSequence();

            // Optimize by only checking for a combo if the sequence meets the minimum length requirement.
            if (comboSequence.Count < _minimumComboLength) { return; }

            IGameplayActionCommand comboCommand = CheckSequenceForCombo(comboSequence);

            if (comboCommand != null)
            {
                ExecuteComboAction(comboCommand);
                ComboEventSystem.OnNewCombo.Invoke();
            }
        }

        // This method evaluates whether the first command in the sequence is the start of any defined combo.
        // It is crucial for early detection of potential combos, reducing unnecessary processing for sequences
        // that cannot form a valid combo, thereby optimizing the match-engine's performance.
        private bool DoesFirstActionStartCombo(Queue<IGameplayActionCommand> comboSequence)
        {
            foreach (var rule in _comboRules)
            {
                if (rule.IsFirstConditionMet(comboSequence.Peek()))
                {
                    return true;
                }
            }
            return false;
        }

        // This is where the engine checks the action command sequence against each defined combo rule.
        // By examining subsequences, it ensures that combos can be detected at any point in the input stream,
        // providing flexibility and robustness to the combo detection mechanism.
        private IGameplayActionCommand CheckSequenceForCombo(Queue<IGameplayActionCommand> comboSequence)
        {
            for (int startIndex = 0; startIndex <= comboSequence.Count; startIndex++)
            {
                var subsequence = GetSubsequence(comboSequence, startIndex);
                foreach (IComboRule rule in _comboRules)
                {
                    if (rule.IsMatch(subsequence))
                    {
                        return rule.GetResultingComboCommand();
                    }
                }
            }
            return null;
        }

        // Retrieves a subsequence from the given start index to the end of the command sequence.
        // The use of deferred execution via LINQ minimizes memory usage and increases efficiency,
        // as the subsequence is not immediately materialized into a new collection.
        private IEnumerable<IGameplayActionCommand> GetSubsequence(Queue<IGameplayActionCommand> comboSequence, int startIndex)
        {
            return comboSequence.Skip(startIndex);
        }

        // Once a combo is detected, this method is responsible for executing the associated action.
        // It also ensures the combo sequence is cleared, resetting the system to accept new input,
        // which is essential for maintaining the flow of gameplay and preparing for the next combo opportunity.
        private void ExecuteComboAction(IGameplayActionCommand comboCommand)
        {
            comboCommand.ExecuteAction();
            _actionQueueManager.ClearComboSequence();
        }
    }
}

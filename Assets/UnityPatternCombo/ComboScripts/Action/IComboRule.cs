using System;
using System.Collections.Generic;
namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Defines the contract for combo rules within the game. Implementations of this interface
    /// will specify the conditions for starting a combo, matching a complete combo sequence,
    /// and retrieving the command to execute when a combo is matched.
    ///
    /// This interface facilitates the ***Strategy Pattern*** by allowing the definition of various
    /// combo detection strategies that can be dynamically applied during gameplay.
    /// </summary>
    public interface IComboRule
    {
        /// <summary>
        /// Gets the length of the combo sequence required to match this rule.
        /// 
        /// This property is used to quickly determine if the current sequence
        /// of commands has the potential to form a valid combo, thus optimizing
        /// the combo checking process. It is set internally within each combo
        /// rule implementation and is immutable, ensuring the integrity of the
        /// combo length throughout the game logic.
        /// </summary>
        public int ComboLength { get; }

        /// <summary>
        /// Determines if the first command in a sequence can potentially start a valid combo.
        /// This method is crucial for optimizing the combo detection process by quickly
        /// filtering out sequences that do not start with a valid initial command, thus
        /// reducing unnecessary processing.
        /// </summary>
        /// <param name="firstCommand">The first command in the sequence to check.</param>
        /// <returns>True if the first command meets the starting condition for a combo; otherwise, false.</returns>
        public bool IsFirstConditionMet(IGameplayActionCommand firstCommand);

        /// <summary>
        /// Checks if a given sequence of commands matches the conditions defined by this rule to form a valid combo.
        /// This method encapsulates the logic for identifying complete combos, allowing for extensible and
        /// maintainable code when adding new combo patterns to the game.
        /// </summary>
        /// <param name="sequence">The sequence of gameplay action commands to check.</param>
        /// <returns>True if the sequence matches the combo pattern; otherwise, false.</returns>
        public bool IsMatch(IEnumerable<IGameplayActionCommand> sequence);

        /// <summary>
        /// Retrieves the command that should be executed when the combo rule is successfully matched.
        /// This method provides a means of associating a specific gameplay effect with a combo,
        /// enabling a clear separation between the detection of combos and the execution of their
        /// corresponding actions.
        /// </summary>
        /// <returns>The gameplay action command associated with the matched combo.</returns>
        public IGameplayActionCommand GetResultingComboCommand();
    }
}





using UnityEngine;
namespace Tutorial.PatternCombo
{ 
    /// <summary>
    /// Represents an executable gameplay display action.
    ///
    /// This interface serves as a contract for all types of gameplay display commands,
    /// including displaying individual buttons and displays for complex combo sequences.
    /// </summary>
    public interface IGameplayDisplayCommand
    {
        void ExecuteDisplay();
    }
}

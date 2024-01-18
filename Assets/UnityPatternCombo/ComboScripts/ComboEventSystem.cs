using System;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// A simple event system for broadcasting when a new combo is executed.
    /// 
    /// Right now only the ComboDisplayTextClimber subscribes so that the text climbs no matter the
    /// combo executed.
    /// </summary>
    public static class ComboEventSystem
    {
        public static Action OnNewCombo;
    }
}

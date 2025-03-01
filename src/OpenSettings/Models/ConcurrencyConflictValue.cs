namespace OpenSettings.Models
{
    public class ConcurrencyConflictValue
    {
        public ConcurrencyConflictValue(object current, object proposed)
        {
            Current = current;
            Proposed = proposed;
        }

        public object Current { get; }

        public object Proposed { get; }
    }
}
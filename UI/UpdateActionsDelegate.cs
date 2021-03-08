using System;

namespace GObjectRepro.UI
{
    public sealed class UpdateActionsDelegate : IDisposable
    {
        public UpdateActionsDelegate(IUpdateActions updateActions)
        {
            UpdateActions = updateActions;

            GLib.Timeout.Add(_timeoutInMs, new GLib.TimeoutHandler(OnIdle));
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // do nothing
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private static uint _timeoutInMs = 100;
        private bool _disposed = false;

        public IUpdateActions UpdateActions { get; init; } = null;

        private bool OnIdle()
        {
            if (_disposed)
                return false;

            UpdateActions?.UpdateActions();

            // invoke this routine again on the next Idle moment.
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Caffeine
{
    class SystemControl
    {
        private Timer timer = null;

        // Import SetThreadExecutionState Win32 API and necessary flags
        [DllImport("kernel32.dll")]
        private static extern uint SetThreadExecutionState(uint esFlags);

        private const uint ES_CONTINUOUS = 0x80000000;
        private const uint ES_SYSTEM_REQUIRED = 0x00000001;
        private const uint ES_DISPLAY_REQUIRED = 0x00000002;

        private const uint ES_AWAYMODE_REQUIRED = 0x00000040;

        public void StartContinuousMode(Boolean require_system = true, Boolean require_display = true)
        {
            if (timer == null)
            {
                Debug.WriteLine("Starting Continuous Mode");

                uint state = ES_CONTINUOUS;

                if (require_system)
                {
                    state |= ES_SYSTEM_REQUIRED;
                }

                if (require_display)
                {
                    state |= ES_DISPLAY_REQUIRED;
                }

                timer = new Timer(SetState, state, 0, 1000 * 60);
            }
        }

        public void StopContinuousMode()
        {
            if (timer != null)
            {
                Debug.WriteLine("Stopping Continuous Mode");

                timer.Dispose();
                timer = null;

                SetThreadExecutionState(ES_CONTINUOUS);
            }
        }

        void SetState(Object stateInfo)
        {
            Debug.WriteLine("SetState");

            SetThreadExecutionState((uint)stateInfo);
        }
    }
}

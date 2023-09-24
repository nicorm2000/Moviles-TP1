using UnityEngine;

namespace Utilities
{
    public class Timer
    {
        #region PARAMETERS
        public enum TIMER_MODE
        {
            INCREASE,
            DECREASE
        }
        private TIMER_MODE timerMode = TIMER_MODE.DECREASE;

        private float totalTime = 0;
        private float currentTime = 0;
        private bool active = false;
        private bool wasActive = false;
        private bool reached = false;

        public float CurrentTime { get => currentTime; }
        public bool Active { get => active; }
        #endregion

        #region METHODS
        /// <summary>
        /// Call this to set timer values, auto start if you want the timer to start or not yet
        /// </summary>
        public void SetTimer(float time, TIMER_MODE timerMode, bool autoStart = false)
        {
            this.timerMode = timerMode;
            totalTime = time;

            if (this.timerMode == TIMER_MODE.DECREASE) currentTime = time;
            else currentTime = 0;

            ChangeTimerState(autoStart);
        }

        /// <summary>
        /// Call this every time the timer is active
        /// </summary>
        public void UpdateTimer(float speed = 1)
        {
            if (!active) return;

            if (timerMode == TIMER_MODE.DECREASE) CheckTimer(-speed, currentTime <= 0, totalTime);
            else CheckTimer(speed, currentTime >= totalTime, 0);
        }

        /// <summary>
        /// Call this if you want to changed time values
        /// </summary>
        public void ResetTimer(float time, TIMER_MODE timerMode, bool autoStart = false)
        {
            SetTimer(time, timerMode, autoStart);
        }

        /// <summary>
        /// Call this to active timer
        /// </summary>
        public void ActiveTimer()
        {
            ResetTimer(totalTime, timerMode, true);
        }

        /// <summary>
        /// Call this to desactive timer
        /// </summary>
        public void DesactiveTimer()
        {
            ChangeTimerState(false);
        }

        /// <summary>
        /// Check the timer already reached
        /// </summary>
        public bool ReachedTimer()
        {
            if (wasActive && reached)
            {
                wasActive = false;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check timer state
        /// </summary>
        private void CheckTimer(float speed, bool condition, float initialTime)
        {
            currentTime += Time.deltaTime * speed;

            if (condition)
            {
                active = false;
                reached = true;
                currentTime = initialTime;
            }
        }

        /// <summary>
        /// Change if the timer is active or not
        /// </summary>
        private void ChangeTimerState(bool state)
        {
            active = state;
            wasActive = state;
            reached = !state;
        }
    }
    #endregion
}
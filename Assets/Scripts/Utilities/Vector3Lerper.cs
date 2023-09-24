using UnityEngine;

namespace Utilities.Lerpers
{
    public class Vector3Lerper : Lerper<Vector3>
    {
        /// <summary>
        /// Call this to set vector3 lerper values, auto start if you want the timer to start or not yet
        /// </summary>
        public override void SetLerperValues(Vector3 start, Vector3 end, float time, LERPER_TYPE lerperType, bool autoStart = false)
        {
            SetValues(start, end, time, lerperType, autoStart);
        }

        /// <summary>
        /// Call this to get the vector3 lerper actual value
        /// </summary>
        public override Vector3 GetValue()
        {
            return currentValue;
        }

        /// <summary>
        /// Update vector3 lerper position
        /// </summary>
        protected override void UpdateCurrentPosition(float percentage)
        {
            currentValue = Vector3.Lerp(start, end, percentage);
        }

        /// <summary>
        /// Check if the vector3 lerper has reached or not
        /// </summary>
        protected override bool CheckReached()
        {
            if (currentValue == end) return true;
            else return false;
        }
    }
}
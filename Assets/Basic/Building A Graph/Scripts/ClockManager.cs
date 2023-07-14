using System;
using UnityEngine;

namespace CatLikeCoding.Basics
{
    public class ClockManager : MonoBehaviour
    {
        #region SerializeField
        [SerializeField] Transform _HoursIndicator;
        [SerializeField] Transform _MinuteIndicator;
        [SerializeField] Transform _SecondIndicator;
        #endregion

        #region Private Variables
        private float mHourRotation = 30f;
        private float mMinuteRotation = 6f;
        private float mSecondRotation = 6f;
        #endregion

        #region Unity LifeCyle
        void Update()
        {
            SetTime();
        }
        #endregion

        #region Private Functions
        void SetTime()
        {
            TimeSpan timeSpan = DateTime.Now.TimeOfDay;
            _HoursIndicator.localRotation = Quaternion.Euler(0, (float)timeSpan.TotalHours * mHourRotation, 0);
            _MinuteIndicator.localRotation = Quaternion.Euler(0, (float)timeSpan.TotalMinutes * mMinuteRotation, 0);
            _SecondIndicator.localRotation = Quaternion.Euler(0, (float)timeSpan.TotalSeconds * mSecondRotation, 0);
        }
        #endregion
    }
}

using static UnityEngine.Mathf;
namespace CatLikeCoding.Basics
{
    public class FunctionLibrary
    {
        #region Delegate
        public delegate float Function(float x, float z, float t);
        #endregion

        #region Private Variables
        static Function[] mFunction = { Wave, MultiWave, Ripple };
        #endregion

        #region Static Functions
        public static float Wave(float x, float z, float t)
        {
            return Sin(PI * (x + z + t));
        }

        public static float MultiWave(float x, float z, float t)
        {
            float y = Sin(PI * (x + .5f * t));
            y += .5f * Sin(PI * 2f * (z + t)) * (2f / 3);
            y += Sin(PI * (x + z + 0.25f * t));
            return y * (1f / 2.5f);
        }

        public static float Ripple(float x, float z, float t)
        {
            float d = Sqrt(x * x + z * z);
            float y = Sin(PI * (4f * d - t));
            return y / (1f + 10f * d);
        }

        public static Function GetFunction(FunctionName functionName)
        {
            return mFunction[(int)functionName];
        }
        #endregion
    }

    #region Enum
    public enum FunctionName
    {
        Wave,
        MultiWave,
        Ripple
    }
    #endregion
}
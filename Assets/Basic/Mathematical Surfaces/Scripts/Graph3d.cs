using UnityEngine;
using static CatLikeCoding.Basics.FunctionLibrary;

namespace CatLikeCoding.Basics
{
    public class Graph3d : MonoBehaviour
    {
        #region Serialize Fields
        [SerializeField] GameObject _CubeObj;
        [SerializeField][Range(10, 100)] int _Resolution = 10;
        [SerializeField] FunctionName _FunctionName;
        #endregion

        #region Private Variables
        Transform[] mCubeTransformArray;
        float mStep;
        #endregion

        #region Unity CallBacks
        void Awake()
        {
            mStep = 2f / _Resolution;
            Vector3 scale = Vector3.one * mStep;
            mCubeTransformArray = new Transform[_Resolution * _Resolution];
            for (int i = 0; i < mCubeTransformArray.Length; ++i)
            {
                var cubeTransform = mCubeTransformArray[i] = Instantiate<GameObject>(_CubeObj, transform).transform;
                cubeTransform.name = $"{i}";
                cubeTransform.localScale = scale;
            }
        }

        void Update()
        {
            Function function = FunctionLibrary.GetFunction(_FunctionName);
            float time = Time.time;
            float v = .5f * mStep - 1;
            for (int i = 0, x = 0, z = 0; i < mCubeTransformArray.Length; ++i, ++x)
            {
                if (x == _Resolution)
                {
                    x = 0;
                    ++z;
                    v = (z + .5f) * mStep - 1;
                }
                float u = (x + .5f) * mStep - 1;
                mCubeTransformArray[i].position = function(u, v, time);
            }
        }
        #endregion
    }
}

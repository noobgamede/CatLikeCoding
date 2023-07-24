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
        Vector3 mPos = Vector3.zero;
        Transform[] mCubeTransformArray;
        #endregion

        #region Unity CallBacks
        void Awake()
        {
            float factor = 2f / _Resolution;
            Vector3 scale = Vector3.one * factor;
            mCubeTransformArray = new Transform[_Resolution * _Resolution];
            for (int i = 0, x = 0, z = 0; i < mCubeTransformArray.Length; ++i, ++x)
            {
                if (x == _Resolution)
                {
                    x = 0;
                    ++z;
                }
                var cubeTransform = mCubeTransformArray[i] = Instantiate<GameObject>(_CubeObj, transform).transform;
                cubeTransform.name = $"{i}";
                mPos.x = (x + .5f) * factor - 1;
                mPos.z = (z + .5f) * factor - 1;
                cubeTransform.position = mPos;
                cubeTransform.localScale = scale;
            }
        }

        void Update()
        {
            float time = Time.time;
            Function function = FunctionLibrary.GetFunction(_FunctionName);
            for (int i = 0; i < mCubeTransformArray.Length; ++i)
            {
                mPos = mCubeTransformArray[i].position;
                mPos.y = function(mPos.x, mPos.z, time);
                mCubeTransformArray[i].position = mPos;
            }
        }
        #endregion
    }
}

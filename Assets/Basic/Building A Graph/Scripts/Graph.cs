using UnityEngine;
namespace CatLikeCoding.Basics
{
    public class Graph : MonoBehaviour
    {
        #region Serializable Fields
        [SerializeField] GameObject _CubePrefab;
        [SerializeField, Range(10, 100)] int _Resolution = 10;
        #endregion

        #region Private Variabels
        Vector3 mPos = Vector3.zero;
        Transform[] mCubeTransforms;
        #endregion

        #region Unity Life Cycle
        void Awake()
        {
            var factor = 2f / _Resolution;
            var scale = Vector3.one * factor;
            mCubeTransforms = new Transform[_Resolution];
            for (int i = 0; i < _Resolution; ++i)
            {
                var cubeTransform = mCubeTransforms[i] = Instantiate<GameObject>(_CubePrefab, transform).transform;
                cubeTransform.name = $"{i}";
                mPos = Vector3.right * ((i + .5f) * factor - 1);
                cubeTransform.position = mPos;
                cubeTransform.localScale = scale;
            }
        }

        void Update()
        {
            float time = Time.time;
            for (int i = 0; i < mCubeTransforms.Length; ++i)
            {
                mPos = mCubeTransforms[i].position;
                mPos.y = Mathf.Sin(Mathf.PI * (mPos.x + time));
                mCubeTransforms[i].position = mPos;
            }
        }
        #endregion
    }
}

using UnityEngine;
namespace CatLikeCoding.Basics
{
    public class Graph : MonoBehaviour
    {
        #region Serializable Fields
        [SerializeField] GameObject _CubePrefab;
        [SerializeField, Range(10, 100)] int _Resolution = 10;
        #endregion

        #region Unity Life Cycle
        void Awake()
        {
            var factore = 2f / _Resolution;
            var scale = Vector3.one * factore;
            Vector3 pos = Vector3.zero;
            for (int i = 0; i < _Resolution; ++i)
            {
                var cube = Instantiate<GameObject>(_CubePrefab, transform);
                cube.name = $"{i}";
                pos = Vector3.right * ((i + .5f) * factore - 1);
                pos.y = pos.x;
                cube.transform.position = pos;
                cube.transform.localScale = scale;
            }
        }
        #endregion
    }
}

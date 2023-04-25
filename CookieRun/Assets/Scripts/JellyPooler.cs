//using UnityEditor.U2D.Path.GUIFramework;
//using UnityEngine;
//using UnityEngine.Pool;

//// 오브젝트 풀링
//public class JellyPooler : MonoBehaviour
//{
//    [SerializeField] Jelly _prefab;
//    ObjectPool<Jelly> _pool;

//    private void Awake()
//    {
//        _pool = new ObjectPool<Jelly>(CreateFunc, GetAction, ReleaseAction);
//    }

//    public Jelly CreateFunc() 
//    {
//        Jelly jelly = Instantiate(_prefab, Vector3.zero, Quaternion.identity);
//        jelly.SetPool(_pool);
//        return jelly;
//    }

//    public void GetAction(Jelly jelly) 
//    {
        
//    }
//    public void ReleaseAction(Jelly jelly)
//    {
//        jelly.Reset();
//    }
//}

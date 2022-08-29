#if UNITY_2021_3

using UnityEngine;

namespace AreYouFruits.Common
{
    public ref struct GameObjectCreationInfo
    {
        public GameObject? Prefab;
        public string? Name;
        public Transform? Parent;
        public Vector3 Position;
        public Quaternion? Rotation;
    }
    
    public static class GameObjectHelper
    {
        public static GameObject Create(GameObjectCreationInfo info)
        {
            GameObject gameObject = info.Prefab.IsNull(out GameObject prefab) ? new GameObject() : Object.Instantiate(prefab);

            if (!info.Name.IsNull(out string name))
            {
                gameObject.name = name;
            }

            gameObject.transform.SetParent(info.Parent);
            gameObject.transform.SetPositionAndRotation(info.Position, info.Rotation ?? Quaternion.identity);

            return gameObject;
        }
    }
}

#endif
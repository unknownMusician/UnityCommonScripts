using UnityEngine;

namespace AreYouFruits.Common
{
    public struct GameObjectCreationInfo
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
            
            GameObject gameObject = info.Prefab is { } prefab ? Object.Instantiate(prefab) : new GameObject();

            if (info.Name is { } name)
            {
                gameObject.name = name;
            }

            gameObject.transform.SetParent(info.Parent);
            gameObject.transform.SetPositionAndRotation(info.Position, info.Rotation ?? Quaternion.identity);

            return gameObject;
        }
    }
}

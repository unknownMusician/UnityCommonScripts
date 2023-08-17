using AreYouFruits.Nullability;
using UnityEngine;

namespace AreYouFruits.MonoBehaviourUtils.Unity
{
    public struct GameObjectCreationInfo
    {
        public Optional<GameObject> Prefab;
        public Optional<string> Name;
        public Optional<Transform> Parent;
        public Vector3 Position;
        public Optional<Quaternion> Rotation;
    }
    
    public static class GameObjectHelper
    {
        public static GameObject Create(GameObjectCreationInfo info)
        {
            GameObject gameObject = info.Prefab.Match(Object.Instantiate, () => new GameObject());

            if (info.Name.TryGet(out string name))
            {
                gameObject.name = name;
            }

            gameObject.transform.SetParent(info.Parent.GetOrDefault());
            gameObject.transform.SetPositionAndRotation(info.Position, info.Rotation.GetOr(Quaternion.identity));

            return gameObject;
        }
    }
}

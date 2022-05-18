using UnityEngine;
namespace Asteroid
{
    public static partial class BuilderExtensions
    {
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }
        public static GameObject AddRigidbody2D(this GameObject gameObject, float mass, float gravityScale, float linearDrag)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            component.gravityScale = gravityScale;
            component.drag = linearDrag;
            return gameObject;
        }

        public static GameObject AddRigidbody2D(this GameObject gameObject, float mass)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            return gameObject;
        }

        public static GameObject AddBoxCollider2D(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<BoxCollider2D>();
            return gameObject;
        }
        public static GameObject AddCircleCollider2D(this GameObject gameObject, float radius)
        {
            var component = gameObject.GetOrAddComponent<CircleCollider2D>();
            component.radius = radius;
            return gameObject;
        }
        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite, Color color, int orderInLayer)
        {
            var component = gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            component.color = color;
            component.sortingOrder = orderInLayer;
            return gameObject;
        }

        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
        {
            var component = gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            return gameObject;
        }

        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }
            return result;
        }
    }
}

using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;


public class EntitySpawner : MonoBehaviour
{
    /*[System.Serializable]
    public struct SharedInitialData : ISharedComponentData
    {
        public float3 Velocity;
        public float LifeTime;
    }*/

    //public SharedInitialData sharedInitialData;
    public GameObject Prefab;
    public int SpawnCount = 500;
    public float2 sVelocity;
    public float sLifeTime;

    void Start()
    {
        // Create entity prefab from the game object hierarchy once
        Entity prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(Prefab, World.Active);
        var entityManager = World.Active.EntityManager;

        for (int i = 0; i < SpawnCount; i++)
        {
            // Efficiently instantiate a bunch of entities from the already converted entity prefab
            var instance = entityManager.Instantiate(prefab);

            // Place the instantiated in the center
            var position = transform.TransformPoint(new float3(0, 0, 0));
            entityManager.SetComponentData(instance, new Translation() { Value = position });
            entityManager.AddComponentData(instance, new MoveComponent() { Velocity = sVelocity, LifeTime = sLifeTime } );
        }
    }
}

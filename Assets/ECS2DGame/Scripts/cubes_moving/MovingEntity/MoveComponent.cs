using Unity.Mathematics;
using Unity.Entities;

// Serializable attribute is for editor support.
[System.Serializable]
public struct MoveComponent : IComponentData
{
    public float2 Velocity;
    public float LifeTime;
}

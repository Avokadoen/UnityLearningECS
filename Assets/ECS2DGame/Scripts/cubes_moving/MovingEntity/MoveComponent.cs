using Unity.Mathematics;
using Unity.Entities;

// Serializable attribute is for editor support.
[System.Serializable]
public struct MoveComponent : IComponentData
{
    // should be normalized vector
    float3 direction;
}

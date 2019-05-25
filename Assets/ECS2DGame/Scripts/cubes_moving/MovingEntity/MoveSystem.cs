using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class MoveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithAllReadOnly<MoveComponent>().ForEach(
         (ref Translation translation, ref MoveComponent moveComponent) =>
         {
             var deltaTime = Time.deltaTime;
             var rotationSpeed = 1f * deltaTime;

             var xRotation = UnityEngine.Random.Range(-rotationSpeed, rotationSpeed);
             moveComponent.Velocity.x = moveComponent.Velocity.x * Mathf.Cos(xRotation) - moveComponent.Velocity.y * Mathf.Sin(xRotation);

             var yRotation = UnityEngine.Random.Range(-rotationSpeed, rotationSpeed);
             moveComponent.Velocity.y = moveComponent.Velocity.x * Mathf.Sin(yRotation) + moveComponent.Velocity.y * Mathf.Cos(yRotation);

             var velocity = new float3(moveComponent.Velocity.x * deltaTime, moveComponent.Velocity.y * deltaTime, 0);

             translation = new Translation()
             {
                 Value = new float3(translation.Value + velocity)
             };
         }
        );
    }
}

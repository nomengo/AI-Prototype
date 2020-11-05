using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
public class IsDoorOpenConditionalTask : Conditional
{
    public SharedTransform DoorOpen;

    public override TaskStatus OnUpdate()
    {
        return DoorOpen.Value.GetComponent<DoorController>().IsDoorOpen ? TaskStatus.Success : TaskStatus.Running;
    }
}

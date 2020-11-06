using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

public class WaitAndMove : Action
{
    [Tooltip("The Amount Of Time To Wait Before Moving")]
    public SharedFloat WaitTime = 1;

    [Tooltip("Speed Of The Agent")]
    public SharedFloat Speed;
    [Tooltip("Agent Will Arrive If The Magnitude Is Less Than This Value")]
    public SharedFloat ArrivedDistance = 1;
    [Tooltip("Look To The Target?")]
    public SharedBool LookAtTarget = false;
    [Tooltip("Max Rotation Delta If LookAtTarget Is Enabled")]
    public float MaxLookRotationDelta;
    [Tooltip("The Target That The Agent Is Gonna Move")]
    public SharedGameObject Target;
    [Tooltip("Use Target Positin When The Target Is Null")]
    public SharedVector3 TargetPosition;


    //the time to wait
    private float waitDuration;
    // The time that the task started to wait.
    private float startTime;
    // Remember the time that the task is paused so the time paused doesn't contribute to the wait time.
    private float pauseTime;

    public override void OnStart()
    {
        startTime = Time.time;
        waitDuration = WaitTime.Value;
    }

    public override TaskStatus OnUpdate()
    {
        if(startTime + waitDuration < Time.time)
        {
            var position = TargetPos();
            if(Vector3.Magnitude(transform.position - position) < ArrivedDistance.Value)
            {
                return TaskStatus.Success;
            }

            transform.position = Vector3.MoveTowards(transform.position, position, Speed.Value * Time.deltaTime);
            if(LookAtTarget.Value && (position - transform.position).sqrMagnitude > 0.01f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(position - transform.position), MaxLookRotationDelta);
            }else
            {
                return TaskStatus.Running;
            }
        }
        return TaskStatus.Running;
    }

    public override void OnPause(bool paused)
    {
        if (paused)
        {
            pauseTime = Time.time;
        }
        else
        {
            startTime += (Time.time - pauseTime);
        }
    }

    private Vector3 TargetPos()
    {
        if(Target == null || Target.Value == null)
        {
            return TargetPosition.Value;
        }
        return Target.Value.transform.position;
    }

    public override void OnReset()
    {
        WaitTime = 1;
        ArrivedDistance = 1;
        LookAtTarget = false;
    }


}

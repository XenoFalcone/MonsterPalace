using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.MonsterTask
{
    [TaskCategory("Monster")]
    [TaskDescription("lower Satisfaction")]
    public class Happy : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;

        [Tooltip("The satisfaction value to gain.")]
        public SharedInt saisfactionValue;
        [Tooltip("The reason the monster is happy.")]
        public SharedString message;
        [Tooltip("Is the message an ID ?")]
        public SharedBool id;

        // cache the navmeshagent component
        private MonsterController controller;

        public override void OnStart()
        {
            controller = GetDefaultGameObject(targetGameObject.Value).GetComponent<MonsterController>();
        }

        public override TaskStatus OnUpdate()
        {


            controller.Happy(saisfactionValue.Value, message.Value, id.Value);

            return TaskStatus.Success;


        }

        public override void OnReset()
        {
            targetGameObject = null;
        }
    }



}

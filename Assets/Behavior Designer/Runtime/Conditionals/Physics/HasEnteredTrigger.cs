using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Returns success when an object enters the trigger.")]
    [TaskCategory("Physics")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=110")]
    public class HasEnteredTrigger : Conditional
    {
        [Tooltip("The object that entered the trigger")]
        public SharedGameObject otherGameObject;

        private bool enteredTrigger = false;

        public override TaskStatus OnUpdate()
        {
            return enteredTrigger ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnEnd()
        {
            enteredTrigger = false;
        }

        public override void OnTriggerEnter(Collider other)
        {
            otherGameObject.Value = other.gameObject;
            enteredTrigger = true;
        }

        public override void OnReset()
        {
            otherGameObject = null;
        }
    }
}
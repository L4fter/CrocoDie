namespace Assets.Src.Controller
{
    using UnityEngine;
    using UnityEngine.UI;

    public class TutorialController : MonoBehaviour
    {
        private static readonly string crocoFirstHint = "Hi! You're are Croco and you are sleeping now. Wait for second player to wake you up and move with Up and Down";
        private static readonly string crocoSecondHint = "Don't get hungry! Eat fish, and remember not to hit the obstacles";
        private static readonly string manFirstHint = "Hey! Your pet Croco is sleeping, press Space to move and wake him up";
        private static readonly string manSecondHint = "Don't let your croco get hungry! Protect yourself from coconuts and birds with Enter and Z";
        private static readonly string lastHint = "";

        public Text firstBubble;
        public Text secondBubble;
        public Text thirdBubble;

        void Start()
        {
            if (GameController.Instance.PlayerControlsCroco)
            {
                firstBubble.text = crocoFirstHint;
                secondBubble.text = crocoSecondHint;
                //                firstBubble.text = crocoFirstHint;
            }
            else
            {
                firstBubble.text = manFirstHint;
                secondBubble.text = manSecondHint;
            }
        }
    }
}
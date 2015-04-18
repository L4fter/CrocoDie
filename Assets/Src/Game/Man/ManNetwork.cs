namespace Assets.Src.Game.Pers
{
    using UnityEngine;

    public class ManNetwork : MonoBehaviour
    {
        public Man man;

        private void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
        {
            var action = -1;

            if (stream.isWriting)
            {
                action = (int)this.man.CurrentAction;
                stream.Serialize(ref action);
            }
            else
            {
                stream.Serialize(ref action);
                Debug.Log("Serialized action: " + (Man.Action)action);
                switch ((Man.Action)action)
                {
                    case Man.Action.Idle:
                        SendMessage("Idle");
                        break;
                    case Man.Action.HighKick:
                        SendMessage("HighKick");
                        break;
                    case Man.Action.LowKick:
                        SendMessage("LowKick");
                        break;
                    case Man.Action.MidKick:
                        SendMessage("MidKick");
                        break;
                }
            }
        }
    }
}
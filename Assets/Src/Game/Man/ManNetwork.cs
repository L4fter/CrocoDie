namespace Assets.Src.Game.Pers
{
    using UnityEngine;

    public class ManNetwork : MonoBehaviour
    {
        public Man man;

        public NetworkView NetworkView;

        private GameController game;

        void Start()
        {
            game = GameController.Instance;
        }

        public void LowKick()
        {
            if (game.OnlineGame && game.PlayerControlsMan)
            {
                NetworkView.RPC("Kick", RPCMode.Others, "LowKick");
            }
        }

        public void MidKick()
        {
            if (game.OnlineGame && game.PlayerControlsMan)
            {
                NetworkView.RPC("Kick", RPCMode.Others, "MidKick");
            }
        }

        public void HighKick()
        {
            if (game.OnlineGame && game.PlayerControlsMan)
            {
                NetworkView.RPC("Kick", RPCMode.Others, "HighKick");
            }
        }

        [RPC]
        public void Kick(string message)
        {
            SendMessage(message);
        }
    }
}
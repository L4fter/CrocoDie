namespace Assets.Src.Game.Crocodile
{
    using UnityEngine;

    public class CrocoNetwork : MonoBehaviour
    {
        public Croco Croco;


        void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
        {
            var pos = Vector3.zero;

            if (stream.isWriting)
            {
                pos = this.Croco.gameObject.transform.position;
                stream.Serialize(ref pos);
            }
            else
            {
                stream.Serialize(ref pos);
                //            UnityEngine.Debug.Log(pos);
                var croco = this.Croco.transform.position;
                //            Croco.transform.position = Vector3.Lerp(croco, pos, 0.95f);
               Croco.Goal = pos;
            }
        }
    }
}
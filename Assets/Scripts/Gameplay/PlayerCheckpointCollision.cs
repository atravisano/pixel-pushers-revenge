using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{
    public class PlayerCheckpointCollision : Simulation.Event<PlayerTokenCollision>
    {
        public PlayerController player;
        public CheckpointInstance checkpoint;

        public override void Execute()
        {
            if (checkpoint.checkpointCollectAudio)
            {
                AudioSource.PlayClipAtPoint(checkpoint.checkpointCollectAudio, checkpoint.transform.position);
            }

            GameController.Instance.PickCard();
        }
    }
}

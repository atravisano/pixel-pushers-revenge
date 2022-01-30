using System.Linq;
using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This class exposes the the game model in the inspector, and ticks the
    /// simulation.
    /// </summary> 
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        //This model field is public and can be therefore be modified in the 
        //inspector.
        //The reference actually comes from the InstanceRegister, and is shared
        //through the simulation and events. Unity will deserialize over this
        //shared reference when the scene loads, allowing the model to be
        //conveniently configured inside the inspector.
        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Transform CardPickerCanvas;

        void OnEnable()
        {
            Instance = this;

            // Temp code
            /*
            Card[] cards = Resources.LoadAll<Card>("Cards");

            var card = cards.First(x => x.title == "No Pain, Low Gain");

            ApplyCard(card);*/
        }

        void OnDisable()
        {
            if (Instance == this) Instance = null;
        }

        void Update()
        {
            if (Instance == this) Simulation.Tick();
        }

        public void ApplyCard(Card card)
        {
            Debug.Log($"Card \"{card.title}\" applied");

            if (card.invincibilityTime > 0)
            {
                var pi = Simulation.Schedule<PlayerInvincibility>();
                pi.InvincibilityTime = card.invincibilityTime;
            }

            if (card.jumpHeight > 0)
            {
                model.player.jumpTakeOffSpeed = card.jumpHeight * model.player.jumpTakeOffSpeed;
            }

            if (card.speedMultiplier > 0)
            {
                model.player.maxSpeed = card.speedMultiplier * model.player.maxSpeed;
            }
        }

        public void PickCard()
        {
            if (CardPickerCanvas)
            {
                PauseGame();

                CardPickerCanvas.gameObject.SetActive(true);
            }
        }

        public void ClosePickCard()
        {
            if (CardPickerCanvas)
            {
                CardPickerCanvas.gameObject.SetActive(false);

                ResumeGame();
            }
        }

        void PauseGame()
        {
            Time.timeScale = 0;
        }

        void ResumeGame()
        {
            Time.timeScale = 1;
        }
    }
}
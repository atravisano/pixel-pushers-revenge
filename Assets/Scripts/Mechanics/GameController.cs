using System.Linq;
using Cinemachine;
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

        public CardSelection CardPicker;

        void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void OnEnable()
        {
            InitializeNewLevel();
        }

        public void InitializeNewLevel()
        {
            Instance = this;

            var player = FindObjectOfType<PlayerController>();
            if (player == null)
            {
                Debug.Log("Could not find the player");
                return;
            }

            model.player = player;

            var camera = FindObjectOfType<CinemachineVirtualCamera>();
            if (camera != null)
            {
                model.virtualCamera = camera;
            }
            else
            {
                Debug.Log("Could not find camera");
            }

            var spawnPoint = GameObject.FindGameObjectWithTag("Respawn");
            if (spawnPoint != null)
            {
                model.spawnPoint = spawnPoint.transform;
                player.transform.position = spawnPoint.transform.position;
            }
            else
            {
                Debug.Log("Cound not find spawn point");
            }
            
            //var cardSelections = FindObjectsOfTypeAll(typeof(CardSelection));
            //if (cardSelections != null && cardSelections.Last() > 0)
            //{
            //    CardPickerCanvas = cardSelections[0].transform;
            //}
            //else
            //{
            //    Debug.Log("Could not find the card selection canvas");
            //}


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
            
            if (card.DmgOverTime > 0)
            {
                //model.player.maxSpeed = card.speedMultiplier * model.player.maxSpeed;
            }

            if (card.sizeMultiplier > 0)
            {
                model.player.transform.localScale *= card.sizeMultiplier;
            }

            if (card.collectableGain > 0)
            {
                var scoreManager = FindObjectOfType<ScoreManager>();
                scoreManager.AddScore((int)card.collectableGain);
            }

            if (card.collectableLoss > 0)
            {
                var scoreManager = FindObjectOfType<ScoreManager>();
                scoreManager.RemoveScore((int)card.collectableLoss);
            }

            if (card.collectableMultiplier > 0)
            {
                var scoreManager = FindObjectOfType<ScoreManager>();
                scoreManager.SetScore(scoreManager.GetScore() * (int)card.collectableMultiplier);
            }

            if (card.collectableOverTime > 0)
            {
                var pi = Simulation.Schedule<PlayerCollectableOverTime>(PlayerCollectableOverTime.TimeBetweenCollects);
                pi.CollectableOverTime = card.collectableOverTime;
            }

            if (card.massMultiplier > 0)
            {
                model.player.gravityModifier *= card.massMultiplier;
            }

            if (card.removeCards > 0)
            {
                for(var i = 0; i < card.removeCards; i++){
                    CardMenu.instance.RemoveRandom();
                }
            }

            if (card.addCards > 0)
            {
                for(var i = 0; i < card.addCards; i++){
                    CardMenu.instance.AddCard(CardDeck.instance.DealCard());
                }
            }
        }

        public void PickCard()
        {
            if (CardPicker)
            {
                PauseGame();

                CardPicker.showCardSelect();
            }
        }

        public void ClosePickCard()
        {
            if (CardPicker)
            {
                CardPicker.hideCardSelect();

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
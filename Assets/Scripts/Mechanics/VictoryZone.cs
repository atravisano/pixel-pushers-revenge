using System.Collections;
using Platformer.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// </summary>
    public class VictoryZone : MonoBehaviour
    {
        public int CoinsRequired;
        public GameObject GameOverScreen;

        void OnTriggerEnter2D(Collider2D collider)
        {
            var player = collider.gameObject.GetComponent<PlayerController>();
            var scoreManager = UnityEngine.Object.FindObjectOfType<ScoreManager>();
            var score = scoreManager.GetScore();
            if (player != null && score >= CoinsRequired)
            {
                // var ev = Schedule<PlayerEnteredVictoryZone>();
                // ev.victoryZone = this;
                var gameController = UnityEngine.Object.FindObjectOfType<GameController>();
                SceneManager.LoadScene("Anthony", LoadSceneMode.Single);
            }
            if (player != null && score < CoinsRequired)
            {
                // Game ends when player can't buy next level.
                Debug.Log("game over");
                StartCoroutine(GameOver());
            }
        }

        private IEnumerator GameOver()
        {
            yield return new WaitForSeconds(0.25f);
            GameOverScreen.SetActive(true);
        }
    }
}
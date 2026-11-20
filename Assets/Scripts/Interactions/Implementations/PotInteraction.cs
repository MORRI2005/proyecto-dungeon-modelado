using UnityEngine;
using Gameplay.Systems;

namespace Gameplay.Interactions
{

    public class PotInteraction : MonoBehaviour
    {
        private Damageable damageable;

        public GameObject rewardObject;

        private bool Destroyed = false;

        public int rewardCount = 1;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            damageable = GetComponent<Damageable>();
            rewardObject = GetComponent<GameObject>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!Destroyed && damageable.IsDead)
            {
                SpawnReward();
                Destroy(gameObject);
                Destroyed = true;
            }
        }

        public void SpawnReward()
        {
            for (int i = 0; i < rewardCount; i++)
            {
                GameObject reward = Instantiate(rewardObject, transform.position + Vector3.up * 0.2f, Quaternion.identity);
                LaunchableReward launchableReward = reward.GetComponent<LaunchableReward>();
                if (launchableReward != null)
                {
                    launchableReward.LaunchReward();
                }
            }
        }
    }
}

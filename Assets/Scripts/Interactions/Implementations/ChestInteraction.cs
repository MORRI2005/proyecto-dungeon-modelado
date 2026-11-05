using UnityEngine;

namespace Gameplay.Interactions
{
    public class ChestInteraction : MonoBehaviour
    {
        private Interactable _interactable;
        private Animator _animator;

        public GameObject rewardPrefab;
        public int rewardCount = 1;

        private bool isOpen = false;
        private bool hasReward = true;

        void Awake()
        {
            _interactable = GetComponent<Interactable>();
            _interactable.OnInteract += Interact;

            _animator = GetComponent<Animator>();
        }

        private void Interact(CharacterInteractor interactor)
        {
            // _animator.SetTrigger("Open");

            if (isOpen)
            {
                isOpen = false;
                _animator.SetBool("ChestState", false);
            }
            else
            {
                _animator.SetBool("ChestState", true);
                isOpen = true;
            }

            // _interactable.InteractionEnabled = false;
        }

        public void SpawnReward()
        {
            if (hasReward)
            {
                hasReward = false;
                for (int i = 0; i < rewardCount; i++)
                {
                    GameObject reward = Instantiate(rewardPrefab, transform.position + Vector3.up * 0.2f, Quaternion.identity);
                    LaunchableReward launchableReward = reward.GetComponent<LaunchableReward>();
                    if (launchableReward != null)
                    {
                        launchableReward.LaunchReward();
                    }
                }

            }
        }
    }
}

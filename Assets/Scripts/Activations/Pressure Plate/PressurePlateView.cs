using UnityEngine;

public class PressurePlateView : MonoBehaviour
{
    Animator _animator;
    [SerializeField] ParticleSystem puffParticles;
    void Awake()
    {
        _animator = GetComponent<Animator>();

        if (TryGetComponent(out ActivatorBase activator))
        {
            activator.ToActivate.AddListener(OnActivated);
        }
    }

    private void OnActivated(ActivatorBase.ActivatorInfo info)
    {
        _animator.SetBool("isPressed", info.Activator.IsActivated);
    }

    //This method is called from the animation.
    public void PlayPuffParticles()
    {
        puffParticles.Play();
    }
}

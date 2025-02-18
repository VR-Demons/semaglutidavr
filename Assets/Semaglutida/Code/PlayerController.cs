using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool _faded;
    [SerializeField] private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        if (_faded)
        {
            FadeFromWhite();
        }
    }
    public void FadeToWhite()
    {
        _animator.SetBool("Fade", true);
    }
    public void FadeFromWhite()
    {
        _animator.SetTrigger("FadeStart");
        _animator.SetBool("Fade", false);
    }
}

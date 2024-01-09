using UnityEngine;
public class CharacterMover : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;

    private float _vInput;
    private float _hInput;
    private Rigidbody _rb;
    Animator anim;
    private bool _isAttacking;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        // Get a reference to the animator
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        anim.SetFloat("CharSpeed", Input.GetAxis("Vertical"));
        _isAttacking = Input.GetKeyDown(KeyCode.LeftShift); // that value will either be true or false depending on if user ispressing the “Shift” key...
        anim.SetBool("CharAttacking", _isAttacking); // so assign it to CharAttacking in the Animator
        this.transform.Translate(Vector3.forward * _vInput *
       Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
    }
    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation *
       Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position +
       this.transform.forward * _vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FirstPersonCharacter : Character
{
    [SerializeField] float mouseSensivity = 2;
    [SerializeField] float cameraPitchRange = 180;
    CharacterMovement characterMovement;
    Camera _camera;
    float cameraPitch;
    
    void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
        _camera = GetComponentInChildren<Camera>();
        cameraPitch = _camera.transform.localEulerAngles.x;
        HideCursor();
        
    }

    void Update()
    {
        characterMovement.SetMovementDirection(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        CameraRotation();
        if (Input.GetAxis("Jump") == 1)
        {
            characterMovement.Jump();
        }
        if (Input.GetAxis("Fire1") == 1)
        {
            GetComponent<Gun>().Shot();
        }
    }
    

    void Shot()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        Ray ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            StartCoroutine(SphereIndicator(hit.point));
        }
    }

    IEnumerator SphereIndicator(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

    void CameraRotation()
    {
        cameraPitch -= Input.GetAxis("Mouse Y") * mouseSensivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -cameraPitchRange / 2, cameraPitchRange / 2);
        _camera.transform.localEulerAngles = new Vector3(cameraPitch, _camera.transform.localEulerAngles.y, _camera.transform.localEulerAngles.z);
        transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensivity, 0);
    }

    void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void ShowCusor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    public override void TakeDamage(float damage)
    {

    }
}


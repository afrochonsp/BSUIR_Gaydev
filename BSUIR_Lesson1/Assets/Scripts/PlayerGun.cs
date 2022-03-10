using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : Gun
{
    Camera _camera;
    new void Start()
    {
        base.Start();
        _camera = GetComponentInChildren<Camera>();
    }

    protected override Ray MakeRay()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        return _camera.ScreenPointToRay(point);
    }
}

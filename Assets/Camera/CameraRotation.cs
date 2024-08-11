using UnityEngine;
using System.Collections;

public class FirstPersonCam : MonoBehaviour
{

    public float LimitAngleX = 180;
    public float LimitAngleY = 360;

    private float AngleX;
    private float AngleY;

    public float sensitivity = 5f;
    public void Update()
    {
        var angles = transform.localEulerAngles;

        var xAxis = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
        var yAxis = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;

        AngleX = Mathf.Clamp(AngleX - yAxis, -LimitAngleX, LimitAngleX);
        AngleY = Mathf.Clamp(AngleY + xAxis, -LimitAngleY, LimitAngleY);

        angles.x = AngleX;
        angles.y = AngleY;

        var euler = Quaternion.Euler(angles);

        transform.localRotation = euler;

        transform.localEulerAngles = angles;
    }
}
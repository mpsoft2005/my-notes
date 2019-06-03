using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTransform : MonoBehaviour
{
    public Transform target;
    public Matrix4x4 local2World;
    public Matrix4x4 myLocal2World;

    void Update()
    {
        local2World = target.localToWorldMatrix;
        myLocal2World = Local2World(target);
        if (local2World != myLocal2World)
        {
            Debug.LogError("Test fail");
        }
    }

    static Matrix4x4 Local2World(Transform target)
    {
        if (target == null) return Matrix4x4.identity;
        Matrix4x4 m = TransformationMatrix(target);
        return Local2World(target.parent) * m;
    }

    static Matrix4x4 TransformationMatrix(Transform target)
    {
        Matrix4x4 translationMatrix = TranslationMatrix(target.localPosition);
        Matrix4x4 rotationMatrix = RotationMatrix(target.localEulerAngles);
        Matrix4x4 scalingMatrix = ScalingMatrix(target.localScale);
        return translationMatrix * rotationMatrix * scalingMatrix;
    }

    static Matrix4x4 TranslationMatrix(Vector3 t)
    {
        Matrix4x4 translation = Matrix4x4.identity;
        translation.m03 = t.x;
        translation.m13 = t.y;
        translation.m23 = t.z;
        return translation;
    }

    static Matrix4x4 RotationMatrix(Vector3 r)
    {
        r = r * Mathf.Deg2Rad;
        Matrix4x4 rot = Ry(r.y) * Rx(r.x) * Rz(r.z);
        return rot;
    }

    static Matrix4x4 Rx(float theta)
    {
        Matrix4x4 rot = Matrix4x4.identity;
        rot.m11 = Mathf.Cos(theta);
        rot.m12 = -Mathf.Sin(theta);
        rot.m21 = Mathf.Sin(theta);
        rot.m22 = Mathf.Cos(theta);
        return rot;
    }

    static Matrix4x4 Ry(float theta)
    {
        Matrix4x4 rot = Matrix4x4.identity;
        rot.m00 = Mathf.Cos(theta);
        rot.m02 = Mathf.Sin(theta);
        rot.m20 = -Mathf.Sin(theta);
        rot.m22 = Mathf.Cos(theta);
        return rot;
    }

    static Matrix4x4 Rz(float theta)
    {
        Matrix4x4 rot = Matrix4x4.identity;
        rot.m00 = Mathf.Cos(theta);
        rot.m01 = -Mathf.Sin(theta);
        rot.m10 = Mathf.Sin(theta);
        rot.m11 = Mathf.Cos(theta);
        return rot;
    }

    static Matrix4x4 ScalingMatrix(Vector3 s)
    {
        Matrix4x4 scaling = Matrix4x4.identity;
        scaling.m00 = s.x;
        scaling.m11 = s.y;
        scaling.m22 = s.z;
        return scaling;
    }
}

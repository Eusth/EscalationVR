using System;
using UnityEngine;
using Valve.VR;

// Token: 0x0200000B RID: 11
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.MeshRenderer), typeof(global::UnityEngine.MeshFilter))]
public class SteamVR_Frustum : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06000075 RID: 117 RVA: 0x00005330 File Offset: 0x00003530
	public void UpdateModel()
	{
		this.fovLeft = global::UnityEngine.Mathf.Clamp(this.fovLeft, 1f, 89f);
		this.fovRight = global::UnityEngine.Mathf.Clamp(this.fovRight, 1f, 89f);
		this.fovTop = global::UnityEngine.Mathf.Clamp(this.fovTop, 1f, 89f);
		this.fovBottom = global::UnityEngine.Mathf.Clamp(this.fovBottom, 1f, 89f);
		this.farZ = global::UnityEngine.Mathf.Max(this.farZ, this.nearZ + 0.01f);
		this.nearZ = global::UnityEngine.Mathf.Clamp(this.nearZ, 0.01f, this.farZ - 0.01f);
		float num = global::UnityEngine.Mathf.Sin(-this.fovLeft * 0.0174532924f);
		float num2 = global::UnityEngine.Mathf.Sin(this.fovRight * 0.0174532924f);
		float num3 = global::UnityEngine.Mathf.Sin(this.fovTop * 0.0174532924f);
		float num4 = global::UnityEngine.Mathf.Sin(-this.fovBottom * 0.0174532924f);
		float num5 = global::UnityEngine.Mathf.Cos(-this.fovLeft * 0.0174532924f);
		float num6 = global::UnityEngine.Mathf.Cos(this.fovRight * 0.0174532924f);
		float num7 = global::UnityEngine.Mathf.Cos(this.fovTop * 0.0174532924f);
		float num8 = global::UnityEngine.Mathf.Cos(-this.fovBottom * 0.0174532924f);
		global::UnityEngine.Vector3[] array = new global::UnityEngine.Vector3[]
		{
			new global::UnityEngine.Vector3(num * this.nearZ / num5, num3 * this.nearZ / num7, this.nearZ),
			new global::UnityEngine.Vector3(num2 * this.nearZ / num6, num3 * this.nearZ / num7, this.nearZ),
			new global::UnityEngine.Vector3(num2 * this.nearZ / num6, num4 * this.nearZ / num8, this.nearZ),
			new global::UnityEngine.Vector3(num * this.nearZ / num5, num4 * this.nearZ / num8, this.nearZ),
			new global::UnityEngine.Vector3(num * this.farZ / num5, num3 * this.farZ / num7, this.farZ),
			new global::UnityEngine.Vector3(num2 * this.farZ / num6, num3 * this.farZ / num7, this.farZ),
			new global::UnityEngine.Vector3(num2 * this.farZ / num6, num4 * this.farZ / num8, this.farZ),
			new global::UnityEngine.Vector3(num * this.farZ / num5, num4 * this.farZ / num8, this.farZ)
		};
		int[] array2 = new int[]
		{
			0,
			4,
			7,
			0,
			7,
			3,
			0,
			7,
			4,
			0,
			3,
			7,
			1,
			5,
			6,
			1,
			6,
			2,
			1,
			6,
			5,
			1,
			2,
			6,
			0,
			4,
			5,
			0,
			5,
			1,
			0,
			5,
			4,
			0,
			1,
			5,
			2,
			3,
			7,
			2,
			7,
			6,
			2,
			7,
			3,
			2,
			6,
			7
		};
		int num9 = 0;
		global::UnityEngine.Vector3[] array3 = new global::UnityEngine.Vector3[array2.Length];
		global::UnityEngine.Vector3[] array4 = new global::UnityEngine.Vector3[array2.Length];
		for (int i = 0; i < array2.Length / 3; i++)
		{
			global::UnityEngine.Vector3 vector = array[array2[i * 3]];
			global::UnityEngine.Vector3 vector2 = array[array2[i * 3 + 1]];
			global::UnityEngine.Vector3 vector3 = array[array2[i * 3 + 2]];
			global::UnityEngine.Vector3 normalized = global::UnityEngine.Vector3.Cross(vector2 - vector, vector3 - vector).normalized;
			array4[i * 3] = normalized;
			array4[i * 3 + 1] = normalized;
			array4[i * 3 + 2] = normalized;
			array3[i * 3] = vector;
			array3[i * 3 + 1] = vector2;
			array3[i * 3 + 2] = vector3;
			array2[i * 3] = num9++;
			array2[i * 3 + 1] = num9++;
			array2[i * 3 + 2] = num9++;
		}
		global::UnityEngine.Mesh mesh = new global::UnityEngine.Mesh();
		mesh.vertices = array3;
		mesh.normals = array4;
		mesh.triangles = array2;
		base.GetComponent<global::UnityEngine.MeshFilter>().mesh = mesh;
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00005728 File Offset: 0x00003928
	private void OnDeviceConnected(params object[] args)
	{
		int num = (int)args[0];
		bool flag = num != (int)this.index;
		if (!flag)
		{
			base.GetComponent<global::UnityEngine.MeshFilter>().mesh = null;
			bool flag2 = (bool)args[1];
			bool flag3 = flag2;
			if (flag3)
			{
				global::Valve.VR.CVRSystem system = global::Valve.VR.OpenVR.System;
				bool flag4 = system != null && system.GetTrackedDeviceClass((uint)num) == global::Valve.VR.ETrackedDeviceClass.TrackingReference;
				if (flag4)
				{
					global::Valve.VR.ETrackedPropertyError etrackedPropertyError = global::Valve.VR.ETrackedPropertyError.TrackedProp_Success;
					float floatTrackedDeviceProperty = system.GetFloatTrackedDeviceProperty((uint)num, global::Valve.VR.ETrackedDeviceProperty.Prop_FieldOfViewLeftDegrees_Float, ref etrackedPropertyError);
					bool flag5 = etrackedPropertyError == global::Valve.VR.ETrackedPropertyError.TrackedProp_Success;
					if (flag5)
					{
						this.fovLeft = floatTrackedDeviceProperty;
					}
					floatTrackedDeviceProperty = system.GetFloatTrackedDeviceProperty((uint)num, global::Valve.VR.ETrackedDeviceProperty.Prop_FieldOfViewRightDegrees_Float, ref etrackedPropertyError);
					bool flag6 = etrackedPropertyError == global::Valve.VR.ETrackedPropertyError.TrackedProp_Success;
					if (flag6)
					{
						this.fovRight = floatTrackedDeviceProperty;
					}
					floatTrackedDeviceProperty = system.GetFloatTrackedDeviceProperty((uint)num, global::Valve.VR.ETrackedDeviceProperty.Prop_FieldOfViewTopDegrees_Float, ref etrackedPropertyError);
					bool flag7 = etrackedPropertyError == global::Valve.VR.ETrackedPropertyError.TrackedProp_Success;
					if (flag7)
					{
						this.fovTop = floatTrackedDeviceProperty;
					}
					floatTrackedDeviceProperty = system.GetFloatTrackedDeviceProperty((uint)num, global::Valve.VR.ETrackedDeviceProperty.Prop_FieldOfViewBottomDegrees_Float, ref etrackedPropertyError);
					bool flag8 = etrackedPropertyError == global::Valve.VR.ETrackedPropertyError.TrackedProp_Success;
					if (flag8)
					{
						this.fovBottom = floatTrackedDeviceProperty;
					}
					floatTrackedDeviceProperty = system.GetFloatTrackedDeviceProperty((uint)num, global::Valve.VR.ETrackedDeviceProperty.Prop_TrackingRangeMinimumMeters_Float, ref etrackedPropertyError);
					bool flag9 = etrackedPropertyError == global::Valve.VR.ETrackedPropertyError.TrackedProp_Success;
					if (flag9)
					{
						this.nearZ = floatTrackedDeviceProperty;
					}
					floatTrackedDeviceProperty = system.GetFloatTrackedDeviceProperty((uint)num, global::Valve.VR.ETrackedDeviceProperty.Prop_TrackingRangeMaximumMeters_Float, ref etrackedPropertyError);
					bool flag10 = etrackedPropertyError == global::Valve.VR.ETrackedPropertyError.TrackedProp_Success;
					if (flag10)
					{
						this.farZ = floatTrackedDeviceProperty;
					}
					this.UpdateModel();
				}
			}
		}
	}

	// Token: 0x06000077 RID: 119 RVA: 0x0000587A File Offset: 0x00003A7A
	private void OnEnable()
	{
		base.GetComponent<global::UnityEngine.MeshFilter>().mesh = null;
		global::SteamVR_Utils.Event.Listen("device_connected", new global::SteamVR_Utils.Event.Handler(this.OnDeviceConnected));
	}

	// Token: 0x06000078 RID: 120 RVA: 0x000058A1 File Offset: 0x00003AA1
	private void OnDisable()
	{
		global::SteamVR_Utils.Event.Remove("device_connected", new global::SteamVR_Utils.Event.Handler(this.OnDeviceConnected));
		base.GetComponent<global::UnityEngine.MeshFilter>().mesh = null;
	}

	// Token: 0x0400003E RID: 62
	public global::SteamVR_TrackedObject.EIndex index;

	// Token: 0x0400003F RID: 63
	public float fovLeft = 45f;

	// Token: 0x04000040 RID: 64
	public float fovRight = 45f;

	// Token: 0x04000041 RID: 65
	public float fovTop = 45f;

	// Token: 0x04000042 RID: 66
	public float fovBottom = 45f;

	// Token: 0x04000043 RID: 67
	public float nearZ = 0.5f;

	// Token: 0x04000044 RID: 68
	public float farZ = 2.5f;
}

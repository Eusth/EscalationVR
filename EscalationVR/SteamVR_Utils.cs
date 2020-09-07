using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using Valve.VR;

// Token: 0x0200001A RID: 26
public static class SteamVR_Utils
{
	// Token: 0x060000F3 RID: 243 RVA: 0x0000A718 File Offset: 0x00008918
	public static global::UnityEngine.Quaternion Slerp(global::UnityEngine.Quaternion A, global::UnityEngine.Quaternion B, float t)
	{
		float num = global::UnityEngine.Mathf.Clamp(A.x * B.x + A.y * B.y + A.z * B.z + A.w * B.w, -1f, 1f);
		bool flag = num < 0f;
		if (flag)
		{
			B..ctor(-B.x, -B.y, -B.z, -B.w);
			num = -num;
		}
		bool flag2 = 1f - num > 0.0001f;
		float num4;
		float num5;
		if (flag2)
		{
			float num2 = global::UnityEngine.Mathf.Acos(num);
			float num3 = global::UnityEngine.Mathf.Sin(num2);
			num4 = global::UnityEngine.Mathf.Sin((1f - t) * num2) / num3;
			num5 = global::UnityEngine.Mathf.Sin(t * num2) / num3;
		}
		else
		{
			num4 = 1f - t;
			num5 = t;
		}
		return new global::UnityEngine.Quaternion(num4 * A.x + num5 * B.x, num4 * A.y + num5 * B.y, num4 * A.z + num5 * B.z, num4 * A.w + num5 * B.w);
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x0000A848 File Offset: 0x00008A48
	public static global::UnityEngine.Vector3 Lerp(global::UnityEngine.Vector3 A, global::UnityEngine.Vector3 B, float t)
	{
		return new global::UnityEngine.Vector3(global::SteamVR_Utils.Lerp(A.x, B.x, t), global::SteamVR_Utils.Lerp(A.y, B.y, t), global::SteamVR_Utils.Lerp(A.z, B.z, t));
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x0000A898 File Offset: 0x00008A98
	public static float Lerp(float A, float B, float t)
	{
		return A + (B - A) * t;
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x0000A8B4 File Offset: 0x00008AB4
	public static double Lerp(double A, double B, double t)
	{
		return A + (B - A) * t;
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x0000A8D0 File Offset: 0x00008AD0
	public static float InverseLerp(global::UnityEngine.Vector3 A, global::UnityEngine.Vector3 B, global::UnityEngine.Vector3 result)
	{
		return global::UnityEngine.Vector3.Dot(result - A, B - A);
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x0000A8F8 File Offset: 0x00008AF8
	public static float InverseLerp(float A, float B, float result)
	{
		return (result - A) / (B - A);
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x0000A914 File Offset: 0x00008B14
	public static double InverseLerp(double A, double B, double result)
	{
		return (result - A) / (B - A);
	}

	// Token: 0x060000FA RID: 250 RVA: 0x0000A930 File Offset: 0x00008B30
	public static float Saturate(float A)
	{
		return (A < 0f) ? 0f : ((A > 1f) ? 1f : A);
	}

	// Token: 0x060000FB RID: 251 RVA: 0x0000A964 File Offset: 0x00008B64
	public static global::UnityEngine.Vector2 Saturate(global::UnityEngine.Vector2 A)
	{
		return new global::UnityEngine.Vector2(global::SteamVR_Utils.Saturate(A.x), global::SteamVR_Utils.Saturate(A.y));
	}

	// Token: 0x060000FC RID: 252 RVA: 0x0000A994 File Offset: 0x00008B94
	public static float Abs(float A)
	{
		return (A < 0f) ? (-A) : A;
	}

	// Token: 0x060000FD RID: 253 RVA: 0x0000A9B4 File Offset: 0x00008BB4
	public static global::UnityEngine.Vector2 Abs(global::UnityEngine.Vector2 A)
	{
		return new global::UnityEngine.Vector2(global::SteamVR_Utils.Abs(A.x), global::SteamVR_Utils.Abs(A.y));
	}

	// Token: 0x060000FE RID: 254 RVA: 0x0000A9E4 File Offset: 0x00008BE4
	private static float _copysign(float sizeval, float signval)
	{
		return (global::UnityEngine.Mathf.Sign(signval) == 1f) ? global::UnityEngine.Mathf.Abs(sizeval) : (-global::UnityEngine.Mathf.Abs(sizeval));
	}

	// Token: 0x060000FF RID: 255 RVA: 0x0000AA14 File Offset: 0x00008C14
	public static global::UnityEngine.Quaternion GetRotation(this global::UnityEngine.Matrix4x4 matrix)
	{
		global::UnityEngine.Quaternion quaternion = default(global::UnityEngine.Quaternion);
		quaternion.w = global::UnityEngine.Mathf.Sqrt(global::UnityEngine.Mathf.Max(0f, 1f + matrix.m00 + matrix.m11 + matrix.m22)) / 2f;
		quaternion.x = global::UnityEngine.Mathf.Sqrt(global::UnityEngine.Mathf.Max(0f, 1f + matrix.m00 - matrix.m11 - matrix.m22)) / 2f;
		quaternion.y = global::UnityEngine.Mathf.Sqrt(global::UnityEngine.Mathf.Max(0f, 1f - matrix.m00 + matrix.m11 - matrix.m22)) / 2f;
		quaternion.z = global::UnityEngine.Mathf.Sqrt(global::UnityEngine.Mathf.Max(0f, 1f - matrix.m00 - matrix.m11 + matrix.m22)) / 2f;
		quaternion.x = global::SteamVR_Utils._copysign(quaternion.x, matrix.m21 - matrix.m12);
		quaternion.y = global::SteamVR_Utils._copysign(quaternion.y, matrix.m02 - matrix.m20);
		quaternion.z = global::SteamVR_Utils._copysign(quaternion.z, matrix.m10 - matrix.m01);
		return quaternion;
	}

	// Token: 0x06000100 RID: 256 RVA: 0x0000AB64 File Offset: 0x00008D64
	public static global::UnityEngine.Vector3 GetPosition(this global::UnityEngine.Matrix4x4 matrix)
	{
		float m = matrix.m03;
		float m2 = matrix.m13;
		float m3 = matrix.m23;
		return new global::UnityEngine.Vector3(m, m2, m3);
	}

	// Token: 0x06000101 RID: 257 RVA: 0x0000AB94 File Offset: 0x00008D94
	public static global::UnityEngine.Vector3 GetScale(this global::UnityEngine.Matrix4x4 m)
	{
		float num = global::UnityEngine.Mathf.Sqrt(m.m00 * m.m00 + m.m01 * m.m01 + m.m02 * m.m02);
		float num2 = global::UnityEngine.Mathf.Sqrt(m.m10 * m.m10 + m.m11 * m.m11 + m.m12 * m.m12);
		float num3 = global::UnityEngine.Mathf.Sqrt(m.m20 * m.m20 + m.m21 * m.m21 + m.m22 * m.m22);
		return new global::UnityEngine.Vector3(num, num2, num3);
	}

	// Token: 0x06000102 RID: 258 RVA: 0x0000AC3C File Offset: 0x00008E3C
	public static global::UnityEngine.Mesh CreateHiddenAreaMesh(global::Valve.VR.HiddenAreaMesh_t src, global::Valve.VR.VRTextureBounds_t bounds)
	{
		bool flag = src.unTriangleCount == 0U;
		global::UnityEngine.Mesh result;
		if (flag)
		{
			result = null;
		}
		else
		{
			float[] array = new float[src.unTriangleCount * 3U * 2U];
			global::System.Runtime.InteropServices.Marshal.Copy(src.pVertexData, array, 0, array.Length);
			global::UnityEngine.Vector3[] array2 = new global::UnityEngine.Vector3[src.unTriangleCount * 3U + 12U];
			int[] array3 = new int[src.unTriangleCount * 3U + 24U];
			float num = 2f * bounds.uMin - 1f;
			float num2 = 2f * bounds.uMax - 1f;
			float num3 = 2f * bounds.vMin - 1f;
			float num4 = 2f * bounds.vMax - 1f;
			int num5 = 0;
			int num6 = 0;
			while ((long)num5 < (long)((ulong)(src.unTriangleCount * 3U)))
			{
				float num7 = global::SteamVR_Utils.Lerp(num, num2, array[num6++]);
				float num8 = global::SteamVR_Utils.Lerp(num3, num4, array[num6++]);
				array2[num5] = new global::UnityEngine.Vector3(num7, num8, 0f);
				array3[num5] = num5;
				num5++;
			}
			int num9 = (int)(src.unTriangleCount * 3U);
			int num10 = num9;
			array2[num10++] = new global::UnityEngine.Vector3(-1f, -1f, 0f);
			array2[num10++] = new global::UnityEngine.Vector3(num, -1f, 0f);
			array2[num10++] = new global::UnityEngine.Vector3(-1f, 1f, 0f);
			array2[num10++] = new global::UnityEngine.Vector3(num, 1f, 0f);
			array2[num10++] = new global::UnityEngine.Vector3(num2, -1f, 0f);
			array2[num10++] = new global::UnityEngine.Vector3(1f, -1f, 0f);
			array2[num10++] = new global::UnityEngine.Vector3(num2, 1f, 0f);
			array2[num10++] = new global::UnityEngine.Vector3(1f, 1f, 0f);
			array2[num10++] = new global::UnityEngine.Vector3(num, num3, 0f);
			array2[num10++] = new global::UnityEngine.Vector3(num2, num3, 0f);
			array2[num10++] = new global::UnityEngine.Vector3(num, num4, 0f);
			array2[num10++] = new global::UnityEngine.Vector3(num2, num4, 0f);
			int num11 = num9;
			array3[num11++] = num9;
			array3[num11++] = num9 + 1;
			array3[num11++] = num9 + 2;
			array3[num11++] = num9 + 2;
			array3[num11++] = num9 + 1;
			array3[num11++] = num9 + 3;
			array3[num11++] = num9 + 4;
			array3[num11++] = num9 + 5;
			array3[num11++] = num9 + 6;
			array3[num11++] = num9 + 6;
			array3[num11++] = num9 + 5;
			array3[num11++] = num9 + 7;
			array3[num11++] = num9 + 1;
			array3[num11++] = num9 + 4;
			array3[num11++] = num9 + 8;
			array3[num11++] = num9 + 8;
			array3[num11++] = num9 + 4;
			array3[num11++] = num9 + 9;
			array3[num11++] = num9 + 10;
			array3[num11++] = num9 + 11;
			array3[num11++] = num9 + 3;
			array3[num11++] = num9 + 3;
			array3[num11++] = num9 + 11;
			array3[num11++] = num9 + 6;
			result = new global::UnityEngine.Mesh
			{
				vertices = array2,
				triangles = array3,
				bounds = new global::UnityEngine.Bounds(global::UnityEngine.Vector3.zero, new global::UnityEngine.Vector3(float.MaxValue, float.MaxValue, float.MaxValue))
			};
		}
		return result;
	}

	// Token: 0x06000103 RID: 259 RVA: 0x0000B054 File Offset: 0x00009254
	public static object CallSystemFn(global::SteamVR_Utils.SystemFn fn, params object[] args)
	{
		bool flag = !global::SteamVR.active && !global::SteamVR.usingNativeSupport;
		bool flag2 = flag;
		if (flag2)
		{
			global::Valve.VR.EVRInitError evrinitError = global::Valve.VR.EVRInitError.None;
			global::Valve.VR.OpenVR.Init(ref evrinitError, global::Valve.VR.EVRApplicationType.VRApplication_Other);
		}
		global::Valve.VR.CVRSystem system = global::Valve.VR.OpenVR.System;
		object result = (system != null) ? fn(system, args) : null;
		bool flag3 = flag;
		if (flag3)
		{
			global::Valve.VR.OpenVR.Shutdown();
		}
		return result;
	}

	// Token: 0x06000104 RID: 260 RVA: 0x0000B0B1 File Offset: 0x000092B1
	public static void QueueEventOnRenderThread(int eventID)
	{
		global::UnityEngine.GL.IssuePluginEvent(global::SteamVR.Unity.GetRenderEventFunc(), eventID);
	}

	// Token: 0x02000106 RID: 262
	public class Event
	{
		// Token: 0x06000687 RID: 1671 RVA: 0x0001FE1C File Offset: 0x0001E01C
		public static void Listen(string message, global::SteamVR_Utils.Event.Handler action)
		{
			global::SteamVR_Utils.Event.Handler handler = global::SteamVR_Utils.Event.listeners[message] as global::SteamVR_Utils.Event.Handler;
			bool flag = handler != null;
			if (flag)
			{
				global::SteamVR_Utils.Event.listeners[message] = (global::SteamVR_Utils.Event.Handler)global::System.Delegate.Combine(handler, action);
			}
			else
			{
				global::SteamVR_Utils.Event.listeners[message] = action;
			}
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x0001FE70 File Offset: 0x0001E070
		public static void Remove(string message, global::SteamVR_Utils.Event.Handler action)
		{
			global::SteamVR_Utils.Event.Handler handler = global::SteamVR_Utils.Event.listeners[message] as global::SteamVR_Utils.Event.Handler;
			bool flag = handler != null;
			if (flag)
			{
				global::SteamVR_Utils.Event.listeners[message] = (global::SteamVR_Utils.Event.Handler)global::System.Delegate.Remove(handler, action);
			}
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0001FEB4 File Offset: 0x0001E0B4
		public static void Send(string message, params object[] args)
		{
			global::SteamVR_Utils.Event.Handler handler = global::SteamVR_Utils.Event.listeners[message] as global::SteamVR_Utils.Event.Handler;
			bool flag = handler != null;
			if (flag)
			{
				handler(args);
			}
		}

		// Token: 0x04000736 RID: 1846
		private static global::System.Collections.Hashtable listeners = new global::System.Collections.Hashtable();

		// Token: 0x02000240 RID: 576
		// (Invoke) Token: 0x06000BB7 RID: 2999
		public delegate void Handler(params object[] args);
	}

	// Token: 0x02000107 RID: 263
	[global::System.Serializable]
	public struct RigidTransform
	{
		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600068C RID: 1676 RVA: 0x0001FEFC File Offset: 0x0001E0FC
		public static global::SteamVR_Utils.RigidTransform identity
		{
			get
			{
				return new global::SteamVR_Utils.RigidTransform(global::UnityEngine.Vector3.zero, global::UnityEngine.Quaternion.identity);
			}
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x0001FF20 File Offset: 0x0001E120
		public static global::SteamVR_Utils.RigidTransform FromLocal(global::UnityEngine.Transform t)
		{
			return new global::SteamVR_Utils.RigidTransform(t.localPosition, t.localRotation);
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0001FF43 File Offset: 0x0001E143
		public RigidTransform(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot)
		{
			this.pos = pos;
			this.rot = rot;
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0001FF54 File Offset: 0x0001E154
		public RigidTransform(global::UnityEngine.Transform t)
		{
			this.pos = t.position;
			this.rot = t.rotation;
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0001FF70 File Offset: 0x0001E170
		public RigidTransform(global::UnityEngine.Transform from, global::UnityEngine.Transform to)
		{
			global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Inverse(from.rotation);
			this.rot = quaternion * to.rotation;
			this.pos = quaternion * (to.position - from.position);
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0001FFBC File Offset: 0x0001E1BC
		public RigidTransform(global::Valve.VR.HmdMatrix34_t pose)
		{
			global::UnityEngine.Matrix4x4 identity = global::UnityEngine.Matrix4x4.identity;
			identity[0, 0] = pose.m0;
			identity[0, 1] = pose.m1;
			identity[0, 2] = -pose.m2;
			identity[0, 3] = pose.m3;
			identity[1, 0] = pose.m4;
			identity[1, 1] = pose.m5;
			identity[1, 2] = -pose.m6;
			identity[1, 3] = pose.m7;
			identity[2, 0] = -pose.m8;
			identity[2, 1] = -pose.m9;
			identity[2, 2] = pose.m10;
			identity[2, 3] = -pose.m11;
			this.pos = identity.GetPosition();
			this.rot = identity.GetRotation();
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x000200B0 File Offset: 0x0001E2B0
		public RigidTransform(global::Valve.VR.HmdMatrix44_t pose)
		{
			global::UnityEngine.Matrix4x4 identity = global::UnityEngine.Matrix4x4.identity;
			identity[0, 0] = pose.m0;
			identity[0, 1] = pose.m1;
			identity[0, 2] = -pose.m2;
			identity[0, 3] = pose.m3;
			identity[1, 0] = pose.m4;
			identity[1, 1] = pose.m5;
			identity[1, 2] = -pose.m6;
			identity[1, 3] = pose.m7;
			identity[2, 0] = -pose.m8;
			identity[2, 1] = -pose.m9;
			identity[2, 2] = pose.m10;
			identity[2, 3] = -pose.m11;
			identity[3, 0] = pose.m12;
			identity[3, 1] = pose.m13;
			identity[3, 2] = -pose.m14;
			identity[3, 3] = pose.m15;
			this.pos = identity.GetPosition();
			this.rot = identity.GetRotation();
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x000201E4 File Offset: 0x0001E3E4
		public global::Valve.VR.HmdMatrix44_t ToHmdMatrix44()
		{
			global::UnityEngine.Matrix4x4 matrix4x = global::UnityEngine.Matrix4x4.TRS(this.pos, this.rot, global::UnityEngine.Vector3.one);
			return new global::Valve.VR.HmdMatrix44_t
			{
				m0 = matrix4x[0, 0],
				m1 = matrix4x[0, 1],
				m2 = -matrix4x[0, 2],
				m3 = matrix4x[0, 3],
				m4 = matrix4x[1, 0],
				m5 = matrix4x[1, 1],
				m6 = -matrix4x[1, 2],
				m7 = matrix4x[1, 3],
				m8 = -matrix4x[2, 0],
				m9 = -matrix4x[2, 1],
				m10 = matrix4x[2, 2],
				m11 = -matrix4x[2, 3],
				m12 = matrix4x[3, 0],
				m13 = matrix4x[3, 1],
				m14 = -matrix4x[3, 2],
				m15 = matrix4x[3, 3]
			};
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0002031C File Offset: 0x0001E51C
		public global::Valve.VR.HmdMatrix34_t ToHmdMatrix34()
		{
			global::UnityEngine.Matrix4x4 matrix4x = global::UnityEngine.Matrix4x4.TRS(this.pos, this.rot, global::UnityEngine.Vector3.one);
			return new global::Valve.VR.HmdMatrix34_t
			{
				m0 = matrix4x[0, 0],
				m1 = matrix4x[0, 1],
				m2 = -matrix4x[0, 2],
				m3 = matrix4x[0, 3],
				m4 = matrix4x[1, 0],
				m5 = matrix4x[1, 1],
				m6 = -matrix4x[1, 2],
				m7 = matrix4x[1, 3],
				m8 = -matrix4x[2, 0],
				m9 = -matrix4x[2, 1],
				m10 = matrix4x[2, 2],
				m11 = -matrix4x[2, 3]
			};
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x00020414 File Offset: 0x0001E614
		public override bool Equals(object o)
		{
			bool flag = o is global::SteamVR_Utils.RigidTransform;
			bool result;
			if (flag)
			{
				global::SteamVR_Utils.RigidTransform rigidTransform = (global::SteamVR_Utils.RigidTransform)o;
				result = (this.pos == rigidTransform.pos && this.rot == rigidTransform.rot);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x00020468 File Offset: 0x0001E668
		public override int GetHashCode()
		{
			return this.pos.GetHashCode() ^ this.rot.GetHashCode();
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x000204A0 File Offset: 0x0001E6A0
		public static bool operator ==(global::SteamVR_Utils.RigidTransform a, global::SteamVR_Utils.RigidTransform b)
		{
			return a.pos == b.pos && a.rot == b.rot;
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x000204DC File Offset: 0x0001E6DC
		public static bool operator !=(global::SteamVR_Utils.RigidTransform a, global::SteamVR_Utils.RigidTransform b)
		{
			return a.pos != b.pos || a.rot != b.rot;
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x00020518 File Offset: 0x0001E718
		public static global::SteamVR_Utils.RigidTransform operator *(global::SteamVR_Utils.RigidTransform a, global::SteamVR_Utils.RigidTransform b)
		{
			return new global::SteamVR_Utils.RigidTransform
			{
				rot = a.rot * b.rot,
				pos = a.pos + a.rot * b.pos
			};
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x0002056E File Offset: 0x0001E76E
		public void Inverse()
		{
			this.rot = global::UnityEngine.Quaternion.Inverse(this.rot);
			this.pos = -(this.rot * this.pos);
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x000205A0 File Offset: 0x0001E7A0
		public global::SteamVR_Utils.RigidTransform GetInverse()
		{
			global::SteamVR_Utils.RigidTransform result = new global::SteamVR_Utils.RigidTransform(this.pos, this.rot);
			result.Inverse();
			return result;
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x000205CE File Offset: 0x0001E7CE
		public void Multiply(global::SteamVR_Utils.RigidTransform a, global::SteamVR_Utils.RigidTransform b)
		{
			this.rot = a.rot * b.rot;
			this.pos = a.pos + a.rot * b.pos;
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x0002060C File Offset: 0x0001E80C
		public global::UnityEngine.Vector3 InverseTransformPoint(global::UnityEngine.Vector3 point)
		{
			return global::UnityEngine.Quaternion.Inverse(this.rot) * (point - this.pos);
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x0002063C File Offset: 0x0001E83C
		public global::UnityEngine.Vector3 TransformPoint(global::UnityEngine.Vector3 point)
		{
			return this.pos + this.rot * point;
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x00020668 File Offset: 0x0001E868
		public static global::UnityEngine.Vector3 operator *(global::SteamVR_Utils.RigidTransform t, global::UnityEngine.Vector3 v)
		{
			return t.TransformPoint(v);
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x00020684 File Offset: 0x0001E884
		public static global::SteamVR_Utils.RigidTransform Interpolate(global::SteamVR_Utils.RigidTransform a, global::SteamVR_Utils.RigidTransform b, float t)
		{
			return new global::SteamVR_Utils.RigidTransform(global::UnityEngine.Vector3.Lerp(a.pos, b.pos, t), global::UnityEngine.Quaternion.Slerp(a.rot, b.rot, t));
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x000206BF File Offset: 0x0001E8BF
		public void Interpolate(global::SteamVR_Utils.RigidTransform to, float t)
		{
			this.pos = global::SteamVR_Utils.Lerp(this.pos, to.pos, t);
			this.rot = global::SteamVR_Utils.Slerp(this.rot, to.rot, t);
		}

		// Token: 0x04000737 RID: 1847
		public global::UnityEngine.Vector3 pos;

		// Token: 0x04000738 RID: 1848
		public global::UnityEngine.Quaternion rot;
	}

	// Token: 0x02000108 RID: 264
	// (Invoke) Token: 0x060006A3 RID: 1699
	public delegate object SystemFn(global::Valve.VR.CVRSystem system, params object[] args);
}

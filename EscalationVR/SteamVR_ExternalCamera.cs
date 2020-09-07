using System;
using System.IO;
using System.Reflection;
using EscalationVR;
using UnityEngine;
using Valve.VR;

// Token: 0x02000009 RID: 9
public class SteamVR_ExternalCamera : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06000064 RID: 100 RVA: 0x00004460 File Offset: 0x00002660
	public void ReadConfig()
	{
		try
		{
			global::Valve.VR.HmdMatrix34_t pose = default(global::Valve.VR.HmdMatrix34_t);
			bool flag = false;
			object obj = this.config;
			string[] array = global::System.IO.File.ReadAllLines(this.configPath);
			foreach (string text in array)
			{
				string[] array3 = text.Split('=', 0);
				bool flag2 = array3.Length == 2;
				if (flag2)
				{
					string text2 = array3[0];
					bool flag3 = text2 == "m";
					if (flag3)
					{
						string[] array4 = array3[1].Split(',', 0);
						bool flag4 = array4.Length == 12;
						if (flag4)
						{
							pose.m0 = float.Parse(array4[0]);
							pose.m1 = float.Parse(array4[1]);
							pose.m2 = float.Parse(array4[2]);
							pose.m3 = float.Parse(array4[3]);
							pose.m4 = float.Parse(array4[4]);
							pose.m5 = float.Parse(array4[5]);
							pose.m6 = float.Parse(array4[6]);
							pose.m7 = float.Parse(array4[7]);
							pose.m8 = float.Parse(array4[8]);
							pose.m9 = float.Parse(array4[9]);
							pose.m10 = float.Parse(array4[10]);
							pose.m11 = float.Parse(array4[11]);
							flag = true;
						}
					}
					else
					{
						bool flag5 = text2 == "disableStandardAssets";
						if (flag5)
						{
							global::System.Reflection.FieldInfo field = obj.GetType().GetField(text2);
							bool flag6 = field != null;
							if (flag6)
							{
								field.SetValue(obj, bool.Parse(array3[1]));
							}
						}
						else
						{
							global::System.Reflection.FieldInfo field2 = obj.GetType().GetField(text2);
							bool flag7 = field2 != null;
							if (flag7)
							{
								field2.SetValue(obj, float.Parse(array3[1]));
							}
						}
					}
				}
			}
			this.config = (global::SteamVR_ExternalCamera.Config)obj;
			bool flag8 = flag;
			if (flag8)
			{
				global::SteamVR_Utils.RigidTransform rigidTransform = new global::SteamVR_Utils.RigidTransform(pose);
				this.config.x = rigidTransform.pos.x;
				this.config.y = rigidTransform.pos.y;
				this.config.z = rigidTransform.pos.z;
				global::UnityEngine.Vector3 eulerAngles = rigidTransform.rot.eulerAngles;
				this.config.rx = eulerAngles.x;
				this.config.ry = eulerAngles.y;
				this.config.rz = eulerAngles.z;
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000065 RID: 101 RVA: 0x0000472C File Offset: 0x0000292C
	public void AttachToCamera(global::SteamVR_Camera vrcam)
	{
		bool flag = this.target == vrcam.head;
		if (!flag)
		{
			this.target = vrcam.head;
			global::UnityEngine.Transform parent = base.transform.parent;
			global::UnityEngine.Transform parent2 = vrcam.head.parent;
			parent.parent = parent2;
			parent.localPosition = global::UnityEngine.Vector3.zero;
			parent.localRotation = global::UnityEngine.Quaternion.identity;
			parent.localScale = global::UnityEngine.Vector3.one;
			vrcam.enabled = false;
			global::UnityEngine.GameObject gameObject = global::UnityEngine.Object.Instantiate<global::UnityEngine.GameObject>(vrcam.gameObject);
			vrcam.enabled = true;
			gameObject.name = "camera";
			global::UnityEngine.Object.DestroyImmediate(gameObject.GetComponent<global::SteamVR_Camera>());
			global::UnityEngine.Object.DestroyImmediate(gameObject.GetComponent<global::SteamVR_CameraFlip>());
			this.cam = gameObject.GetComponent<global::UnityEngine.Camera>();
			this.cam.fieldOfView = this.config.fov;
			this.cam.useOcclusionCulling = false;
			this.cam.enabled = false;
			this.colorMat = new global::UnityEngine.Material(global::EscalationVR.UnityHelper.GetShader("Custom/SteamVR_ColorOut"));
			this.alphaMat = new global::UnityEngine.Material(global::EscalationVR.UnityHelper.GetShader("Custom/SteamVR_AlphaOut"));
			this.clipMaterial = new global::UnityEngine.Material(global::EscalationVR.UnityHelper.GetShader("Custom/SteamVR_ClearAll"));
			global::UnityEngine.Transform transform = gameObject.transform;
			transform.parent = base.transform;
			transform.localPosition = new global::UnityEngine.Vector3(this.config.x, this.config.y, this.config.z);
			transform.localRotation = global::UnityEngine.Quaternion.Euler(this.config.rx, this.config.ry, this.config.rz);
			transform.localScale = global::UnityEngine.Vector3.one;
			while (transform.childCount > 0)
			{
				global::UnityEngine.Object.DestroyImmediate(transform.GetChild(0).gameObject);
			}
			this.clipQuad = global::UnityEngine.GameObject.CreatePrimitive(5);
			this.clipQuad.name = "ClipQuad";
			global::UnityEngine.Object.DestroyImmediate(this.clipQuad.GetComponent<global::UnityEngine.MeshCollider>());
			global::UnityEngine.MeshRenderer component = this.clipQuad.GetComponent<global::UnityEngine.MeshRenderer>();
			component.material = this.clipMaterial;
			component.shadowCastingMode = 0;
			component.receiveShadows = false;
			component.useLightProbes = false;
			component.reflectionProbeUsage = 0;
			global::UnityEngine.Transform transform2 = this.clipQuad.transform;
			transform2.parent = transform;
			transform2.localScale = new global::UnityEngine.Vector3(1000f, 1000f, 1f);
			transform2.localRotation = global::UnityEngine.Quaternion.identity;
			this.clipQuad.SetActive(false);
		}
	}

	// Token: 0x06000066 RID: 102 RVA: 0x000049B8 File Offset: 0x00002BB8
	public float GetTargetDistance()
	{
		bool flag = this.target == null;
		float result;
		if (flag)
		{
			result = this.config.near + 0.01f;
		}
		else
		{
			global::UnityEngine.Transform transform = this.cam.transform;
			global::UnityEngine.Vector3 normalized = new global::UnityEngine.Vector3(transform.forward.x, 0f, transform.forward.z).normalized;
			global::UnityEngine.Vector3 vector = this.target.position + new global::UnityEngine.Vector3(this.target.forward.x, 0f, this.target.forward.z).normalized * this.config.hmdOffset;
			float num = -new global::UnityEngine.Plane(normalized, vector).GetDistanceToPoint(transform.position);
			result = global::UnityEngine.Mathf.Clamp(num, this.config.near + 0.01f, this.config.far - 0.01f);
		}
		return result;
	}

	// Token: 0x06000067 RID: 103 RVA: 0x00004AC0 File Offset: 0x00002CC0
	public void RenderNear()
	{
		int num = global::UnityEngine.Screen.width / 2;
		int num2 = global::UnityEngine.Screen.height / 2;
		bool flag = this.cam.targetTexture == null || this.cam.targetTexture.width != num || this.cam.targetTexture.height != num2;
		if (flag)
		{
			this.cam.targetTexture = new global::UnityEngine.RenderTexture(num, num2, 24, 0);
			this.cam.targetTexture.antiAliasing = ((global::UnityEngine.QualitySettings.antiAliasing == 0) ? 1 : global::UnityEngine.QualitySettings.antiAliasing);
		}
		this.cam.nearClipPlane = this.config.near;
		this.cam.farClipPlane = this.config.far;
		global::UnityEngine.CameraClearFlags clearFlags = this.cam.clearFlags;
		global::UnityEngine.Color backgroundColor = this.cam.backgroundColor;
		this.cam.clearFlags = 2;
		this.cam.backgroundColor = global::UnityEngine.Color.clear;
		float num3 = global::UnityEngine.Mathf.Clamp(this.GetTargetDistance() + this.config.nearOffset, this.config.near, this.config.far);
		global::UnityEngine.Transform parent = this.clipQuad.transform.parent;
		this.clipQuad.transform.position = parent.position + parent.forward * num3;
		global::UnityEngine.MonoBehaviour[] array = null;
		bool[] array2 = null;
		bool disableStandardAssets = this.config.disableStandardAssets;
		if (disableStandardAssets)
		{
			array = this.cam.gameObject.GetComponents<global::UnityEngine.MonoBehaviour>();
			array2 = new bool[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				global::UnityEngine.MonoBehaviour monoBehaviour = array[i];
				bool flag2 = monoBehaviour.enabled && monoBehaviour.GetType().ToString().StartsWith("UnityStandardAssets.");
				if (flag2)
				{
					monoBehaviour.enabled = false;
					array2[i] = true;
				}
			}
		}
		this.clipQuad.SetActive(true);
		this.cam.Render();
		this.clipQuad.SetActive(false);
		bool flag3 = array != null;
		if (flag3)
		{
			for (int j = 0; j < array.Length; j++)
			{
				bool flag4 = array2[j];
				if (flag4)
				{
					array[j].enabled = true;
				}
			}
		}
		this.cam.clearFlags = clearFlags;
		this.cam.backgroundColor = backgroundColor;
		global::UnityEngine.Graphics.DrawTexture(new global::UnityEngine.Rect(0f, 0f, (float)num, (float)num2), this.cam.targetTexture, this.colorMat);
		global::UnityEngine.Graphics.DrawTexture(new global::UnityEngine.Rect((float)num, 0f, (float)num, (float)num2), this.cam.targetTexture, this.alphaMat);
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00004D90 File Offset: 0x00002F90
	public void RenderFar()
	{
		this.cam.nearClipPlane = this.config.near;
		this.cam.farClipPlane = this.config.far;
		this.cam.Render();
		int num = global::UnityEngine.Screen.width / 2;
		int num2 = global::UnityEngine.Screen.height / 2;
		global::UnityEngine.Graphics.DrawTexture(new global::UnityEngine.Rect(0f, (float)num2, (float)num, (float)num2), this.cam.targetTexture, this.colorMat);
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00004E0F File Offset: 0x0000300F
	private void OnGUI()
	{
	}

	// Token: 0x0600006A RID: 106 RVA: 0x00004E14 File Offset: 0x00003014
	private void OnEnable()
	{
		this.cameras = global::UnityEngine.Object.FindObjectsOfType<global::UnityEngine.Camera>();
		bool flag = this.cameras != null;
		if (flag)
		{
			int num = this.cameras.Length;
			this.cameraRects = new global::UnityEngine.Rect[num];
			for (int i = 0; i < num; i++)
			{
				global::UnityEngine.Camera camera = this.cameras[i];
				this.cameraRects[i] = camera.rect;
				bool flag2 = camera == this.cam;
				if (!flag2)
				{
					bool flag3 = camera.targetTexture != null;
					if (!flag3)
					{
						bool flag4 = camera.GetComponent<global::SteamVR_Camera>() != null;
						if (!flag4)
						{
							camera.rect = new global::UnityEngine.Rect(0.5f, 0f, 0.5f, 0.5f);
						}
					}
				}
			}
		}
		bool flag5 = this.config.sceneResolutionScale > 0f;
		if (flag5)
		{
			this.sceneResolutionScale = global::SteamVR_Camera.sceneResolutionScale;
			global::SteamVR_Camera.sceneResolutionScale = this.config.sceneResolutionScale;
		}
	}

	// Token: 0x0600006B RID: 107 RVA: 0x00004F18 File Offset: 0x00003118
	private void OnDisable()
	{
		bool flag = this.cameras != null;
		if (flag)
		{
			int num = this.cameras.Length;
			for (int i = 0; i < num; i++)
			{
				global::UnityEngine.Camera camera = this.cameras[i];
				bool flag2 = camera != null;
				if (flag2)
				{
					camera.rect = this.cameraRects[i];
				}
			}
			this.cameras = null;
			this.cameraRects = null;
		}
		bool flag3 = this.config.sceneResolutionScale > 0f;
		if (flag3)
		{
			global::SteamVR_Camera.sceneResolutionScale = this.sceneResolutionScale;
		}
	}

	// Token: 0x0400002E RID: 46
	public global::SteamVR_ExternalCamera.Config config;

	// Token: 0x0400002F RID: 47
	public string configPath;

	// Token: 0x04000030 RID: 48
	private global::UnityEngine.Camera cam;

	// Token: 0x04000031 RID: 49
	private global::UnityEngine.Transform target;

	// Token: 0x04000032 RID: 50
	private global::UnityEngine.GameObject clipQuad;

	// Token: 0x04000033 RID: 51
	private global::UnityEngine.Material clipMaterial;

	// Token: 0x04000034 RID: 52
	private global::UnityEngine.Material colorMat;

	// Token: 0x04000035 RID: 53
	private global::UnityEngine.Material alphaMat;

	// Token: 0x04000036 RID: 54
	private global::UnityEngine.Camera[] cameras;

	// Token: 0x04000037 RID: 55
	private global::UnityEngine.Rect[] cameraRects;

	// Token: 0x04000038 RID: 56
	private float sceneResolutionScale;

	// Token: 0x020000F9 RID: 249
	public struct Config
	{
		// Token: 0x040006C1 RID: 1729
		public float x;

		// Token: 0x040006C2 RID: 1730
		public float y;

		// Token: 0x040006C3 RID: 1731
		public float z;

		// Token: 0x040006C4 RID: 1732
		public float rx;

		// Token: 0x040006C5 RID: 1733
		public float ry;

		// Token: 0x040006C6 RID: 1734
		public float rz;

		// Token: 0x040006C7 RID: 1735
		public float fov;

		// Token: 0x040006C8 RID: 1736
		public float near;

		// Token: 0x040006C9 RID: 1737
		public float far;

		// Token: 0x040006CA RID: 1738
		public float sceneResolutionScale;

		// Token: 0x040006CB RID: 1739
		public float frameSkip;

		// Token: 0x040006CC RID: 1740
		public float nearOffset;

		// Token: 0x040006CD RID: 1741
		public float farOffset;

		// Token: 0x040006CE RID: 1742
		public float hmdOffset;

		// Token: 0x040006CF RID: 1743
		public bool disableStandardAssets;
	}
}

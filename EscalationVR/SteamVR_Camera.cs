using System;
using System.Collections;
using System.Reflection;
using EscalationVR;
using UnityEngine;
using Valve.VR;

// Token: 0x02000003 RID: 3
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class SteamVR_Camera : global::UnityEngine.MonoBehaviour
{
	// Token: 0x17000017 RID: 23
	// (get) Token: 0x06000036 RID: 54 RVA: 0x00002C20 File Offset: 0x00000E20
	public global::UnityEngine.Transform head
	{
		get
		{
			return this._head;
		}
	}

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x06000037 RID: 55 RVA: 0x00002C38 File Offset: 0x00000E38
	public global::UnityEngine.Transform offset
	{
		get
		{
			return this._head;
		}
	}

	// Token: 0x17000019 RID: 25
	// (get) Token: 0x06000038 RID: 56 RVA: 0x00002C50 File Offset: 0x00000E50
	public global::UnityEngine.Transform origin
	{
		get
		{
			return this._head.parent;
		}
	}

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x06000039 RID: 57 RVA: 0x00002C70 File Offset: 0x00000E70
	public global::UnityEngine.Transform ears
	{
		get
		{
			return this._ears;
		}
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00002C88 File Offset: 0x00000E88
	public global::UnityEngine.Ray GetRay()
	{
		return new global::UnityEngine.Ray(this._head.position, this._head.forward);
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00002CB8 File Offset: 0x00000EB8
	public static global::UnityEngine.RenderTexture GetSceneTexture(bool hdr)
	{
		global::SteamVR instance = global::SteamVR.instance;
		bool flag = instance == null;
		global::UnityEngine.RenderTexture result;
		if (flag)
		{
			result = null;
		}
		else
		{
			int num = (int)(instance.sceneWidth * global::SteamVR_Camera.sceneResolutionScale);
			int num2 = (int)(instance.sceneHeight * global::SteamVR_Camera.sceneResolutionScale);
			int num3 = (global::UnityEngine.QualitySettings.antiAliasing == 0) ? 1 : global::UnityEngine.QualitySettings.antiAliasing;
			global::UnityEngine.RenderTextureFormat renderTextureFormat = hdr ? 2 : 0;
			bool flag2 = global::SteamVR_Camera._sceneTexture != null;
			if (flag2)
			{
				bool flag3 = global::SteamVR_Camera._sceneTexture.width != num || global::SteamVR_Camera._sceneTexture.height != num2 || global::SteamVR_Camera._sceneTexture.antiAliasing != num3 || global::SteamVR_Camera._sceneTexture.format != renderTextureFormat;
				if (flag3)
				{
					global::UnityEngine.Debug.Log(string.Format("Recreating scene texture.. Old: {0}x{1} MSAA={2} [{3}] New: {4}x{5} MSAA={6} [{7}]", new object[]
					{
						global::SteamVR_Camera._sceneTexture.width,
						global::SteamVR_Camera._sceneTexture.height,
						global::SteamVR_Camera._sceneTexture.antiAliasing,
						global::SteamVR_Camera._sceneTexture.format,
						num,
						num2,
						num3,
						renderTextureFormat
					}));
					global::UnityEngine.Object.Destroy(global::SteamVR_Camera._sceneTexture);
					global::SteamVR_Camera._sceneTexture = null;
				}
			}
			bool flag4 = global::SteamVR_Camera._sceneTexture == null;
			if (flag4)
			{
				global::SteamVR_Camera._sceneTexture = new global::UnityEngine.RenderTexture(num, num2, 24, renderTextureFormat);
				global::SteamVR_Camera._sceneTexture.antiAliasing = num3;
				global::Valve.VR.EColorSpace colorSpace = (hdr && global::UnityEngine.QualitySettings.activeColorSpace == null) ? global::Valve.VR.EColorSpace.Gamma : global::Valve.VR.EColorSpace.Auto;
				global::SteamVR.Unity.SetColorSpace(colorSpace);
			}
			result = global::SteamVR_Camera._sceneTexture;
		}
		return result;
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00002E55 File Offset: 0x00001055
	private void OnDisable()
	{
		global::SteamVR_Render.Remove(this);
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00002E60 File Offset: 0x00001060
	private void OnEnable()
	{
		global::SteamVR instance = global::SteamVR.instance;
		bool flag = instance == null;
		if (flag)
		{
			bool flag2 = this.head != null;
			if (flag2)
			{
				this.head.GetComponent<global::SteamVR_GameView>().enabled = false;
				this.head.GetComponent<global::SteamVR_TrackedObject>().enabled = false;
			}
			bool flag3 = this.flip != null;
			if (flag3)
			{
				this.flip.enabled = false;
			}
			base.enabled = false;
		}
		else
		{
			this.Expand();
			bool flag4 = global::SteamVR_Camera.blitMaterial == null;
			if (flag4)
			{
				global::SteamVR_Camera.blitMaterial = new global::UnityEngine.Material(global::EscalationVR.UnityHelper.GetShader("Custom/SteamVR_Blit"));
			}
			global::UnityEngine.Camera component = base.GetComponent<global::UnityEngine.Camera>();
			component.fieldOfView = instance.fieldOfView;
			component.aspect = instance.aspect;
			component.eventMask = 0;
			component.orthographic = false;
			component.enabled = false;
			bool flag5 = component.actualRenderingPath != 1 && global::UnityEngine.QualitySettings.antiAliasing > 1;
			if (flag5)
			{
				global::UnityEngine.Debug.LogWarning("MSAA only supported in Forward rendering path. (disabling MSAA)");
				global::UnityEngine.QualitySettings.antiAliasing = 0;
			}
			global::UnityEngine.Camera component2 = this.head.GetComponent<global::UnityEngine.Camera>();
			bool flag6 = component2 != null;
			if (flag6)
			{
				component2.allowHDR = component.allowHDR;
				component2.renderingPath = component.renderingPath;
			}
			bool flag7 = this.ears == null;
			if (flag7)
			{
				global::SteamVR_Ears componentInChildren = base.transform.GetComponentInChildren<global::SteamVR_Ears>();
				bool flag8 = componentInChildren != null;
				if (flag8)
				{
					this._ears = componentInChildren.transform;
				}
			}
			bool flag9 = this.ears != null;
			if (flag9)
			{
				this.ears.GetComponent<global::SteamVR_Ears>().vrcam = this;
			}
			global::SteamVR_Render.Add(this);
		}
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00003011 File Offset: 0x00001211
	private void Awake()
	{
		this.ForceLast();
	}

	// Token: 0x0600003F RID: 63 RVA: 0x0000301C File Offset: 0x0000121C
	public void ForceLast()
	{
		bool flag = global::SteamVR_Camera.values != null;
		if (flag)
		{
			foreach (object obj in global::SteamVR_Camera.values)
			{
				global::System.Collections.DictionaryEntry dictionaryEntry = (global::System.Collections.DictionaryEntry)obj;
				global::System.Reflection.FieldInfo fieldInfo = dictionaryEntry.Key as global::System.Reflection.FieldInfo;
				fieldInfo.SetValue(this, dictionaryEntry.Value);
			}
			global::SteamVR_Camera.values = null;
		}
		else
		{
			global::UnityEngine.Component[] components = base.GetComponents<global::UnityEngine.Component>();
			for (int i = 0; i < components.Length; i++)
			{
				global::SteamVR_Camera steamVR_Camera = components[i] as global::SteamVR_Camera;
				bool flag2 = steamVR_Camera != null && steamVR_Camera != this;
				if (flag2)
				{
					bool flag3 = steamVR_Camera.flip != null;
					if (flag3)
					{
						global::UnityEngine.Object.DestroyImmediate(steamVR_Camera.flip);
					}
					global::UnityEngine.Object.DestroyImmediate(steamVR_Camera);
				}
			}
			components = base.GetComponents<global::UnityEngine.Component>();
			bool flag4 = this != components[components.Length - 1] || this.flip == null;
			if (flag4)
			{
				bool flag5 = this.flip == null;
				if (flag5)
				{
					this.flip = base.gameObject.AddComponent<global::SteamVR_CameraFlip>();
				}
				global::SteamVR_Camera.values = new global::System.Collections.Hashtable();
				global::System.Reflection.FieldInfo[] fields = base.GetType().GetFields(52);
				foreach (global::System.Reflection.FieldInfo fieldInfo2 in fields)
				{
					bool flag6 = fieldInfo2.IsPublic || fieldInfo2.IsDefined(typeof(global::UnityEngine.SerializeField), true);
					if (flag6)
					{
						global::SteamVR_Camera.values[fieldInfo2] = fieldInfo2.GetValue(this);
					}
				}
				global::UnityEngine.GameObject gameObject = base.gameObject;
				global::UnityEngine.Object.DestroyImmediate(this);
				gameObject.AddComponent<global::SteamVR_Camera>().ForceLast();
			}
		}
	}

	// Token: 0x1700001B RID: 27
	// (get) Token: 0x06000040 RID: 64 RVA: 0x00003204 File Offset: 0x00001404
	public string baseName
	{
		get
		{
			return base.name.EndsWith(" (eye)") ? base.name.Substring(0, base.name.Length - " (eye)".Length) : base.name;
		}
	}

	// Token: 0x06000041 RID: 65 RVA: 0x00003254 File Offset: 0x00001454
	public void Expand()
	{
		global::UnityEngine.Transform transform = base.transform.parent;
		bool flag = transform == null;
		if (flag)
		{
			transform = new global::UnityEngine.GameObject(base.name + " (origin)").transform;
			transform.localPosition = base.transform.localPosition;
			transform.localRotation = base.transform.localRotation;
			transform.localScale = base.transform.localScale;
		}
		bool flag2 = this.head == null;
		if (flag2)
		{
			this._head = new global::UnityEngine.GameObject(base.name + " (head)", new global::System.Type[]
			{
				typeof(global::SteamVR_GameView),
				typeof(global::SteamVR_TrackedObject)
			}).transform;
			this.head.parent = transform;
			this.head.position = base.transform.position;
			this.head.rotation = base.transform.rotation;
			this.head.localScale = global::UnityEngine.Vector3.one;
			this.head.tag = base.tag;
			global::UnityEngine.Camera component = this.head.GetComponent<global::UnityEngine.Camera>();
			component.clearFlags = 4;
			component.cullingMask = 0;
			component.eventMask = 0;
			component.orthographic = true;
			component.orthographicSize = 1f;
			component.nearClipPlane = 0f;
			component.farClipPlane = 1f;
			component.useOcclusionCulling = false;
		}
		bool flag3 = base.transform.parent != this.head;
		if (flag3)
		{
			base.transform.parent = this.head;
			base.transform.localPosition = global::UnityEngine.Vector3.zero;
			base.transform.localRotation = global::UnityEngine.Quaternion.identity;
			base.transform.localScale = global::UnityEngine.Vector3.one;
			while (base.transform.childCount > 0)
			{
				base.transform.GetChild(0).parent = this.head;
			}
			global::UnityEngine.GUILayer component2 = base.GetComponent<global::UnityEngine.GUILayer>();
			bool flag4 = component2 != null;
			if (flag4)
			{
				global::UnityEngine.Object.DestroyImmediate(component2);
				this.head.gameObject.AddComponent<global::UnityEngine.GUILayer>();
			}
			global::UnityEngine.AudioListener component3 = base.GetComponent<global::UnityEngine.AudioListener>();
			bool flag5 = component3 != null;
			if (flag5)
			{
				global::UnityEngine.Object.DestroyImmediate(component3);
				this._ears = new global::UnityEngine.GameObject(base.name + " (ears)", new global::System.Type[]
				{
					typeof(global::SteamVR_Ears)
				}).transform;
				this.ears.parent = this._head;
				this.ears.localPosition = global::UnityEngine.Vector3.zero;
				this.ears.localRotation = global::UnityEngine.Quaternion.identity;
				this.ears.localScale = global::UnityEngine.Vector3.one;
			}
		}
		bool flag6 = !base.name.EndsWith(" (eye)");
		if (flag6)
		{
			base.name += " (eye)";
		}
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00003568 File Offset: 0x00001768
	public void Collapse()
	{
		base.transform.parent = null;
		while (this.head.childCount > 0)
		{
			this.head.GetChild(0).parent = base.transform;
		}
		global::UnityEngine.GUILayer component = this.head.GetComponent<global::UnityEngine.GUILayer>();
		bool flag = component != null;
		if (flag)
		{
			global::UnityEngine.Object.DestroyImmediate(component);
			base.gameObject.AddComponent<global::UnityEngine.GUILayer>();
		}
		bool flag2 = this.ears != null;
		if (flag2)
		{
			while (this.ears.childCount > 0)
			{
				this.ears.GetChild(0).parent = base.transform;
			}
			global::UnityEngine.Object.DestroyImmediate(this.ears.gameObject);
			this._ears = null;
			base.gameObject.AddComponent(typeof(global::UnityEngine.AudioListener));
		}
		bool flag3 = this.origin != null;
		if (flag3)
		{
			bool flag4 = this.origin.name.EndsWith(" (origin)");
			if (flag4)
			{
				global::UnityEngine.Transform origin = this.origin;
				while (origin.childCount > 0)
				{
					origin.GetChild(0).parent = origin.parent;
				}
				global::UnityEngine.Object.DestroyImmediate(origin.gameObject);
			}
			else
			{
				base.transform.parent = this.origin;
			}
		}
		global::UnityEngine.Object.DestroyImmediate(this.head.gameObject);
		this._head = null;
		bool flag5 = base.name.EndsWith(" (eye)");
		if (flag5)
		{
			base.name = base.name.Substring(0, base.name.Length - " (eye)".Length);
		}
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00003724 File Offset: 0x00001924
	private void OnPreRender()
	{
		bool flag = this.flip;
		if (flag)
		{
			this.flip.enabled = (global::SteamVR_Render.Top() == this && global::SteamVR.instance.graphicsAPI == global::Valve.VR.EGraphicsAPIConvention.API_DirectX);
		}
		global::UnityEngine.Camera component = this.head.GetComponent<global::UnityEngine.Camera>();
		bool flag2 = component != null;
		if (flag2)
		{
			component.enabled = (global::SteamVR_Render.Top() == this);
		}
		bool flag3 = this.wireframe;
		if (flag3)
		{
			global::UnityEngine.GL.wireframe = true;
		}
	}

	// Token: 0x06000044 RID: 68 RVA: 0x000037A4 File Offset: 0x000019A4
	private void OnPostRender()
	{
		bool flag = this.wireframe;
		if (flag)
		{
			global::UnityEngine.GL.wireframe = false;
		}
	}

	// Token: 0x06000045 RID: 69 RVA: 0x000037C4 File Offset: 0x000019C4
	private void OnRenderImage(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dest)
	{
		bool flag = global::SteamVR_Render.Top() == this;
		if (flag)
		{
			bool flag2 = global::SteamVR_Render.eye == global::Valve.VR.EVREye.Eye_Left;
			int eventID;
			if (flag2)
			{
				global::SteamVR_Utils.QueueEventOnRenderThread(201510023);
				eventID = 201510021;
			}
			else
			{
				eventID = 201510022;
			}
			global::SteamVR_Utils.QueueEventOnRenderThread(eventID);
		}
		global::UnityEngine.Graphics.SetRenderTarget(dest);
		global::SteamVR_Camera.blitMaterial.mainTexture = src;
		global::UnityEngine.GL.PushMatrix();
		global::UnityEngine.GL.LoadOrtho();
		global::SteamVR_Camera.blitMaterial.SetPass(0);
		global::UnityEngine.GL.Begin(7);
		global::UnityEngine.GL.TexCoord2(0f, 0f);
		global::UnityEngine.GL.Vertex3(-1f, 1f, 0f);
		global::UnityEngine.GL.TexCoord2(1f, 0f);
		global::UnityEngine.GL.Vertex3(1f, 1f, 0f);
		global::UnityEngine.GL.TexCoord2(1f, 1f);
		global::UnityEngine.GL.Vertex3(1f, -1f, 0f);
		global::UnityEngine.GL.TexCoord2(0f, 1f);
		global::UnityEngine.GL.Vertex3(-1f, -1f, 0f);
		global::UnityEngine.GL.End();
		global::UnityEngine.GL.PopMatrix();
		global::UnityEngine.Graphics.SetRenderTarget(null);
	}

	// Token: 0x04000012 RID: 18
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Transform _head;

	// Token: 0x04000013 RID: 19
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Transform _ears;

	// Token: 0x04000014 RID: 20
	public bool wireframe = false;

	// Token: 0x04000015 RID: 21
	[global::UnityEngine.SerializeField]
	private global::SteamVR_CameraFlip flip;

	// Token: 0x04000016 RID: 22
	public static global::UnityEngine.Material blitMaterial;

	// Token: 0x04000017 RID: 23
	public static float sceneResolutionScale = 1f;

	// Token: 0x04000018 RID: 24
	private static global::UnityEngine.RenderTexture _sceneTexture;

	// Token: 0x04000019 RID: 25
	private static global::System.Collections.Hashtable values;

	// Token: 0x0400001A RID: 26
	private const string eyeSuffix = " (eye)";

	// Token: 0x0400001B RID: 27
	private const string earsSuffix = " (ears)";

	// Token: 0x0400001C RID: 28
	private const string headSuffix = " (head)";

	// Token: 0x0400001D RID: 29
	private const string originSuffix = " (origin)";
}

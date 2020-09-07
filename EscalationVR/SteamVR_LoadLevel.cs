using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

// Token: 0x0200000E RID: 14
public class SteamVR_LoadLevel : global::UnityEngine.MonoBehaviour
{
	// Token: 0x1700001C RID: 28
	// (get) Token: 0x06000080 RID: 128 RVA: 0x000061A8 File Offset: 0x000043A8
	public static bool loading
	{
		get
		{
			return global::SteamVR_LoadLevel._active != null;
		}
	}

	// Token: 0x1700001D RID: 29
	// (get) Token: 0x06000081 RID: 129 RVA: 0x000061C8 File Offset: 0x000043C8
	public static float progress
	{
		get
		{
			return (global::SteamVR_LoadLevel._active != null && global::SteamVR_LoadLevel._active.async != null) ? global::SteamVR_LoadLevel._active.async.progress : 0f;
		}
	}

	// Token: 0x1700001E RID: 30
	// (get) Token: 0x06000082 RID: 130 RVA: 0x0000620C File Offset: 0x0000440C
	public static global::UnityEngine.Texture progressTexture
	{
		get
		{
			return (global::SteamVR_LoadLevel._active != null) ? global::SteamVR_LoadLevel._active.renderTexture : null;
		}
	}

	// Token: 0x06000083 RID: 131 RVA: 0x00006238 File Offset: 0x00004438
	private void OnEnable()
	{
		bool flag = this.autoTriggerOnEnable;
		if (flag)
		{
			this.Trigger();
		}
	}

	// Token: 0x06000084 RID: 132 RVA: 0x00006258 File Offset: 0x00004458
	public void Trigger()
	{
		bool flag = !global::SteamVR_LoadLevel.loading && !string.IsNullOrEmpty(this.levelName);
		if (flag)
		{
			base.StartCoroutine("LoadLevel");
		}
	}

	// Token: 0x06000085 RID: 133 RVA: 0x00006290 File Offset: 0x00004490
	public static void Begin(string levelName, bool showGrid = false, float fadeOutTime = 0.5f, float r = 0f, float g = 0f, float b = 0f, float a = 1f)
	{
		global::SteamVR_LoadLevel steamVR_LoadLevel = new global::UnityEngine.GameObject("loader").AddComponent<global::SteamVR_LoadLevel>();
		steamVR_LoadLevel.levelName = levelName;
		steamVR_LoadLevel.showGrid = showGrid;
		steamVR_LoadLevel.fadeOutTime = fadeOutTime;
		steamVR_LoadLevel.backgroundColor = new global::UnityEngine.Color(r, g, b, a);
		steamVR_LoadLevel.Trigger();
	}

	// Token: 0x06000086 RID: 134 RVA: 0x000062DC File Offset: 0x000044DC
	private void OnGUI()
	{
		bool flag = global::SteamVR_LoadLevel._active != this;
		if (!flag)
		{
			bool flag2 = this.progressBarEmpty != null && this.progressBarFull != null;
			if (flag2)
			{
				bool flag3 = this.progressBarOverlayHandle == 0UL;
				if (flag3)
				{
					this.progressBarOverlayHandle = this.GetOverlayHandle("progressBar", (this.progressBarTransform != null) ? this.progressBarTransform : base.transform, this.progressBarWidthInMeters);
				}
				bool flag4 = this.progressBarOverlayHandle > 0UL;
				if (flag4)
				{
					float num = (this.async != null) ? this.async.progress : 0f;
					int width = this.progressBarFull.width;
					int height = this.progressBarFull.height;
					bool flag5 = this.renderTexture == null;
					if (flag5)
					{
						this.renderTexture = new global::UnityEngine.RenderTexture(width, height, 0);
						this.renderTexture.Create();
					}
					global::UnityEngine.RenderTexture active = global::UnityEngine.RenderTexture.active;
					global::UnityEngine.RenderTexture.active = this.renderTexture;
					bool flag6 = global::UnityEngine.Event.current.type == 7;
					if (flag6)
					{
						global::UnityEngine.GL.Clear(false, true, global::UnityEngine.Color.clear);
					}
					global::UnityEngine.GUILayout.BeginArea(new global::UnityEngine.Rect(0f, 0f, (float)width, (float)height));
					global::UnityEngine.GUI.DrawTexture(new global::UnityEngine.Rect(0f, 0f, (float)width, (float)height), this.progressBarEmpty);
					global::UnityEngine.GUI.DrawTextureWithTexCoords(new global::UnityEngine.Rect(0f, 0f, num * (float)width, (float)height), this.progressBarFull, new global::UnityEngine.Rect(0f, 0f, num, 1f));
					global::UnityEngine.GUILayout.EndArea();
					global::UnityEngine.RenderTexture.active = active;
					global::Valve.VR.CVROverlay overlay = global::Valve.VR.OpenVR.Overlay;
					bool flag7 = overlay != null;
					if (flag7)
					{
						global::Valve.VR.Texture_t texture_t = default(global::Valve.VR.Texture_t);
						texture_t.handle = this.renderTexture.GetNativeTexturePtr();
						texture_t.eType = global::SteamVR.instance.graphicsAPI;
						texture_t.eColorSpace = global::Valve.VR.EColorSpace.Auto;
						overlay.SetOverlayTexture(this.progressBarOverlayHandle, ref texture_t);
					}
				}
			}
		}
	}

	// Token: 0x06000087 RID: 135 RVA: 0x000064EC File Offset: 0x000046EC
	private void Update()
	{
		bool flag = global::SteamVR_LoadLevel._active != this;
		if (!flag)
		{
			this.alpha = global::UnityEngine.Mathf.Clamp01(this.alpha + this.fadeRate * global::UnityEngine.Time.deltaTime);
			global::Valve.VR.CVROverlay overlay = global::Valve.VR.OpenVR.Overlay;
			bool flag2 = overlay != null;
			if (flag2)
			{
				bool flag3 = this.loadingScreenOverlayHandle > 0UL;
				if (flag3)
				{
					overlay.SetOverlayAlpha(this.loadingScreenOverlayHandle, this.alpha);
				}
				bool flag4 = this.progressBarOverlayHandle > 0UL;
				if (flag4)
				{
					overlay.SetOverlayAlpha(this.progressBarOverlayHandle, this.alpha);
				}
			}
		}
	}

	// Token: 0x06000088 RID: 136 RVA: 0x0000657D File Offset: 0x0000477D
	private global::System.Collections.IEnumerator LoadLevel()
	{
		bool flag = this.loadingScreen != null && this.loadingScreenDistance > 0f;
		if (flag)
		{
			global::SteamVR_Controller.Device hmd = global::SteamVR_Controller.Input(0);
			while (!hmd.hasTracking)
			{
				yield return null;
			}
			global::SteamVR_Utils.RigidTransform tloading = hmd.transform;
			tloading.rot = global::UnityEngine.Quaternion.Euler(0f, tloading.rot.eulerAngles.y, 0f);
			tloading.pos += tloading.rot * new global::UnityEngine.Vector3(0f, 0f, this.loadingScreenDistance);
			global::UnityEngine.Transform t = (this.loadingScreenTransform != null) ? this.loadingScreenTransform : base.transform;
			t.position = tloading.pos;
			t.rotation = tloading.rot;
			hmd = null;
			tloading = default(global::SteamVR_Utils.RigidTransform);
			t = null;
		}
		global::SteamVR_LoadLevel._active = this;
		global::SteamVR_Utils.Event.Send("loading", new object[]
		{
			true
		});
		bool flag2 = this.loadingScreenFadeInTime > 0f;
		if (flag2)
		{
			this.fadeRate = 1f / this.loadingScreenFadeInTime;
		}
		else
		{
			this.alpha = 1f;
		}
		global::Valve.VR.CVROverlay overlay = global::Valve.VR.OpenVR.Overlay;
		bool flag3 = this.loadingScreen != null && overlay != null;
		if (flag3)
		{
			this.loadingScreenOverlayHandle = this.GetOverlayHandle("loadingScreen", (this.loadingScreenTransform != null) ? this.loadingScreenTransform : base.transform, this.loadingScreenWidthInMeters);
			bool flag4 = this.loadingScreenOverlayHandle > 0UL;
			if (flag4)
			{
				global::Valve.VR.Texture_t texture = default(global::Valve.VR.Texture_t);
				texture.handle = this.loadingScreen.GetNativeTexturePtr();
				texture.eType = global::SteamVR.instance.graphicsAPI;
				texture.eColorSpace = global::Valve.VR.EColorSpace.Auto;
				overlay.SetOverlayTexture(this.loadingScreenOverlayHandle, ref texture);
			}
		}
		bool fadedForeground = false;
		global::SteamVR_Utils.Event.Send("loading_fade_out", new object[]
		{
			this.fadeOutTime
		});
		global::Valve.VR.CVRCompositor compositor = global::Valve.VR.OpenVR.Compositor;
		bool flag5 = compositor != null;
		if (flag5)
		{
			bool flag6 = this.front != null;
			if (flag6)
			{
				global::SteamVR_Skybox.SetOverride(this.front, this.back, this.left, this.right, this.top, this.bottom);
				compositor.FadeGrid(this.fadeOutTime, true);
				yield return new global::UnityEngine.WaitForSeconds(this.fadeOutTime);
			}
			else
			{
				bool flag7 = this.backgroundColor != global::UnityEngine.Color.clear;
				if (flag7)
				{
					bool flag8 = this.showGrid;
					if (flag8)
					{
						compositor.FadeToColor(0f, this.backgroundColor.r, this.backgroundColor.g, this.backgroundColor.b, this.backgroundColor.a, true);
						compositor.FadeGrid(this.fadeOutTime, true);
						yield return new global::UnityEngine.WaitForSeconds(this.fadeOutTime);
					}
					else
					{
						compositor.FadeToColor(this.fadeOutTime, this.backgroundColor.r, this.backgroundColor.g, this.backgroundColor.b, this.backgroundColor.a, false);
						yield return new global::UnityEngine.WaitForSeconds(this.fadeOutTime + 0.1f);
						compositor.FadeGrid(0f, true);
						fadedForeground = true;
					}
				}
			}
		}
		global::SteamVR_Render.pauseRendering = true;
		while (this.alpha < 1f)
		{
			yield return null;
		}
		base.transform.parent = null;
		global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		bool flag9 = this.loadExternalApp;
		if (flag9)
		{
			global::UnityEngine.Debug.Log("Launching external application...");
			global::Valve.VR.CVRApplications applications = global::Valve.VR.OpenVR.Applications;
			bool flag10 = applications == null;
			if (flag10)
			{
				global::UnityEngine.Debug.Log("Failed to get OpenVR.Applications interface!");
			}
			else
			{
				string workingDirectory = global::System.IO.Directory.GetCurrentDirectory();
				string fullPath = global::System.IO.Path.Combine(workingDirectory, this.externalAppPath);
				global::UnityEngine.Debug.Log("LaunchingInternalProcess");
				global::UnityEngine.Debug.Log("ExternalAppPath = " + this.externalAppPath);
				global::UnityEngine.Debug.Log("FullPath = " + fullPath);
				global::UnityEngine.Debug.Log("ExternalAppArgs = " + this.externalAppArgs);
				global::UnityEngine.Debug.Log("WorkingDirectory = " + workingDirectory);
				global::UnityEngine.Debug.Log("LaunchInternalProcessError: " + applications.LaunchInternalProcess(fullPath, this.externalAppArgs, workingDirectory).ToString());
				global::System.Diagnostics.Process.GetCurrentProcess().Kill();
				workingDirectory = null;
				fullPath = null;
			}
			applications = null;
		}
		else
		{
			global::UnityEngine.SceneManagement.LoadSceneMode mode = this.loadAdditive ? 1 : 0;
			bool flag11 = this.loadAsync;
			if (flag11)
			{
				global::UnityEngine.Application.backgroundLoadingPriority = 0;
				this.async = global::UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(this.levelName, mode);
				while (!this.async.isDone)
				{
					yield return null;
				}
			}
			else
			{
				global::UnityEngine.SceneManagement.SceneManager.LoadScene(this.levelName, mode);
			}
		}
		yield return null;
		global::System.GC.Collect();
		yield return null;
		global::UnityEngine.Shader.WarmupAllShaders();
		yield return new global::UnityEngine.WaitForSeconds(this.postLoadSettleTime);
		global::SteamVR_Render.pauseRendering = false;
		bool flag12 = this.loadingScreenFadeOutTime > 0f;
		if (flag12)
		{
			this.fadeRate = -1f / this.loadingScreenFadeOutTime;
		}
		else
		{
			this.alpha = 0f;
		}
		global::SteamVR_Utils.Event.Send("loading_fade_in", new object[]
		{
			this.fadeInTime
		});
		bool flag13 = compositor != null;
		if (flag13)
		{
			bool flag14 = fadedForeground;
			if (flag14)
			{
				compositor.FadeGrid(0f, false);
				compositor.FadeToColor(this.fadeInTime, 0f, 0f, 0f, 0f, false);
				yield return new global::UnityEngine.WaitForSeconds(this.fadeInTime);
			}
			else
			{
				compositor.FadeGrid(this.fadeInTime, false);
				yield return new global::UnityEngine.WaitForSeconds(this.fadeInTime);
				bool flag15 = this.front != null;
				if (flag15)
				{
					global::SteamVR_Skybox.ClearOverride();
				}
			}
		}
		while (this.alpha > 0f)
		{
			yield return null;
		}
		bool flag16 = overlay != null;
		if (flag16)
		{
			bool flag17 = this.progressBarOverlayHandle > 0UL;
			if (flag17)
			{
				overlay.HideOverlay(this.progressBarOverlayHandle);
			}
			bool flag18 = this.loadingScreenOverlayHandle > 0UL;
			if (flag18)
			{
				overlay.HideOverlay(this.loadingScreenOverlayHandle);
			}
		}
		global::UnityEngine.Object.Destroy(base.gameObject);
		global::SteamVR_LoadLevel._active = null;
		global::SteamVR_Utils.Event.Send("loading", new object[]
		{
			false
		});
		yield break;
	}

	// Token: 0x06000089 RID: 137 RVA: 0x0000658C File Offset: 0x0000478C
	private ulong GetOverlayHandle(string overlayName, global::UnityEngine.Transform transform, float widthInMeters = 1f)
	{
		ulong num = 0UL;
		global::Valve.VR.CVROverlay overlay = global::Valve.VR.OpenVR.Overlay;
		bool flag = overlay == null;
		ulong result;
		if (flag)
		{
			result = num;
		}
		else
		{
			string pchOverlayKey = global::SteamVR_Overlay.key + "." + overlayName;
			global::Valve.VR.EVROverlayError evroverlayError = overlay.FindOverlay(pchOverlayKey, ref num);
			bool flag2 = evroverlayError > global::Valve.VR.EVROverlayError.None;
			if (flag2)
			{
				evroverlayError = overlay.CreateOverlay(pchOverlayKey, overlayName, ref num);
			}
			bool flag3 = evroverlayError == global::Valve.VR.EVROverlayError.None;
			if (flag3)
			{
				overlay.ShowOverlay(num);
				overlay.SetOverlayAlpha(num, this.alpha);
				overlay.SetOverlayWidthInMeters(num, widthInMeters);
				bool flag4 = global::SteamVR.instance.graphicsAPI == global::Valve.VR.EGraphicsAPIConvention.API_DirectX;
				if (flag4)
				{
					global::Valve.VR.VRTextureBounds_t vrtextureBounds_t = default(global::Valve.VR.VRTextureBounds_t);
					vrtextureBounds_t.uMin = 0f;
					vrtextureBounds_t.vMin = 1f;
					vrtextureBounds_t.uMax = 1f;
					vrtextureBounds_t.vMax = 0f;
					overlay.SetOverlayTextureBounds(num, ref vrtextureBounds_t);
				}
				global::SteamVR_Camera steamVR_Camera = (this.loadingScreenDistance == 0f) ? global::SteamVR_Render.Top() : null;
				bool flag5 = steamVR_Camera != null && steamVR_Camera.origin != null;
				if (flag5)
				{
					global::SteamVR_Utils.RigidTransform rigidTransform = new global::SteamVR_Utils.RigidTransform(steamVR_Camera.origin, transform);
					rigidTransform.pos.x = rigidTransform.pos.x / steamVR_Camera.origin.localScale.x;
					rigidTransform.pos.y = rigidTransform.pos.y / steamVR_Camera.origin.localScale.y;
					rigidTransform.pos.z = rigidTransform.pos.z / steamVR_Camera.origin.localScale.z;
					global::Valve.VR.HmdMatrix34_t hmdMatrix34_t = rigidTransform.ToHmdMatrix34();
					overlay.SetOverlayTransformAbsolute(num, global::SteamVR_Render.instance.trackingSpace, ref hmdMatrix34_t);
				}
				else
				{
					global::Valve.VR.HmdMatrix34_t hmdMatrix34_t2 = new global::SteamVR_Utils.RigidTransform(transform).ToHmdMatrix34();
					overlay.SetOverlayTransformAbsolute(num, global::SteamVR_Render.instance.trackingSpace, ref hmdMatrix34_t2);
				}
			}
			result = num;
		}
		return result;
	}

	// Token: 0x04000052 RID: 82
	private static global::SteamVR_LoadLevel _active = null;

	// Token: 0x04000053 RID: 83
	public string levelName;

	// Token: 0x04000054 RID: 84
	public bool loadExternalApp;

	// Token: 0x04000055 RID: 85
	public string externalAppPath;

	// Token: 0x04000056 RID: 86
	public string externalAppArgs;

	// Token: 0x04000057 RID: 87
	public bool loadAdditive;

	// Token: 0x04000058 RID: 88
	public bool loadAsync = true;

	// Token: 0x04000059 RID: 89
	public global::UnityEngine.Texture loadingScreen;

	// Token: 0x0400005A RID: 90
	public global::UnityEngine.Texture progressBarEmpty;

	// Token: 0x0400005B RID: 91
	public global::UnityEngine.Texture progressBarFull;

	// Token: 0x0400005C RID: 92
	public float loadingScreenWidthInMeters = 6f;

	// Token: 0x0400005D RID: 93
	public float progressBarWidthInMeters = 3f;

	// Token: 0x0400005E RID: 94
	public float loadingScreenDistance = 0f;

	// Token: 0x0400005F RID: 95
	public global::UnityEngine.Transform loadingScreenTransform;

	// Token: 0x04000060 RID: 96
	public global::UnityEngine.Transform progressBarTransform;

	// Token: 0x04000061 RID: 97
	public global::UnityEngine.Texture front;

	// Token: 0x04000062 RID: 98
	public global::UnityEngine.Texture back;

	// Token: 0x04000063 RID: 99
	public global::UnityEngine.Texture left;

	// Token: 0x04000064 RID: 100
	public global::UnityEngine.Texture right;

	// Token: 0x04000065 RID: 101
	public global::UnityEngine.Texture top;

	// Token: 0x04000066 RID: 102
	public global::UnityEngine.Texture bottom;

	// Token: 0x04000067 RID: 103
	public global::UnityEngine.Color backgroundColor = global::UnityEngine.Color.black;

	// Token: 0x04000068 RID: 104
	public bool showGrid = false;

	// Token: 0x04000069 RID: 105
	public float fadeOutTime = 0.5f;

	// Token: 0x0400006A RID: 106
	public float fadeInTime = 0.5f;

	// Token: 0x0400006B RID: 107
	public float postLoadSettleTime = 0f;

	// Token: 0x0400006C RID: 108
	public float loadingScreenFadeInTime = 1f;

	// Token: 0x0400006D RID: 109
	public float loadingScreenFadeOutTime = 0.25f;

	// Token: 0x0400006E RID: 110
	private float fadeRate = 1f;

	// Token: 0x0400006F RID: 111
	private float alpha = 0f;

	// Token: 0x04000070 RID: 112
	private global::UnityEngine.AsyncOperation async;

	// Token: 0x04000071 RID: 113
	private global::UnityEngine.RenderTexture renderTexture;

	// Token: 0x04000072 RID: 114
	private ulong loadingScreenOverlayHandle = 0UL;

	// Token: 0x04000073 RID: 115
	private ulong progressBarOverlayHandle = 0UL;

	// Token: 0x04000074 RID: 116
	public bool autoTriggerOnEnable = false;
}

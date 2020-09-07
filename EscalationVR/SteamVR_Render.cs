using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using Valve.VR;

// Token: 0x02000012 RID: 18
public class SteamVR_Render : global::UnityEngine.MonoBehaviour
{
	// Token: 0x17000023 RID: 35
	// (get) Token: 0x060000A9 RID: 169 RVA: 0x000080FA File Offset: 0x000062FA
	// (set) Token: 0x060000AA RID: 170 RVA: 0x00008101 File Offset: 0x00006301
	public static global::Valve.VR.EVREye eye { get; private set; }

	// Token: 0x17000024 RID: 36
	// (get) Token: 0x060000AB RID: 171 RVA: 0x0000810C File Offset: 0x0000630C
	public static global::SteamVR_Render instance
	{
		get
		{
			bool flag = global::SteamVR_Render._instance == null;
			if (flag)
			{
				global::SteamVR_Render._instance = global::UnityEngine.Object.FindObjectOfType<global::SteamVR_Render>();
				bool flag2 = global::SteamVR_Render._instance == null;
				if (flag2)
				{
					global::SteamVR_Render._instance = new global::UnityEngine.GameObject("[SteamVR]").AddComponent<global::SteamVR_Render>();
				}
			}
			return global::SteamVR_Render._instance;
		}
	}

	// Token: 0x060000AC RID: 172 RVA: 0x00008161 File Offset: 0x00006361
	private void OnDestroy()
	{
		global::SteamVR_Render._instance = null;
	}

	// Token: 0x060000AD RID: 173 RVA: 0x0000816A File Offset: 0x0000636A
	private void OnApplicationQuit()
	{
	}

	// Token: 0x060000AE RID: 174 RVA: 0x00008170 File Offset: 0x00006370
	public static void Add(global::SteamVR_Camera vrcam)
	{
		bool flag = !global::SteamVR_Render.isQuitting;
		if (flag)
		{
			global::SteamVR_Render.instance.AddInternal(vrcam);
		}
	}

	// Token: 0x060000AF RID: 175 RVA: 0x00008198 File Offset: 0x00006398
	public static void Remove(global::SteamVR_Camera vrcam)
	{
		bool flag = !global::SteamVR_Render.isQuitting && global::SteamVR_Render._instance != null;
		if (flag)
		{
			global::SteamVR_Render.instance.RemoveInternal(vrcam);
		}
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x000081CC File Offset: 0x000063CC
	public static global::SteamVR_Camera Top()
	{
		bool flag = !global::SteamVR_Render.isQuitting;
		global::SteamVR_Camera result;
		if (flag)
		{
			result = global::SteamVR_Render.instance.TopInternal();
		}
		else
		{
			result = null;
		}
		return result;
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x000081F8 File Offset: 0x000063F8
	private void AddInternal(global::SteamVR_Camera vrcam)
	{
		global::UnityEngine.Camera component = vrcam.GetComponent<global::UnityEngine.Camera>();
		int num = this.cameras.Length;
		global::SteamVR_Camera[] array = new global::SteamVR_Camera[num + 1];
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			global::UnityEngine.Camera component2 = this.cameras[i].GetComponent<global::UnityEngine.Camera>();
			bool flag = i == num2 && component2.depth > component.depth;
			if (flag)
			{
				array[num2++] = vrcam;
			}
			array[num2++] = this.cameras[i];
		}
		bool flag2 = num2 == num;
		if (flag2)
		{
			array[num2] = vrcam;
		}
		this.cameras = array;
		base.enabled = true;
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x0000829C File Offset: 0x0000649C
	private void RemoveInternal(global::SteamVR_Camera vrcam)
	{
		int num = this.cameras.Length;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			global::SteamVR_Camera steamVR_Camera = this.cameras[i];
			bool flag = steamVR_Camera == vrcam;
			if (flag)
			{
				num2++;
			}
		}
		bool flag2 = num2 == 0;
		if (!flag2)
		{
			global::SteamVR_Camera[] array = new global::SteamVR_Camera[num - num2];
			int num3 = 0;
			for (int j = 0; j < num; j++)
			{
				global::SteamVR_Camera steamVR_Camera2 = this.cameras[j];
				bool flag3 = steamVR_Camera2 != vrcam;
				if (flag3)
				{
					array[num3++] = steamVR_Camera2;
				}
			}
			this.cameras = array;
		}
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x00008344 File Offset: 0x00006544
	private global::SteamVR_Camera TopInternal()
	{
		bool flag = this.cameras.Length != 0;
		global::SteamVR_Camera result;
		if (flag)
		{
			result = this.cameras[this.cameras.Length - 1];
		}
		else
		{
			result = null;
		}
		return result;
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x060000B4 RID: 180 RVA: 0x0000837C File Offset: 0x0000657C
	// (set) Token: 0x060000B5 RID: 181 RVA: 0x00008393 File Offset: 0x00006593
	public static bool pauseRendering
	{
		get
		{
			return global::SteamVR_Render._pauseRendering;
		}
		set
		{
			global::SteamVR_Render._pauseRendering = value;
		}
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x0000839C File Offset: 0x0000659C
	private global::System.Collections.IEnumerator RenderLoop()
	{
		for (;;)
		{
			yield return new global::UnityEngine.WaitForEndOfFrame();
			bool pauseRendering = global::SteamVR_Render.pauseRendering;
			if (!pauseRendering)
			{
				global::Valve.VR.CVRCompositor compositor = global::Valve.VR.OpenVR.Compositor;
				bool flag = compositor != null;
				if (flag)
				{
					bool flag2 = !compositor.CanRenderScene();
					if (flag2)
					{
						continue;
					}
					compositor.SetTrackingSpace(this.trackingSpace);
					global::SteamVR_Utils.QueueEventOnRenderThread(201510020);
					global::SteamVR.Unity.EventWriteString("[UnityMain] GetNativeTexturePtr - Begin");
					global::SteamVR_Camera.GetSceneTexture(this.cameras[0].GetComponent<global::UnityEngine.Camera>().allowHDR).GetNativeTexturePtr();
					global::SteamVR.Unity.EventWriteString("[UnityMain] GetNativeTexturePtr - End");
					compositor.GetLastPoses(this.poses, this.gamePoses);
					global::SteamVR_Utils.Event.Send("new_poses", new object[]
					{
						this.poses
					});
					global::SteamVR_Utils.Event.Send("new_poses_applied", global::System.Array.Empty<object>());
				}
				global::SteamVR_Overlay overlay = global::SteamVR_Overlay.instance;
				bool flag3 = overlay != null;
				if (flag3)
				{
					overlay.UpdateOverlay();
				}
				this.RenderExternalCamera();
				global::SteamVR vr = global::SteamVR.instance;
				this.RenderEye(vr, global::Valve.VR.EVREye.Eye_Left);
				this.RenderEye(vr, global::Valve.VR.EVREye.Eye_Right);
				foreach (global::SteamVR_Camera c in this.cameras)
				{
					c.transform.localPosition = global::UnityEngine.Vector3.zero;
					c.transform.localRotation = global::UnityEngine.Quaternion.identity;
					c = null;
				}
				global::SteamVR_Camera[] array = null;
				bool flag4 = this.cameraMask != null;
				if (flag4)
				{
					this.cameraMask.Clear();
				}
				compositor = null;
				overlay = null;
				vr = null;
			}
		}
		yield break;
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x000083AC File Offset: 0x000065AC
	private void RenderEye(global::SteamVR vr, global::Valve.VR.EVREye eye)
	{
		global::SteamVR_Render.eye = eye;
		bool flag = this.cameraMask != null;
		if (flag)
		{
			this.cameraMask.Set(vr, eye);
		}
		foreach (global::SteamVR_Camera steamVR_Camera in this.cameras)
		{
			steamVR_Camera.transform.localPosition = vr.eyes[(int)eye].pos;
			steamVR_Camera.transform.localRotation = vr.eyes[(int)eye].rot;
			this.cameraMask.transform.position = steamVR_Camera.transform.position;
			global::UnityEngine.Camera component = steamVR_Camera.GetComponent<global::UnityEngine.Camera>();
			component.targetTexture = global::SteamVR_Camera.GetSceneTexture(component.allowHDR);
			int cullingMask = component.cullingMask;
			bool flag2 = eye == global::Valve.VR.EVREye.Eye_Left;
			if (flag2)
			{
				component.cullingMask &= ~this.rightMask;
				component.cullingMask |= this.leftMask;
			}
			else
			{
				component.cullingMask &= ~this.leftMask;
				component.cullingMask |= this.rightMask;
			}
			component.Render();
			component.cullingMask = cullingMask;
		}
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00008510 File Offset: 0x00006710
	private void RenderExternalCamera()
	{
		bool flag = this.externalCamera == null;
		if (!flag)
		{
			bool flag2 = !this.externalCamera.gameObject.activeInHierarchy;
			if (!flag2)
			{
				int num = (int)global::UnityEngine.Mathf.Max(this.externalCamera.config.frameSkip, 0f);
				bool flag3 = global::UnityEngine.Time.frameCount % (num + 1) != 0;
				if (!flag3)
				{
					this.externalCamera.AttachToCamera(this.TopInternal());
					this.externalCamera.RenderNear();
					this.externalCamera.RenderFar();
				}
			}
		}
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x000085A4 File Offset: 0x000067A4
	private void OnInputFocus(params object[] args)
	{
		bool flag = (bool)args[0];
		bool flag2 = flag;
		if (flag2)
		{
			bool flag3 = this.pauseGameWhenDashboardIsVisible;
			if (flag3)
			{
				global::UnityEngine.Time.timeScale = this.timeScale;
			}
			global::SteamVR_Camera.sceneResolutionScale = this.sceneResolutionScale;
		}
		else
		{
			bool flag4 = this.pauseGameWhenDashboardIsVisible;
			if (flag4)
			{
				this.timeScale = global::UnityEngine.Time.timeScale;
				global::UnityEngine.Time.timeScale = 0f;
			}
			this.sceneResolutionScale = global::SteamVR_Camera.sceneResolutionScale;
			global::SteamVR_Camera.sceneResolutionScale = 0.5f;
		}
	}

	// Token: 0x060000BA RID: 186 RVA: 0x00008620 File Offset: 0x00006820
	private void OnQuit(params object[] args)
	{
		global::UnityEngine.Application.Quit();
	}

	// Token: 0x060000BB RID: 187 RVA: 0x00008629 File Offset: 0x00006829
	private void OnEnable()
	{
		base.StartCoroutine("RenderLoop");
		global::SteamVR_Utils.Event.Listen("input_focus", new global::SteamVR_Utils.Event.Handler(this.OnInputFocus));
		global::SteamVR_Utils.Event.Listen("Quit", new global::SteamVR_Utils.Event.Handler(this.OnQuit));
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00008666 File Offset: 0x00006866
	private void OnDisable()
	{
		base.StopAllCoroutines();
		global::SteamVR_Utils.Event.Remove("input_focus", new global::SteamVR_Utils.Event.Handler(this.OnInputFocus));
		global::SteamVR_Utils.Event.Remove("Quit", new global::SteamVR_Utils.Event.Handler(this.OnQuit));
	}

	// Token: 0x060000BD RID: 189 RVA: 0x000086A0 File Offset: 0x000068A0
	private void Awake()
	{
		this.cameraMask = new global::UnityEngine.GameObject("cameraMask")
		{
			transform = 
			{
				parent = base.transform
			}
		}.AddComponent<global::SteamVR_CameraMask>();
		bool flag = this.externalCamera == null && global::System.IO.File.Exists(this.externalCameraConfigPath);
		if (flag)
		{
			global::UnityEngine.GameObject gameObject = global::UnityEngine.Resources.Load<global::UnityEngine.GameObject>("SteamVR_ExternalCamera");
			global::UnityEngine.GameObject gameObject2 = global::UnityEngine.Object.Instantiate<global::UnityEngine.GameObject>(gameObject);
			gameObject2.gameObject.name = "External Camera";
			this.externalCamera = gameObject2.transform.GetChild(0).GetComponent<global::SteamVR_ExternalCamera>();
			this.externalCamera.configPath = this.externalCameraConfigPath;
			this.externalCamera.ReadConfig();
		}
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00008750 File Offset: 0x00006950
	private void FixedUpdate()
	{
		global::SteamVR_Utils.QueueEventOnRenderThread(201510024);
	}

	// Token: 0x060000BF RID: 191 RVA: 0x00008760 File Offset: 0x00006960
	private void Update()
	{
		bool flag = this.cameras.Length == 0;
		if (flag)
		{
			base.enabled = false;
		}
		else
		{
			global::SteamVR_Utils.QueueEventOnRenderThread(201510024);
			global::SteamVR_Controller.Update();
			global::Valve.VR.CVRSystem system = global::Valve.VR.OpenVR.System;
			bool flag2 = system != null;
			if (flag2)
			{
				global::Valve.VR.VREvent_t vrevent_t = default(global::Valve.VR.VREvent_t);
				uint uncbVREvent = (uint)global::System.Runtime.InteropServices.Marshal.SizeOf(typeof(global::Valve.VR.VREvent_t));
				int i = 0;
				while (i < 64)
				{
					bool flag3 = !system.PollNextEvent(ref vrevent_t, uncbVREvent);
					if (flag3)
					{
						break;
					}
					global::Valve.VR.EVREventType eventType = (global::Valve.VR.EVREventType)vrevent_t.eventType;
					global::Valve.VR.EVREventType evreventType = eventType;
					if (evreventType <= global::Valve.VR.EVREventType.VREvent_InputFocusReleased)
					{
						if (evreventType != global::Valve.VR.EVREventType.VREvent_InputFocusCaptured)
						{
							if (evreventType != global::Valve.VR.EVREventType.VREvent_InputFocusReleased)
							{
								goto IL_16D;
							}
							bool flag4 = vrevent_t.data.process.pid == 0U;
							if (flag4)
							{
								global::SteamVR_Utils.Event.Send("input_focus", new object[]
								{
									true
								});
							}
						}
						else
						{
							bool flag5 = vrevent_t.data.process.oldPid == 0U;
							if (flag5)
							{
								global::SteamVR_Utils.Event.Send("input_focus", new object[]
								{
									false
								});
							}
						}
					}
					else if (evreventType != global::Valve.VR.EVREventType.VREvent_HideRenderModels)
					{
						if (evreventType != global::Valve.VR.EVREventType.VREvent_ShowRenderModels)
						{
							goto IL_16D;
						}
						global::SteamVR_Utils.Event.Send("hide_render_models", new object[]
						{
							false
						});
					}
					else
					{
						global::SteamVR_Utils.Event.Send("hide_render_models", new object[]
						{
							true
						});
					}
					IL_1B3:
					i++;
					continue;
					IL_16D:
					string name = global::System.Enum.GetName(typeof(global::Valve.VR.EVREventType), vrevent_t.eventType);
					bool flag6 = name != null;
					if (flag6)
					{
						global::SteamVR_Utils.Event.Send(name.Substring(8), new object[]
						{
							vrevent_t
						});
					}
					goto IL_1B3;
				}
			}
			global::UnityEngine.Application.targetFrameRate = -1;
			global::UnityEngine.Application.runInBackground = true;
			global::UnityEngine.QualitySettings.maxQueuedFrames = -1;
			global::UnityEngine.QualitySettings.vSyncCount = 0;
			bool flag7 = this.lockPhysicsUpdateRateToRenderFrequency && global::UnityEngine.Time.timeScale > 0f;
			if (flag7)
			{
				global::SteamVR instance = global::SteamVR.instance;
				bool flag8 = instance != null;
				if (flag8)
				{
					global::Valve.VR.Compositor_FrameTiming compositor_FrameTiming = default(global::Valve.VR.Compositor_FrameTiming);
					compositor_FrameTiming.m_nSize = (uint)global::System.Runtime.InteropServices.Marshal.SizeOf(typeof(global::Valve.VR.Compositor_FrameTiming));
					instance.compositor.GetFrameTiming(ref compositor_FrameTiming, 0U);
					global::UnityEngine.Time.fixedDeltaTime = global::UnityEngine.Time.timeScale / instance.hmd_DisplayFrequency;
					global::UnityEngine.Time.maximumDeltaTime = global::UnityEngine.Time.fixedDeltaTime * compositor_FrameTiming.m_nNumFramePresents;
				}
			}
		}
	}

	// Token: 0x0400009A RID: 154
	public bool pauseGameWhenDashboardIsVisible = true;

	// Token: 0x0400009B RID: 155
	public bool lockPhysicsUpdateRateToRenderFrequency = true;

	// Token: 0x0400009C RID: 156
	public global::SteamVR_ExternalCamera externalCamera;

	// Token: 0x0400009D RID: 157
	public string externalCameraConfigPath = "externalcamera.cfg";

	// Token: 0x0400009E RID: 158
	public global::UnityEngine.LayerMask leftMask;

	// Token: 0x0400009F RID: 159
	public global::UnityEngine.LayerMask rightMask;

	// Token: 0x040000A0 RID: 160
	private global::SteamVR_CameraMask cameraMask;

	// Token: 0x040000A1 RID: 161
	public global::Valve.VR.ETrackingUniverseOrigin trackingSpace = global::Valve.VR.ETrackingUniverseOrigin.TrackingUniverseStanding;

	// Token: 0x040000A3 RID: 163
	private static global::SteamVR_Render _instance;

	// Token: 0x040000A4 RID: 164
	private static bool isQuitting;

	// Token: 0x040000A5 RID: 165
	private global::SteamVR_Camera[] cameras = new global::SteamVR_Camera[0];

	// Token: 0x040000A6 RID: 166
	public global::Valve.VR.TrackedDevicePose_t[] poses = new global::Valve.VR.TrackedDevicePose_t[16];

	// Token: 0x040000A7 RID: 167
	public global::Valve.VR.TrackedDevicePose_t[] gamePoses = new global::Valve.VR.TrackedDevicePose_t[0];

	// Token: 0x040000A8 RID: 168
	private static bool _pauseRendering;

	// Token: 0x040000A9 RID: 169
	private float sceneResolutionScale = 1f;

	// Token: 0x040000AA RID: 170
	private float timeScale = 1f;
}

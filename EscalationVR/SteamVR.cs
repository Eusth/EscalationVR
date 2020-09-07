using System;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using Valve.VR;

// Token: 0x02000002 RID: 2
public class SteamVR : global::System.IDisposable
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static bool active
	{
		get
		{
			return global::SteamVR._instance != null;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000002 RID: 2 RVA: 0x0000206C File Offset: 0x0000026C
	// (set) Token: 0x06000003 RID: 3 RVA: 0x00002084 File Offset: 0x00000284
	public static bool enabled
	{
		get
		{
			return global::SteamVR._enabled;
		}
		set
		{
			global::SteamVR._enabled = value;
			bool flag = !global::SteamVR._enabled;
			if (flag)
			{
				global::SteamVR.SafeDispose();
			}
		}
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000004 RID: 4 RVA: 0x000020AC File Offset: 0x000002AC
	public static global::SteamVR instance
	{
		get
		{
			bool flag = !global::SteamVR.enabled;
			global::SteamVR result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = global::SteamVR._instance == null;
				if (flag2)
				{
					global::SteamVR._instance = global::SteamVR.CreateInstance();
					bool flag3 = global::SteamVR._instance == null;
					if (flag3)
					{
						global::SteamVR._enabled = false;
					}
				}
				result = global::SteamVR._instance;
			}
			return result;
		}
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000005 RID: 5 RVA: 0x00002100 File Offset: 0x00000300
	public static bool usingNativeSupport
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002114 File Offset: 0x00000314
	private static global::SteamVR CreateInstance()
	{
		try
		{
			global::Valve.VR.EVRInitError evrinitError = global::Valve.VR.EVRInitError.None;
			bool flag = !global::SteamVR.usingNativeSupport;
			if (flag)
			{
				global::Valve.VR.OpenVR.Init(ref evrinitError, global::Valve.VR.EVRApplicationType.VRApplication_Scene);
				bool flag2 = evrinitError > global::Valve.VR.EVRInitError.None;
				if (flag2)
				{
					global::SteamVR.ReportError(evrinitError);
					global::SteamVR.ShutdownSystems();
					return null;
				}
			}
			global::Valve.VR.OpenVR.GetGenericInterface("IVRCompositor_014", ref evrinitError);
			bool flag3 = evrinitError > global::Valve.VR.EVRInitError.None;
			if (flag3)
			{
				global::SteamVR.ReportError(evrinitError);
				global::SteamVR.ShutdownSystems();
				return null;
			}
			global::Valve.VR.OpenVR.GetGenericInterface("IVROverlay_011", ref evrinitError);
			bool flag4 = evrinitError > global::Valve.VR.EVRInitError.None;
			if (flag4)
			{
				global::SteamVR.ReportError(evrinitError);
				global::SteamVR.ShutdownSystems();
				return null;
			}
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex);
			return null;
		}
		return new global::SteamVR();
	}

	// Token: 0x06000007 RID: 7 RVA: 0x000021D4 File Offset: 0x000003D4
	private static void ReportError(global::Valve.VR.EVRInitError error)
	{
		if (error <= global::Valve.VR.EVRInitError.Init_VRClientDLLNotFound)
		{
			if (error == global::Valve.VR.EVRInitError.None)
			{
				return;
			}
			if (error == global::Valve.VR.EVRInitError.Init_VRClientDLLNotFound)
			{
				global::UnityEngine.Debug.Log("SteamVR drivers not found!  They can be installed via Steam under Library > Tools.  Visit http://steampowered.com to install Steam.");
				return;
			}
		}
		else
		{
			if (error == global::Valve.VR.EVRInitError.Driver_RuntimeOutOfDate)
			{
				global::UnityEngine.Debug.Log("SteamVR Initialization Failed!  Make sure device's runtime is up to date.");
				return;
			}
			if (error == global::Valve.VR.EVRInitError.VendorSpecific_UnableToConnectToOculusRuntime)
			{
				global::UnityEngine.Debug.Log("SteamVR Initialization Failed!  Make sure device is on, Oculus runtime is installed, and OVRService_*.exe is running.");
				return;
			}
		}
		global::UnityEngine.Debug.Log(global::Valve.VR.OpenVR.GetStringForHmdError(error));
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000008 RID: 8 RVA: 0x00002242 File Offset: 0x00000442
	// (set) Token: 0x06000009 RID: 9 RVA: 0x0000224A File Offset: 0x0000044A
	public global::Valve.VR.CVRSystem hmd { get; private set; }

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x0600000A RID: 10 RVA: 0x00002253 File Offset: 0x00000453
	// (set) Token: 0x0600000B RID: 11 RVA: 0x0000225B File Offset: 0x0000045B
	public global::Valve.VR.CVRCompositor compositor { get; private set; }

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x0600000C RID: 12 RVA: 0x00002264 File Offset: 0x00000464
	// (set) Token: 0x0600000D RID: 13 RVA: 0x0000226C File Offset: 0x0000046C
	public global::Valve.VR.CVROverlay overlay { get; private set; }

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x0600000E RID: 14 RVA: 0x00002275 File Offset: 0x00000475
	// (set) Token: 0x0600000F RID: 15 RVA: 0x0000227C File Offset: 0x0000047C
	public static bool initializing { get; private set; }

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000010 RID: 16 RVA: 0x00002284 File Offset: 0x00000484
	// (set) Token: 0x06000011 RID: 17 RVA: 0x0000228B File Offset: 0x0000048B
	public static bool calibrating { get; private set; }

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000012 RID: 18 RVA: 0x00002293 File Offset: 0x00000493
	// (set) Token: 0x06000013 RID: 19 RVA: 0x0000229A File Offset: 0x0000049A
	public static bool outOfRange { get; private set; }

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x06000014 RID: 20 RVA: 0x000022A2 File Offset: 0x000004A2
	// (set) Token: 0x06000015 RID: 21 RVA: 0x000022AA File Offset: 0x000004AA
	public float sceneWidth { get; private set; }

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000016 RID: 22 RVA: 0x000022B3 File Offset: 0x000004B3
	// (set) Token: 0x06000017 RID: 23 RVA: 0x000022BB File Offset: 0x000004BB
	public float sceneHeight { get; private set; }

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x06000018 RID: 24 RVA: 0x000022C4 File Offset: 0x000004C4
	// (set) Token: 0x06000019 RID: 25 RVA: 0x000022CC File Offset: 0x000004CC
	public float aspect { get; private set; }

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x0600001A RID: 26 RVA: 0x000022D5 File Offset: 0x000004D5
	// (set) Token: 0x0600001B RID: 27 RVA: 0x000022DD File Offset: 0x000004DD
	public float fieldOfView { get; private set; }

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x0600001C RID: 28 RVA: 0x000022E6 File Offset: 0x000004E6
	// (set) Token: 0x0600001D RID: 29 RVA: 0x000022EE File Offset: 0x000004EE
	public global::UnityEngine.Vector2 tanHalfFov { get; private set; }

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x0600001E RID: 30 RVA: 0x000022F7 File Offset: 0x000004F7
	// (set) Token: 0x0600001F RID: 31 RVA: 0x000022FF File Offset: 0x000004FF
	public global::Valve.VR.VRTextureBounds_t[] textureBounds { get; private set; }

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x06000020 RID: 32 RVA: 0x00002308 File Offset: 0x00000508
	// (set) Token: 0x06000021 RID: 33 RVA: 0x00002310 File Offset: 0x00000510
	public global::SteamVR_Utils.RigidTransform[] eyes { get; private set; }

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x06000022 RID: 34 RVA: 0x0000231C File Offset: 0x0000051C
	public string hmd_TrackingSystemName
	{
		get
		{
			return this.GetStringProperty(global::Valve.VR.ETrackedDeviceProperty.Prop_TrackingSystemName_String);
		}
	}

	// Token: 0x17000013 RID: 19
	// (get) Token: 0x06000023 RID: 35 RVA: 0x0000233C File Offset: 0x0000053C
	public string hmd_ModelNumber
	{
		get
		{
			return this.GetStringProperty(global::Valve.VR.ETrackedDeviceProperty.Prop_ModelNumber_String);
		}
	}

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x06000024 RID: 36 RVA: 0x0000235C File Offset: 0x0000055C
	public string hmd_SerialNumber
	{
		get
		{
			return this.GetStringProperty(global::Valve.VR.ETrackedDeviceProperty.Prop_SerialNumber_String);
		}
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x06000025 RID: 37 RVA: 0x0000237C File Offset: 0x0000057C
	public float hmd_SecondsFromVsyncToPhotons
	{
		get
		{
			return this.GetFloatProperty(global::Valve.VR.ETrackedDeviceProperty.Prop_SecondsFromVsyncToPhotons_Float);
		}
	}

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x06000026 RID: 38 RVA: 0x0000239C File Offset: 0x0000059C
	public float hmd_DisplayFrequency
	{
		get
		{
			return this.GetFloatProperty(global::Valve.VR.ETrackedDeviceProperty.Prop_DisplayFrequency_Float);
		}
	}

	// Token: 0x06000027 RID: 39 RVA: 0x000023BC File Offset: 0x000005BC
	public string GetTrackedDeviceString(uint deviceId)
	{
		global::Valve.VR.ETrackedPropertyError etrackedPropertyError = global::Valve.VR.ETrackedPropertyError.TrackedProp_Success;
		uint stringTrackedDeviceProperty = this.hmd.GetStringTrackedDeviceProperty(deviceId, global::Valve.VR.ETrackedDeviceProperty.Prop_AttachedDeviceId_String, null, 0U, ref etrackedPropertyError);
		bool flag = stringTrackedDeviceProperty > 1U;
		string result;
		if (flag)
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder((int)stringTrackedDeviceProperty);
			this.hmd.GetStringTrackedDeviceProperty(deviceId, global::Valve.VR.ETrackedDeviceProperty.Prop_AttachedDeviceId_String, stringBuilder, stringTrackedDeviceProperty, ref etrackedPropertyError);
			result = stringBuilder.ToString();
		}
		else
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000028 RID: 40 RVA: 0x0000241C File Offset: 0x0000061C
	private string GetStringProperty(global::Valve.VR.ETrackedDeviceProperty prop)
	{
		global::Valve.VR.ETrackedPropertyError etrackedPropertyError = global::Valve.VR.ETrackedPropertyError.TrackedProp_Success;
		uint stringTrackedDeviceProperty = this.hmd.GetStringTrackedDeviceProperty(0U, prop, null, 0U, ref etrackedPropertyError);
		bool flag = stringTrackedDeviceProperty > 1U;
		string result;
		if (flag)
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder((int)stringTrackedDeviceProperty);
			this.hmd.GetStringTrackedDeviceProperty(0U, prop, stringBuilder, stringTrackedDeviceProperty, ref etrackedPropertyError);
			result = stringBuilder.ToString();
		}
		else
		{
			result = ((etrackedPropertyError != global::Valve.VR.ETrackedPropertyError.TrackedProp_Success) ? etrackedPropertyError.ToString() : "<unknown>");
		}
		return result;
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00002488 File Offset: 0x00000688
	public float GetFloatProperty(global::Valve.VR.ETrackedDeviceProperty prop)
	{
		global::Valve.VR.ETrackedPropertyError etrackedPropertyError = global::Valve.VR.ETrackedPropertyError.TrackedProp_Success;
		return this.hmd.GetFloatTrackedDeviceProperty(0U, prop, ref etrackedPropertyError);
	}

	// Token: 0x0600002A RID: 42 RVA: 0x000024AB File Offset: 0x000006AB
	private void OnInitializing(params object[] args)
	{
		global::SteamVR.initializing = (bool)args[0];
	}

	// Token: 0x0600002B RID: 43 RVA: 0x000024BC File Offset: 0x000006BC
	private void OnCalibrating(params object[] args)
	{
		global::SteamVR.calibrating = (bool)args[0];
	}

	// Token: 0x0600002C RID: 44 RVA: 0x000024CD File Offset: 0x000006CD
	private void OnOutOfRange(params object[] args)
	{
		global::SteamVR.outOfRange = (bool)args[0];
	}

	// Token: 0x0600002D RID: 45 RVA: 0x000024E0 File Offset: 0x000006E0
	private void OnDeviceConnected(params object[] args)
	{
		int num = (int)args[0];
		global::SteamVR.connected[num] = (bool)args[1];
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00002508 File Offset: 0x00000708
	private void OnNewPoses(params object[] args)
	{
		global::Valve.VR.TrackedDevicePose_t[] array = (global::Valve.VR.TrackedDevicePose_t[])args[0];
		this.eyes[0] = new global::SteamVR_Utils.RigidTransform(this.hmd.GetEyeToHeadTransform(global::Valve.VR.EVREye.Eye_Left));
		this.eyes[1] = new global::SteamVR_Utils.RigidTransform(this.hmd.GetEyeToHeadTransform(global::Valve.VR.EVREye.Eye_Right));
		for (int i = 0; i < array.Length; i++)
		{
			bool bDeviceIsConnected = array[i].bDeviceIsConnected;
			bool flag = bDeviceIsConnected != global::SteamVR.connected[i];
			if (flag)
			{
				global::SteamVR_Utils.Event.Send("device_connected", new object[]
				{
					i,
					bDeviceIsConnected
				});
			}
		}
		bool flag2 = (long)array.Length > 0L;
		if (flag2)
		{
			global::Valve.VR.ETrackingResult eTrackingResult = array[0].eTrackingResult;
			bool flag3 = eTrackingResult == global::Valve.VR.ETrackingResult.Uninitialized;
			bool flag4 = flag3 != global::SteamVR.initializing;
			if (flag4)
			{
				global::SteamVR_Utils.Event.Send("initializing", new object[]
				{
					flag3
				});
			}
			bool flag5 = eTrackingResult == global::Valve.VR.ETrackingResult.Calibrating_InProgress || eTrackingResult == global::Valve.VR.ETrackingResult.Calibrating_OutOfRange;
			bool flag6 = flag5 != global::SteamVR.calibrating;
			if (flag6)
			{
				global::SteamVR_Utils.Event.Send("calibrating", new object[]
				{
					flag5
				});
			}
			bool flag7 = eTrackingResult == global::Valve.VR.ETrackingResult.Running_OutOfRange || eTrackingResult == global::Valve.VR.ETrackingResult.Calibrating_OutOfRange;
			bool flag8 = flag7 != global::SteamVR.outOfRange;
			if (flag8)
			{
				global::SteamVR_Utils.Event.Send("out_of_range", new object[]
				{
					flag7
				});
			}
		}
	}

	// Token: 0x0600002F RID: 47 RVA: 0x0000268C File Offset: 0x0000088C
	private SteamVR()
	{
		this.hmd = global::Valve.VR.OpenVR.System;
		global::UnityEngine.Debug.Log("Connected to " + this.hmd_TrackingSystemName + ":" + this.hmd_SerialNumber);
		this.compositor = global::Valve.VR.OpenVR.Compositor;
		this.overlay = global::Valve.VR.OpenVR.Overlay;
		uint num = 0U;
		uint num2 = 0U;
		this.hmd.GetRecommendedRenderTargetSize(ref num, ref num2);
		this.sceneWidth = num;
		this.sceneHeight = num2;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		this.hmd.GetProjectionRaw(global::Valve.VR.EVREye.Eye_Left, ref num3, ref num4, ref num5, ref num6);
		float num7 = 0f;
		float num8 = 0f;
		float num9 = 0f;
		float num10 = 0f;
		this.hmd.GetProjectionRaw(global::Valve.VR.EVREye.Eye_Right, ref num7, ref num8, ref num9, ref num10);
		this.tanHalfFov = new global::UnityEngine.Vector2(global::UnityEngine.Mathf.Max(new float[]
		{
			-num3,
			num4,
			-num7,
			num8
		}), global::UnityEngine.Mathf.Max(new float[]
		{
			-num5,
			num6,
			-num9,
			num10
		}));
		this.textureBounds = new global::Valve.VR.VRTextureBounds_t[2];
		this.textureBounds[0].uMin = 0.5f + 0.5f * num3 / this.tanHalfFov.x;
		this.textureBounds[0].uMax = 0.5f + 0.5f * num4 / this.tanHalfFov.x;
		this.textureBounds[0].vMin = 0.5f - 0.5f * num6 / this.tanHalfFov.y;
		this.textureBounds[0].vMax = 0.5f - 0.5f * num5 / this.tanHalfFov.y;
		this.textureBounds[1].uMin = 0.5f + 0.5f * num7 / this.tanHalfFov.x;
		this.textureBounds[1].uMax = 0.5f + 0.5f * num8 / this.tanHalfFov.x;
		this.textureBounds[1].vMin = 0.5f - 0.5f * num10 / this.tanHalfFov.y;
		this.textureBounds[1].vMax = 0.5f - 0.5f * num9 / this.tanHalfFov.y;
		global::SteamVR.Unity.SetSubmitParams(this.textureBounds[0], this.textureBounds[1], global::Valve.VR.EVRSubmitFlags.Submit_Default);
		this.sceneWidth /= global::UnityEngine.Mathf.Max(this.textureBounds[0].uMax - this.textureBounds[0].uMin, this.textureBounds[1].uMax - this.textureBounds[1].uMin);
		this.sceneHeight /= global::UnityEngine.Mathf.Max(this.textureBounds[0].vMax - this.textureBounds[0].vMin, this.textureBounds[1].vMax - this.textureBounds[1].vMin);
		this.aspect = this.tanHalfFov.x / this.tanHalfFov.y;
		this.fieldOfView = 2f * global::UnityEngine.Mathf.Atan(this.tanHalfFov.y) * 57.29578f;
		this.eyes = new global::SteamVR_Utils.RigidTransform[]
		{
			new global::SteamVR_Utils.RigidTransform(this.hmd.GetEyeToHeadTransform(global::Valve.VR.EVREye.Eye_Left)),
			new global::SteamVR_Utils.RigidTransform(this.hmd.GetEyeToHeadTransform(global::Valve.VR.EVREye.Eye_Right))
		};
		bool flag = global::UnityEngine.SystemInfo.graphicsDeviceVersion.StartsWith("OpenGL");
		if (flag)
		{
			this.graphicsAPI = global::Valve.VR.EGraphicsAPIConvention.API_OpenGL;
		}
		else
		{
			this.graphicsAPI = global::Valve.VR.EGraphicsAPIConvention.API_DirectX;
		}
		global::SteamVR_Utils.Event.Listen("initializing", new global::SteamVR_Utils.Event.Handler(this.OnInitializing));
		global::SteamVR_Utils.Event.Listen("calibrating", new global::SteamVR_Utils.Event.Handler(this.OnCalibrating));
		global::SteamVR_Utils.Event.Listen("out_of_range", new global::SteamVR_Utils.Event.Handler(this.OnOutOfRange));
		global::SteamVR_Utils.Event.Listen("device_connected", new global::SteamVR_Utils.Event.Handler(this.OnDeviceConnected));
		global::SteamVR_Utils.Event.Listen("new_poses", new global::SteamVR_Utils.Event.Handler(this.OnNewPoses));
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00002B04 File Offset: 0x00000D04
	~SteamVR()
	{
		this.Dispose(false);
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00002B38 File Offset: 0x00000D38
	public void Dispose()
	{
		this.Dispose(true);
		global::System.GC.SuppressFinalize(this);
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00002B4C File Offset: 0x00000D4C
	private void Dispose(bool disposing)
	{
		global::SteamVR_Utils.Event.Remove("initializing", new global::SteamVR_Utils.Event.Handler(this.OnInitializing));
		global::SteamVR_Utils.Event.Remove("calibrating", new global::SteamVR_Utils.Event.Handler(this.OnCalibrating));
		global::SteamVR_Utils.Event.Remove("out_of_range", new global::SteamVR_Utils.Event.Handler(this.OnOutOfRange));
		global::SteamVR_Utils.Event.Remove("device_connected", new global::SteamVR_Utils.Event.Handler(this.OnDeviceConnected));
		global::SteamVR_Utils.Event.Remove("new_poses", new global::SteamVR_Utils.Event.Handler(this.OnNewPoses));
		global::SteamVR.ShutdownSystems();
		global::SteamVR._instance = null;
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00002BD9 File Offset: 0x00000DD9
	private static void ShutdownSystems()
	{
		global::Valve.VR.OpenVR.Shutdown();
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00002BE4 File Offset: 0x00000DE4
	public static void SafeDispose()
	{
		bool flag = global::SteamVR._instance != null;
		if (flag)
		{
			global::SteamVR._instance.Dispose();
		}
	}

	// Token: 0x04000001 RID: 1
	private static bool _enabled = true;

	// Token: 0x04000002 RID: 2
	private static global::SteamVR _instance;

	// Token: 0x04000009 RID: 9
	public static bool[] connected = new bool[16];

	// Token: 0x04000011 RID: 17
	public global::Valve.VR.EGraphicsAPIConvention graphicsAPI;

	// Token: 0x020000F5 RID: 245
	public class Unity
	{
		// Token: 0x06000637 RID: 1591
		[global::System.Runtime.InteropServices.DllImport("openvr_api", EntryPoint = "UnityHooks_GetRenderEventFunc")]
		public static extern global::System.IntPtr GetRenderEventFunc();

		// Token: 0x06000638 RID: 1592
		[global::System.Runtime.InteropServices.DllImport("openvr_api", EntryPoint = "UnityHooks_SetSubmitParams")]
		public static extern void SetSubmitParams(global::Valve.VR.VRTextureBounds_t boundsL, global::Valve.VR.VRTextureBounds_t boundsR, global::Valve.VR.EVRSubmitFlags nSubmitFlags);

		// Token: 0x06000639 RID: 1593
		[global::System.Runtime.InteropServices.DllImport("openvr_api", EntryPoint = "UnityHooks_SetColorSpace")]
		public static extern void SetColorSpace(global::Valve.VR.EColorSpace eColorSpace);

		// Token: 0x0600063A RID: 1594
		[global::System.Runtime.InteropServices.DllImport("openvr_api", EntryPoint = "UnityHooks_EventWriteString")]
		public static extern void EventWriteString([global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.MarshalAs(21)] string sEvent);

		// Token: 0x040006A2 RID: 1698
		public const int k_nRenderEventID_WaitGetPoses = 201510020;

		// Token: 0x040006A3 RID: 1699
		public const int k_nRenderEventID_SubmitL = 201510021;

		// Token: 0x040006A4 RID: 1700
		public const int k_nRenderEventID_SubmitR = 201510022;

		// Token: 0x040006A5 RID: 1701
		public const int k_nRenderEventID_Flush = 201510023;

		// Token: 0x040006A6 RID: 1702
		public const int k_nRenderEventID_PostPresentHandoff = 201510024;
	}
}

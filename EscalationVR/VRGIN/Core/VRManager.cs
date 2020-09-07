using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using VRGIN.Controls.Speech;
using VRGIN.Modes;
using WindowsInput;

namespace VRGIN.Core
{
	// Token: 0x020000B3 RID: 179
	public class VRManager : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x000134C8 File Offset: 0x000116C8
		public static global::VRGIN.Core.VRManager Instance
		{
			get
			{
				bool flag = global::VRGIN.Core.VRManager._Instance == null;
				if (flag)
				{
					throw new global::System.InvalidOperationException("VR Manager has not been created yet!");
				}
				return global::VRGIN.Core.VRManager._Instance;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x000134FA File Offset: 0x000116FA
		// (set) Token: 0x060003B6 RID: 950 RVA: 0x00013502 File Offset: 0x00011702
		public global::VRGIN.Core.IVRManagerContext Context { get; private set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x0001350B File Offset: 0x0001170B
		// (set) Token: 0x060003B8 RID: 952 RVA: 0x00013513 File Offset: 0x00011713
		public global::VRGIN.Core.GameInterpreter Interpreter { get; private set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060003B9 RID: 953 RVA: 0x0001351C File Offset: 0x0001171C
		// (set) Token: 0x060003BA RID: 954 RVA: 0x00013524 File Offset: 0x00011724
		public global::VRGIN.Controls.Speech.SpeechManager Speech { get; private set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060003BB RID: 955 RVA: 0x0001352D File Offset: 0x0001172D
		// (set) Token: 0x060003BC RID: 956 RVA: 0x00013535 File Offset: 0x00011735
		public global::VRGIN.Core.HMDType HMD { get; private set; }

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060003BD RID: 957 RVA: 0x00013540 File Offset: 0x00011740
		// (remove) Token: 0x060003BE RID: 958 RVA: 0x00013578 File Offset: 0x00011778
		[global::System.Diagnostics.DebuggerBrowsable(0)]
		public event global::System.EventHandler<global::VRGIN.Core.ModeInitializedEventArgs> ModeInitialized = delegate(object <p0>, global::VRGIN.Core.ModeInitializedEventArgs <p1>)
		{
		};

		// Token: 0x060003BF RID: 959 RVA: 0x000135B0 File Offset: 0x000117B0
		public static global::VRGIN.Core.VRManager Create<T>(global::VRGIN.Core.IVRManagerContext context) where T : global::VRGIN.Core.GameInterpreter
		{
			bool flag = global::VRGIN.Core.VRManager._Instance == null;
			if (flag)
			{
				global::VRGIN.Core.VR.Active = true;
				global::VRGIN.Core.VRManager._Instance = new global::UnityEngine.GameObject("VRGIN_Manager").AddComponent<global::VRGIN.Core.VRManager>();
				global::VRGIN.Core.VRManager._Instance.Context = context;
				global::VRGIN.Core.VRManager._Instance.Interpreter = global::VRGIN.Core.VRManager._Instance.gameObject.AddComponent<T>();
				global::VRGIN.Core.VRManager._Instance._Gui = global::VRGIN.Core.VRGUI.Instance;
				global::VRGIN.Core.VRManager._Instance.Input = new global::WindowsInput.InputSimulator();
				bool speechRecognition = global::VRGIN.Core.VR.Settings.SpeechRecognition;
				if (speechRecognition)
				{
					global::VRGIN.Core.VRManager._Instance.Speech = global::VRGIN.Core.VRManager._Instance.gameObject.AddComponent<global::VRGIN.Controls.Speech.SpeechManager>();
				}
				global::VRGIN.Core.VR.Settings.Save();
			}
			return global::VRGIN.Core.VRManager._Instance;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00013678 File Offset: 0x00011878
		public void SetMode<T>() where T : global::VRGIN.Modes.ControlMode
		{
			bool flag = this.Mode == null || !(this.Mode is T);
			if (flag)
			{
				global::VRGIN.Core.VRManager.ModeType = typeof(T);
				bool flag2 = this.Mode != null;
				if (flag2)
				{
					this.Mode.ControllersCreated -= new global::System.EventHandler<global::System.EventArgs>(this.OnControllersCreated);
					global::UnityEngine.Object.DestroyImmediate(this.Mode);
				}
				this.Mode = global::VRGIN.Core.VRCamera.Instance.gameObject.AddComponent<T>();
				this.Mode.ControllersCreated += new global::System.EventHandler<global::System.EventArgs>(this.OnControllersCreated);
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x00013726 File Offset: 0x00011926
		// (set) Token: 0x060003C2 RID: 962 RVA: 0x0001372E File Offset: 0x0001192E
		public global::VRGIN.Modes.ControlMode Mode { get; private set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x00013737 File Offset: 0x00011937
		// (set) Token: 0x060003C4 RID: 964 RVA: 0x0001373F File Offset: 0x0001193F
		public global::WindowsInput.InputSimulator Input { get; internal set; }

		// Token: 0x060003C5 RID: 965 RVA: 0x00013748 File Offset: 0x00011948
		protected override void OnAwake()
		{
			string hmd_TrackingSystemName = global::SteamVR.instance.hmd_TrackingSystemName;
			global::VRGIN.Core.VRLog.Info("------------------------------------", global::System.Array.Empty<object>());
			global::VRGIN.Core.VRLog.Info(" Booting VR [{0}]", new object[]
			{
				hmd_TrackingSystemName
			});
			global::VRGIN.Core.VRLog.Info("------------------------------------", global::System.Array.Empty<object>());
			this.HMD = ((hmd_TrackingSystemName == "oculus") ? global::VRGIN.Core.HMDType.Oculus : ((hmd_TrackingSystemName == "lighthouse") ? global::VRGIN.Core.HMDType.Vive : global::VRGIN.Core.HMDType.Other));
			global::UnityEngine.Application.targetFrameRate = 90;
			global::UnityEngine.Time.fixedDeltaTime = 0.0111111114f;
			global::UnityEngine.Application.runInBackground = true;
			global::UnityEngine.Object.DontDestroyOnLoad(global::SteamVR_Render.instance.gameObject);
			global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x000137F4 File Offset: 0x000119F4
		protected override void OnStart()
		{
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x000137F7 File Offset: 0x000119F7
		protected override void OnLevel(int level)
		{
			this._CheckedCameras.Clear();
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00013808 File Offset: 0x00011A08
		protected override void OnUpdate()
		{
			foreach (global::UnityEngine.Camera camera in global::System.Linq.Enumerable.ToList<global::UnityEngine.Camera>(global::System.Linq.Enumerable.Except<global::UnityEngine.Camera>(global::UnityEngine.Camera.allCameras, this._CheckedCameras)))
			{
				this._CheckedCameras.Add(camera);
				global::VRGIN.Core.CameraJudgement cameraJudgement = global::VRGIN.Core.VR.Interpreter.JudgeCamera(camera);
				global::VRGIN.Core.VRLog.Info("Detected new camera {0} Action: {1}", new object[]
				{
					camera.name,
					cameraJudgement
				});
				switch (cameraJudgement)
				{
				case global::VRGIN.Core.CameraJudgement.SubCamera:
					global::VRGIN.Core.VR.Camera.Copy(camera, false, false);
					break;
				case global::VRGIN.Core.CameraJudgement.MainCamera:
					global::VRGIN.Core.VR.Camera.Copy(camera, true, false);
					break;
				case global::VRGIN.Core.CameraJudgement.GUI:
					global::VRGIN.Core.VR.GUI.AddCamera(camera);
					break;
				case global::VRGIN.Core.CameraJudgement.GUIAndCamera:
					global::VRGIN.Core.VR.Camera.Copy(camera, false, true);
					global::VRGIN.Core.VR.GUI.AddCamera(camera);
					break;
				}
			}
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00013918 File Offset: 0x00011B18
		private void OnControllersCreated(object sender, global::System.EventArgs e)
		{
			this.ModeInitialized.Invoke(this, new global::VRGIN.Core.ModeInitializedEventArgs(this.Mode));
		}

		// Token: 0x0400059E RID: 1438
		private global::VRGIN.Core.VRGUI _Gui;

		// Token: 0x0400059F RID: 1439
		private bool _CameraLoaded = false;

		// Token: 0x040005A0 RID: 1440
		private static global::VRGIN.Core.VRManager _Instance;

		// Token: 0x040005A6 RID: 1446
		private global::System.Collections.Generic.HashSet<global::UnityEngine.Camera> _CheckedCameras = new global::System.Collections.Generic.HashSet<global::UnityEngine.Camera>();

		// Token: 0x040005A9 RID: 1449
		private static global::System.Type ModeType;
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Valve.VR;
using VRGIN.Controls;
using VRGIN.Controls.Speech;
using VRGIN.Core;
using VRGIN.Helpers;
using VRGIN.Visuals;

namespace VRGIN.Modes
{
	// Token: 0x02000094 RID: 148
	public abstract class ControlMode : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x06000278 RID: 632 RVA: 0x0000F33D File Offset: 0x0000D53D
		public virtual void Impersonate(global::VRGIN.Core.IActor actor)
		{
			this.Impersonate(actor, global::VRGIN.Modes.ImpersonationMode.Approximately);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000F34C File Offset: 0x0000D54C
		public virtual void Impersonate(global::VRGIN.Core.IActor actor, global::VRGIN.Modes.ImpersonationMode mode)
		{
			bool flag = actor != null;
			if (flag)
			{
				actor.HasHead = false;
			}
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000F36C File Offset: 0x0000D56C
		public virtual void MoveToPosition(global::UnityEngine.Vector3 targetPosition, bool ignoreHeight = true)
		{
			this.MoveToPosition(targetPosition, global::VRGIN.Core.VR.Camera.SteamCam.head.rotation, ignoreHeight);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000F38C File Offset: 0x0000D58C
		public virtual void MoveToPosition(global::UnityEngine.Vector3 targetPosition, global::UnityEngine.Quaternion rotation = default(global::UnityEngine.Quaternion), bool ignoreHeight = true)
		{
			this.ApplyRotation(rotation);
			float num = ignoreHeight ? 0f : targetPosition.y;
			float num2 = ignoreHeight ? 0f : global::VRGIN.Core.VR.Camera.SteamCam.head.position.y;
			targetPosition..ctor(targetPosition.x, num, targetPosition.z);
			global::UnityEngine.Vector3 vector;
			vector..ctor(global::VRGIN.Core.VR.Camera.SteamCam.head.position.x, num2, global::VRGIN.Core.VR.Camera.SteamCam.head.position.z);
			global::VRGIN.Core.VR.Camera.SteamCam.origin.position += targetPosition - vector;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000F44C File Offset: 0x0000D64C
		public virtual void ApplyRotation(global::UnityEngine.Quaternion rotation)
		{
			global::UnityEngine.Vector3 forwardVector = global::VRGIN.Helpers.Calculator.GetForwardVector(rotation);
			global::UnityEngine.Vector3 forwardVector2 = global::VRGIN.Helpers.Calculator.GetForwardVector(global::VRGIN.Core.VR.Camera.SteamCam.head.rotation);
			bool flag = global::UnityEngine.Vector3.Dot(forwardVector, forwardVector2) < 0.99f;
			if (flag)
			{
				global::VRGIN.Core.VR.Camera.SteamCam.origin.rotation *= global::UnityEngine.Quaternion.FromToRotation(forwardVector2, forwardVector);
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600027D RID: 637
		public abstract global::Valve.VR.ETrackingUniverseOrigin TrackingOrigin { get; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600027E RID: 638 RVA: 0x0000F4B6 File Offset: 0x0000D6B6
		// (set) Token: 0x0600027F RID: 639 RVA: 0x0000F4BE File Offset: 0x0000D6BE
		public global::VRGIN.Controls.Controller Left { get; private set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000280 RID: 640 RVA: 0x0000F4C7 File Offset: 0x0000D6C7
		// (set) Token: 0x06000281 RID: 641 RVA: 0x0000F4CF File Offset: 0x0000D6CF
		public global::VRGIN.Controls.Controller Right { get; private set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000282 RID: 642 RVA: 0x0000F4D8 File Offset: 0x0000D6D8
		// (set) Token: 0x06000283 RID: 643 RVA: 0x0000F4E0 File Offset: 0x0000D6E0
		private protected global::System.Collections.Generic.IEnumerable<global::VRGIN.Controls.IShortcut> Shortcuts { protected get; private set; }

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000284 RID: 644 RVA: 0x0000F4EC File Offset: 0x0000D6EC
		// (remove) Token: 0x06000285 RID: 645 RVA: 0x0000F524 File Offset: 0x0000D724
		[global::System.Diagnostics.DebuggerBrowsable(0)]
		internal event global::System.EventHandler<global::System.EventArgs> ControllersCreated = delegate(object <p0>, global::System.EventArgs <p1>)
		{
		};

		// Token: 0x06000286 RID: 646 RVA: 0x0000F559 File Offset: 0x0000D759
		protected override void OnStart()
		{
			this.CreateControllers();
			this.Shortcuts = this.CreateShortcuts();
			global::SteamVR_Render.instance.trackingSpace = this.TrackingOrigin;
			this.InitializeScreenCapture();
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000F587 File Offset: 0x0000D787
		protected virtual void OnEnable()
		{
			global::SteamVR_Utils.Event.Listen("device_connected", new global::SteamVR_Utils.Event.Handler(this.OnDeviceConnected));
			global::VRGIN.Core.VRLog.Info("Enabled {0}", new object[]
			{
				base.GetType().Name
			});
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000F5C0 File Offset: 0x0000D7C0
		protected virtual void OnDisable()
		{
			global::VRGIN.Core.VRLog.Info("Disabled {0}", new object[]
			{
				base.GetType().Name
			});
			global::SteamVR_Utils.Event.Listen("device_connected", new global::SteamVR_Utils.Event.Handler(this.OnDeviceConnected));
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000F5FC File Offset: 0x0000D7FC
		protected virtual void CreateControllers()
		{
			global::SteamVR_Camera steamCam = global::VRGIN.Core.VR.Camera.SteamCam;
			steamCam.origin.gameObject.SetActive(false);
			this.ControllerManager = steamCam.origin.gameObject.AddComponent<global::SteamVR_ControllerManager>();
			this.Left = this.CreateLeftController();
			this.Left.transform.SetParent(steamCam.origin, false);
			this.Right = this.CreateRightController();
			this.Right.transform.SetParent(steamCam.origin, false);
			this.Left.Other = this.Right;
			this.Right.Other = this.Left;
			this.ControllerManager.left = this.Left.gameObject;
			this.ControllerManager.right = this.Right.gameObject;
			steamCam.origin.gameObject.SetActive(true);
			global::VRGIN.Core.VRLog.Info("---- Initialize left tools", global::System.Array.Empty<object>());
			this.InitializeTools(this.Left, true);
			global::VRGIN.Core.VRLog.Info("---- Initialize right tools", global::System.Array.Empty<object>());
			this.InitializeTools(this.Right, false);
			this.ControllersCreated.Invoke(this, new global::System.EventArgs());
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000F738 File Offset: 0x0000D938
		public virtual void OnDestroy()
		{
			global::UnityEngine.Object.Destroy(this.ControllerManager);
			global::UnityEngine.Object.Destroy(this.Left);
			global::UnityEngine.Object.Destroy(this.Right);
			bool flag = this.Shortcuts != null;
			if (flag)
			{
				foreach (global::VRGIN.Controls.IShortcut shortcut in this.Shortcuts)
				{
					shortcut.Dispose();
				}
			}
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000F7C0 File Offset: 0x0000D9C0
		protected virtual void InitializeTools(global::VRGIN.Controls.Controller controller, bool isLeft)
		{
			global::System.Collections.Generic.IEnumerable<global::System.Type> enumerable = global::System.Linq.Enumerable.Distinct<global::System.Type>(global::System.Linq.Enumerable.Concat<global::System.Type>(this.Tools, isLeft ? this.LeftTools : this.RightTools));
			foreach (global::System.Type toolType in enumerable)
			{
				controller.AddTool(toolType);
			}
			global::VRGIN.Core.VRLog.Info("{0} tools added", new object[]
			{
				global::System.Linq.Enumerable.Count<global::System.Type>(enumerable)
			});
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000F850 File Offset: 0x0000DA50
		protected virtual global::VRGIN.Controls.Controller CreateLeftController()
		{
			return global::VRGIN.Controls.LeftController.Create();
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000F868 File Offset: 0x0000DA68
		protected virtual global::VRGIN.Controls.Controller CreateRightController()
		{
			return global::VRGIN.Controls.RightController.Create();
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600028E RID: 654 RVA: 0x0000F880 File Offset: 0x0000DA80
		public virtual global::System.Collections.Generic.IEnumerable<global::System.Type> Tools
		{
			get
			{
				return new global::System.Collections.Generic.List<global::System.Type>();
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600028F RID: 655 RVA: 0x0000F898 File Offset: 0x0000DA98
		public virtual global::System.Collections.Generic.IEnumerable<global::System.Type> LeftTools
		{
			get
			{
				return new global::System.Collections.Generic.List<global::System.Type>();
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000290 RID: 656 RVA: 0x0000F8B0 File Offset: 0x0000DAB0
		public virtual global::System.Collections.Generic.IEnumerable<global::System.Type> RightTools
		{
			get
			{
				return new global::System.Collections.Generic.List<global::System.Type>();
			}
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000F8C8 File Offset: 0x0000DAC8
		protected virtual global::System.Collections.Generic.IEnumerable<global::VRGIN.Controls.IShortcut> CreateShortcuts()
		{
			global::System.Collections.Generic.List<global::VRGIN.Controls.IShortcut> list = new global::System.Collections.Generic.List<global::VRGIN.Controls.IShortcut>();
			list.Add(new global::VRGIN.Controls.KeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.ShrinkWorld, delegate()
			{
				global::VRGIN.Core.VR.Settings.IPDScale += global::UnityEngine.Time.deltaTime;
			}));
			list.Add(new global::VRGIN.Controls.KeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.EnlargeWorld, delegate()
			{
				global::VRGIN.Core.VR.Settings.IPDScale -= global::UnityEngine.Time.deltaTime;
			}));
			list.Add(new global::VRGIN.Controls.Speech.VoiceShortcut(global::VRGIN.Controls.Speech.VoiceCommand.DecreaseScale, delegate
			{
				global::VRGIN.Core.VR.Settings.IPDScale *= 1.2f;
			}));
			list.Add(new global::VRGIN.Controls.Speech.VoiceShortcut(global::VRGIN.Controls.Speech.VoiceCommand.IncreaseScale, delegate
			{
				global::VRGIN.Core.VR.Settings.IPDScale *= 0.8f;
			}));
			list.Add(new global::VRGIN.Controls.MultiKeyboardShortcut(new global::VRGIN.Helpers.KeyStroke("Ctrl + C"), new global::VRGIN.Helpers.KeyStroke("Ctrl + D"), delegate()
			{
				global::VRGIN.Helpers.UnityHelper.DumpScene("dump.json", false);
			}, global::VRGIN.Helpers.KeyMode.PressUp));
			list.Add(new global::VRGIN.Controls.MultiKeyboardShortcut(new global::VRGIN.Helpers.KeyStroke("Ctrl + C"), new global::VRGIN.Helpers.KeyStroke("Ctrl + I"), delegate()
			{
				global::VRGIN.Helpers.UnityHelper.DumpScene("dump.json", true);
			}, global::VRGIN.Helpers.KeyMode.PressUp));
			list.Add(new global::VRGIN.Controls.MultiKeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.ToggleUserCamera, new global::System.Action(this.ToggleUserCamera)));
			list.Add(new global::VRGIN.Controls.MultiKeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.SaveSettings, delegate()
			{
				global::VRGIN.Core.VR.Settings.Save();
			}));
			list.Add(new global::VRGIN.Controls.Speech.VoiceShortcut(global::VRGIN.Controls.Speech.VoiceCommand.SaveSettings, delegate
			{
				global::VRGIN.Core.VR.Settings.Save();
			}));
			list.Add(new global::VRGIN.Controls.KeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.LoadSettings, delegate()
			{
				global::VRGIN.Core.VR.Settings.Reload();
			}));
			list.Add(new global::VRGIN.Controls.Speech.VoiceShortcut(global::VRGIN.Controls.Speech.VoiceCommand.LoadSettings, delegate
			{
				global::VRGIN.Core.VR.Settings.Reload();
			}));
			list.Add(new global::VRGIN.Controls.KeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.ResetSettings, delegate()
			{
				global::VRGIN.Core.VR.Settings.Reset();
			}));
			list.Add(new global::VRGIN.Controls.Speech.VoiceShortcut(global::VRGIN.Controls.Speech.VoiceCommand.ResetSettings, delegate
			{
				global::VRGIN.Core.VR.Settings.Reset();
			}));
			list.Add(new global::VRGIN.Controls.Speech.VoiceShortcut(global::VRGIN.Controls.Speech.VoiceCommand.Impersonate, delegate
			{
				this.Impersonate(global::System.Linq.Enumerable.FirstOrDefault<global::VRGIN.Core.IActor>(global::VRGIN.Core.VR.Interpreter.Actors));
			}));
			list.Add(new global::VRGIN.Controls.KeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.ApplyEffects, delegate()
			{
				global::VRGIN.Core.VR.Camera.CopyFX(global::VRGIN.Core.VR.Camera.Blueprint);
			}));
			return list;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000FBD0 File Offset: 0x0000DDD0
		protected virtual void ToggleUserCamera()
		{
			bool flag = !global::VRGIN.Visuals.PlayerCamera.Created;
			if (flag)
			{
				global::VRGIN.Core.VRLog.Info("Create user camera", global::System.Array.Empty<object>());
				global::VRGIN.Visuals.PlayerCamera.Create();
			}
			else
			{
				global::VRGIN.Core.VRLog.Info("Remove user camera", global::System.Array.Empty<object>());
				global::VRGIN.Visuals.PlayerCamera.Remove();
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000FC1C File Offset: 0x0000DE1C
		protected virtual void InitializeScreenCapture()
		{
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000FC20 File Offset: 0x0000DE20
		protected override void OnUpdate()
		{
			base.OnUpdate();
			global::SteamVR_Render.instance.trackingSpace = this.TrackingOrigin;
			global::SteamVR_Camera steamCam = global::VRGIN.Core.VRCamera.Instance.SteamCam;
			int num = 0;
			bool isEveryoneHeaded = global::VRGIN.Core.VR.Interpreter.IsEveryoneHeaded;
			foreach (global::VRGIN.Core.IActor actor in global::VRGIN.Core.VR.Interpreter.Actors)
			{
				bool hasHead = actor.HasHead;
				if (hasHead)
				{
					bool flag = isEveryoneHeaded;
					if (flag)
					{
						global::UnityEngine.Vector3 position = actor.Eyes.position;
						global::UnityEngine.Vector3 forward = actor.Eyes.forward;
						global::UnityEngine.Vector3 position2 = steamCam.head.position;
						global::UnityEngine.Vector3 forward2 = steamCam.head.forward;
						global::VRGIN.Core.VRLog.Debug("Actor #{0} -- He: {1} -> {2} | Me: {3} -> {4}", new object[]
						{
							num,
							position,
							forward,
							position2,
							forward2
						});
						bool flag2 = global::UnityEngine.Vector3.Distance(position, position2) * global::VRGIN.Core.VR.Context.UnitToMeter < 0.15f && global::UnityEngine.Vector3.Dot(forward, forward2) > 0.6f;
						if (flag2)
						{
							actor.HasHead = false;
						}
					}
				}
				else
				{
					bool flag3 = global::UnityEngine.Vector3.Distance(actor.Eyes.position, steamCam.head.position) * global::VRGIN.Core.VR.Context.UnitToMeter > 0.3f;
					if (flag3)
					{
						actor.HasHead = true;
					}
				}
				num++;
			}
			this.CheckInput();
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000FDD8 File Offset: 0x0000DFD8
		protected void CheckInput()
		{
			foreach (global::VRGIN.Controls.IShortcut shortcut in this.Shortcuts)
			{
				shortcut.Evaluate();
			}
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000FE2C File Offset: 0x0000E02C
		private void OnDeviceConnected(object[] args)
		{
			bool flag = !global::VRGIN.Modes.ControlMode._ControllerFound;
			if (flag)
			{
				uint num = (uint)((int)args[0]);
				bool flag2 = (bool)args[1];
				global::VRGIN.Core.VRLog.Info("Device connected: {0}", new object[]
				{
					num
				});
				bool flag3 = flag2 && num > 0U;
				if (flag3)
				{
					global::Valve.VR.CVRSystem system = global::Valve.VR.OpenVR.System;
					bool flag4 = system != null && system.GetTrackedDeviceClass(num) == global::Valve.VR.ETrackedDeviceClass.Controller;
					if (flag4)
					{
						global::VRGIN.Modes.ControlMode._ControllerFound = true;
						this.ChangeModeOnControllersDetected();
					}
				}
			}
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000FEB2 File Offset: 0x0000E0B2
		protected virtual void ChangeModeOnControllersDetected()
		{
		}

		// Token: 0x0400053A RID: 1338
		private static bool _ControllerFound = false;

		// Token: 0x0400053E RID: 1342
		protected global::SteamVR_ControllerManager ControllerManager;

		// Token: 0x04000540 RID: 1344
		private static int cnter = 0;
	}
}

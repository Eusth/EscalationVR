using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Valve.VR;
using VRGIN.Controls;
using VRGIN.Controls.Tools;
using VRGIN.Core;
using VRGIN.Visuals;

namespace VRGIN.Modes
{
	// Token: 0x02000096 RID: 150
	public class SeatedMode : global::VRGIN.Modes.ControlMode
	{
		// Token: 0x0600029B RID: 667 RVA: 0x0000FF0C File Offset: 0x0000E10C
		protected override void OnStart()
		{
			base.OnStart();
			bool isFirstStart = global::VRGIN.Modes.SeatedMode._IsFirstStart;
			if (isFirstStart)
			{
				global::VRGIN.Core.VR.Camera.SteamCam.origin.transform.position = new global::UnityEngine.Vector3(0f, 0f, 0f);
				this.Recenter();
				global::VRGIN.Modes.SeatedMode._IsFirstStart = false;
			}
			this.Monitor = global::VRGIN.Visuals.GUIMonitor.Create();
			this.Monitor.transform.SetParent(global::VRGIN.Core.VR.Camera.SteamCam.origin, false);
			global::Valve.VR.OpenVR.ChaperoneSetup.SetWorkingPlayAreaSize(1000f, 1000f);
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000FFA8 File Offset: 0x0000E1A8
		protected override void OnEnable()
		{
			base.OnEnable();
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000FFB2 File Offset: 0x0000E1B2
		protected override void OnDisable()
		{
			base.OnDisable();
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000FFBC File Offset: 0x0000E1BC
		protected override void OnUpdate()
		{
			base.OnUpdate();
			this.ApplyCameraPose();
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000FFD0 File Offset: 0x0000E1D0
		protected virtual void ApplyCameraPose()
		{
			bool flag = global::VRGIN.Core.VR.Camera.HasValidBlueprint && global::VRGIN.Core.VR.Camera.Blueprint;
			if (flag)
			{
				bool flag2 = this.LockTarget != null && this.LockTarget.IsValid;
				if (flag2)
				{
					global::VRGIN.Core.VR.Camera.Blueprint.transform.position = this.LockTarget.Eyes.position;
					bool flag3 = this.LockMode == global::VRGIN.Modes.ImpersonationMode.Approximately;
					if (flag3)
					{
						global::VRGIN.Core.VR.Camera.Blueprint.transform.eulerAngles = new global::UnityEngine.Vector3(0f, this.LockTarget.Eyes.rotation.eulerAngles.y, 0f);
					}
					else
					{
						global::VRGIN.Core.VR.Camera.Blueprint.transform.rotation = this.LockTarget.Eyes.rotation;
					}
				}
				global::VRGIN.Core.VR.Camera.SteamCam.origin.transform.position = global::VRGIN.Core.VR.Camera.Blueprint.transform.position;
				bool flag4 = global::VRGIN.Core.VR.Settings.PitchLock && this.LockTarget == null;
				if (flag4)
				{
					global::VRGIN.Core.VR.Camera.SteamCam.origin.transform.eulerAngles = new global::UnityEngine.Vector3(0f, global::VRGIN.Core.VR.Camera.Blueprint.transform.eulerAngles.y, 0f);
					this.CorrectRotationLock();
				}
				else
				{
					global::VRGIN.Core.VR.Camera.SteamCam.origin.transform.rotation = global::VRGIN.Core.VR.Camera.Blueprint.transform.rotation;
				}
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0001018B File Offset: 0x0000E38B
		protected virtual void SyncCameras()
		{
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0001018E File Offset: 0x0000E38E
		protected virtual void CorrectRotationLock()
		{
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00010191 File Offset: 0x0000E391
		public override void Impersonate(global::VRGIN.Core.IActor actor, global::VRGIN.Modes.ImpersonationMode mode)
		{
			base.Impersonate(actor, mode);
			this.SyncCameras();
			this.LockTarget = actor;
			this.LockMode = mode;
			this.Recenter();
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x000101B9 File Offset: 0x0000E3B9
		public override void OnDestroy()
		{
			base.OnDestroy();
			global::UnityEngine.Object.Destroy(this.Monitor.gameObject);
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x000101D4 File Offset: 0x0000E3D4
		public override global::System.Collections.Generic.IEnumerable<global::System.Type> Tools
		{
			get
			{
				return global::System.Linq.Enumerable.Concat<global::System.Type>(base.Tools, new global::System.Type[]
				{
					typeof(global::VRGIN.Controls.Tools.MenuTool)
				});
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x00010204 File Offset: 0x0000E404
		public override global::Valve.VR.ETrackingUniverseOrigin TrackingOrigin
		{
			get
			{
				return global::Valve.VR.ETrackingUniverseOrigin.TrackingUniverseSeated;
			}
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00010218 File Offset: 0x0000E418
		protected override global::System.Collections.Generic.IEnumerable<global::VRGIN.Controls.IShortcut> CreateShortcuts()
		{
			global::System.Collections.Generic.List<global::VRGIN.Controls.IShortcut> list = new global::System.Collections.Generic.List<global::VRGIN.Controls.IShortcut>();
			list.Add(new global::VRGIN.Controls.KeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.GUIRaise, this.MoveGUI(0.1f)));
			list.Add(new global::VRGIN.Controls.KeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.GUILower, this.MoveGUI(-0.1f)));
			list.Add(new global::VRGIN.Controls.KeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.GUIIncreaseAngle, delegate()
			{
				global::VRGIN.Core.VR.Settings.Angle += global::UnityEngine.Time.deltaTime * 50f;
			}));
			list.Add(new global::VRGIN.Controls.KeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.GUIDecreaseAngle, delegate()
			{
				global::VRGIN.Core.VR.Settings.Angle -= global::UnityEngine.Time.deltaTime * 50f;
			}));
			list.Add(new global::VRGIN.Controls.KeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.GUIIncreaseDistance, delegate()
			{
				global::VRGIN.Core.VR.Settings.Distance += global::UnityEngine.Time.deltaTime * 0.1f;
			}));
			list.Add(new global::VRGIN.Controls.KeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.GUIDecreaseDistance, delegate()
			{
				global::VRGIN.Core.VR.Settings.Distance -= global::UnityEngine.Time.deltaTime * 0.1f;
			}));
			list.Add(new global::VRGIN.Controls.KeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.GUIRotateLeft, delegate()
			{
				global::VRGIN.Core.VR.Settings.Rotation += global::UnityEngine.Time.deltaTime * 50f;
			}));
			list.Add(new global::VRGIN.Controls.KeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.GUIRotateRight, delegate()
			{
				global::VRGIN.Core.VR.Settings.Rotation -= global::UnityEngine.Time.deltaTime * 50f;
			}));
			list.Add(new global::VRGIN.Controls.KeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.GUIChangeProjection, new global::System.Action(this.ChangeProjection)));
			list.Add(new global::VRGIN.Controls.MultiKeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.ToggleRotationLock, new global::System.Action(this.ToggleRotationLock)));
			list.Add(new global::VRGIN.Controls.MultiKeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.ImpersonateApproximately, delegate()
			{
				bool flag = this.LockTarget == null || !this.LockTarget.IsValid;
				if (flag)
				{
					this.Impersonate(global::VRGIN.Core.VR.Interpreter.FindNextActorToImpersonate(), global::VRGIN.Modes.ImpersonationMode.Approximately);
				}
				else
				{
					this.Impersonate(null);
				}
			}));
			list.Add(new global::VRGIN.Controls.MultiKeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.ImpersonateExactly, delegate()
			{
				bool flag = this.LockTarget == null || !this.LockTarget.IsValid;
				if (flag)
				{
					this.Impersonate(global::VRGIN.Core.VR.Interpreter.FindNextActorToImpersonate(), global::VRGIN.Modes.ImpersonationMode.Exactly);
				}
				else
				{
					this.Impersonate(null);
				}
			}));
			list.Add(new global::VRGIN.Controls.MultiKeyboardShortcut(global::VRGIN.Core.VR.Shortcuts.ResetView, new global::System.Action(this.Recenter)));
			return global::System.Linq.Enumerable.Concat<global::VRGIN.Controls.IShortcut>(list, base.CreateShortcuts());
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00010465 File Offset: 0x0000E665
		private void ToggleRotationLock()
		{
			this.SyncCameras();
			global::VRGIN.Core.VR.Settings.PitchLock = !global::VRGIN.Core.VR.Settings.PitchLock;
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00010487 File Offset: 0x0000E687
		private void ChangeProjection()
		{
			global::VRGIN.Core.VR.Settings.Projection = (global::VRGIN.Core.VR.Settings.Projection + 1) % (global::VRGIN.Visuals.GUIMonitor.CurvinessState)global::System.Enum.GetValues(typeof(global::VRGIN.Visuals.GUIMonitor.CurvinessState)).Length;
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x000104B6 File Offset: 0x0000E6B6
		public virtual void Recenter()
		{
			global::VRGIN.Core.VRLog.Info("Recenter", global::System.Array.Empty<object>());
			global::Valve.VR.OpenVR.System.ResetSeatedZeroPose();
		}

		// Token: 0x060002AA RID: 682 RVA: 0x000104D4 File Offset: 0x0000E6D4
		protected global::System.Action MoveGUI(float speed)
		{
			return delegate()
			{
				global::VRGIN.Core.VR.Settings.OffsetY += speed * global::UnityEngine.Time.deltaTime;
			};
		}

		// Token: 0x04000544 RID: 1348
		private static bool _IsFirstStart = true;

		// Token: 0x04000545 RID: 1349
		protected global::VRGIN.Visuals.GUIMonitor Monitor;

		// Token: 0x04000546 RID: 1350
		protected global::VRGIN.Core.IActor LockTarget;

		// Token: 0x04000547 RID: 1351
		protected global::VRGIN.Modes.ImpersonationMode LockMode;
	}
}

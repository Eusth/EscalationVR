using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using VRGIN.Controls;
using VRGIN.Core;
using VRGIN.Helpers;
using VRGIN.Modes;
using VRGIN.Visuals;

namespace EscalationVR
{
	// Token: 0x020000EE RID: 238
	public class MasoMode : global::VRGIN.Modes.SeatedMode
	{
		// Token: 0x0600060C RID: 1548 RVA: 0x0001D574 File Offset: 0x0001B774
		protected override global::System.Collections.Generic.IEnumerable<global::VRGIN.Controls.IShortcut> CreateShortcuts()
		{
			global::VRGIN.Controls.IShortcut[] array = new global::VRGIN.Controls.IShortcut[3];
			array[0] = new global::VRGIN.Controls.KeyboardShortcut(new global::VRGIN.Helpers.KeyStroke("Return"), delegate()
			{
				global::VRGIN.Core.VR.Input.Mouse.LeftButtonClick();
			}, global::VRGIN.Helpers.KeyMode.PressUp);
			array[1] = new global::VRGIN.Controls.KeyboardShortcut(new global::VRGIN.Helpers.KeyStroke("Space"), delegate()
			{
				global::VRGIN.Core.VR.Input.Mouse.RightButtonClick();
			}, global::VRGIN.Helpers.KeyMode.PressUp);
			array[2] = new global::VRGIN.Controls.KeyboardShortcut(new global::VRGIN.Helpers.KeyStroke("Tab"), delegate()
			{
				global::VRGIN.Core.VR.Manager.SetMode<global::EscalationVR.MasoStandingMode>();
			}, global::VRGIN.Helpers.KeyMode.PressUp);
			return global::System.Linq.Enumerable.Concat<global::VRGIN.Controls.IShortcut>(array, base.CreateShortcuts());
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0001D62D File Offset: 0x0001B82D
		public override void Recenter()
		{
			base.Recenter();
			this._resetPosition = true;
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x0001D63E File Offset: 0x0001B83E
		protected override void CreateControllers()
		{
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0001D641 File Offset: 0x0001B841
		public void ResetPosition()
		{
			this._resetPosition = true;
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0001D64C File Offset: 0x0001B84C
		[global::System.Diagnostics.DebuggerStepThrough]
		protected override void OnStart()
		{
			global::EscalationVR.MasoMode.<OnStart>d__7 <OnStart>d__ = new global::EscalationVR.MasoMode.<OnStart>d__7();
			<OnStart>d__.<>4__this = this;
			<OnStart>d__.<>t__builder = global::System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Create();
			<OnStart>d__.<>1__state = -1;
			<OnStart>d__.<>t__builder.Start<global::EscalationVR.MasoMode.<OnStart>d__7>(ref <OnStart>d__);
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x0001D685 File Offset: 0x0001B885
		public override void OnDestroy()
		{
			global::UnityEngine.SceneManagement.SceneManager.activeSceneChanged -= new global::UnityEngine.Events.UnityAction<global::UnityEngine.SceneManagement.Scene, global::UnityEngine.SceneManagement.Scene>(this.OnActiveSceneChanged);
			base.OnDestroy();
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x0001D6A1 File Offset: 0x0001B8A1
		private void OnActiveSceneChanged(global::UnityEngine.SceneManagement.Scene arg0, global::UnityEngine.SceneManagement.Scene arg1)
		{
			this._windowManager = global::UnityEngine.Object.FindObjectOfType<global::WindowManager>();
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x0001D6AF File Offset: 0x0001B8AF
		protected override void ApplyCameraPose()
		{
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000614 RID: 1556 RVA: 0x0001D6B2 File Offset: 0x0001B8B2
		// (set) Token: 0x06000615 RID: 1557 RVA: 0x0001D6BA File Offset: 0x0001B8BA
		public new global::VRGIN.Visuals.GUIMonitor Monitor { get; set; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000616 RID: 1558 RVA: 0x0001D6C3 File Offset: 0x0001B8C3
		// (set) Token: 0x06000617 RID: 1559 RVA: 0x0001D6CC File Offset: 0x0001B8CC
		private bool IsBlack
		{
			get
			{
				return this._isBlack;
			}
			set
			{
				bool flag = this._isBlack == value;
				if (!flag)
				{
					this._isBlack = value;
					bool isBlack = this._isBlack;
					if (isBlack)
					{
						global::SteamVR_Fade.View(global::UnityEngine.Color.black, 0.5f);
					}
					else
					{
						global::SteamVR_Fade.View(global::UnityEngine.Color.clear, 0.5f);
					}
				}
			}
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x0001D720 File Offset: 0x0001B920
		protected override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this._windowManager;
			if (flag)
			{
				this.IsBlack = (this._windowManager.darker > 0f);
			}
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0001D75F File Offset: 0x0001B95F
		protected global::System.Collections.IEnumerator VeryLateUpdate()
		{
			global::UnityEngine.WaitForEndOfFrame waitForEndOfFrame = new global::UnityEngine.WaitForEndOfFrame();
			for (;;)
			{
				yield return waitForEndOfFrame;
				global::EscalationVR.EscalationActor actor = global::System.Linq.Enumerable.FirstOrDefault<global::VRGIN.Core.IActor>(global::VRGIN.Core.VR.Interpreter.Actors) as global::EscalationVR.EscalationActor;
				global::UnityEngine.Pose pose = new global::UnityEngine.Pose(global::VRGIN.Core.VR.Camera.Blueprint.transform.position, global::VRGIN.Core.VR.Camera.Blueprint.transform.rotation);
				bool flag = actor != null;
				if (flag)
				{
					pose = actor.Eyes;
					pose.rotation = actor.GetBodyOrientation();
					actor.HasHead = false;
				}
				global::UnityEngine.Pose usedPose = pose;
				bool flag2 = (double)global::UnityEngine.Quaternion.Dot(this._previousPose.rotation, pose.rotation) > 0.95 && !this._resetPosition;
				if (flag2)
				{
					usedPose.rotation = global::VRGIN.Core.VR.Camera.Head.rotation;
				}
				bool flag3 = global::UnityEngine.Vector3.Distance(this._previousPose.position, usedPose.position) > 1f || this._resetPosition;
				if (flag3)
				{
					this.MoveToPosition(usedPose.position, usedPose.rotation, false);
				}
				else
				{
					this.ApplyRotation(usedPose.rotation);
					global::VRGIN.Core.VR.Camera.Origin.position += usedPose.position - this._previousPose.position;
				}
				this._previousPose = pose;
				this._resetPosition = false;
				actor = null;
				pose = default(global::UnityEngine.Pose);
				usedPose = default(global::UnityEngine.Pose);
			}
			yield break;
		}

		// Token: 0x04000696 RID: 1686
		private global::UnityEngine.Pose _previousPose;

		// Token: 0x04000697 RID: 1687
		private bool _resetPosition = false;

		// Token: 0x04000698 RID: 1688
		private global::WindowManager _windowManager;

		// Token: 0x0400069A RID: 1690
		private bool _isBlack;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Valve.VR;
using VRGIN.Core;
using VRGIN.Helpers;
using VRGIN.Modes;
using VRGIN.U46.Visuals;
using VRGIN.Visuals;

namespace VRGIN.Controls.Tools
{
	// Token: 0x020000C3 RID: 195
	public class WarpTool : global::VRGIN.Controls.Tools.Tool
	{
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x000160D0 File Offset: 0x000142D0
		public override global::UnityEngine.Texture2D Image
		{
			get
			{
				return global::VRGIN.Helpers.UnityHelper.LoadImage("icon_warp.png");
			}
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x000160EC File Offset: 0x000142EC
		protected override void OnAwake()
		{
			global::VRGIN.Core.VRLog.Info("Awake!", global::System.Array.Empty<object>());
			this.ArcRenderer = new global::UnityEngine.GameObject("Arc Renderer").AddComponent<global::VRGIN.Visuals.ArcRenderer>();
			this.ArcRenderer.transform.SetParent(base.transform, false);
			this.ArcRenderer.gameObject.SetActive(false);
			this._TravelRumble = new global::VRGIN.Helpers.TravelDistanceRumble(500, 0.1f, base.transform);
			this._TravelRumble.UseLocalPosition = true;
			this._Visualization = global::VRGIN.U46.Visuals.PlayAreaVisualization.Create(this._ProspectedPlayArea);
			global::UnityEngine.Object.DontDestroyOnLoad(this._Visualization.gameObject);
			this.SetVisibility(false);
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0001619B File Offset: 0x0001439B
		protected override void OnDestroy()
		{
			global::VRGIN.Core.VRLog.Info("Destroy!", global::System.Array.Empty<object>());
			global::UnityEngine.Object.DestroyImmediate(this._Visualization.gameObject);
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x000161BF File Offset: 0x000143BF
		protected override void OnStart()
		{
			global::VRGIN.Core.VRLog.Info("Start!", global::System.Array.Empty<object>());
			base.OnStart();
			this._IPDOnStart = global::VRGIN.Core.VR.Settings.IPDScale;
			this.ResetPlayArea(this._ProspectedPlayArea);
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x000161F6 File Offset: 0x000143F6
		protected override void OnEnable()
		{
			base.OnEnable();
			this.SetVisibility(false);
			this.ResetPlayArea(this._ProspectedPlayArea);
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00016215 File Offset: 0x00014415
		public void OnPlayAreaUpdated()
		{
			this.ResetPlayArea(this._ProspectedPlayArea);
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00016228 File Offset: 0x00014428
		private void SetVisibility(bool visible)
		{
			this.Showing = visible;
			if (visible)
			{
				this.ArcRenderer.Update();
				this.UpdateProspectedArea();
				this._Visualization.UpdatePosition();
			}
			this.ArcRenderer.gameObject.SetActive(visible);
			this._Visualization.gameObject.SetActive(visible);
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00016288 File Offset: 0x00014488
		private void ResetPlayArea(global::VRGIN.Core.PlayArea area)
		{
			area.Position = global::VRGIN.Core.VR.Camera.SteamCam.origin.position;
			area.Scale = global::VRGIN.Core.VR.Settings.IPDScale;
			area.Rotation = global::VRGIN.Core.VR.Camera.SteamCam.origin.rotation.eulerAngles.y;
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x000162EA File Offset: 0x000144EA
		protected override void OnDisable()
		{
			base.OnDisable();
			this.EnterState(global::VRGIN.Controls.Tools.WarpTool.WarpState.None);
			this.SetVisibility(false);
			this.Owner.StopRumble(this._TravelRumble);
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00016318 File Offset: 0x00014518
		protected override void OnLateUpdate()
		{
			bool showing = this.Showing;
			if (showing)
			{
				this.UpdateProspectedArea();
			}
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0001633C File Offset: 0x0001453C
		private void UpdateProspectedArea()
		{
			this.ArcRenderer.Offset = this._ProspectedPlayArea.Height;
			this.ArcRenderer.Scale = global::VRGIN.Core.VR.Settings.IPDScale;
			this._ProspectedPlayArea.Position = new global::UnityEngine.Vector3(this.ArcRenderer.target.x, this._ProspectedPlayArea.Position.y, this.ArcRenderer.target.z);
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x000163B8 File Offset: 0x000145B8
		private void CheckRotationalPress()
		{
			bool pressDown = base.Controller.GetPressDown(global::Valve.VR.EVRButtonId.k_EButton_Axis0);
			if (pressDown)
			{
				global::UnityEngine.Vector2 axis = base.Controller.GetAxis(global::Valve.VR.EVRButtonId.k_EButton_Axis0);
				this._ProspectedPlayArea.Reset();
				bool flag = axis.x < -0.2f;
				if (flag)
				{
					this._ProspectedPlayArea.Rotation -= 20f;
				}
				else
				{
					bool flag2 = axis.x > 0.2f;
					if (flag2)
					{
						this._ProspectedPlayArea.Rotation += 20f;
					}
				}
				this._ProspectedPlayArea.Apply();
			}
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0001645C File Offset: 0x0001465C
		protected override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.State == global::VRGIN.Controls.Tools.WarpTool.WarpState.None;
			if (flag)
			{
				bool flag2 = base.Controller.GetAxis(global::Valve.VR.EVRButtonId.k_EButton_Axis0).magnitude < 0.5f;
				if (flag2)
				{
					bool touchDown = base.Controller.GetTouchDown(global::Valve.VR.EVRButtonId.k_EButton_Axis0);
					if (touchDown)
					{
						this.EnterState(global::VRGIN.Controls.Tools.WarpTool.WarpState.Rotating);
					}
				}
				else
				{
					this.CheckRotationalPress();
				}
				bool pressDown = base.Controller.GetPressDown(global::Valve.VR.EVRButtonId.k_EButton_Grip);
				if (pressDown)
				{
					this.EnterState(global::VRGIN.Controls.Tools.WarpTool.WarpState.Grabbing);
				}
			}
			bool flag3 = this.State == global::VRGIN.Controls.Tools.WarpTool.WarpState.Grabbing;
			if (flag3)
			{
				this.HandleGrabbing();
			}
			bool flag4 = this.State == global::VRGIN.Controls.Tools.WarpTool.WarpState.Rotating;
			if (flag4)
			{
				this.HandleRotation();
			}
			bool flag5 = this.State == global::VRGIN.Controls.Tools.WarpTool.WarpState.Transforming;
			if (flag5)
			{
				bool pressUp = base.Controller.GetPressUp(global::Valve.VR.EVRButtonId.k_EButton_Axis0);
				if (pressUp)
				{
					this._ProspectedPlayArea.Apply();
					this.ArcRenderer.Update();
					this.EnterState(global::VRGIN.Controls.Tools.WarpTool.WarpState.Rotating);
				}
			}
			bool flag6 = this.State == global::VRGIN.Controls.Tools.WarpTool.WarpState.None;
			if (flag6)
			{
				bool hairTriggerDown = base.Controller.GetHairTriggerDown();
				if (hairTriggerDown)
				{
					this._TriggerDownTime = new float?(global::UnityEngine.Time.unscaledTime);
				}
				bool flag7 = this._TriggerDownTime != null;
				if (flag7)
				{
					bool flag8;
					if (base.Controller.GetHairTrigger())
					{
						float? num = global::UnityEngine.Time.unscaledTime - this._TriggerDownTime;
						float num2 = 1f;
						flag8 = (num.GetValueOrDefault() > num2 & num != null);
					}
					else
					{
						flag8 = false;
					}
					bool flag9 = flag8;
					if (flag9)
					{
						global::VRGIN.Core.VRManager.Instance.Mode.Impersonate(global::VRGIN.Core.VR.Interpreter.FindNextActorToImpersonate(), global::VRGIN.Modes.ImpersonationMode.Exactly);
						this._TriggerDownTime = default(float?);
					}
					bool flag10 = global::System.Linq.Enumerable.Any<global::VRGIN.Core.IActor>(global::VRGIN.Core.VRManager.Instance.Interpreter.Actors) && base.Controller.GetHairTriggerUp();
					if (flag10)
					{
						global::VRGIN.Core.VRManager.Instance.Mode.Impersonate(global::VRGIN.Core.VR.Interpreter.FindNextActorToImpersonate(), global::VRGIN.Modes.ImpersonationMode.Approximately);
					}
				}
			}
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0001667C File Offset: 0x0001487C
		private void HandleRotation()
		{
			bool showing = this.Showing;
			if (showing)
			{
				this._Points.Add(base.Controller.GetAxis(global::Valve.VR.EVRButtonId.k_EButton_Axis0));
				bool flag = this._Points.Count > 2;
				if (flag)
				{
					this.DetectCircle();
				}
			}
			bool pressDown = base.Controller.GetPressDown(global::Valve.VR.EVRButtonId.k_EButton_Axis0);
			if (pressDown)
			{
				this.EnterState(global::VRGIN.Controls.Tools.WarpTool.WarpState.Transforming);
			}
			bool touchUp = base.Controller.GetTouchUp(global::Valve.VR.EVRButtonId.k_EButton_Axis0);
			if (touchUp)
			{
				this.EnterState(global::VRGIN.Controls.Tools.WarpTool.WarpState.None);
			}
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00016700 File Offset: 0x00014900
		private void InitializeScaleIfNeeded()
		{
			bool flag = !this._ScaleInitialized;
			if (flag)
			{
				this._InitialControllerDistance = global::UnityEngine.Vector3.Distance(base.OtherController.transform.position, base.transform.position);
				this._InitialIPD = global::VRGIN.Core.VR.Settings.IPDScale;
				this._PrevFromTo = (base.OtherController.transform.position - base.transform.position).normalized;
				this._ScaleInitialized = true;
			}
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00016788 File Offset: 0x00014988
		private void InitializeRotationIfNeeded()
		{
			bool flag = !this._ScaleInitialized && !this._RotationInitialized;
			if (flag)
			{
				this._PrevFromTo = (base.OtherController.transform.position - base.transform.position).normalized;
				this._RotationInitialized = true;
			}
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x000167E8 File Offset: 0x000149E8
		private void HandleGrabbing()
		{
			bool flag = base.OtherController.IsTracking && !this.HasLock();
			if (flag)
			{
				base.OtherController.TryAcquireFocus(out this._OtherLock);
			}
			bool flag2 = this.HasLock() && base.OtherController.Input.GetPressDown(global::Valve.VR.EVRButtonId.k_EButton_Axis1);
			if (flag2)
			{
				this._ScaleInitialized = false;
			}
			bool flag3 = this.HasLock() && base.OtherController.Input.GetPressDown(global::Valve.VR.EVRButtonId.k_EButton_Grip);
			if (flag3)
			{
				this._RotationInitialized = false;
			}
			bool press = base.Controller.GetPress(global::Valve.VR.EVRButtonId.k_EButton_Grip);
			if (press)
			{
				bool flag4 = this.HasLock() && (base.OtherController.Input.GetPress(global::Valve.VR.EVRButtonId.k_EButton_Grip) || base.OtherController.Input.GetPress(global::Valve.VR.EVRButtonId.k_EButton_Axis1));
				if (flag4)
				{
					global::UnityEngine.Vector3 normalized = (base.OtherController.transform.position - base.transform.position).normalized;
					bool press2 = base.OtherController.Input.GetPress(global::Valve.VR.EVRButtonId.k_EButton_Axis1);
					if (press2)
					{
						this.InitializeScaleIfNeeded();
						float num = global::UnityEngine.Vector3.Distance(base.OtherController.transform.position, base.transform.position) * (this._InitialIPD / global::VRGIN.Core.VR.Settings.IPDScale);
						float num2 = num / this._InitialControllerDistance;
						global::VRGIN.Core.VR.Settings.IPDScale = num2 * this._InitialIPD;
						this._ProspectedPlayArea.Scale = global::VRGIN.Core.VR.Settings.IPDScale;
					}
					bool press3 = base.OtherController.Input.GetPress(global::Valve.VR.EVRButtonId.k_EButton_Grip);
					if (press3)
					{
						this.InitializeRotationIfNeeded();
						float num3 = global::VRGIN.Helpers.Calculator.Angle(this._PrevFromTo, normalized) * global::VRGIN.Core.VR.Settings.RotationMultiplier;
						global::VRGIN.Core.VR.Camera.SteamCam.origin.transform.RotateAround(global::VRGIN.Core.VR.Camera.Head.position, global::UnityEngine.Vector3.up, num3);
						this._ProspectedPlayArea.Rotation += num3;
					}
					this._PrevFromTo = (base.OtherController.transform.position - base.transform.position).normalized;
				}
				else
				{
					global::UnityEngine.Vector3 vector = base.transform.position - this._PrevControllerPos;
					global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Inverse(this._PrevControllerRot * global::UnityEngine.Quaternion.Inverse(base.transform.rotation)) * (base.transform.rotation * global::UnityEngine.Quaternion.Inverse(base.transform.rotation));
					float? num4 = global::UnityEngine.Time.unscaledTime - this._GripStartTime;
					float num5 = 0.1f;
					bool flag5 = (num4.GetValueOrDefault() > num5 & num4 != null) || global::VRGIN.Helpers.Calculator.Distance(vector.magnitude) > 0.01f;
					if (flag5)
					{
						global::UnityEngine.Vector3 forward = global::UnityEngine.Vector3.forward;
						global::UnityEngine.Vector3 v = quaternion * global::UnityEngine.Vector3.forward;
						float num6 = global::VRGIN.Helpers.Calculator.Angle(forward, v) * global::VRGIN.Core.VR.Settings.RotationMultiplier;
						global::VRGIN.Core.VR.Camera.SteamCam.origin.transform.position -= vector;
						this._ProspectedPlayArea.Height -= vector.y;
						bool flag6 = !global::VRGIN.Core.VR.Settings.GrabRotationImmediateMode && base.Controller.GetPress(12884901888UL);
						if (flag6)
						{
							global::VRGIN.Core.VR.Camera.SteamCam.origin.transform.RotateAround(global::VRGIN.Core.VR.Camera.Head.position, global::UnityEngine.Vector3.up, -num6);
							this._ProspectedPlayArea.Rotation -= num6;
						}
						this._GripStartTime = new float?(0f);
					}
				}
			}
			bool pressUp = base.Controller.GetPressUp(global::Valve.VR.EVRButtonId.k_EButton_Grip);
			if (pressUp)
			{
				this.EnterState(global::VRGIN.Controls.Tools.WarpTool.WarpState.None);
				float? num4 = global::UnityEngine.Time.unscaledTime - this._GripStartTime;
				float num5 = 0.1f;
				bool flag7 = num4.GetValueOrDefault() < num5 & num4 != null;
				if (flag7)
				{
					this.Owner.StartRumble(new global::VRGIN.Helpers.RumbleImpulse(800));
					this._ProspectedPlayArea.Height = 0f;
					this._ProspectedPlayArea.Scale = this._IPDOnStart;
				}
			}
			bool flag8 = global::VRGIN.Core.VR.Settings.GrabRotationImmediateMode && base.Controller.GetPressUp(12884901888UL);
			if (flag8)
			{
				global::UnityEngine.Vector3 normalized2 = global::UnityEngine.Vector3.ProjectOnPlane(base.transform.position - global::VRGIN.Core.VR.Camera.Head.position, global::UnityEngine.Vector3.up).normalized;
				global::UnityEngine.Vector3 normalized3 = global::UnityEngine.Vector3.ProjectOnPlane(global::VRGIN.Core.VR.Camera.Head.forward, global::UnityEngine.Vector3.up).normalized;
				float num7 = global::VRGIN.Helpers.Calculator.Angle(normalized2, normalized3);
				global::VRGIN.Core.VR.Camera.SteamCam.origin.transform.RotateAround(global::VRGIN.Core.VR.Camera.Head.position, global::UnityEngine.Vector3.up, num7);
				this._ProspectedPlayArea.Rotation = num7;
			}
			this._PrevControllerPos = base.transform.position;
			this._PrevControllerRot = base.transform.rotation;
			this.CheckRotationalPress();
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00016D9C File Offset: 0x00014F9C
		private float NormalizeAngle(float angle)
		{
			return angle % 360f;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00016DB8 File Offset: 0x00014FB8
		private void DetectCircle()
		{
			float? num = default(float?);
			float? num2 = default(float?);
			float num3 = 0f;
			foreach (global::UnityEngine.Vector2 vector in this._Points)
			{
				float magnitude = vector.magnitude;
				num = new float?(global::System.Math.Max(num ?? magnitude, magnitude));
				num2 = new float?(global::System.Math.Max(num2 ?? magnitude, magnitude));
				num3 += magnitude;
			}
			num3 /= (float)this._Points.Count;
			float? num4 = num2 - num;
			float num5 = 0.2f;
			bool flag;
			if (num4.GetValueOrDefault() < num5 & num4 != null)
			{
				num4 = num;
				num5 = 0.2f;
				flag = (num4.GetValueOrDefault() > num5 & num4 != null);
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			if (flag2)
			{
				float num6 = global::UnityEngine.Mathf.Atan2(global::System.Linq.Enumerable.First<global::UnityEngine.Vector2>(this._Points).y, global::System.Linq.Enumerable.First<global::UnityEngine.Vector2>(this._Points).x) * 57.29578f;
				float num7 = global::UnityEngine.Mathf.Atan2(global::System.Linq.Enumerable.Last<global::UnityEngine.Vector2>(this._Points).y, global::System.Linq.Enumerable.Last<global::UnityEngine.Vector2>(this._Points).x) * 57.29578f;
				float num8 = num7 - num6;
				bool flag3 = global::UnityEngine.Mathf.Abs(num8) < 60f;
				if (flag3)
				{
					this._ProspectedPlayArea.Rotation -= num8;
				}
				else
				{
					global::VRGIN.Core.VRLog.Info("Discarding too large rotation: {0}", new object[]
					{
						num8
					});
				}
			}
			this._Points.Clear();
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00016FBC File Offset: 0x000151BC
		private void EnterState(global::VRGIN.Controls.Tools.WarpTool.WarpState state)
		{
			switch (this.State)
			{
			case global::VRGIN.Controls.Tools.WarpTool.WarpState.Grabbing:
			{
				this.Owner.StopRumble(this._TravelRumble);
				this._ScaleInitialized = (this._RotationInitialized = false);
				bool flag = this.HasLock();
				if (flag)
				{
					global::VRGIN.Core.VRLog.Info("Releasing lock on other controller!", global::System.Array.Empty<object>());
					this._OtherLock.SafeRelease();
				}
				break;
			}
			}
			switch (state)
			{
			case global::VRGIN.Controls.Tools.WarpTool.WarpState.None:
				this.SetVisibility(false);
				break;
			case global::VRGIN.Controls.Tools.WarpTool.WarpState.Rotating:
				this.SetVisibility(true);
				this.Reset();
				break;
			case global::VRGIN.Controls.Tools.WarpTool.WarpState.Grabbing:
				this._PrevControllerPos = base.transform.position;
				this._GripStartTime = new float?(global::UnityEngine.Time.unscaledTime);
				this._TravelRumble.Reset();
				this._PrevControllerPos = base.transform.position;
				this._PrevControllerRot = base.transform.rotation;
				this.Owner.StartRumble(this._TravelRumble);
				break;
			}
			this.State = state;
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x000170E0 File Offset: 0x000152E0
		private bool HasLock()
		{
			return this._OtherLock != null && this._OtherLock.IsValid;
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00017108 File Offset: 0x00015308
		private void Reset()
		{
			this._Points.Clear();
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x00017118 File Offset: 0x00015318
		public override global::System.Collections.Generic.List<global::VRGIN.Controls.HelpText> GetHelpTexts()
		{
			return new global::System.Collections.Generic.List<global::VRGIN.Controls.HelpText>(new global::VRGIN.Controls.HelpText[]
			{
				global::VRGIN.Controls.HelpText.Create("Press to teleport", base.FindAttachPosition(new string[]
				{
					"trackpad"
				}), new global::UnityEngine.Vector3(0f, 0.02f, 0.05f), default(global::UnityEngine.Vector3?)),
				global::VRGIN.Controls.HelpText.Create("Circle to rotate", base.FindAttachPosition(new string[]
				{
					"trackpad"
				}), new global::UnityEngine.Vector3(0.05f, 0.02f, 0f), new global::UnityEngine.Vector3?(new global::UnityEngine.Vector3(0.015f, 0f, 0f))),
				global::VRGIN.Controls.HelpText.Create("press & move controller", base.FindAttachPosition(new string[]
				{
					"trackpad"
				}), new global::UnityEngine.Vector3(-0.05f, 0.02f, 0f), new global::UnityEngine.Vector3?(new global::UnityEngine.Vector3(-0.015f, 0f, 0f))),
				global::VRGIN.Controls.HelpText.Create("Warp into main char", base.FindAttachPosition(new string[]
				{
					"trigger"
				}), new global::UnityEngine.Vector3(0.06f, 0.04f, -0.05f), default(global::UnityEngine.Vector3?)),
				global::VRGIN.Controls.HelpText.Create("reset area", base.FindAttachPosition(new string[]
				{
					"lgrip"
				}), new global::UnityEngine.Vector3(-0.06f, 0f, -0.05f), default(global::UnityEngine.Vector3?))
			});
		}

		// Token: 0x0400060C RID: 1548
		private global::VRGIN.Visuals.ArcRenderer ArcRenderer;

		// Token: 0x0400060D RID: 1549
		private global::VRGIN.U46.Visuals.PlayAreaVisualization _Visualization;

		// Token: 0x0400060E RID: 1550
		private global::VRGIN.Core.PlayArea _ProspectedPlayArea = new global::VRGIN.Core.PlayArea();

		// Token: 0x0400060F RID: 1551
		private const float SCALE_THRESHOLD = 0.05f;

		// Token: 0x04000610 RID: 1552
		private const float TRANSLATE_THRESHOLD = 0.05f;

		// Token: 0x04000611 RID: 1553
		private global::VRGIN.Controls.Tools.WarpTool.WarpState State = global::VRGIN.Controls.Tools.WarpTool.WarpState.None;

		// Token: 0x04000612 RID: 1554
		private global::VRGIN.Helpers.TravelDistanceRumble _TravelRumble;

		// Token: 0x04000613 RID: 1555
		private global::UnityEngine.Vector3 _PrevPoint;

		// Token: 0x04000614 RID: 1556
		private float? _GripStartTime = default(float?);

		// Token: 0x04000615 RID: 1557
		private float? _TriggerDownTime = default(float?);

		// Token: 0x04000616 RID: 1558
		private bool Showing = false;

		// Token: 0x04000617 RID: 1559
		private global::System.Collections.Generic.List<global::UnityEngine.Vector2> _Points = new global::System.Collections.Generic.List<global::UnityEngine.Vector2>();

		// Token: 0x04000618 RID: 1560
		private const float GRIP_TIME_THRESHOLD = 0.1f;

		// Token: 0x04000619 RID: 1561
		private const float GRIP_DIFF_THRESHOLD = 0.01f;

		// Token: 0x0400061A RID: 1562
		private const float EXACT_IMPERSONATION_TIME = 1f;

		// Token: 0x0400061B RID: 1563
		private global::UnityEngine.Vector3 _PrevControllerPos;

		// Token: 0x0400061C RID: 1564
		private global::UnityEngine.Quaternion _PrevControllerRot;

		// Token: 0x0400061D RID: 1565
		private global::VRGIN.Controls.Controller.Lock _OtherLock;

		// Token: 0x0400061E RID: 1566
		private float _InitialControllerDistance;

		// Token: 0x0400061F RID: 1567
		private float _InitialIPD;

		// Token: 0x04000620 RID: 1568
		private global::UnityEngine.Vector3 _PrevFromTo;

		// Token: 0x04000621 RID: 1569
		private const global::Valve.VR.EVRButtonId SECONDARY_SCALE_BUTTON = global::Valve.VR.EVRButtonId.k_EButton_Axis1;

		// Token: 0x04000622 RID: 1570
		private const global::Valve.VR.EVRButtonId SECONDARY_ROTATE_BUTTON = global::Valve.VR.EVRButtonId.k_EButton_Grip;

		// Token: 0x04000623 RID: 1571
		private float _IPDOnStart;

		// Token: 0x04000624 RID: 1572
		private bool _ScaleInitialized;

		// Token: 0x04000625 RID: 1573
		private bool _RotationInitialized;

		// Token: 0x0200020C RID: 524
		private enum WarpState
		{
			// Token: 0x040007AD RID: 1965
			None,
			// Token: 0x040007AE RID: 1966
			Rotating,
			// Token: 0x040007AF RID: 1967
			Transforming,
			// Token: 0x040007B0 RID: 1968
			Grabbing
		}
	}
}

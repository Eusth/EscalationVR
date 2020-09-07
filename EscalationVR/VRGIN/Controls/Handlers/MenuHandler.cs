using System;
using System.Linq;
using UnityEngine;
using Valve.VR;
using VRGIN.Controls.Tools;
using VRGIN.Core;
using VRGIN.Native;
using VRGIN.Visuals;

namespace VRGIN.Controls.Handlers
{
	// Token: 0x020000CA RID: 202
	public class MenuHandler : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x060004AE RID: 1198 RVA: 0x00018074 File Offset: 0x00016274
		protected override void OnStart()
		{
			base.OnStart();
			global::VRGIN.Core.VRLog.Info("Menu Handler started", global::System.Array.Empty<object>());
			this._Controller = base.GetComponent<global::VRGIN.Controls.Controller>();
			this._ScaleVector = new global::UnityEngine.Vector2((float)global::VRGIN.Core.VRGUI.Width / (float)global::UnityEngine.Screen.width, (float)global::VRGIN.Core.VRGUI.Height / (float)global::UnityEngine.Screen.height);
			this._Other = this._Controller.Other.GetComponent<global::VRGIN.Controls.Handlers.MenuHandler>();
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x000180E8 File Offset: 0x000162E8
		private void OnRenderModelLoaded()
		{
			try
			{
				bool flag = !this._Controller;
				if (flag)
				{
					this._Controller = base.GetComponent<global::VRGIN.Controls.Controller>();
				}
				global::UnityEngine.Transform transform = this._Controller.FindAttachPosition(new string[]
				{
					"tip"
				});
				bool flag2 = !transform;
				if (flag2)
				{
					global::VRGIN.Core.VRLog.Error("Attach position not found for laser!", global::System.Array.Empty<object>());
					transform = base.transform;
				}
				this.Laser = new global::UnityEngine.GameObject().AddComponent<global::UnityEngine.LineRenderer>();
				this.Laser.transform.SetParent(transform, false);
				this.Laser.material = global::UnityEngine.Resources.GetBuiltinResource<global::UnityEngine.Material>("Sprites-Default.mat");
				this.Laser.material.renderQueue += 5000;
				this.Laser.SetColors(global::UnityEngine.Color.cyan, global::UnityEngine.Color.cyan);
				bool flag3 = global::SteamVR.instance.hmd_TrackingSystemName == "lighthouse";
				if (flag3)
				{
					this.Laser.transform.localRotation = global::UnityEngine.Quaternion.Euler(60f, 0f, 0f);
					this.Laser.transform.position += this.Laser.transform.forward * 0.06f;
				}
				this.Laser.SetVertexCount(2);
				this.Laser.useWorldSpace = true;
				this.Laser.SetWidth(0.002f, 0.002f);
			}
			catch (global::System.Exception obj)
			{
				global::VRGIN.Core.VRLog.Error(obj);
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060004B0 RID: 1200 RVA: 0x00018294 File Offset: 0x00016494
		protected global::SteamVR_Controller.Device Device
		{
			get
			{
				return global::SteamVR_Controller.Input((int)this._Controller.Tracking.index);
			}
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x000182BC File Offset: 0x000164BC
		protected override void OnUpdate()
		{
			base.OnUpdate();
			bool laserVisible = this.LaserVisible;
			if (laserVisible)
			{
				bool isResizing = this.IsResizing;
				if (isResizing)
				{
					this.Laser.SetPosition(0, this.Laser.transform.position);
					this.Laser.SetPosition(1, this.Laser.transform.position);
				}
				else
				{
					this.UpdateLaser();
				}
			}
			else
			{
				bool flag = this._Controller.CanAcquireFocus();
				if (flag)
				{
					this.CheckForNearMenu();
				}
			}
			this.CheckInput();
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00018350 File Offset: 0x00016550
		private void OnDisable()
		{
			bool isValid = this._LaserLock.IsValid;
			if (isValid)
			{
				this._LaserLock.Release();
			}
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0001837C File Offset: 0x0001657C
		private void EnsureResizeHandler()
		{
			bool flag = !this._ResizeHandler;
			if (flag)
			{
				this._ResizeHandler = this._Target.GetComponent<global::VRGIN.Controls.Handlers.MenuHandler.ResizeHandler>();
				bool flag2 = !this._ResizeHandler;
				if (flag2)
				{
					this._ResizeHandler = this._Target.gameObject.AddComponent<global::VRGIN.Controls.Handlers.MenuHandler.ResizeHandler>();
				}
			}
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x000183DC File Offset: 0x000165DC
		private void EnsureNoResizeHandler()
		{
			bool flag = this._ResizeHandler;
			if (flag)
			{
				global::UnityEngine.Object.DestroyImmediate(this._ResizeHandler);
			}
			this._ResizeHandler = null;
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00018410 File Offset: 0x00016610
		protected void CheckInput()
		{
			this.IsPressing = false;
			bool flag = this.LaserVisible && this._Target;
			if (flag)
			{
				bool flag2 = this._Other.LaserVisible && this._Other._Target == this._Target;
				if (flag2)
				{
					this.EnsureResizeHandler();
				}
				else
				{
					this.EnsureNoResizeHandler();
				}
				bool flag3 = !this.IsResizing;
				if (flag3)
				{
					bool pressDown = this.Device.GetPressDown(global::Valve.VR.EVRButtonId.k_EButton_Axis1);
					if (pressDown)
					{
						this.IsPressing = true;
						global::VRGIN.Core.VR.Input.Mouse.LeftButtonDown();
						this.mouseDownPosition = new global::UnityEngine.Vector2?(global::UnityEngine.Vector2.Scale(new global::UnityEngine.Vector2(global::UnityEngine.Input.mousePosition.x, (float)global::UnityEngine.Screen.height - global::UnityEngine.Input.mousePosition.y), this._ScaleVector));
					}
					bool press = this.Device.GetPress(global::Valve.VR.EVRButtonId.k_EButton_Axis1);
					if (press)
					{
						this.IsPressing = true;
					}
					bool pressUp = this.Device.GetPressUp(global::Valve.VR.EVRButtonId.k_EButton_Axis1);
					if (pressUp)
					{
						this.IsPressing = true;
						global::VRGIN.Core.VR.Input.Mouse.LeftButtonUp();
						this.mouseDownPosition = default(global::UnityEngine.Vector2?);
					}
					bool pressUp2 = this.Device.GetPressUp(global::Valve.VR.EVRButtonId.k_EButton_Grip);
					if (pressUp2)
					{
						global::VRGIN.Controls.Tools.MenuTool component = this._Controller.GetComponent<global::VRGIN.Controls.Tools.MenuTool>();
						bool flag4 = component && !component.Gui;
						if (flag4)
						{
							component.TakeGUI(this._Target);
							this._Controller.ToolIndex = this._Controller.Tools.IndexOf(component);
						}
					}
				}
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x000185C4 File Offset: 0x000167C4
		private bool IsResizing
		{
			get
			{
				return this._ResizeHandler && this._ResizeHandler.IsDragging;
			}
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x000185F4 File Offset: 0x000167F4
		private void CheckForNearMenu()
		{
			this._Target = global::System.Linq.Enumerable.FirstOrDefault<global::VRGIN.Visuals.GUIQuad>(global::VRGIN.Visuals.GUIQuadRegistry.Quads, new global::System.Func<global::VRGIN.Visuals.GUIQuad, bool>(this.IsLaserable));
			bool flag = this._Target;
			if (flag)
			{
				this.LaserVisible = true;
			}
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00018638 File Offset: 0x00016838
		private bool IsLaserable(global::VRGIN.Visuals.GUIQuad quad)
		{
			global::UnityEngine.RaycastHit raycastHit;
			return this.IsWithinRange(quad) && this.Raycast(quad, out raycastHit);
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00018660 File Offset: 0x00016860
		private float GetRange(global::VRGIN.Visuals.GUIQuad quad)
		{
			return global::UnityEngine.Mathf.Clamp(quad.transform.localScale.magnitude * 0.25f, 0.25f, 1.25f) * global::VRGIN.Core.VR.Settings.IPDScale;
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x000186A8 File Offset: 0x000168A8
		private bool IsWithinRange(global::VRGIN.Visuals.GUIQuad quad)
		{
			bool flag = !this.Laser;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = quad.transform.parent == base.transform;
				if (flag2)
				{
					result = false;
				}
				else
				{
					global::UnityEngine.Vector3 vector = -quad.transform.forward;
					global::UnityEngine.Vector3 position = quad.transform.position;
					global::UnityEngine.Vector3 position2 = this.Laser.transform.position;
					global::UnityEngine.Vector3 forward = this.Laser.transform.forward;
					float num = -quad.transform.InverseTransformPoint(position2).z * quad.transform.localScale.magnitude;
					result = (num > 0f && num < this.GetRange(quad) && global::UnityEngine.Vector3.Dot(vector, forward) < 0f);
				}
			}
			return result;
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0001878C File Offset: 0x0001698C
		private bool Raycast(global::VRGIN.Visuals.GUIQuad quad, out global::UnityEngine.RaycastHit hit)
		{
			global::UnityEngine.Vector3 position = this.Laser.transform.position;
			global::UnityEngine.Vector3 forward = this.Laser.transform.forward;
			global::UnityEngine.Collider component = quad.GetComponent<global::UnityEngine.Collider>();
			bool flag = component;
			bool result;
			if (flag)
			{
				global::UnityEngine.Ray ray;
				ray..ctor(position, forward);
				result = component.Raycast(ray, ref hit, this.GetRange(quad));
			}
			else
			{
				hit = default(global::UnityEngine.RaycastHit);
				result = false;
			}
			return result;
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x000187FC File Offset: 0x000169FC
		private void UpdateLaser()
		{
			this.Laser.SetPosition(0, this.Laser.transform.position);
			this.Laser.SetPosition(1, this.Laser.transform.position + this.Laser.transform.forward);
			bool flag = this._Target && this._Target.gameObject.activeInHierarchy;
			if (flag)
			{
				global::UnityEngine.RaycastHit raycastHit;
				bool flag2 = this.IsWithinRange(this._Target) && this.Raycast(this._Target, out raycastHit);
				if (flag2)
				{
					this.Laser.SetPosition(1, raycastHit.point);
					bool flag3 = !this.IsOtherWorkingOn(this._Target);
					if (flag3)
					{
						global::UnityEngine.Vector2 vector;
						vector..ctor(raycastHit.textureCoord.x * (float)global::VRGIN.Core.VRGUI.Width, (1f - raycastHit.textureCoord.y) * (float)global::VRGIN.Core.VRGUI.Height);
						bool flag4 = this.mouseDownPosition == null || global::UnityEngine.Vector2.Distance(this.mouseDownPosition.Value, vector) > 30f;
						if (flag4)
						{
							global::VRGIN.Native.MouseOperations.SetClientCursorPosition((int)vector.x, (int)vector.y);
							this.mouseDownPosition = default(global::UnityEngine.Vector2?);
						}
					}
				}
				else
				{
					this.LaserVisible = false;
				}
			}
			else
			{
				this.LaserVisible = false;
			}
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x00018974 File Offset: 0x00016B74
		private bool IsOtherWorkingOn(global::VRGIN.Visuals.GUIQuad target)
		{
			return this._Other && this._Other.LaserVisible && this._Other._Target == target && this._Other.IsPressing;
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x000189C4 File Offset: 0x00016BC4
		// (set) Token: 0x060004BF RID: 1215 RVA: 0x000189F8 File Offset: 0x00016BF8
		public bool LaserVisible
		{
			get
			{
				return this.Laser && this.Laser.gameObject.activeSelf;
			}
			set
			{
				bool flag = !this.Laser;
				if (!flag)
				{
					bool flag2 = value && !this._LaserLock.IsValid;
					if (flag2)
					{
						this._LaserLock = this._Controller.AcquireFocus();
						bool flag3 = !this._LaserLock.IsValid;
						if (flag3)
						{
							return;
						}
					}
					else
					{
						bool flag4 = !value && this._LaserLock.IsValid;
						if (flag4)
						{
							this._LaserLock.Release();
						}
					}
					this.Laser.gameObject.SetActive(value);
					if (value)
					{
						this.Laser.SetPosition(0, this.Laser.transform.position);
						this.Laser.SetPosition(1, this.Laser.transform.position);
					}
					else
					{
						this.mouseDownPosition = default(global::UnityEngine.Vector2?);
					}
				}
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x00018AEA File Offset: 0x00016CEA
		// (set) Token: 0x060004C1 RID: 1217 RVA: 0x00018AF2 File Offset: 0x00016CF2
		public bool IsPressing { get; private set; }

		// Token: 0x04000642 RID: 1602
		private global::VRGIN.Controls.Controller _Controller;

		// Token: 0x04000643 RID: 1603
		private const float RANGE = 0.25f;

		// Token: 0x04000644 RID: 1604
		private const int MOUSE_STABILIZER_THRESHOLD = 30;

		// Token: 0x04000645 RID: 1605
		private global::VRGIN.Controls.Controller.Lock _LaserLock = global::VRGIN.Controls.Controller.Lock.Invalid;

		// Token: 0x04000646 RID: 1606
		private global::UnityEngine.LineRenderer Laser;

		// Token: 0x04000647 RID: 1607
		private global::UnityEngine.Vector2? mouseDownPosition;

		// Token: 0x04000648 RID: 1608
		private global::VRGIN.Visuals.GUIQuad _Target;

		// Token: 0x04000649 RID: 1609
		private global::VRGIN.Controls.Handlers.MenuHandler _Other;

		// Token: 0x0400064A RID: 1610
		private global::VRGIN.Controls.Handlers.MenuHandler.ResizeHandler _ResizeHandler;

		// Token: 0x0400064B RID: 1611
		private global::UnityEngine.Vector3 _ScaleVector;

		// Token: 0x0200020F RID: 527
		private class ResizeHandler : global::VRGIN.Core.ProtectedBehaviour
		{
			// Token: 0x1700015D RID: 349
			// (get) Token: 0x06000AC6 RID: 2758 RVA: 0x0002166F File Offset: 0x0001F86F
			// (set) Token: 0x06000AC7 RID: 2759 RVA: 0x00021677 File Offset: 0x0001F877
			public bool IsDragging { get; private set; }

			// Token: 0x06000AC8 RID: 2760 RVA: 0x00021680 File Offset: 0x0001F880
			protected override void OnStart()
			{
				base.OnStart();
				this._Gui = base.GetComponent<global::VRGIN.Visuals.GUIQuad>();
			}

			// Token: 0x06000AC9 RID: 2761 RVA: 0x00021698 File Offset: 0x0001F898
			protected override void OnUpdate()
			{
				base.OnUpdate();
				this.IsDragging = (this.GetDevice(global::VRGIN.Core.VR.Mode.Left).GetPress(global::Valve.VR.EVRButtonId.k_EButton_Axis1) && this.GetDevice(global::VRGIN.Core.VR.Mode.Right).GetPress(global::Valve.VR.EVRButtonId.k_EButton_Axis1));
				bool isDragging = this.IsDragging;
				if (isDragging)
				{
					bool flag = this._StartScale == null;
					if (flag)
					{
						this.Initialize();
					}
					global::UnityEngine.Vector3 position = global::VRGIN.Core.VR.Mode.Left.transform.position;
					global::UnityEngine.Vector3 position2 = global::VRGIN.Core.VR.Mode.Right.transform.position;
					float num = global::UnityEngine.Vector3.Distance(position, position2);
					float num2 = global::UnityEngine.Vector3.Distance(this._StartLeft.Value, this._StartRight.Value);
					global::UnityEngine.Vector3 vector = position2 - position;
					global::UnityEngine.Vector3 vector2 = position + vector * 0.5f;
					global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Inverse(global::VRGIN.Core.VR.Camera.SteamCam.origin.rotation);
					global::UnityEngine.Quaternion averageRotation = this.GetAverageRotation();
					global::UnityEngine.Quaternion quaternion2 = quaternion * averageRotation * global::UnityEngine.Quaternion.Inverse(quaternion * this._StartRotationController);
					this._Gui.transform.localScale = num / num2 * this._StartScale.Value;
					this._Gui.transform.localRotation = quaternion2 * this._StartRotation.Value;
					this._Gui.transform.position = vector2 + averageRotation * global::UnityEngine.Quaternion.Inverse(this._StartRotationController) * this._OffsetFromCenter.Value;
				}
				else
				{
					this._StartScale = default(global::UnityEngine.Vector3?);
				}
			}

			// Token: 0x06000ACA RID: 2762 RVA: 0x00021858 File Offset: 0x0001FA58
			private global::UnityEngine.Quaternion GetAverageRotation()
			{
				global::UnityEngine.Vector3 position = global::VRGIN.Core.VR.Mode.Left.transform.position;
				global::UnityEngine.Vector3 position2 = global::VRGIN.Core.VR.Mode.Right.transform.position;
				global::UnityEngine.Vector3 normalized = (position2 - position).normalized;
				global::UnityEngine.Vector3 vector = global::UnityEngine.Vector3.Lerp(global::VRGIN.Core.VR.Mode.Left.transform.forward, global::VRGIN.Core.VR.Mode.Right.transform.forward, 0.5f);
				global::UnityEngine.Vector3 normalized2 = global::UnityEngine.Vector3.Cross(normalized, vector).normalized;
				return global::UnityEngine.Quaternion.LookRotation(normalized2, vector);
			}

			// Token: 0x06000ACB RID: 2763 RVA: 0x000218F4 File Offset: 0x0001FAF4
			private void Initialize()
			{
				this._StartLeft = new global::UnityEngine.Vector3?(global::VRGIN.Core.VR.Mode.Left.transform.position);
				this._StartRight = new global::UnityEngine.Vector3?(global::VRGIN.Core.VR.Mode.Right.transform.position);
				this._StartScale = new global::UnityEngine.Vector3?(this._Gui.transform.localScale);
				this._StartRotation = new global::UnityEngine.Quaternion?(this._Gui.transform.localRotation);
				this._StartPosition = new global::UnityEngine.Vector3?(this._Gui.transform.position);
				this._StartRotationController = this.GetAverageRotation();
				float num = global::UnityEngine.Vector3.Distance(this._StartLeft.Value, this._StartRight.Value);
				global::UnityEngine.Vector3 vector = this._StartRight.Value - this._StartLeft.Value;
				global::UnityEngine.Vector3 vector2 = this._StartLeft.Value + vector * 0.5f;
				this._OffsetFromCenter = new global::UnityEngine.Vector3?(base.transform.position - vector2);
			}

			// Token: 0x06000ACC RID: 2764 RVA: 0x00021A10 File Offset: 0x0001FC10
			private global::SteamVR_Controller.Device GetDevice(global::VRGIN.Controls.Controller controller)
			{
				return global::SteamVR_Controller.Input((int)controller.Tracking.index);
			}

			// Token: 0x040007B8 RID: 1976
			private global::VRGIN.Visuals.GUIQuad _Gui;

			// Token: 0x040007B9 RID: 1977
			private global::UnityEngine.Vector3? _StartLeft;

			// Token: 0x040007BA RID: 1978
			private global::UnityEngine.Vector3? _StartRight;

			// Token: 0x040007BB RID: 1979
			private global::UnityEngine.Vector3? _StartScale;

			// Token: 0x040007BC RID: 1980
			private global::UnityEngine.Quaternion? _StartRotation;

			// Token: 0x040007BD RID: 1981
			private global::UnityEngine.Vector3? _StartPosition;

			// Token: 0x040007BE RID: 1982
			private global::UnityEngine.Quaternion _StartRotationController;

			// Token: 0x040007BF RID: 1983
			private global::UnityEngine.Vector3? _OffsetFromCenter;
		}
	}
}

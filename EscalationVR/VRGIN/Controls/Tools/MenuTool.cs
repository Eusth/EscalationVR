using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Valve.VR;
using VRGIN.Core;
using VRGIN.Helpers;
using VRGIN.Native;
using VRGIN.Visuals;

namespace VRGIN.Controls.Tools
{
	// Token: 0x020000C1 RID: 193
	public class MenuTool : global::VRGIN.Controls.Tools.Tool
	{
		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000452 RID: 1106 RVA: 0x000158AD File Offset: 0x00013AAD
		// (set) Token: 0x06000453 RID: 1107 RVA: 0x000158B5 File Offset: 0x00013AB5
		public global::VRGIN.Visuals.GUIQuad Gui { get; private set; }

		// Token: 0x06000454 RID: 1108 RVA: 0x000158C0 File Offset: 0x00013AC0
		public void TakeGUI(global::VRGIN.Visuals.GUIQuad quad)
		{
			bool flag = quad && !this.Gui && !quad.IsOwned;
			if (flag)
			{
				this.Gui = quad;
				this.Gui.transform.parent = base.transform;
				this.Gui.transform.SetParent(base.transform, true);
				this.Gui.transform.localPosition = new global::UnityEngine.Vector3(0f, 0.05f, -0.06f);
				this.Gui.transform.localRotation = global::UnityEngine.Quaternion.Euler(90f, 0f, 0f);
				quad.IsOwned = true;
			}
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00015980 File Offset: 0x00013B80
		public void AbandonGUI()
		{
			bool flag = this.Gui;
			if (flag)
			{
				this.timeAbandoned = global::UnityEngine.Time.unscaledTime;
				this.Gui.IsOwned = false;
				this.Gui.transform.SetParent(global::VRGIN.Core.VR.Camera.SteamCam.origin, true);
				this.Gui = null;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x000159E0 File Offset: 0x00013BE0
		public override global::UnityEngine.Texture2D Image
		{
			get
			{
				return global::VRGIN.Helpers.UnityHelper.LoadImage("icon_settings.png");
			}
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x000159FC File Offset: 0x00013BFC
		protected override void OnAwake()
		{
			base.OnAwake();
			this.Gui = global::VRGIN.Visuals.GUIQuad.Create(null);
			this.Gui.transform.parent = base.transform;
			this.Gui.transform.localScale = global::UnityEngine.Vector3.one * 0.3f;
			this.Gui.transform.localPosition = new global::UnityEngine.Vector3(0f, 0.05f, -0.06f);
			this.Gui.transform.localRotation = global::UnityEngine.Quaternion.Euler(90f, 0f, 0f);
			this.Gui.IsOwned = true;
			global::UnityEngine.Object.DontDestroyOnLoad(this.Gui.gameObject);
			global::UnityEngine.Debug.Log("Menu tool awake!");
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00015AC7 File Offset: 0x00013CC7
		protected override void OnStart()
		{
			base.OnStart();
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00015AD1 File Offset: 0x00013CD1
		protected override void OnDestroy()
		{
			global::UnityEngine.Object.DestroyImmediate(this.Gui.gameObject);
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00015AE8 File Offset: 0x00013CE8
		protected override void OnDisable()
		{
			base.OnDisable();
			bool flag = this.Gui;
			if (flag)
			{
				this.Gui.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00015B20 File Offset: 0x00013D20
		protected override void OnEnable()
		{
			base.OnEnable();
			bool flag = this.Gui;
			if (flag)
			{
				this.Gui.gameObject.SetActive(true);
			}
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00015B58 File Offset: 0x00013D58
		protected override void OnUpdate()
		{
			base.OnUpdate();
			global::SteamVR_Controller.Device controller = base.Controller;
			bool pressDown = controller.GetPressDown(12884901888UL);
			if (pressDown)
			{
				global::VRGIN.Core.VR.Input.Mouse.LeftButtonDown();
				this.pressDownTime = global::UnityEngine.Time.unscaledTime;
			}
			bool pressUp = controller.GetPressUp(4UL);
			if (pressUp)
			{
				bool flag = this.Gui;
				if (flag)
				{
					this.AbandonGUI();
				}
				else
				{
					this.TakeGUI(global::System.Linq.Enumerable.FirstOrDefault<global::VRGIN.Visuals.GUIQuad>(global::VRGIN.Visuals.GUIQuadRegistry.Quads, (global::VRGIN.Visuals.GUIQuad q) => !q.IsOwned));
				}
			}
			bool touchDown = controller.GetTouchDown(4294967296UL);
			if (touchDown)
			{
				this.touchDownPosition = controller.GetAxis(global::Valve.VR.EVRButtonId.k_EButton_Axis0);
				this.touchDownMousePosition = global::VRGIN.Native.MouseOperations.GetClientCursorPosition();
			}
			bool flag2 = controller.GetTouch(4294967296UL) && global::UnityEngine.Time.unscaledTime - this.pressDownTime > 0.3f;
			if (flag2)
			{
				global::UnityEngine.Vector2 axis = controller.GetAxis(global::Valve.VR.EVRButtonId.k_EButton_Axis0);
				global::UnityEngine.Vector2 vector = axis - ((global::VRGIN.Core.VR.HMD == global::VRGIN.Core.HMDType.Oculus) ? global::UnityEngine.Vector2.zero : this.touchDownPosition);
				float num = (global::VRGIN.Core.VR.HMD == global::VRGIN.Core.HMDType.Oculus) ? (global::UnityEngine.Time.unscaledDeltaTime * 5f) : 1f;
				this._DeltaX += (double)(vector.x * (float)global::VRGIN.Core.VRGUI.Width) * 0.1 * (double)num;
				this._DeltaY += (double)(-(double)vector.y * (float)global::VRGIN.Core.VRGUI.Height) * 0.2 * (double)num;
				int num2 = (int)((this._DeltaX > 0.0) ? global::System.Math.Floor(this._DeltaX) : global::System.Math.Ceiling(this._DeltaX));
				int num3 = (int)((this._DeltaY > 0.0) ? global::System.Math.Floor(this._DeltaY) : global::System.Math.Ceiling(this._DeltaY));
				this._DeltaX -= (double)num2;
				this._DeltaY -= (double)num3;
				global::VRGIN.Core.VR.Input.Mouse.MoveMouseBy(num2, num3);
				this.touchDownPosition = axis;
			}
			bool pressUp2 = controller.GetPressUp(12884901888UL);
			if (pressUp2)
			{
				global::VRGIN.Core.VR.Input.Mouse.LeftButtonUp();
				this.pressDownTime = 0f;
			}
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00015DC0 File Offset: 0x00013FC0
		public override global::System.Collections.Generic.List<global::VRGIN.Controls.HelpText> GetHelpTexts()
		{
			return new global::System.Collections.Generic.List<global::VRGIN.Controls.HelpText>(new global::VRGIN.Controls.HelpText[]
			{
				global::VRGIN.Controls.HelpText.Create("Tap to click", base.FindAttachPosition(new string[]
				{
					"trackpad"
				}), new global::UnityEngine.Vector3(0f, 0.02f, 0.05f), default(global::UnityEngine.Vector3?)),
				global::VRGIN.Controls.HelpText.Create("Slide to move cursor", base.FindAttachPosition(new string[]
				{
					"trackpad"
				}), new global::UnityEngine.Vector3(0.05f, 0.02f, 0f), new global::UnityEngine.Vector3?(new global::UnityEngine.Vector3(0.015f, 0f, 0f))),
				global::VRGIN.Controls.HelpText.Create("Attach/Remove menu", base.FindAttachPosition(new string[]
				{
					"lgrip"
				}), new global::UnityEngine.Vector3(-0.06f, 0f, -0.05f), default(global::UnityEngine.Vector3?))
			});
		}

		// Token: 0x04000602 RID: 1538
		private float pressDownTime;

		// Token: 0x04000603 RID: 1539
		private global::UnityEngine.Vector2 touchDownPosition;

		// Token: 0x04000604 RID: 1540
		private global::VRGIN.Native.WindowsInterop.POINT touchDownMousePosition;

		// Token: 0x04000605 RID: 1541
		private float timeAbandoned;

		// Token: 0x04000606 RID: 1542
		private double _DeltaX = 0.0;

		// Token: 0x04000607 RID: 1543
		private double _DeltaY = 0.0;
	}
}

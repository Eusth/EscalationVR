using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using VRGIN.Controls.Handlers;
using VRGIN.Controls.Tools;
using VRGIN.Core;
using VRGIN.Helpers;

namespace VRGIN.Controls
{
	// Token: 0x020000B9 RID: 185
	public abstract class Controller : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x00014509 File Offset: 0x00012709
		// (set) Token: 0x0600040B RID: 1035 RVA: 0x00014511 File Offset: 0x00012711
		public global::SteamVR_RenderModel Model { get; private set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600040C RID: 1036 RVA: 0x0001451A File Offset: 0x0001271A
		// (set) Token: 0x0600040D RID: 1037 RVA: 0x00014522 File Offset: 0x00012722
		public global::VRGIN.Controls.RumbleManager Rumble { get; private set; }

		// Token: 0x0600040E RID: 1038 RVA: 0x0001452C File Offset: 0x0001272C
		[global::System.Obsolete("Use TryAcquireFocus() or AcquireFocus()")]
		public bool AcquireFocus(out global::VRGIN.Controls.Controller.Lock lockObj)
		{
			return this.TryAcquireFocus(out lockObj);
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00014548 File Offset: 0x00012748
		public bool TryAcquireFocus(out global::VRGIN.Controls.Controller.Lock lockObj)
		{
			lockObj = null;
			bool flag = this.CanAcquireFocus();
			bool result;
			if (flag)
			{
				lockObj = new global::VRGIN.Controls.Controller.Lock(this);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00014578 File Offset: 0x00012778
		public global::VRGIN.Controls.Controller.Lock AcquireFocus()
		{
			global::VRGIN.Controls.Controller.Lock @lock;
			bool flag = this.TryAcquireFocus(out @lock);
			global::VRGIN.Controls.Controller.Lock result;
			if (flag)
			{
				result = @lock;
			}
			else
			{
				result = global::VRGIN.Controls.Controller.Lock.Invalid;
			}
			return result;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x000145A4 File Offset: 0x000127A4
		public bool CanAcquireFocus()
		{
			return this._Lock == null || !this._Lock.IsValid;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x000145CF File Offset: 0x000127CF
		protected virtual void OnLock()
		{
			this.ToolEnabled = false;
			this._AlphaConcealer.SetActive(false);
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x000145E7 File Offset: 0x000127E7
		protected virtual void OnUnlock()
		{
			this.ToolEnabled = true;
			this._AlphaConcealer.SetActive(true);
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x000145FF File Offset: 0x000127FF
		protected virtual void OnDestroy()
		{
			global::UnityEngine.Object.Destroy(base.gameObject);
			global::SteamVR_Utils.Event.Remove("render_model_loaded", new global::SteamVR_Utils.Event.Handler(this._OnRenderModelLoaded));
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00014628 File Offset: 0x00012828
		protected void SetUp()
		{
			global::SteamVR_Utils.Event.Listen("render_model_loaded", new global::SteamVR_Utils.Event.Handler(this._OnRenderModelLoaded));
			this.Tracking = base.gameObject.AddComponent<global::SteamVR_TrackedObject>();
			this.Rumble = base.gameObject.AddComponent<global::VRGIN.Controls.RumbleManager>();
			base.gameObject.AddComponent<global::VRGIN.Controls.Handlers.BodyRumbleHandler>();
			base.gameObject.AddComponent<global::VRGIN.Controls.Handlers.MenuHandler>();
			this.Model = new global::UnityEngine.GameObject("Model").AddComponent<global::SteamVR_RenderModel>();
			this.Model.shader = global::VRGIN.Core.VRManager.Instance.Context.Materials.StandardShader;
			bool flag = !this.Model.shader;
			if (flag)
			{
				global::VRGIN.Core.VRLog.Warn("Shader not found", global::System.Array.Empty<object>());
			}
			this.Model.transform.SetParent(base.transform, false);
			this.BuildCanvas();
			this.Collider = new global::UnityEngine.GameObject("Collider").AddComponent<global::UnityEngine.BoxCollider>();
			this.Collider.transform.SetParent(base.transform, false);
			this.Collider.center = new global::UnityEngine.Vector3(0f, -0.02f, -0.06f);
			this.Collider.size = new global::UnityEngine.Vector3(-0.05f, 0.05f, 0.2f);
			this.Collider.isTrigger = true;
			base.gameObject.AddComponent<global::UnityEngine.Rigidbody>().isKinematic = true;
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00014794 File Offset: 0x00012994
		private void _OnRenderModelLoaded(object[] args)
		{
			try
			{
				bool flag = args.Length != 0;
				if (flag)
				{
					global::SteamVR_RenderModel steamVR_RenderModel = args[0] as global::SteamVR_RenderModel;
					bool flag2 = steamVR_RenderModel && steamVR_RenderModel.transform.IsChildOf(base.transform);
					if (flag2)
					{
						global::VRGIN.Core.VRLog.Info("Render model loaded!", global::System.Array.Empty<object>());
						base.gameObject.SendMessageToAll("OnRenderModelLoaded", global::System.Array.Empty<object>());
						this.OnRenderModelLoaded();
					}
				}
			}
			catch (global::System.Exception obj)
			{
				global::VRGIN.Core.VRLog.Error(obj);
			}
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00014828 File Offset: 0x00012A28
		private void OnRenderModelLoaded()
		{
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x0001482B File Offset: 0x00012A2B
		protected override void OnAwake()
		{
			base.OnAwake();
			this.SetUp();
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x0001483C File Offset: 0x00012A3C
		public void AddTool(global::System.Type toolType)
		{
			bool flag = toolType.IsSubclassOf(typeof(global::VRGIN.Controls.Tools.Tool)) && !global::System.Linq.Enumerable.Any<global::VRGIN.Controls.Tools.Tool>(this.Tools, (global::VRGIN.Controls.Tools.Tool tool) => toolType.IsAssignableFrom(tool.GetType()));
			if (flag)
			{
				global::VRGIN.Controls.Tools.Tool tool2 = base.gameObject.AddComponent(toolType) as global::VRGIN.Controls.Tools.Tool;
				this.Tools.Add(tool2);
				this.CreateToolCanvas(tool2);
				tool2.enabled = false;
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x000148C5 File Offset: 0x00012AC5
		public void AddTool<T>() where T : global::VRGIN.Controls.Tools.Tool
		{
			this.AddTool(typeof(T));
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600041B RID: 1051 RVA: 0x000148D9 File Offset: 0x00012AD9
		// (set) Token: 0x0600041C RID: 1052 RVA: 0x000148E1 File Offset: 0x00012AE1
		public virtual int ToolIndex { get; set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x000148EC File Offset: 0x00012AEC
		public global::VRGIN.Controls.Tools.Tool ActiveTool
		{
			get
			{
				bool flag = this.ToolIndex >= this.Tools.Count;
				global::VRGIN.Controls.Tools.Tool result;
				if (flag)
				{
					result = null;
				}
				else
				{
					result = this.Tools[this.ToolIndex];
				}
				return result;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x00014930 File Offset: 0x00012B30
		public virtual global::System.Collections.Generic.IList<global::System.Type> ToolTypes
		{
			get
			{
				return new global::System.Collections.Generic.List<global::System.Type>();
			}
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00014948 File Offset: 0x00012B48
		protected override void OnStart()
		{
			int num = 0;
			foreach (global::VRGIN.Controls.Tools.Tool tool in this.Tools)
			{
				bool flag = num++ != this.ToolIndex && tool;
				if (flag)
				{
					tool.enabled = true;
					tool.enabled = false;
					global::VRGIN.Core.VRLog.Info("Disable tool #{0} ({1})", new object[]
					{
						num - 1,
						this.ToolIndex
					});
				}
				else
				{
					global::VRGIN.Core.VRLog.Info("Enable Tool #{0}", new object[]
					{
						num - 1
					});
					bool enabled = tool.enabled;
					if (enabled)
					{
						tool.enabled = false;
					}
					tool.enabled = true;
				}
			}
			this._Started = true;
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x00014A3C File Offset: 0x00012C3C
		// (set) Token: 0x06000421 RID: 1057 RVA: 0x00014A6C File Offset: 0x00012C6C
		public bool ToolEnabled
		{
			get
			{
				return this.ActiveTool != null && this.ActiveTool.enabled;
			}
			set
			{
				bool flag = this.ActiveTool != null;
				if (flag)
				{
					this.ActiveTool.enabled = value;
					bool flag2 = !value;
					if (flag2)
					{
						this.HideHelp();
					}
				}
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000422 RID: 1058 RVA: 0x00014AAC File Offset: 0x00012CAC
		public bool IsTracking
		{
			get
			{
				return this.Tracking && this.Tracking.isValid;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x00014ADC File Offset: 0x00012CDC
		public global::SteamVR_Controller.Device Input
		{
			get
			{
				return global::SteamVR_Controller.Input((int)this.Tracking.index);
			}
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00014B00 File Offset: 0x00012D00
		protected override void OnUpdate()
		{
			base.OnUpdate();
			global::SteamVR_Controller.Device device = global::SteamVR_Controller.Input((int)this.Tracking.index);
			bool flag = this._Lock != null && this._Lock.IsInvalidating;
			if (flag)
			{
				this.TryReleaseLock();
			}
			bool flag2 = this._Lock == null || !this._Lock.IsValid;
			if (flag2)
			{
				bool pressDown = device.GetPressDown(global::Valve.VR.EVRButtonId.k_EButton_ApplicationMenu);
				if (pressDown)
				{
					this.appButtonPressTime = new float?(global::UnityEngine.Time.unscaledTime);
				}
				bool flag3;
				if (device.GetPress(global::Valve.VR.EVRButtonId.k_EButton_ApplicationMenu))
				{
					float? num = global::UnityEngine.Time.unscaledTime - this.appButtonPressTime;
					float num2 = 0.5f;
					flag3 = (num.GetValueOrDefault() > num2 & num != null);
				}
				else
				{
					flag3 = false;
				}
				bool flag4 = flag3;
				if (flag4)
				{
					this.ShowHelp();
					this.appButtonPressTime = default(float?);
				}
				bool pressUp = device.GetPressUp(global::Valve.VR.EVRButtonId.k_EButton_ApplicationMenu);
				if (pressUp)
				{
					bool flag5 = this.helpShown;
					if (flag5)
					{
						this.HideHelp();
					}
					else
					{
						bool flag6 = this.ActiveTool;
						if (flag6)
						{
							this.ActiveTool.enabled = false;
						}
						this.ToolIndex = (this.ToolIndex + 1) % this.Tools.Count;
						bool flag7 = this.ActiveTool;
						if (flag7)
						{
							this.ActiveTool.enabled = true;
						}
					}
					this.appButtonPressTime = default(float?);
				}
			}
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00014C90 File Offset: 0x00012E90
		private void TryReleaseLock()
		{
			global::SteamVR_Controller.Device input = this.Input;
			foreach (global::Valve.VR.EVRButtonId buttonId in global::System.Linq.Enumerable.OfType<global::Valve.VR.EVRButtonId>(global::System.Enum.GetValues(typeof(global::Valve.VR.EVRButtonId))))
			{
				bool press = input.GetPress(buttonId);
				if (press)
				{
					return;
				}
			}
			this._Lock.Release();
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00014D0C File Offset: 0x00012F0C
		public void StartRumble(global::VRGIN.Helpers.IRumbleSession session)
		{
			this.Rumble.StartRumble(session);
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00014D1C File Offset: 0x00012F1C
		public void StopRumble(global::VRGIN.Helpers.IRumbleSession session)
		{
			this.Rumble.StopRumble(session);
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00014D2C File Offset: 0x00012F2C
		private void HideHelp()
		{
			bool flag = this.helpShown;
			if (flag)
			{
				this.helpTexts.ForEach(delegate(global::VRGIN.Controls.HelpText h)
				{
					global::UnityEngine.Object.Destroy(h.gameObject);
				});
				this.helpShown = false;
			}
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00014D78 File Offset: 0x00012F78
		private void ShowHelp()
		{
			bool flag = this.ActiveTool != null;
			if (flag)
			{
				this.helpTexts = this.ActiveTool.GetHelpTexts();
				this.helpShown = true;
			}
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00014DB0 File Offset: 0x00012FB0
		private void BuildCanvas()
		{
			global::UnityEngine.Canvas canvas = this._Canvas = new global::UnityEngine.GameObject().AddComponent<global::UnityEngine.Canvas>();
			canvas.renderMode = 2;
			canvas.transform.SetParent(base.transform, false);
			canvas.GetComponent<global::UnityEngine.RectTransform>().SetSizeWithCurrentAnchors(0, 950f);
			canvas.GetComponent<global::UnityEngine.RectTransform>().SetSizeWithCurrentAnchors(1, 950f);
			canvas.transform.localPosition = new global::UnityEngine.Vector3(0f, -0.02725995f, 0.0279f);
			canvas.transform.localRotation = global::UnityEngine.Quaternion.Euler(30f, 180f, 180f);
			canvas.transform.localScale = new global::UnityEngine.Vector3(4.930151E-05f, 4.930148E-05f, 0f);
			canvas.gameObject.layer = 0;
			this._AlphaConcealer = global::UnityEngine.GameObject.CreatePrimitive(0);
			this._AlphaConcealer.transform.SetParent(base.transform, false);
			this._AlphaConcealer.transform.localScale = new global::UnityEngine.Vector3(0.05f, 0f, 0.05f);
			this._AlphaConcealer.transform.localPosition = new global::UnityEngine.Vector3(0f, -0.0303f, 0.0142f);
			this._AlphaConcealer.transform.localRotation = global::UnityEngine.Quaternion.Euler(60f, 0f, 0f);
			this._AlphaConcealer.GetComponent<global::UnityEngine.Collider>().enabled = false;
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00014F24 File Offset: 0x00013124
		private void CreateToolCanvas(global::VRGIN.Controls.Tools.Tool tool)
		{
			global::UnityEngine.UI.Image image = new global::UnityEngine.GameObject().AddComponent<global::UnityEngine.UI.Image>();
			image.transform.SetParent(this._Canvas.transform, false);
			global::UnityEngine.Texture2D image2 = tool.Image;
			image.sprite = global::UnityEngine.Sprite.Create(image2, new global::UnityEngine.Rect(0f, 0f, (float)image2.width, (float)image2.height), new global::UnityEngine.Vector2(0.5f, 0.5f));
			image.GetComponent<global::UnityEngine.RectTransform>().anchorMin = new global::UnityEngine.Vector2(0f, 0f);
			image.GetComponent<global::UnityEngine.RectTransform>().anchorMax = new global::UnityEngine.Vector2(1f, 1f);
			image.color = global::UnityEngine.Color.cyan;
			tool.Icon = image.gameObject;
			tool.Icon.SetActive(false);
			tool.Icon.layer = 0;
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x00015000 File Offset: 0x00013200
		public global::UnityEngine.Transform FindAttachPosition(params string[] names)
		{
			global::UnityEngine.Transform transform = global::System.Linq.Enumerable.FirstOrDefault<global::UnityEngine.Transform>(global::System.Linq.Enumerable.Where<global::UnityEngine.Transform>(base.transform.GetComponentsInChildren<global::UnityEngine.Transform>(), (global::UnityEngine.Transform t) => global::System.Linq.Enumerable.Contains<string>(names, t.name)));
			bool flag = transform == null;
			global::UnityEngine.Transform result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = transform.Find("attach");
			}
			return result;
		}

		// Token: 0x040005DC RID: 1500
		private bool _Started = false;

		// Token: 0x040005DD RID: 1501
		public global::SteamVR_TrackedObject Tracking;

		// Token: 0x040005DF RID: 1503
		protected global::UnityEngine.BoxCollider Collider;

		// Token: 0x040005E0 RID: 1504
		private float? appButtonPressTime;

		// Token: 0x040005E1 RID: 1505
		public global::System.Collections.Generic.List<global::VRGIN.Controls.Tools.Tool> Tools = new global::System.Collections.Generic.List<global::VRGIN.Controls.Tools.Tool>();

		// Token: 0x040005E2 RID: 1506
		public global::VRGIN.Controls.Controller Other;

		// Token: 0x040005E3 RID: 1507
		private const float APP_BUTTON_TIME_THRESHOLD = 0.5f;

		// Token: 0x040005E4 RID: 1508
		private bool helpShown;

		// Token: 0x040005E5 RID: 1509
		private global::System.Collections.Generic.List<global::VRGIN.Controls.HelpText> helpTexts;

		// Token: 0x040005E6 RID: 1510
		private global::UnityEngine.Canvas _Canvas;

		// Token: 0x040005E7 RID: 1511
		private global::VRGIN.Controls.Controller.Lock _Lock = global::VRGIN.Controls.Controller.Lock.Invalid;

		// Token: 0x040005E8 RID: 1512
		private global::UnityEngine.GameObject _AlphaConcealer;

		// Token: 0x02000207 RID: 519
		public class Lock
		{
			// Token: 0x1700015B RID: 347
			// (get) Token: 0x06000AAA RID: 2730 RVA: 0x000214A5 File Offset: 0x0001F6A5
			// (set) Token: 0x06000AAB RID: 2731 RVA: 0x000214AD File Offset: 0x0001F6AD
			public bool IsInvalidating { get; private set; }

			// Token: 0x1700015C RID: 348
			// (get) Token: 0x06000AAC RID: 2732 RVA: 0x000214B6 File Offset: 0x0001F6B6
			// (set) Token: 0x06000AAD RID: 2733 RVA: 0x000214BE File Offset: 0x0001F6BE
			public bool IsValid { get; private set; }

			// Token: 0x06000AAE RID: 2734 RVA: 0x000214C7 File Offset: 0x0001F6C7
			private Lock()
			{
				this.IsValid = false;
			}

			// Token: 0x06000AAF RID: 2735 RVA: 0x000214D9 File Offset: 0x0001F6D9
			internal Lock(global::VRGIN.Controls.Controller controller)
			{
				this.IsValid = true;
				this._Controller = controller;
				this._Controller._Lock = this;
				this._Controller.OnLock();
			}

			// Token: 0x06000AB0 RID: 2736 RVA: 0x0002150C File Offset: 0x0001F70C
			public void Release()
			{
				bool isValid = this.IsValid;
				if (isValid)
				{
					this._Controller._Lock = null;
					this._Controller.OnUnlock();
					this.IsValid = false;
				}
				else
				{
					global::VRGIN.Core.VRLog.Warn("Tried to release an invalid lock!", global::System.Array.Empty<object>());
				}
			}

			// Token: 0x06000AB1 RID: 2737 RVA: 0x0002155C File Offset: 0x0001F75C
			public void SafeRelease()
			{
				bool isValid = this.IsValid;
				if (isValid)
				{
					this.IsInvalidating = true;
				}
				else
				{
					global::VRGIN.Core.VRLog.Warn("Tried to release an invalid lock!", global::System.Array.Empty<object>());
				}
			}

			// Token: 0x040007A4 RID: 1956
			private global::VRGIN.Controls.Controller _Controller;

			// Token: 0x040007A5 RID: 1957
			public static readonly global::VRGIN.Controls.Controller.Lock Invalid = new global::VRGIN.Controls.Controller.Lock();
		}
	}
}

using System;
using UnityEngine;
using Valve.VR;
using VRGIN.Controls;
using VRGIN.Core;

namespace VRGIN.Visuals
{
	// Token: 0x0200008D RID: 141
	public class PlayerCamera : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000240 RID: 576 RVA: 0x0000E2E8 File Offset: 0x0000C4E8
		// (set) Token: 0x06000241 RID: 577 RVA: 0x0000E2EF File Offset: 0x0000C4EF
		public static bool Created { get; private set; }

		// Token: 0x06000242 RID: 578 RVA: 0x0000E2F8 File Offset: 0x0000C4F8
		public static global::VRGIN.Visuals.PlayerCamera Create()
		{
			global::VRGIN.Visuals.PlayerCamera.Created = true;
			return global::UnityEngine.GameObject.CreatePrimitive(3).AddComponent<global::VRGIN.Visuals.PlayerCamera>();
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000E31C File Offset: 0x0000C51C
		internal static void Remove()
		{
			bool created = global::VRGIN.Visuals.PlayerCamera.Created;
			if (created)
			{
				global::UnityEngine.Object.Destroy(global::UnityEngine.Object.FindObjectOfType<global::VRGIN.Visuals.PlayerCamera>().gameObject);
				global::VRGIN.Visuals.PlayerCamera.Created = false;
			}
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000E34C File Offset: 0x0000C54C
		protected void OnEnable()
		{
			global::VRGIN.Core.VRGUI.Instance.Listen();
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000E35A File Offset: 0x0000C55A
		protected void OnDisable()
		{
			global::VRGIN.Core.VRGUI.Instance.Unlisten();
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000E368 File Offset: 0x0000C568
		protected override void OnAwake()
		{
			global::UnityEngine.GameObject gameObject = global::UnityEngine.GameObject.CreatePrimitive(0);
			gameObject.transform.SetParent(base.transform, false);
			global::UnityEngine.GameObject gameObject2 = global::UnityEngine.GameObject.CreatePrimitive(0);
			gameObject2.transform.SetParent(base.transform, false);
			base.transform.localScale = 0.3f * global::UnityEngine.Vector3.one;
			base.transform.localScale = new global::UnityEngine.Vector3(0.2f, 0.2f, 0.4f);
			gameObject.transform.localScale = global::UnityEngine.Vector3.one * 0.3f;
			gameObject.transform.localPosition = global::UnityEngine.Vector3.forward * 0.5f;
			gameObject2.transform.localScale = global::UnityEngine.Vector3.one * 0.3f;
			gameObject2.transform.localPosition = global::UnityEngine.Vector3.up * 0.5f;
			base.GetComponent<global::UnityEngine.Collider>().isTrigger = true;
			this.model = new global::UnityEngine.GameObject("Model").AddComponent<global::SteamVR_RenderModel>();
			this.model.transform.SetParent(global::VRGIN.Core.VR.Camera.SteamCam.head, false);
			this.model.shader = global::VRGIN.Core.VR.Context.Materials.StandardShader;
			this.model.SetDeviceIndex(0);
			this.model.gameObject.layer = global::UnityEngine.LayerMask.NameToLayer(global::VRGIN.Core.VR.Context.InvisibleLayer);
			global::UnityEngine.Camera camera = base.gameObject.AddComponent<global::UnityEngine.Camera>();
			camera.depth = 1f;
			camera.nearClipPlane = 0.3f;
			camera.cullingMask = (int.MaxValue & ~global::VRGIN.Core.VR.Context.UILayerMask);
			base.transform.position = global::VRGIN.Visuals.PlayerCamera.S_Position;
			base.transform.rotation = global::VRGIN.Visuals.PlayerCamera.S_Rotation;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000E539 File Offset: 0x0000C739
		protected override void OnUpdate()
		{
			global::VRGIN.Visuals.PlayerCamera.S_Position = base.transform.position;
			global::VRGIN.Visuals.PlayerCamera.S_Rotation = base.transform.rotation;
			this.CheckInput();
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000E564 File Offset: 0x0000C764
		protected void CheckInput()
		{
			bool flag = this.controller;
			if (flag)
			{
				bool flag2 = !this.tracking && global::SteamVR_Controller.Input((int)this.controller.Tracking.index).GetPressDown(global::Valve.VR.EVRButtonId.k_EButton_Axis1);
				if (flag2)
				{
					this.tracking = true;
					this.posOffset = base.transform.position - this.controller.transform.position;
					this.rotOffset = global::UnityEngine.Quaternion.Inverse(this.controller.transform.rotation) * base.transform.rotation;
				}
				else
				{
					bool flag3 = this.tracking;
					if (flag3)
					{
						bool pressUp = global::SteamVR_Controller.Input((int)this.controller.Tracking.index).GetPressUp(global::Valve.VR.EVRButtonId.k_EButton_Axis1);
						if (pressUp)
						{
							this.tracking = false;
						}
						else
						{
							base.transform.position = this.controller.transform.position + this.posOffset;
							base.transform.rotation = this.controller.transform.rotation * this.rotOffset;
						}
					}
				}
			}
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000E697 File Offset: 0x0000C897
		public void OnTriggerEnter(global::UnityEngine.Collider other)
		{
			base.GetComponent<global::UnityEngine.Renderer>().material.color = global::UnityEngine.Color.red;
			this.controller = other.GetComponentInParent<global::VRGIN.Controls.Controller>();
			this.controller.ToolEnabled = false;
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000E6CC File Offset: 0x0000C8CC
		public void OnTriggerExit()
		{
			base.GetComponent<global::UnityEngine.Renderer>().material.color = global::UnityEngine.Color.white;
			this.controller.ToolEnabled = true;
			bool flag = !this.tracking;
			if (flag)
			{
				this.controller = null;
			}
		}

		// Token: 0x04000516 RID: 1302
		private global::SteamVR_RenderModel model;

		// Token: 0x04000517 RID: 1303
		private global::VRGIN.Controls.Controller controller;

		// Token: 0x04000518 RID: 1304
		private bool tracking;

		// Token: 0x04000519 RID: 1305
		private static global::UnityEngine.Vector3 S_Position;

		// Token: 0x0400051A RID: 1306
		private static global::UnityEngine.Quaternion S_Rotation;

		// Token: 0x0400051B RID: 1307
		private global::UnityEngine.Vector3 posOffset;

		// Token: 0x0400051C RID: 1308
		private global::UnityEngine.Quaternion rotOffset;
	}
}

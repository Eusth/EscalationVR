using System;
using UnityEngine;
using VRGIN.Core;

namespace VRGIN.U46.Visuals
{
	// Token: 0x02000098 RID: 152
	public class PlayAreaVisualization : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x060002B7 RID: 695 RVA: 0x00010704 File Offset: 0x0000E904
		protected override void OnAwake()
		{
			base.OnAwake();
			this.CreateArea();
			this.Indicator = global::UnityEngine.GameObject.CreatePrimitive(0).transform;
			this.Indicator.SetParent(base.transform, false);
			this.HeightIndicator = global::UnityEngine.GameObject.CreatePrimitive(2).transform;
			this.HeightIndicator.SetParent(base.transform, false);
			foreach (global::UnityEngine.Transform transform in new global::UnityEngine.Transform[]
			{
				this.Indicator,
				this.HeightIndicator
			})
			{
				global::UnityEngine.Renderer component = transform.GetComponent<global::UnityEngine.Renderer>();
				component.material = global::UnityEngine.Resources.GetBuiltinResource<global::UnityEngine.Material>("Sprites-Default.mat");
				component.reflectionProbeUsage = 0;
				component.shadowCastingMode = 0;
				component.receiveShadows = false;
				component.useLightProbes = false;
				component.material.color = global::VRGIN.Core.VR.Context.PrimaryColor;
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x000107E4 File Offset: 0x0000E9E4
		protected virtual void CreateArea()
		{
			this.PlayArea = new global::UnityEngine.GameObject("PlayArea").AddComponent<global::SteamVR_PlayArea>();
			this.PlayArea.drawInGame = true;
			this.PlayArea.size = global::SteamVR_PlayArea.Size.Calibrated;
			this.PlayArea.transform.SetParent(base.transform, false);
			this.DirectionIndicator = this.CreateClone();
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00010844 File Offset: 0x0000EA44
		protected virtual global::UnityEngine.Transform CreateClone()
		{
			global::VRGIN.U46.Visuals.PlayAreaVisualization.HMDLoader hmdloader = new global::UnityEngine.GameObject("Model").AddComponent<global::VRGIN.U46.Visuals.PlayAreaVisualization.HMDLoader>();
			hmdloader.NewParent = this.PlayArea.transform;
			return hmdloader.transform;
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00010880 File Offset: 0x0000EA80
		internal static global::VRGIN.U46.Visuals.PlayAreaVisualization Create(global::VRGIN.Core.PlayArea playArea = null)
		{
			global::VRGIN.U46.Visuals.PlayAreaVisualization playAreaVisualization = new global::UnityEngine.GameObject("Play Area Viszalization").AddComponent<global::VRGIN.U46.Visuals.PlayAreaVisualization>();
			bool flag = playArea != null;
			if (flag)
			{
				playAreaVisualization.Area = playArea;
			}
			return playAreaVisualization;
		}

		// Token: 0x060002BB RID: 699 RVA: 0x000108B4 File Offset: 0x0000EAB4
		protected override void OnStart()
		{
			base.OnStart();
		}

		// Token: 0x060002BC RID: 700 RVA: 0x000108BE File Offset: 0x0000EABE
		protected virtual void OnEnable()
		{
			this.PlayArea.BuildMesh();
		}

		// Token: 0x060002BD RID: 701 RVA: 0x000108CD File Offset: 0x0000EACD
		protected virtual void OnDisable()
		{
		}

		// Token: 0x060002BE RID: 702 RVA: 0x000108D0 File Offset: 0x0000EAD0
		protected virtual void OnDestroy()
		{
		}

		// Token: 0x060002BF RID: 703 RVA: 0x000108D3 File Offset: 0x0000EAD3
		public void Enable()
		{
			base.gameObject.SetActive(true);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x000108E3 File Offset: 0x0000EAE3
		public void Disable()
		{
			base.gameObject.SetActive(false);
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x000108F4 File Offset: 0x0000EAF4
		public void UpdatePosition()
		{
			global::SteamVR_Camera steamCam = global::VRGIN.Core.VRCamera.Instance.SteamCam;
			float num = 2f;
			float y = steamCam.head.localPosition.y;
			float num2 = 1f;
			base.transform.position = this.Area.Position;
			base.transform.localScale = global::UnityEngine.Vector3.one * this.Area.Scale;
			this.PlayArea.transform.localPosition = -new global::UnityEngine.Vector3(steamCam.head.transform.localPosition.x, 0f, steamCam.head.transform.localPosition.z);
			base.transform.rotation = global::UnityEngine.Quaternion.Euler(0f, this.Area.Rotation, 0f);
			this.Indicator.localScale = global::UnityEngine.Vector3.one * 0.1f + global::UnityEngine.Vector3.one * global::UnityEngine.Mathf.Sin(global::UnityEngine.Time.time * 5f) * 0.05f;
			this.HeightIndicator.localScale = new global::UnityEngine.Vector3(0.01f, y / num, 0.01f);
			this.HeightIndicator.localPosition = new global::UnityEngine.Vector3(0f, y - num2 * (y / num), 0f);
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00010A56 File Offset: 0x0000EC56
		protected override void OnLateUpdate()
		{
			this.UpdatePosition();
		}

		// Token: 0x04000548 RID: 1352
		public global::VRGIN.Core.PlayArea Area = new global::VRGIN.Core.PlayArea();

		// Token: 0x04000549 RID: 1353
		private global::SteamVR_PlayArea PlayArea;

		// Token: 0x0400054A RID: 1354
		private global::UnityEngine.Transform Indicator;

		// Token: 0x0400054B RID: 1355
		private global::UnityEngine.Transform DirectionIndicator;

		// Token: 0x0400054C RID: 1356
		private global::UnityEngine.Transform HeightIndicator;

		// Token: 0x020001F3 RID: 499
		private class HMDLoader : global::VRGIN.Core.ProtectedBehaviour
		{
			// Token: 0x06000A57 RID: 2647 RVA: 0x00020D7C File Offset: 0x0001EF7C
			protected override void OnStart()
			{
				global::UnityEngine.Object.DontDestroyOnLoad(this);
				base.transform.localScale = global::UnityEngine.Vector3.zero;
				this._Model = base.gameObject.AddComponent<global::SteamVR_RenderModel>();
				this._Model.shader = global::VRGIN.Core.VR.Context.Materials.StandardShader;
				base.gameObject.AddComponent<global::SteamVR_TrackedObject>();
				this._Model.SetDeviceIndex(0);
			}

			// Token: 0x06000A58 RID: 2648 RVA: 0x00020DE8 File Offset: 0x0001EFE8
			protected override void OnUpdate()
			{
				base.OnUpdate();
				bool flag = !this.NewParent && !base.enabled;
				if (flag)
				{
					global::UnityEngine.Object.DestroyImmediate(base.gameObject);
				}
				bool flag2 = base.GetComponent<global::UnityEngine.Renderer>();
				if (flag2)
				{
					bool flag3 = this.NewParent;
					if (flag3)
					{
						base.transform.SetParent(this.NewParent, false);
						base.transform.localScale = global::UnityEngine.Vector3.one;
						base.GetComponent<global::UnityEngine.Renderer>().material.color = global::VRGIN.Core.VR.Context.PrimaryColor;
						base.enabled = false;
					}
					else
					{
						global::VRGIN.Core.VRLog.Info("We're too late!", global::System.Array.Empty<object>());
						global::UnityEngine.Object.Destroy(base.gameObject);
					}
				}
			}

			// Token: 0x04000770 RID: 1904
			public global::UnityEngine.Transform NewParent;

			// Token: 0x04000771 RID: 1905
			private global::SteamVR_RenderModel _Model;
		}
	}
}

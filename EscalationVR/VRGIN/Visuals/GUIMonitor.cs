using System;
using System.ComponentModel;
using UnityEngine;
using VRGIN.Core;

namespace VRGIN.Visuals
{
	// Token: 0x02000089 RID: 137
	public class GUIMonitor : global::VRGIN.Visuals.GUIQuad
	{
		// Token: 0x06000225 RID: 549 RVA: 0x0000DC34 File Offset: 0x0000BE34
		protected override void OnStart()
		{
			base.OnStart();
			this._Plane = base.GetComponent<global::VRGIN.Visuals.ProceduralPlane>();
			this._Plane.xSegments = 100;
			bool flag = this._Plane;
			if (flag)
			{
				global::VRGIN.Core.VRLog.Info("Plane was added...", global::System.Array.Empty<object>());
			}
			else
			{
				global::VRGIN.Core.VRLog.Info("No plane either?", global::System.Array.Empty<object>());
			}
			this.UpdateGUI();
			this.Rebuild();
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000DCA5 File Offset: 0x0000BEA5
		protected override void OnEnable()
		{
			base.OnEnable();
			global::VRGIN.Core.VR.Settings.PropertyChanged += new global::System.EventHandler<global::System.ComponentModel.PropertyChangedEventArgs>(this.OnPropertyChanged);
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000DCC6 File Offset: 0x0000BEC6
		protected override void OnDisable()
		{
			base.OnDisable();
			global::VRGIN.Core.VR.Settings.PropertyChanged -= new global::System.EventHandler<global::System.ComponentModel.PropertyChangedEventArgs>(this.OnPropertyChanged);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000DCE8 File Offset: 0x0000BEE8
		public static global::VRGIN.Visuals.GUIMonitor Create()
		{
			return new global::UnityEngine.GameObject("GUI Monitor").AddComponent<global::VRGIN.Visuals.ProceduralPlane>().gameObject.AddComponent<global::VRGIN.Visuals.GUIMonitor>();
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000DD15 File Offset: 0x0000BF15
		public override void UpdateAspect()
		{
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000DD18 File Offset: 0x0000BF18
		private void OnPropertyChanged(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
		{
			bool flag = this._Plane;
			if (flag)
			{
				string propertyName = e.PropertyName;
				string text = propertyName;
				if (text != null)
				{
					if (!(text == "Angle") && !(text == "OffsetY") && !(text == "Distance") && !(text == "Rotation"))
					{
						if (text == "Projection")
						{
							this.TargetCurviness = global::VRGIN.Core.VR.Settings.Projection;
						}
					}
					else
					{
						this.Rebuild();
					}
				}
			}
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000DDA4 File Offset: 0x0000BFA4
		protected override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = global::UnityEngine.Mathf.Abs(this._Curviness - (float)this.TargetCurviness) > float.Epsilon;
			if (flag)
			{
				this._Curviness = global::UnityEngine.Mathf.MoveTowards(this._Curviness, (float)this.TargetCurviness, global::UnityEngine.Time.deltaTime * 5f);
				this.Rebuild();
			}
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000DE04 File Offset: 0x0000C004
		public void Rebuild()
		{
			global::VRGIN.Core.VRLog.Info("Build monitor", global::System.Array.Empty<object>());
			try
			{
				base.transform.localPosition = new global::UnityEngine.Vector3(base.transform.localPosition.x, global::VRGIN.Core.VR.Settings.OffsetY, base.transform.localPosition.z);
				base.transform.localScale = global::UnityEngine.Vector3.one * global::VRGIN.Core.VR.Settings.Distance;
				base.transform.localRotation = global::UnityEngine.Quaternion.Euler(0f, global::VRGIN.Core.VR.Settings.Rotation, 0f);
				this._Plane.angleSpan = global::VRGIN.Core.VR.Settings.Angle;
				this._Plane.curviness = this._Curviness;
				this._Plane.height = global::VRGIN.Core.VR.Settings.Angle / 100f;
				this._Plane.distance = 1f;
				this._Plane.Rebuild();
			}
			catch (global::System.Exception obj)
			{
				global::VRGIN.Core.VRLog.Error(obj);
			}
		}

		// Token: 0x0400050D RID: 1293
		public global::VRGIN.Visuals.GUIMonitor.CurvinessState TargetCurviness = global::VRGIN.Core.VR.Settings.Projection;

		// Token: 0x0400050E RID: 1294
		private float _Curviness = 1f;

		// Token: 0x0400050F RID: 1295
		public float Angle = 0f;

		// Token: 0x04000510 RID: 1296
		public float Distance = 0f;

		// Token: 0x04000511 RID: 1297
		private global::VRGIN.Visuals.ProceduralPlane _Plane;

		// Token: 0x020001EB RID: 491
		public enum CurvinessState
		{
			// Token: 0x04000747 RID: 1863
			Flat,
			// Token: 0x04000748 RID: 1864
			Curved,
			// Token: 0x04000749 RID: 1865
			Spherical
		}
	}
}

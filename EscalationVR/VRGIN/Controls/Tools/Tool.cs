using System;
using System.Collections.Generic;
using UnityEngine;
using VRGIN.Core;

namespace VRGIN.Controls.Tools
{
	// Token: 0x020000C2 RID: 194
	public abstract class Tool : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x0600045F RID: 1119
		public abstract global::UnityEngine.Texture2D Image { get; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000460 RID: 1120 RVA: 0x00015ECE File Offset: 0x000140CE
		// (set) Token: 0x06000461 RID: 1121 RVA: 0x00015ED6 File Offset: 0x000140D6
		public global::UnityEngine.GameObject Icon { get; set; }

		// Token: 0x06000462 RID: 1122 RVA: 0x00015EE0 File Offset: 0x000140E0
		protected override void OnStart()
		{
			base.OnStart();
			this.Tracking = base.GetComponent<global::SteamVR_TrackedObject>();
			this.Owner = base.GetComponent<global::VRGIN.Controls.Controller>();
			this.Neighbor = ((global::VRGIN.Core.VR.Mode.Left == this.Owner) ? global::VRGIN.Core.VR.Mode.Right : global::VRGIN.Core.VR.Mode.Left);
			global::VRGIN.Core.VRLog.Info(this.Neighbor ? "Got my neighbor!" : "No neighbor", global::System.Array.Empty<object>());
		}

		// Token: 0x06000463 RID: 1123
		protected abstract void OnDestroy();

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x00015F64 File Offset: 0x00014164
		protected bool IsTracking
		{
			get
			{
				return this.Tracking && this.Tracking.isValid;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x00015F94 File Offset: 0x00014194
		protected global::SteamVR_Controller.Device Controller
		{
			get
			{
				return global::SteamVR_Controller.Input((int)this.Tracking.index);
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000466 RID: 1126 RVA: 0x00015FB8 File Offset: 0x000141B8
		protected global::VRGIN.Controls.Controller OtherController
		{
			get
			{
				return this.Neighbor;
			}
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00015FD0 File Offset: 0x000141D0
		protected virtual void OnEnable()
		{
			global::VRGIN.Core.VRLog.Info("On Enable: {0}", new object[]
			{
				base.GetType().Name
			});
			bool flag = this.Icon;
			if (flag)
			{
				this.Icon.SetActive(true);
			}
			else
			{
				global::VRGIN.Core.VRLog.Info("But no icon...", global::System.Array.Empty<object>());
			}
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00016030 File Offset: 0x00014230
		protected virtual void OnDisable()
		{
			global::VRGIN.Core.VRLog.Info("On Disable: {0}", new object[]
			{
				base.GetType().Name
			});
			bool flag = this.Icon;
			if (flag)
			{
				this.Icon.SetActive(false);
			}
			else
			{
				global::VRGIN.Core.VRLog.Info("But no icon...", global::System.Array.Empty<object>());
			}
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00016090 File Offset: 0x00014290
		public virtual global::System.Collections.Generic.List<global::VRGIN.Controls.HelpText> GetHelpTexts()
		{
			return new global::System.Collections.Generic.List<global::VRGIN.Controls.HelpText>();
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x000160A8 File Offset: 0x000142A8
		protected global::UnityEngine.Transform FindAttachPosition(params string[] names)
		{
			return this.Owner.FindAttachPosition(names);
		}

		// Token: 0x04000608 RID: 1544
		protected global::SteamVR_TrackedObject Tracking;

		// Token: 0x04000609 RID: 1545
		protected global::VRGIN.Controls.Controller Owner;

		// Token: 0x0400060A RID: 1546
		protected global::VRGIN.Controls.Controller Neighbor;
	}
}

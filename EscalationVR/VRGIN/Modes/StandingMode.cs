using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Valve.VR;
using VRGIN.Controls.Tools;
using VRGIN.Core;

namespace VRGIN.Modes
{
	// Token: 0x02000097 RID: 151
	public class StandingMode : global::VRGIN.Modes.ControlMode
	{
		// Token: 0x060002AF RID: 687 RVA: 0x000105A7 File Offset: 0x0000E7A7
		public override void Impersonate(global::VRGIN.Core.IActor actor, global::VRGIN.Modes.ImpersonationMode mode)
		{
			base.Impersonate(actor, mode);
			this.MoveToPosition(actor.Eyes.position, actor.Eyes.rotation, mode == global::VRGIN.Modes.ImpersonationMode.Approximately);
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x000105D4 File Offset: 0x0000E7D4
		public override void OnDestroy()
		{
			base.OnDestroy();
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x000105DE File Offset: 0x0000E7DE
		protected override void OnStart()
		{
			base.OnStart();
			global::VRGIN.Core.VR.Camera.SteamCam.origin.position = global::UnityEngine.Vector3.zero;
			global::VRGIN.Core.VR.Camera.SteamCam.origin.rotation = global::UnityEngine.Quaternion.identity;
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0001061C File Offset: 0x0000E81C
		protected override void OnUpdate()
		{
			base.OnUpdate();
			bool hasValidBlueprint = global::VRGIN.Core.VRCamera.Instance.HasValidBlueprint;
			if (hasValidBlueprint)
			{
				this.SyncCameras();
			}
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00010648 File Offset: 0x0000E848
		protected virtual void SyncCameras()
		{
			global::VRGIN.Core.VRCamera.Instance.Blueprint.transform.position = global::VRGIN.Core.VR.Camera.SteamCam.head.position;
			global::VRGIN.Core.VRCamera.Instance.Blueprint.transform.rotation = global::VRGIN.Core.VR.Camera.SteamCam.head.rotation;
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x000106A8 File Offset: 0x0000E8A8
		public override global::System.Collections.Generic.IEnumerable<global::System.Type> Tools
		{
			get
			{
				return global::System.Linq.Enumerable.Concat<global::System.Type>(base.Tools, new global::System.Type[]
				{
					typeof(global::VRGIN.Controls.Tools.MenuTool),
					typeof(global::VRGIN.Controls.Tools.WarpTool)
				});
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x000106E8 File Offset: 0x0000E8E8
		public override global::Valve.VR.ETrackingUniverseOrigin TrackingOrigin
		{
			get
			{
				return global::Valve.VR.ETrackingUniverseOrigin.TrackingUniverseStanding;
			}
		}
	}
}

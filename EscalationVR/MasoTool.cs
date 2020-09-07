using System;
using UnityEngine;
using Valve.VR;
using VRGIN.Controls.Tools;
using VRGIN.Core;
using VRGIN.Helpers;

namespace EscalationVR
{
	// Token: 0x020000F0 RID: 240
	public class MasoTool : global::VRGIN.Controls.Tools.Tool
	{
		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000622 RID: 1570 RVA: 0x0001D868 File Offset: 0x0001BA68
		public override global::UnityEngine.Texture2D Image
		{
			get
			{
				return global::VRGIN.Helpers.UnityHelper.LoadImage("icon_warp.png");
			}
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0001D884 File Offset: 0x0001BA84
		protected override void OnUpdate()
		{
			bool pressUp = base.Controller.GetPressUp(global::Valve.VR.EVRButtonId.k_EButton_Grip);
			if (pressUp)
			{
				global::EscalationVR.MasoMode masoMode = global::VRGIN.Core.VR.Mode as global::EscalationVR.MasoMode;
				if (masoMode != null)
				{
					masoMode.ResetPosition();
				}
			}
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0001D8BA File Offset: 0x0001BABA
		protected override void OnDestroy()
		{
		}
	}
}

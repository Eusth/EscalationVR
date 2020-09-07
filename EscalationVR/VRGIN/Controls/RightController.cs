using System;
using UnityEngine;

namespace VRGIN.Controls
{
	// Token: 0x020000BF RID: 191
	public class RightController : global::VRGIN.Controls.Controller
	{
		// Token: 0x0600044A RID: 1098 RVA: 0x00015740 File Offset: 0x00013940
		public static global::VRGIN.Controls.RightController Create()
		{
			global::VRGIN.Controls.RightController rightController = new global::UnityEngine.GameObject("Right Controller").AddComponent<global::VRGIN.Controls.RightController>();
			rightController.ToolIndex = 1;
			return rightController;
		}
	}
}

using System;
using UnityEngine;

namespace VRGIN.Controls
{
	// Token: 0x020000BE RID: 190
	public class LeftController : global::VRGIN.Controls.Controller
	{
		// Token: 0x06000448 RID: 1096 RVA: 0x00015714 File Offset: 0x00013914
		public static global::VRGIN.Controls.LeftController Create()
		{
			return new global::UnityEngine.GameObject("Left Controller").AddComponent<global::VRGIN.Controls.LeftController>();
		}
	}
}

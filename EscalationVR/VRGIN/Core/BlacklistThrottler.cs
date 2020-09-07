using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VRGIN.Core
{
	// Token: 0x020000A9 RID: 169
	internal class BlacklistThrottler : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x06000342 RID: 834 RVA: 0x000119FA File Offset: 0x0000FBFA
		protected override void OnStart()
		{
			this.Targets.Add(typeof(global::UnityEngine.Camera));
			base.OnStart();
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00011A1C File Offset: 0x0000FC1C
		protected override void OnUpdate()
		{
			foreach (global::UnityEngine.Behaviour behaviour in global::System.Linq.Enumerable.Where<global::UnityEngine.Behaviour>(base.GetComponents<global::UnityEngine.Behaviour>(), (global::UnityEngine.Behaviour c) => this.Targets.Contains(c.GetType())))
			{
				behaviour.enabled = false;
			}
			base.OnUpdate();
		}

		// Token: 0x04000571 RID: 1393
		public global::System.Collections.Generic.HashSet<global::System.Type> Targets = new global::System.Collections.Generic.HashSet<global::System.Type>();
	}
}

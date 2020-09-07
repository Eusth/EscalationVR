using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VRGIN.Core
{
	// Token: 0x020000A8 RID: 168
	internal class WhitelistThrottler : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x0600033E RID: 830 RVA: 0x0001192D File Offset: 0x0000FB2D
		protected override void OnStart()
		{
			this.Exceptions.Add(typeof(global::UnityEngine.Transform));
			this.Exceptions.Add(typeof(global::VRGIN.Core.ProtectedBehaviour));
			base.OnStart();
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00011964 File Offset: 0x0000FB64
		protected override void OnUpdate()
		{
			foreach (global::UnityEngine.Behaviour behaviour in global::System.Linq.Enumerable.Where<global::UnityEngine.Behaviour>(base.GetComponents<global::UnityEngine.Behaviour>(), (global::UnityEngine.Behaviour c) => !this.Exceptions.Contains(c.GetType())))
			{
				behaviour.enabled = false;
			}
			base.OnUpdate();
		}

		// Token: 0x04000570 RID: 1392
		public global::System.Collections.Generic.HashSet<global::System.Type> Exceptions = new global::System.Collections.Generic.HashSet<global::System.Type>();
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;
using VRGIN.Core;

namespace EscalationVR
{
	// Token: 0x020000E9 RID: 233
	public class EscalationInterpreter : global::VRGIN.Core.GameInterpreter
	{
		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060005E2 RID: 1506 RVA: 0x0001CF38 File Offset: 0x0001B138
		public override global::System.Collections.Generic.IEnumerable<global::VRGIN.Core.IActor> Actors
		{
			get
			{
				bool flag = this._currentActor == null || !this._currentActor.IsValid;
				if (flag)
				{
					global::FlagActivator_Man actor = global::UnityEngine.Object.FindObjectOfType<global::FlagActivator_Man>();
					global::FlagActivator_Skanojo woman = global::UnityEngine.Object.FindObjectOfType<global::FlagActivator_Skanojo>();
					bool flag2 = actor && woman;
					if (!flag2)
					{
						yield break;
					}
					this._currentActor = new global::EscalationVR.EscalationActor(actor, woman);
					actor = null;
					woman = null;
				}
				bool isValid = this._currentActor.IsValid;
				if (isValid)
				{
					yield return this._currentActor;
				}
				yield break;
			}
		}

		// Token: 0x0400068F RID: 1679
		private global::EscalationVR.EscalationActor _currentActor;
	}
}

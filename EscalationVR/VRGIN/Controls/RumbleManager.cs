using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Valve.VR;
using VRGIN.Core;
using VRGIN.Helpers;

namespace VRGIN.Controls
{
	// Token: 0x020000C0 RID: 192
	public class RumbleManager : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x0600044C RID: 1100 RVA: 0x00015774 File Offset: 0x00013974
		protected override void OnStart()
		{
			base.OnStart();
			this._Controller = base.GetComponent<global::VRGIN.Controls.Controller>();
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0001578A File Offset: 0x0001398A
		protected virtual void OnDisable()
		{
			this._RumbleSessions.Clear();
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0001579C File Offset: 0x0001399C
		protected override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this._RumbleSessions.Count > 0;
			if (flag)
			{
				global::VRGIN.Helpers.IRumbleSession rumbleSession = global::System.Linq.Enumerable.Max<global::VRGIN.Helpers.IRumbleSession>(this._RumbleSessions);
				float num = global::UnityEngine.Time.unscaledTime - this._LastImpulse;
				bool flag2 = this._Controller.Tracking.isValid && num >= rumbleSession.MilliInterval * 0.001f && num > 0.00500000035f;
				if (flag2)
				{
					bool isOver = rumbleSession.IsOver;
					if (isOver)
					{
						this._RumbleSessions.Remove(rumbleSession);
					}
					else
					{
						bool rumble = global::VRGIN.Core.VR.Settings.Rumble;
						if (rumble)
						{
							global::SteamVR_Controller.Input((int)this._Controller.Tracking.index).TriggerHapticPulse(rumbleSession.MicroDuration, global::Valve.VR.EVRButtonId.k_EButton_Axis0);
						}
						this._LastImpulse = global::UnityEngine.Time.unscaledTime;
						rumbleSession.Consume();
					}
				}
			}
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00015879 File Offset: 0x00013A79
		public void StartRumble(global::VRGIN.Helpers.IRumbleSession session)
		{
			this._RumbleSessions.Add(session);
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00015889 File Offset: 0x00013A89
		internal void StopRumble(global::VRGIN.Helpers.IRumbleSession session)
		{
			this._RumbleSessions.Remove(session);
		}

		// Token: 0x040005FC RID: 1532
		private const float MILLI_TO_SECONDS = 0.001f;

		// Token: 0x040005FD RID: 1533
		public const float MIN_INTERVAL = 0.00500000035f;

		// Token: 0x040005FE RID: 1534
		private global::System.Collections.Generic.HashSet<global::VRGIN.Helpers.IRumbleSession> _RumbleSessions = new global::System.Collections.Generic.HashSet<global::VRGIN.Helpers.IRumbleSession>();

		// Token: 0x040005FF RID: 1535
		private float _LastImpulse;

		// Token: 0x04000600 RID: 1536
		private global::VRGIN.Controls.Controller _Controller;
	}
}

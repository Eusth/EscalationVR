using System;
using UnityEngine;

// Token: 0x02000016 RID: 22
public abstract class SteamVR_Status : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060000DF RID: 223
	protected abstract void SetAlpha(float a);

	// Token: 0x060000E0 RID: 224 RVA: 0x00009CC7 File Offset: 0x00007EC7
	private void OnEnable()
	{
		global::SteamVR_Utils.Event.Listen(this.message, new global::SteamVR_Utils.Event.Handler(this.OnEvent));
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x00009CE2 File Offset: 0x00007EE2
	private void OnDisable()
	{
		global::SteamVR_Utils.Event.Remove(this.message, new global::SteamVR_Utils.Event.Handler(this.OnEvent));
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x00009D00 File Offset: 0x00007F00
	private void OnEvent(params object[] args)
	{
		this.status = (bool)args[0];
		bool flag = this.status;
		if (flag)
		{
			bool flag2 = this.mode == global::SteamVR_Status.Mode.OnTrue;
			if (flag2)
			{
				this.timer = this.duration;
			}
		}
		else
		{
			bool flag3 = this.mode == global::SteamVR_Status.Mode.OnFalse;
			if (flag3)
			{
				this.timer = this.duration;
			}
		}
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x00009D60 File Offset: 0x00007F60
	private void Update()
	{
		bool flag = this.mode == global::SteamVR_Status.Mode.OnTrue || this.mode == global::SteamVR_Status.Mode.OnFalse;
		if (flag)
		{
			this.timer -= global::UnityEngine.Time.deltaTime;
			bool flag2 = this.timer < 0f;
			if (flag2)
			{
				this.SetAlpha(0f);
			}
			else
			{
				float alpha = 1f;
				bool flag3 = this.timer < this.fade;
				if (flag3)
				{
					alpha = this.timer / this.fade;
				}
				bool flag4 = this.timer > this.duration - this.fade;
				if (flag4)
				{
					alpha = global::UnityEngine.Mathf.InverseLerp(this.duration, this.duration - this.fade, this.timer);
				}
				this.SetAlpha(alpha);
			}
		}
		else
		{
			this.timer = (((this.mode == global::SteamVR_Status.Mode.WhileTrue && this.status) || (this.mode == global::SteamVR_Status.Mode.WhileFalse && !this.status)) ? global::UnityEngine.Mathf.Min(this.fade, this.timer + global::UnityEngine.Time.deltaTime) : global::UnityEngine.Mathf.Max(0f, this.timer - global::UnityEngine.Time.deltaTime));
			this.SetAlpha(this.timer / this.fade);
		}
	}

	// Token: 0x040000BF RID: 191
	public string message;

	// Token: 0x040000C0 RID: 192
	public float duration;

	// Token: 0x040000C1 RID: 193
	public float fade;

	// Token: 0x040000C2 RID: 194
	protected float timer;

	// Token: 0x040000C3 RID: 195
	protected bool status;

	// Token: 0x040000C4 RID: 196
	public global::SteamVR_Status.Mode mode;

	// Token: 0x02000104 RID: 260
	public enum Mode
	{
		// Token: 0x04000720 RID: 1824
		OnTrue,
		// Token: 0x04000721 RID: 1825
		OnFalse,
		// Token: 0x04000722 RID: 1826
		WhileTrue,
		// Token: 0x04000723 RID: 1827
		WhileFalse
	}
}

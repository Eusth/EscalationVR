using System;
using UnityEngine;
using Valve.VR;

// Token: 0x0200000F RID: 15
public class SteamVR_Menu : global::UnityEngine.MonoBehaviour
{
	// Token: 0x1700001F RID: 31
	// (get) Token: 0x0600008C RID: 140 RVA: 0x00006824 File Offset: 0x00004A24
	public global::UnityEngine.RenderTexture texture
	{
		get
		{
			return this.overlay ? (this.overlay.texture as global::UnityEngine.RenderTexture) : null;
		}
	}

	// Token: 0x17000020 RID: 32
	// (get) Token: 0x0600008D RID: 141 RVA: 0x00006856 File Offset: 0x00004A56
	// (set) Token: 0x0600008E RID: 142 RVA: 0x0000685E File Offset: 0x00004A5E
	public float scale { get; private set; }

	// Token: 0x0600008F RID: 143 RVA: 0x00006868 File Offset: 0x00004A68
	private void Awake()
	{
		this.scaleLimitX = string.Format("{0:N1}", this.scaleLimits.x);
		this.scaleLimitY = string.Format("{0:N1}", this.scaleLimits.y);
		this.scaleRateText = string.Format("{0:N1}", this.scaleRate);
		global::SteamVR_Overlay instance = global::SteamVR_Overlay.instance;
		bool flag = instance != null;
		if (flag)
		{
			this.uvOffset = instance.uvOffset;
			this.distance = instance.distance;
		}
	}

	// Token: 0x06000090 RID: 144 RVA: 0x000068FC File Offset: 0x00004AFC
	private void OnGUI()
	{
		bool flag = this.overlay == null;
		if (!flag)
		{
			global::UnityEngine.RenderTexture renderTexture = this.overlay.texture as global::UnityEngine.RenderTexture;
			global::UnityEngine.RenderTexture active = global::UnityEngine.RenderTexture.active;
			global::UnityEngine.RenderTexture.active = renderTexture;
			bool flag2 = global::UnityEngine.Event.current.type == 7;
			if (flag2)
			{
				global::UnityEngine.GL.Clear(false, true, global::UnityEngine.Color.clear);
			}
			global::UnityEngine.Rect rect;
			rect..ctor(0f, 0f, (float)renderTexture.width, (float)renderTexture.height);
			bool flag3 = global::UnityEngine.Screen.width < renderTexture.width;
			if (flag3)
			{
				rect.width = (float)global::UnityEngine.Screen.width;
				this.overlay.uvOffset.x = -(float)(renderTexture.width - global::UnityEngine.Screen.width) / (float)(2 * renderTexture.width);
			}
			bool flag4 = global::UnityEngine.Screen.height < renderTexture.height;
			if (flag4)
			{
				rect.height = (float)global::UnityEngine.Screen.height;
				this.overlay.uvOffset.y = (float)(renderTexture.height - global::UnityEngine.Screen.height) / (float)(2 * renderTexture.height);
			}
			global::UnityEngine.GUILayout.BeginArea(rect);
			bool flag5 = this.background != null;
			if (flag5)
			{
				global::UnityEngine.GUI.DrawTexture(new global::UnityEngine.Rect((rect.width - (float)this.background.width) / 2f, (rect.height - (float)this.background.height) / 2f, (float)this.background.width, (float)this.background.height), this.background);
			}
			global::UnityEngine.GUILayout.BeginHorizontal(global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			global::UnityEngine.GUILayout.FlexibleSpace();
			global::UnityEngine.GUILayout.BeginVertical(global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			bool flag6 = this.logo != null;
			if (flag6)
			{
				global::UnityEngine.GUILayout.Space(rect.height / 2f - this.logoHeight);
				global::UnityEngine.GUILayout.Box(this.logo, global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			}
			global::UnityEngine.GUILayout.Space(this.menuOffset);
			bool flag7 = global::UnityEngine.GUILayout.Button("[Esc] - Close menu", global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			global::UnityEngine.GUILayout.BeginHorizontal(global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			global::UnityEngine.GUILayout.Label(string.Format("Scale: {0:N4}", this.scale), global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			float num = global::UnityEngine.GUILayout.HorizontalSlider(this.scale, this.scaleLimits.x, this.scaleLimits.y, global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			bool flag8 = num != this.scale;
			if (flag8)
			{
				this.SetScale(num);
			}
			global::UnityEngine.GUILayout.EndHorizontal();
			global::UnityEngine.GUILayout.BeginHorizontal(global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			global::UnityEngine.GUILayout.Label(string.Format("Scale limits:", global::System.Array.Empty<object>()), global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			string text = global::UnityEngine.GUILayout.TextField(this.scaleLimitX, global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			bool flag9 = text != this.scaleLimitX;
			if (flag9)
			{
				bool flag10 = float.TryParse(text, ref this.scaleLimits.x);
				if (flag10)
				{
					this.scaleLimitX = text;
				}
			}
			string text2 = global::UnityEngine.GUILayout.TextField(this.scaleLimitY, global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			bool flag11 = text2 != this.scaleLimitY;
			if (flag11)
			{
				bool flag12 = float.TryParse(text2, ref this.scaleLimits.y);
				if (flag12)
				{
					this.scaleLimitY = text2;
				}
			}
			global::UnityEngine.GUILayout.EndHorizontal();
			global::UnityEngine.GUILayout.BeginHorizontal(global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			global::UnityEngine.GUILayout.Label(string.Format("Scale rate:", global::System.Array.Empty<object>()), global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			string text3 = global::UnityEngine.GUILayout.TextField(this.scaleRateText, global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			bool flag13 = text3 != this.scaleRateText;
			if (flag13)
			{
				bool flag14 = float.TryParse(text3, ref this.scaleRate);
				if (flag14)
				{
					this.scaleRateText = text3;
				}
			}
			global::UnityEngine.GUILayout.EndHorizontal();
			bool active2 = global::SteamVR.active;
			if (active2)
			{
				global::SteamVR instance = global::SteamVR.instance;
				global::UnityEngine.GUILayout.BeginHorizontal(global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
				float sceneResolutionScale = global::SteamVR_Camera.sceneResolutionScale;
				int num2 = (int)(instance.sceneWidth * sceneResolutionScale);
				int num3 = (int)(instance.sceneHeight * sceneResolutionScale);
				int num4 = (int)(100f * sceneResolutionScale);
				global::UnityEngine.GUILayout.Label(string.Format("Scene quality: {0}x{1} ({2}%)", num2, num3, num4), global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
				int num5 = global::UnityEngine.Mathf.RoundToInt(global::UnityEngine.GUILayout.HorizontalSlider((float)num4, 50f, 200f, global::System.Array.Empty<global::UnityEngine.GUILayoutOption>()));
				bool flag15 = num5 != num4;
				if (flag15)
				{
					global::SteamVR_Camera.sceneResolutionScale = (float)num5 / 100f;
				}
				global::UnityEngine.GUILayout.EndHorizontal();
			}
			this.overlay.highquality = global::UnityEngine.GUILayout.Toggle(this.overlay.highquality, "High quality", global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			bool highquality = this.overlay.highquality;
			if (highquality)
			{
				this.overlay.curved = global::UnityEngine.GUILayout.Toggle(this.overlay.curved, "Curved overlay", global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
				this.overlay.antialias = global::UnityEngine.GUILayout.Toggle(this.overlay.antialias, "Overlay RGSS(2x2)", global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			}
			else
			{
				this.overlay.curved = false;
				this.overlay.antialias = false;
			}
			global::SteamVR_Camera steamVR_Camera = global::SteamVR_Render.Top();
			bool flag16 = steamVR_Camera != null;
			if (flag16)
			{
				steamVR_Camera.wireframe = global::UnityEngine.GUILayout.Toggle(steamVR_Camera.wireframe, "Wireframe", global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
				global::SteamVR_Render instance2 = global::SteamVR_Render.instance;
				bool flag17 = instance2.trackingSpace == global::Valve.VR.ETrackingUniverseOrigin.TrackingUniverseSeated;
				if (flag17)
				{
					bool flag18 = global::UnityEngine.GUILayout.Button("Switch to Standing", global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
					if (flag18)
					{
						instance2.trackingSpace = global::Valve.VR.ETrackingUniverseOrigin.TrackingUniverseStanding;
					}
					bool flag19 = global::UnityEngine.GUILayout.Button("Center View", global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
					if (flag19)
					{
						global::Valve.VR.CVRSystem system = global::Valve.VR.OpenVR.System;
						bool flag20 = system != null;
						if (flag20)
						{
							system.ResetSeatedZeroPose();
						}
					}
				}
				else
				{
					bool flag21 = global::UnityEngine.GUILayout.Button("Switch to Seated", global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
					if (flag21)
					{
						instance2.trackingSpace = global::Valve.VR.ETrackingUniverseOrigin.TrackingUniverseSeated;
					}
				}
			}
			bool flag22 = global::UnityEngine.GUILayout.Button("Exit", global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			if (flag22)
			{
				global::UnityEngine.Application.Quit();
			}
			global::UnityEngine.GUILayout.Space(this.menuOffset);
			string environmentVariable = global::System.Environment.GetEnvironmentVariable("VR_OVERRIDE");
			bool flag23 = environmentVariable != null;
			if (flag23)
			{
				global::UnityEngine.GUILayout.Label("VR_OVERRIDE=" + environmentVariable, global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			}
			global::UnityEngine.GUILayout.Label("Graphics device: " + global::UnityEngine.SystemInfo.graphicsDeviceVersion, global::System.Array.Empty<global::UnityEngine.GUILayoutOption>());
			global::UnityEngine.GUILayout.EndVertical();
			global::UnityEngine.GUILayout.FlexibleSpace();
			global::UnityEngine.GUILayout.EndHorizontal();
			global::UnityEngine.GUILayout.EndArea();
			bool flag24 = this.cursor != null;
			if (flag24)
			{
				float x = global::UnityEngine.Input.mousePosition.x;
				float num6 = (float)global::UnityEngine.Screen.height - global::UnityEngine.Input.mousePosition.y;
				float num7 = (float)this.cursor.width;
				float num8 = (float)this.cursor.height;
				global::UnityEngine.GUI.DrawTexture(new global::UnityEngine.Rect(x, num6, num7, num8), this.cursor);
			}
			global::UnityEngine.RenderTexture.active = active;
			bool flag25 = flag7;
			if (flag25)
			{
				this.HideMenu();
			}
		}
	}

	// Token: 0x06000091 RID: 145 RVA: 0x00006FC8 File Offset: 0x000051C8
	public void ShowMenu()
	{
		global::SteamVR_Overlay instance = global::SteamVR_Overlay.instance;
		bool flag = instance == null;
		if (!flag)
		{
			global::UnityEngine.RenderTexture renderTexture = instance.texture as global::UnityEngine.RenderTexture;
			bool flag2 = renderTexture == null;
			if (flag2)
			{
				global::UnityEngine.Debug.LogError("Menu requires overlay texture to be a render texture.");
			}
			else
			{
				this.SaveCursorState();
				global::UnityEngine.Cursor.visible = true;
				global::UnityEngine.Cursor.lockState = 0;
				this.overlay = instance;
				this.uvOffset = instance.uvOffset;
				this.distance = instance.distance;
				global::UnityEngine.Camera[] array = global::UnityEngine.Object.FindObjectsOfType(typeof(global::UnityEngine.Camera)) as global::UnityEngine.Camera[];
				foreach (global::UnityEngine.Camera camera in array)
				{
					bool flag3 = camera.enabled && camera.targetTexture == renderTexture;
					if (flag3)
					{
						this.overlayCam = camera;
						this.overlayCam.enabled = false;
						break;
					}
				}
				global::SteamVR_Camera steamVR_Camera = global::SteamVR_Render.Top();
				bool flag4 = steamVR_Camera != null;
				if (flag4)
				{
					this.scale = steamVR_Camera.origin.localScale.x;
				}
			}
		}
	}

	// Token: 0x06000092 RID: 146 RVA: 0x000070E4 File Offset: 0x000052E4
	public void HideMenu()
	{
		this.RestoreCursorState();
		bool flag = this.overlayCam != null;
		if (flag)
		{
			this.overlayCam.enabled = true;
		}
		bool flag2 = this.overlay != null;
		if (flag2)
		{
			this.overlay.uvOffset = this.uvOffset;
			this.overlay.distance = this.distance;
			this.overlay = null;
		}
	}

	// Token: 0x06000093 RID: 147 RVA: 0x00007154 File Offset: 0x00005354
	private void Update()
	{
		bool flag = global::UnityEngine.Input.GetKeyDown(27) || global::UnityEngine.Input.GetKeyDown(357);
		if (flag)
		{
			bool flag2 = this.overlay == null;
			if (flag2)
			{
				this.ShowMenu();
			}
			else
			{
				this.HideMenu();
			}
		}
		else
		{
			bool keyDown = global::UnityEngine.Input.GetKeyDown(278);
			if (keyDown)
			{
				this.SetScale(1f);
			}
			else
			{
				bool key = global::UnityEngine.Input.GetKey(280);
				if (key)
				{
					this.SetScale(global::UnityEngine.Mathf.Clamp(this.scale + this.scaleRate * global::UnityEngine.Time.deltaTime, this.scaleLimits.x, this.scaleLimits.y));
				}
				else
				{
					bool key2 = global::UnityEngine.Input.GetKey(281);
					if (key2)
					{
						this.SetScale(global::UnityEngine.Mathf.Clamp(this.scale - this.scaleRate * global::UnityEngine.Time.deltaTime, this.scaleLimits.x, this.scaleLimits.y));
					}
				}
			}
		}
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00007258 File Offset: 0x00005458
	private void SetScale(float scale)
	{
		this.scale = scale;
		global::SteamVR_Camera steamVR_Camera = global::SteamVR_Render.Top();
		bool flag = steamVR_Camera != null;
		if (flag)
		{
			steamVR_Camera.origin.localScale = new global::UnityEngine.Vector3(scale, scale, scale);
		}
	}

	// Token: 0x06000095 RID: 149 RVA: 0x00007293 File Offset: 0x00005493
	private void SaveCursorState()
	{
		this.savedCursorVisible = global::UnityEngine.Cursor.visible;
		this.savedCursorLockState = global::UnityEngine.Cursor.lockState;
	}

	// Token: 0x06000096 RID: 150 RVA: 0x000072AC File Offset: 0x000054AC
	private void RestoreCursorState()
	{
		global::UnityEngine.Cursor.visible = this.savedCursorVisible;
		global::UnityEngine.Cursor.lockState = this.savedCursorLockState;
	}

	// Token: 0x04000075 RID: 117
	public global::UnityEngine.Texture cursor;

	// Token: 0x04000076 RID: 118
	public global::UnityEngine.Texture background;

	// Token: 0x04000077 RID: 119
	public global::UnityEngine.Texture logo;

	// Token: 0x04000078 RID: 120
	public float logoHeight;

	// Token: 0x04000079 RID: 121
	public float menuOffset;

	// Token: 0x0400007A RID: 122
	public global::UnityEngine.Vector2 scaleLimits = new global::UnityEngine.Vector2(0.1f, 5f);

	// Token: 0x0400007B RID: 123
	public float scaleRate = 0.5f;

	// Token: 0x0400007C RID: 124
	private global::SteamVR_Overlay overlay;

	// Token: 0x0400007D RID: 125
	private global::UnityEngine.Camera overlayCam;

	// Token: 0x0400007E RID: 126
	private global::UnityEngine.Vector4 uvOffset;

	// Token: 0x0400007F RID: 127
	private float distance;

	// Token: 0x04000081 RID: 129
	private string scaleLimitX;

	// Token: 0x04000082 RID: 130
	private string scaleLimitY;

	// Token: 0x04000083 RID: 131
	private string scaleRateText;

	// Token: 0x04000084 RID: 132
	private global::UnityEngine.CursorLockMode savedCursorLockState;

	// Token: 0x04000085 RID: 133
	private bool savedCursorVisible;
}

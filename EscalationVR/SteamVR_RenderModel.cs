using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using EscalationVR;
using UnityEngine;
using Valve.VR;

// Token: 0x02000013 RID: 19
[global::UnityEngine.ExecuteInEditMode]
public class SteamVR_RenderModel : global::UnityEngine.MonoBehaviour
{
	// Token: 0x17000026 RID: 38
	// (get) Token: 0x060000C1 RID: 193 RVA: 0x00008A4B File Offset: 0x00006C4B
	// (set) Token: 0x060000C2 RID: 194 RVA: 0x00008A53 File Offset: 0x00006C53
	public string renderModelName { get; private set; }

	// Token: 0x060000C3 RID: 195 RVA: 0x00008A5C File Offset: 0x00006C5C
	private void OnModelSkinSettingsHaveChanged(params object[] args)
	{
		bool flag = !string.IsNullOrEmpty(this.renderModelName);
		if (flag)
		{
			this.renderModelName = "";
			this.UpdateModel();
		}
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x00008A94 File Offset: 0x00006C94
	private void OnHideRenderModels(params object[] args)
	{
		bool flag = (bool)args[0];
		global::UnityEngine.MeshRenderer component = base.GetComponent<global::UnityEngine.MeshRenderer>();
		bool flag2 = component != null;
		if (flag2)
		{
			component.enabled = !flag;
		}
		foreach (global::UnityEngine.MeshRenderer meshRenderer in base.transform.GetComponentsInChildren<global::UnityEngine.MeshRenderer>())
		{
			meshRenderer.enabled = !flag;
		}
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00008AFC File Offset: 0x00006CFC
	private void OnDeviceConnected(params object[] args)
	{
		int num = (int)args[0];
		bool flag = num != (int)this.index;
		if (!flag)
		{
			bool flag2 = (bool)args[1];
			bool flag3 = flag2;
			if (flag3)
			{
				this.UpdateModel();
			}
		}
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x00008B3C File Offset: 0x00006D3C
	public void UpdateModel()
	{
		global::Valve.VR.CVRSystem system = global::Valve.VR.OpenVR.System;
		bool flag = system == null;
		if (!flag)
		{
			global::Valve.VR.ETrackedPropertyError etrackedPropertyError = global::Valve.VR.ETrackedPropertyError.TrackedProp_Success;
			uint stringTrackedDeviceProperty = system.GetStringTrackedDeviceProperty((uint)this.index, global::Valve.VR.ETrackedDeviceProperty.Prop_RenderModelName_String, null, 0U, ref etrackedPropertyError);
			bool flag2 = stringTrackedDeviceProperty <= 1U;
			if (flag2)
			{
				global::UnityEngine.Debug.LogError("Failed to get render model name for tracked object " + this.index.ToString());
			}
			else
			{
				global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder((int)stringTrackedDeviceProperty);
				system.GetStringTrackedDeviceProperty((uint)this.index, global::Valve.VR.ETrackedDeviceProperty.Prop_RenderModelName_String, stringBuilder, stringTrackedDeviceProperty, ref etrackedPropertyError);
				string text = stringBuilder.ToString();
				bool flag3 = this.renderModelName != text;
				if (flag3)
				{
					this.renderModelName = text;
					base.StartCoroutine(this.SetModelAsync(text));
				}
			}
		}
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x00008BFA File Offset: 0x00006DFA
	private global::System.Collections.IEnumerator SetModelAsync(string renderModelName)
	{
		bool flag = string.IsNullOrEmpty(renderModelName);
		if (flag)
		{
			yield break;
		}
		using (global::SteamVR_RenderModel.RenderModelInterfaceHolder holder = new global::SteamVR_RenderModel.RenderModelInterfaceHolder())
		{
			global::Valve.VR.CVRRenderModels renderModels = holder.instance;
			bool flag2 = renderModels == null;
			if (flag2)
			{
				yield break;
			}
			uint count = renderModels.GetComponentCount(renderModelName);
			bool flag3 = count > 0U;
			string[] renderModelNames;
			if (flag3)
			{
				renderModelNames = new string[count];
				int i = 0;
				while ((long)i < (long)((ulong)count))
				{
					uint capacity = renderModels.GetComponentName(renderModelName, (uint)i, null, 0U);
					bool flag4 = capacity == 0U;
					if (!flag4)
					{
						global::System.Text.StringBuilder componentName = new global::System.Text.StringBuilder((int)capacity);
						bool flag5 = renderModels.GetComponentName(renderModelName, (uint)i, componentName, capacity) == 0U;
						if (!flag5)
						{
							capacity = renderModels.GetComponentRenderModelName(renderModelName, componentName.ToString(), null, 0U);
							bool flag6 = capacity == 0U;
							if (!flag6)
							{
								global::System.Text.StringBuilder name = new global::System.Text.StringBuilder((int)capacity);
								bool flag7 = renderModels.GetComponentRenderModelName(renderModelName, componentName.ToString(), name, capacity) == 0U;
								if (!flag7)
								{
									string s = name.ToString();
									global::SteamVR_RenderModel.RenderModel model = global::SteamVR_RenderModel.models[s] as global::SteamVR_RenderModel.RenderModel;
									bool flag8 = model == null || model.mesh == null;
									if (flag8)
									{
										renderModelNames[i] = s;
									}
									componentName = null;
									name = null;
									s = null;
									model = null;
								}
							}
						}
					}
					int num = i;
					i = num + 1;
				}
			}
			else
			{
				global::SteamVR_RenderModel.RenderModel model2 = global::SteamVR_RenderModel.models[renderModelName] as global::SteamVR_RenderModel.RenderModel;
				bool flag9 = model2 == null || model2.mesh == null;
				if (flag9)
				{
					renderModelNames = new string[]
					{
						renderModelName
					};
				}
				else
				{
					renderModelNames = new string[0];
				}
				model2 = null;
			}
			for (;;)
			{
				bool loading = false;
				foreach (string name2 in renderModelNames)
				{
					bool flag10 = string.IsNullOrEmpty(name2);
					if (!flag10)
					{
						global::System.IntPtr pRenderModel = global::System.IntPtr.Zero;
						global::Valve.VR.EVRRenderModelError error = renderModels.LoadRenderModel_Async(name2, ref pRenderModel);
						bool flag11 = error == global::Valve.VR.EVRRenderModelError.Loading;
						if (flag11)
						{
							loading = true;
						}
						else
						{
							bool flag12 = error == global::Valve.VR.EVRRenderModelError.None;
							if (flag12)
							{
								global::Valve.VR.RenderModel_t renderModel = (global::Valve.VR.RenderModel_t)global::System.Runtime.InteropServices.Marshal.PtrToStructure(pRenderModel, typeof(global::Valve.VR.RenderModel_t));
								global::UnityEngine.Material material = global::SteamVR_RenderModel.materials[renderModel.diffuseTextureId] as global::UnityEngine.Material;
								bool flag13 = material == null || material.mainTexture == null;
								if (flag13)
								{
									global::System.IntPtr pDiffuseTexture = global::System.IntPtr.Zero;
									error = renderModels.LoadTexture_Async(renderModel.diffuseTextureId, ref pDiffuseTexture);
									bool flag14 = error == global::Valve.VR.EVRRenderModelError.Loading;
									if (flag14)
									{
										loading = true;
									}
								}
								material = null;
							}
						}
						name2 = null;
					}
				}
				string[] array = null;
				bool flag15 = loading;
				if (!flag15)
				{
					break;
				}
				yield return new global::UnityEngine.WaitForSeconds(0.1f);
			}
			renderModels = null;
			renderModelNames = null;
		}
		global::SteamVR_RenderModel.RenderModelInterfaceHolder holder = null;
		bool success = this.SetModel(renderModelName);
		global::SteamVR_Utils.Event.Send("render_model_loaded", new object[]
		{
			this,
			success
		});
		yield break;
		yield break;
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x00008C10 File Offset: 0x00006E10
	private bool SetModel(string renderModelName)
	{
		this.StripMesh(base.gameObject);
		using (global::SteamVR_RenderModel.RenderModelInterfaceHolder renderModelInterfaceHolder = new global::SteamVR_RenderModel.RenderModelInterfaceHolder())
		{
			bool flag = this.createComponents;
			if (flag)
			{
				bool flag2 = this.LoadComponents(renderModelInterfaceHolder, renderModelName);
				if (flag2)
				{
					this.UpdateComponents();
					return true;
				}
				global::UnityEngine.Debug.Log("[" + base.gameObject.name + "] Render model does not support components, falling back to single mesh.");
			}
			bool flag3 = !string.IsNullOrEmpty(renderModelName);
			if (flag3)
			{
				global::SteamVR_RenderModel.RenderModel renderModel = global::SteamVR_RenderModel.models[renderModelName] as global::SteamVR_RenderModel.RenderModel;
				bool flag4 = renderModel == null || renderModel.mesh == null;
				if (flag4)
				{
					global::Valve.VR.CVRRenderModels instance = renderModelInterfaceHolder.instance;
					bool flag5 = instance == null;
					if (flag5)
					{
						return false;
					}
					bool flag6 = this.verbose;
					if (flag6)
					{
						global::UnityEngine.Debug.Log("Loading render model " + renderModelName);
					}
					renderModel = this.LoadRenderModel(instance, renderModelName, renderModelName);
					bool flag7 = renderModel == null;
					if (flag7)
					{
						return false;
					}
					global::SteamVR_RenderModel.models[renderModelName] = renderModel;
				}
				base.gameObject.AddComponent<global::UnityEngine.MeshFilter>().mesh = renderModel.mesh;
				base.gameObject.AddComponent<global::UnityEngine.MeshRenderer>().sharedMaterial = renderModel.material;
				return true;
			}
		}
		return false;
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x00008D80 File Offset: 0x00006F80
	private global::SteamVR_RenderModel.RenderModel LoadRenderModel(global::Valve.VR.CVRRenderModels renderModels, string renderModelName, string baseName)
	{
		global::System.IntPtr zero = global::System.IntPtr.Zero;
		global::Valve.VR.EVRRenderModelError evrrenderModelError;
		for (;;)
		{
			evrrenderModelError = renderModels.LoadRenderModel_Async(renderModelName, ref zero);
			bool flag = evrrenderModelError != global::Valve.VR.EVRRenderModelError.Loading;
			if (flag)
			{
				break;
			}
			global::System.Threading.Thread.Sleep(1);
		}
		bool flag2 = evrrenderModelError > global::Valve.VR.EVRRenderModelError.None;
		global::SteamVR_RenderModel.RenderModel result;
		if (flag2)
		{
			global::UnityEngine.Debug.LogError(string.Format("Failed to load render model {0} - {1}", renderModelName, evrrenderModelError.ToString()));
			result = null;
		}
		else
		{
			global::Valve.VR.RenderModel_t renderModel_t = (global::Valve.VR.RenderModel_t)global::System.Runtime.InteropServices.Marshal.PtrToStructure(zero, typeof(global::Valve.VR.RenderModel_t));
			global::UnityEngine.Vector3[] array = new global::UnityEngine.Vector3[renderModel_t.unVertexCount];
			global::UnityEngine.Vector3[] array2 = new global::UnityEngine.Vector3[renderModel_t.unVertexCount];
			global::UnityEngine.Vector2[] array3 = new global::UnityEngine.Vector2[renderModel_t.unVertexCount];
			global::System.Type typeFromHandle = typeof(global::Valve.VR.RenderModel_Vertex_t);
			int num = 0;
			while ((long)num < (long)((ulong)renderModel_t.unVertexCount))
			{
				global::System.IntPtr intPtr;
				intPtr..ctor(renderModel_t.rVertexData.ToInt64() + (long)(num * global::System.Runtime.InteropServices.Marshal.SizeOf(typeFromHandle)));
				global::Valve.VR.RenderModel_Vertex_t renderModel_Vertex_t = (global::Valve.VR.RenderModel_Vertex_t)global::System.Runtime.InteropServices.Marshal.PtrToStructure(intPtr, typeFromHandle);
				array[num] = new global::UnityEngine.Vector3(renderModel_Vertex_t.vPosition.v0, renderModel_Vertex_t.vPosition.v1, -renderModel_Vertex_t.vPosition.v2);
				array2[num] = new global::UnityEngine.Vector3(renderModel_Vertex_t.vNormal.v0, renderModel_Vertex_t.vNormal.v1, -renderModel_Vertex_t.vNormal.v2);
				array3[num] = new global::UnityEngine.Vector2(renderModel_Vertex_t.rfTextureCoord0, renderModel_Vertex_t.rfTextureCoord1);
				num++;
			}
			int num2 = (int)(renderModel_t.unTriangleCount * 3U);
			short[] array4 = new short[num2];
			global::System.Runtime.InteropServices.Marshal.Copy(renderModel_t.rIndexData, array4, 0, array4.Length);
			int[] array5 = new int[num2];
			int num3 = 0;
			while ((long)num3 < (long)((ulong)renderModel_t.unTriangleCount))
			{
				array5[num3 * 3] = (int)array4[num3 * 3 + 2];
				array5[num3 * 3 + 1] = (int)array4[num3 * 3 + 1];
				array5[num3 * 3 + 2] = (int)array4[num3 * 3];
				num3++;
			}
			global::UnityEngine.Mesh mesh = new global::UnityEngine.Mesh();
			mesh.vertices = array;
			mesh.normals = array2;
			mesh.uv = array3;
			mesh.triangles = array5;
			mesh.Optimize();
			global::UnityEngine.Material material = global::SteamVR_RenderModel.materials[renderModel_t.diffuseTextureId] as global::UnityEngine.Material;
			bool flag3 = material == null || material.mainTexture == null;
			if (flag3)
			{
				global::System.IntPtr zero2 = global::System.IntPtr.Zero;
				for (;;)
				{
					evrrenderModelError = renderModels.LoadTexture_Async(renderModel_t.diffuseTextureId, ref zero2);
					bool flag4 = evrrenderModelError != global::Valve.VR.EVRRenderModelError.Loading;
					if (flag4)
					{
						break;
					}
					global::System.Threading.Thread.Sleep(1);
				}
				bool flag5 = evrrenderModelError == global::Valve.VR.EVRRenderModelError.None;
				if (flag5)
				{
					global::Valve.VR.RenderModel_TextureMap_t renderModel_TextureMap_t = (global::Valve.VR.RenderModel_TextureMap_t)global::System.Runtime.InteropServices.Marshal.PtrToStructure(zero2, typeof(global::Valve.VR.RenderModel_TextureMap_t));
					global::UnityEngine.Texture2D texture2D = new global::UnityEngine.Texture2D((int)renderModel_TextureMap_t.unWidth, (int)renderModel_TextureMap_t.unHeight, 5, false);
					bool flag6 = global::UnityEngine.SystemInfo.graphicsDeviceVersion.StartsWith("OpenGL");
					if (flag6)
					{
						byte[] array6 = new byte[(int)(renderModel_TextureMap_t.unWidth * renderModel_TextureMap_t.unHeight * '\u0004')];
						global::System.Runtime.InteropServices.Marshal.Copy(renderModel_TextureMap_t.rubTextureMapData, array6, 0, array6.Length);
						global::UnityEngine.Color32[] array7 = new global::UnityEngine.Color32[(int)(renderModel_TextureMap_t.unWidth * renderModel_TextureMap_t.unHeight)];
						int num4 = 0;
						for (int i = 0; i < (int)renderModel_TextureMap_t.unHeight; i++)
						{
							for (int j = 0; j < (int)renderModel_TextureMap_t.unWidth; j++)
							{
								byte b = array6[num4++];
								byte b2 = array6[num4++];
								byte b3 = array6[num4++];
								byte b4 = array6[num4++];
								array7[i * (int)renderModel_TextureMap_t.unWidth + j] = new global::UnityEngine.Color32(b, b2, b3, b4);
							}
						}
						texture2D.SetPixels32(array7);
						texture2D.Apply();
					}
					else
					{
						texture2D.Apply();
						for (;;)
						{
							evrrenderModelError = renderModels.LoadIntoTextureD3D11_Async(renderModel_t.diffuseTextureId, texture2D.GetNativeTexturePtr());
							bool flag7 = evrrenderModelError != global::Valve.VR.EVRRenderModelError.Loading;
							if (flag7)
							{
								break;
							}
							global::System.Threading.Thread.Sleep(1);
						}
					}
					material = new global::UnityEngine.Material((this.shader != null) ? this.shader : global::EscalationVR.UnityHelper.GetShader("Standard"));
					material.mainTexture = texture2D;
					global::SteamVR_RenderModel.materials[renderModel_t.diffuseTextureId] = material;
					renderModels.FreeTexture(zero2);
				}
				else
				{
					global::UnityEngine.Debug.Log("Failed to load render model texture for render model " + renderModelName);
				}
			}
			base.StartCoroutine(this.FreeRenderModel(zero));
			result = new global::SteamVR_RenderModel.RenderModel(mesh, material);
		}
		return result;
	}

	// Token: 0x060000CA RID: 202 RVA: 0x0000923C File Offset: 0x0000743C
	private global::System.Collections.IEnumerator FreeRenderModel(global::System.IntPtr pRenderModel)
	{
		yield return new global::UnityEngine.WaitForSeconds(1f);
		using (global::SteamVR_RenderModel.RenderModelInterfaceHolder holder = new global::SteamVR_RenderModel.RenderModelInterfaceHolder())
		{
			global::Valve.VR.CVRRenderModels renderModels = holder.instance;
			renderModels.FreeRenderModel(pRenderModel);
			renderModels = null;
		}
		global::SteamVR_RenderModel.RenderModelInterfaceHolder holder = null;
		yield break;
	}

	// Token: 0x060000CB RID: 203 RVA: 0x00009254 File Offset: 0x00007454
	public global::UnityEngine.Transform FindComponent(string componentName)
	{
		global::UnityEngine.Transform transform = base.transform;
		for (int i = 0; i < transform.childCount; i++)
		{
			global::UnityEngine.Transform child = transform.GetChild(i);
			bool flag = child.name == componentName;
			if (flag)
			{
				return child;
			}
		}
		return null;
	}

	// Token: 0x060000CC RID: 204 RVA: 0x000092A8 File Offset: 0x000074A8
	private void StripMesh(global::UnityEngine.GameObject go)
	{
		global::UnityEngine.MeshRenderer component = go.GetComponent<global::UnityEngine.MeshRenderer>();
		bool flag = component != null;
		if (flag)
		{
			global::UnityEngine.Object.DestroyImmediate(component);
		}
		global::UnityEngine.MeshFilter component2 = go.GetComponent<global::UnityEngine.MeshFilter>();
		bool flag2 = component2 != null;
		if (flag2)
		{
			global::UnityEngine.Object.DestroyImmediate(component2);
		}
	}

	// Token: 0x060000CD RID: 205 RVA: 0x000092E8 File Offset: 0x000074E8
	private bool LoadComponents(global::SteamVR_RenderModel.RenderModelInterfaceHolder holder, string renderModelName)
	{
		global::UnityEngine.Transform transform = base.transform;
		for (int i = 0; i < transform.childCount; i++)
		{
			global::UnityEngine.Transform child = transform.GetChild(i);
			child.gameObject.SetActive(false);
			this.StripMesh(child.gameObject);
		}
		bool flag = string.IsNullOrEmpty(renderModelName);
		bool result;
		if (flag)
		{
			result = true;
		}
		else
		{
			global::Valve.VR.CVRRenderModels instance = holder.instance;
			bool flag2 = instance == null;
			if (flag2)
			{
				result = false;
			}
			else
			{
				uint componentCount = instance.GetComponentCount(renderModelName);
				bool flag3 = componentCount == 0U;
				if (flag3)
				{
					result = false;
				}
				else
				{
					int num = 0;
					while ((long)num < (long)((ulong)componentCount))
					{
						uint num2 = instance.GetComponentName(renderModelName, (uint)num, null, 0U);
						bool flag4 = num2 == 0U;
						if (!flag4)
						{
							global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder((int)num2);
							bool flag5 = instance.GetComponentName(renderModelName, (uint)num, stringBuilder, num2) == 0U;
							if (!flag5)
							{
								transform = this.FindComponent(stringBuilder.ToString());
								bool flag6 = transform != null;
								if (flag6)
								{
									transform.gameObject.SetActive(true);
								}
								else
								{
									transform = new global::UnityEngine.GameObject(stringBuilder.ToString()).transform;
									transform.parent = base.transform;
									transform.gameObject.layer = base.gameObject.layer;
									global::UnityEngine.Transform transform2 = new global::UnityEngine.GameObject("attach").transform;
									transform2.parent = transform;
									transform2.localPosition = global::UnityEngine.Vector3.zero;
									transform2.localRotation = global::UnityEngine.Quaternion.identity;
									transform2.localScale = global::UnityEngine.Vector3.one;
									transform2.gameObject.layer = base.gameObject.layer;
								}
								transform.localPosition = global::UnityEngine.Vector3.zero;
								transform.localRotation = global::UnityEngine.Quaternion.identity;
								transform.localScale = global::UnityEngine.Vector3.one;
								num2 = instance.GetComponentRenderModelName(renderModelName, stringBuilder.ToString(), null, 0U);
								bool flag7 = num2 == 0U;
								if (!flag7)
								{
									global::System.Text.StringBuilder stringBuilder2 = new global::System.Text.StringBuilder((int)num2);
									bool flag8 = instance.GetComponentRenderModelName(renderModelName, stringBuilder.ToString(), stringBuilder2, num2) == 0U;
									if (!flag8)
									{
										global::SteamVR_RenderModel.RenderModel renderModel = global::SteamVR_RenderModel.models[stringBuilder2] as global::SteamVR_RenderModel.RenderModel;
										bool flag9 = renderModel == null || renderModel.mesh == null;
										if (flag9)
										{
											bool flag10 = this.verbose;
											if (flag10)
											{
												string text = "Loading render model ";
												global::System.Text.StringBuilder stringBuilder3 = stringBuilder2;
												global::UnityEngine.Debug.Log(text + ((stringBuilder3 != null) ? stringBuilder3.ToString() : null));
											}
											renderModel = this.LoadRenderModel(instance, stringBuilder2.ToString(), renderModelName);
											bool flag11 = renderModel == null;
											if (flag11)
											{
												goto IL_2BD;
											}
											global::SteamVR_RenderModel.models[stringBuilder2] = renderModel;
										}
										transform.gameObject.AddComponent<global::UnityEngine.MeshFilter>().mesh = renderModel.mesh;
										transform.gameObject.AddComponent<global::UnityEngine.MeshRenderer>().sharedMaterial = renderModel.material;
									}
								}
							}
						}
						IL_2BD:
						num++;
					}
					result = true;
				}
			}
		}
		return result;
	}

	// Token: 0x060000CE RID: 206 RVA: 0x000095D0 File Offset: 0x000077D0
	private void OnEnable()
	{
		bool flag = !string.IsNullOrEmpty(this.modelOverride);
		if (flag)
		{
			global::UnityEngine.Debug.Log("Model override is really only meant to be used in the scene view for lining things up; using it at runtime is discouraged.  Use tracked device index instead to ensure the correct model is displayed for all users.");
			base.enabled = false;
		}
		else
		{
			global::Valve.VR.CVRSystem system = global::Valve.VR.OpenVR.System;
			bool flag2 = system != null && system.IsTrackedDeviceConnected((uint)this.index);
			if (flag2)
			{
				this.UpdateModel();
			}
			global::SteamVR_Utils.Event.Listen("device_connected", new global::SteamVR_Utils.Event.Handler(this.OnDeviceConnected));
			global::SteamVR_Utils.Event.Listen("hide_render_models", new global::SteamVR_Utils.Event.Handler(this.OnHideRenderModels));
			global::SteamVR_Utils.Event.Listen("ModelSkinSettingsHaveChanged", new global::SteamVR_Utils.Event.Handler(this.OnModelSkinSettingsHaveChanged));
		}
	}

	// Token: 0x060000CF RID: 207 RVA: 0x00009670 File Offset: 0x00007870
	private void OnDisable()
	{
		global::SteamVR_Utils.Event.Remove("device_connected", new global::SteamVR_Utils.Event.Handler(this.OnDeviceConnected));
		global::SteamVR_Utils.Event.Remove("hide_render_models", new global::SteamVR_Utils.Event.Handler(this.OnHideRenderModels));
		global::SteamVR_Utils.Event.Remove("ModelSkinSettingsHaveChanged", new global::SteamVR_Utils.Event.Handler(this.OnModelSkinSettingsHaveChanged));
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x000096C4 File Offset: 0x000078C4
	private void Update()
	{
		bool flag = this.updateDynamically;
		if (flag)
		{
			this.UpdateComponents();
		}
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x000096E4 File Offset: 0x000078E4
	public void UpdateComponents()
	{
		global::UnityEngine.Transform transform = base.transform;
		bool flag = transform.childCount == 0;
		if (!flag)
		{
			using (global::SteamVR_RenderModel.RenderModelInterfaceHolder renderModelInterfaceHolder = new global::SteamVR_RenderModel.RenderModelInterfaceHolder())
			{
				global::Valve.VR.VRControllerState_t vrcontrollerState_t = (this.index != global::SteamVR_TrackedObject.EIndex.None) ? global::SteamVR_Controller.Input((int)this.index).GetState() : default(global::Valve.VR.VRControllerState_t);
				for (int i = 0; i < transform.childCount; i++)
				{
					global::UnityEngine.Transform child = transform.GetChild(i);
					global::Valve.VR.CVRRenderModels instance = renderModelInterfaceHolder.instance;
					bool flag2 = instance == null;
					if (flag2)
					{
						break;
					}
					global::Valve.VR.RenderModel_ComponentState_t renderModel_ComponentState_t = default(global::Valve.VR.RenderModel_ComponentState_t);
					bool flag3 = !instance.GetComponentState(this.renderModelName, child.name, ref vrcontrollerState_t, ref this.controllerModeState, ref renderModel_ComponentState_t);
					if (!flag3)
					{
						global::SteamVR_Utils.RigidTransform rigidTransform = new global::SteamVR_Utils.RigidTransform(renderModel_ComponentState_t.mTrackingToComponentRenderModel);
						child.localPosition = rigidTransform.pos;
						child.localRotation = rigidTransform.rot;
						global::UnityEngine.Transform transform2 = child.FindChild("attach");
						bool flag4 = transform2 != null;
						if (flag4)
						{
							global::SteamVR_Utils.RigidTransform rigidTransform2 = new global::SteamVR_Utils.RigidTransform(renderModel_ComponentState_t.mTrackingToComponentLocal);
							transform2.position = transform.TransformPoint(rigidTransform2.pos);
							transform2.rotation = transform.rotation * rigidTransform2.rot;
						}
						bool flag5 = (renderModel_ComponentState_t.uProperties & 2U) > 0U;
						bool flag6 = flag5 != child.gameObject.activeSelf;
						if (flag6)
						{
							child.gameObject.SetActive(flag5);
						}
					}
				}
			}
		}
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x0000989C File Offset: 0x00007A9C
	public void SetDeviceIndex(int index)
	{
		this.index = (global::SteamVR_TrackedObject.EIndex)index;
		this.modelOverride = "";
		bool enabled = base.enabled;
		if (enabled)
		{
			this.UpdateModel();
		}
	}

	// Token: 0x040000AB RID: 171
	public global::SteamVR_TrackedObject.EIndex index = global::SteamVR_TrackedObject.EIndex.None;

	// Token: 0x040000AC RID: 172
	public string modelOverride;

	// Token: 0x040000AD RID: 173
	public global::UnityEngine.Shader shader;

	// Token: 0x040000AE RID: 174
	public bool verbose = false;

	// Token: 0x040000AF RID: 175
	public bool createComponents = true;

	// Token: 0x040000B0 RID: 176
	public bool updateDynamically = true;

	// Token: 0x040000B1 RID: 177
	public global::Valve.VR.RenderModel_ControllerMode_State_t controllerModeState;

	// Token: 0x040000B2 RID: 178
	public const string k_localTransformName = "attach";

	// Token: 0x040000B4 RID: 180
	public static global::System.Collections.Hashtable models = new global::System.Collections.Hashtable();

	// Token: 0x040000B5 RID: 181
	public static global::System.Collections.Hashtable materials = new global::System.Collections.Hashtable();

	// Token: 0x020000FF RID: 255
	public class RenderModel
	{
		// Token: 0x06000672 RID: 1650 RVA: 0x0001F681 File Offset: 0x0001D881
		public RenderModel(global::UnityEngine.Mesh mesh, global::UnityEngine.Material material)
		{
			this.mesh = mesh;
			this.material = material;
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000673 RID: 1651 RVA: 0x0001F69B File Offset: 0x0001D89B
		// (set) Token: 0x06000674 RID: 1652 RVA: 0x0001F6A3 File Offset: 0x0001D8A3
		public global::UnityEngine.Mesh mesh { get; private set; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000675 RID: 1653 RVA: 0x0001F6AC File Offset: 0x0001D8AC
		// (set) Token: 0x06000676 RID: 1654 RVA: 0x0001F6B4 File Offset: 0x0001D8B4
		public global::UnityEngine.Material material { get; private set; }
	}

	// Token: 0x02000100 RID: 256
	public sealed class RenderModelInterfaceHolder : global::System.IDisposable
	{
		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000677 RID: 1655 RVA: 0x0001F6C0 File Offset: 0x0001D8C0
		public global::Valve.VR.CVRRenderModels instance
		{
			get
			{
				bool flag = this._instance == null && !this.failedLoadInterface;
				if (flag)
				{
					bool flag2 = !global::SteamVR.active && !global::SteamVR.usingNativeSupport;
					if (flag2)
					{
						global::Valve.VR.EVRInitError evrinitError = global::Valve.VR.EVRInitError.None;
						global::Valve.VR.OpenVR.Init(ref evrinitError, global::Valve.VR.EVRApplicationType.VRApplication_Other);
						this.needsShutdown = true;
					}
					this._instance = global::Valve.VR.OpenVR.RenderModels;
					bool flag3 = this._instance == null;
					if (flag3)
					{
						global::UnityEngine.Debug.LogError("Failed to load IVRRenderModels interface version IVRRenderModels_005");
						this.failedLoadInterface = true;
					}
				}
				return this._instance;
			}
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x0001F74C File Offset: 0x0001D94C
		public void Dispose()
		{
			bool flag = this.needsShutdown;
			if (flag)
			{
				global::Valve.VR.OpenVR.Shutdown();
			}
		}

		// Token: 0x040006F7 RID: 1783
		private bool needsShutdown;

		// Token: 0x040006F8 RID: 1784
		private bool failedLoadInterface;

		// Token: 0x040006F9 RID: 1785
		private global::Valve.VR.CVRRenderModels _instance;
	}
}

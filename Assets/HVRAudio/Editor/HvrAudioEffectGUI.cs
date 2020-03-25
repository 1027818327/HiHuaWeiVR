using UnityEditor;
using UnityEngine;
using System.Runtime.InteropServices;

#if UNITY_EDITOR
public class HvrAudioEffectCustomGUI : IAudioEffectPluginGUI
{
    public override string Name
    {
        get { return "HvrAudioEffect"; }
    }

    public override string Description
    {
        get { return "Parameters for HuaweiVR Audio Effect"; }
    }

    public override string Vendor
    {
        get { return "Huawei"; }
    }

    public enum HvrWallMaterial {
        HVR_WALL_MATERIAL_ROUGH_CONCRETE,         //粗糙的混凝土
        HVR_WALL_MATERIAL_ROUGH_PLASTER,          //粗糙的石膏
        HVR_WALL_MATERIAL_CARPET_THICK,           //厚地毯

        HVR_WALL_MATERIAL_TRANSPARENT,            //全吸收材料
        HVR_WALL_MATERIAL_MARBLE,                 //大理石

        HVR_WALL_MATERIAL_MEDIUM_AUDIENCE,        // 中等密度的听众
        HVR_WALL_MATERIAL_SMOOTH_CONCRETE,        // 光滑的混凝土墙
        HVR_WALL_MATERIAL_ROUGH_BRICKWORK,        // 粗糙的砖墙
        HVR_WALL_MATERIAL_SMOOTH_BRICKWORK,       // 光滑的砖墙


        HVR_WALL_MATERIAL_SMOOTH_PLASTER,         // 光滑的石膏墙
        HVR_WALL_MATERIAL_WOOD_THICK,             // 厚木板
        HVR_WALL_MATERIAL_WOOD_MEDIUM,            // 中等厚度木板
        HVR_WALL_MATERIAL_WOOD_THIN,              // 薄木板
        HVR_WALL_MATERIAL_PLYWOOD_PANELING,       // 胶合板
        HVR_WALL_MATERIAL_GLASS_THICK,            // 厚玻璃
        HVR_WALL_MATERIAL_GLASS_THIN,             // 薄玻璃

        HVR_WALL_MATERIAL_CARPET_THIN,            // 薄地毯
        HVR_WALL_MATERIAL_LINOLEUM_ON_CONCRETE,   // 混凝土上的漆布
        HVR_WALL_MATERIAL_CURTAIN_COTTON_THICK,   // 厚的棉窗帘

        HVR_WALL_MATERIAL_CURTAIN_FABRIC,         // 布窗帘
        HVR_WALL_MATERIAL_HEAVY_CONCERT_CHAIRS,   // 音乐厅中厚重的椅子
        HVR_WALL_MATERIAL_MEDIUM_CONCERT_CHAIRS,  // 音乐厅中普通的椅子
        HVR_WALL_MATERIAL_LIGHT_CONCERT_CHAIRS,   // 音乐厅中轻便的椅子
        HVR_WALL_MATERIAL_DENSE_AUDIENCE,         // 稠密的听众

        HVR_WALL_MATERIAL_SPARSE_AUDIENCE         // 稀疏的听众
    }

    public override bool OnGUI(IAudioEffectPlugin plugin)
    {
        float fvar = 0.0f;
        bool bvar = false;
        HvrWallMaterial evar = HvrWallMaterial.HVR_WALL_MATERIAL_ROUGH_CONCRETE;

        Separator();

        plugin.GetFloatParameter("PoseTrack", out fvar);
        bvar = (fvar == 0.0f) ? false : true;
        bvar = EditorGUILayout.Toggle("Posture Tracking", bvar);
        plugin.SetFloatParameter("PoseTrack", (bvar == false) ? 0.0f : 1.0f);
        /*
        plugin.GetFloatParameter("PositionTrack", out fvar);
        bvar = (fvar == 0.0f) ? false : true;
        bvar = EditorGUILayout.Toggle("Position Tracking", bvar);
        plugin.SetFloatParameter("PositionTrack", (bvar == false) ? 0.0f : 1.0f);
        */
        Separator();

        Label("ROOM PARAMETERS (meters)");
		plugin.GetFloatParameter("Room Center X", out fvar);
        plugin.SetFloatParameter("Room Center X", EditorGUILayout.Slider("Center Pos X", fvar, -1000.0f, 1000.0f));
        plugin.GetFloatParameter("Room Center Y", out fvar);
        plugin.SetFloatParameter("Room Center Y", EditorGUILayout.Slider("Center Pos Y", fvar, -1000.0f, 1000.0f));
        plugin.GetFloatParameter("Room Center Z", out fvar);
        plugin.SetFloatParameter("Room Center Z", EditorGUILayout.Slider("Center Pos Z", fvar, -1000.0f, 1000.0f));
		
        plugin.GetFloatParameter("Room Size X", out fvar);
        plugin.SetFloatParameter("Room Size X", EditorGUILayout.Slider("Width", fvar, 2.0f, 200.0f));
        plugin.GetFloatParameter("Room Size Y", out fvar);
        plugin.SetFloatParameter("Room Size Y", EditorGUILayout.Slider("Height", fvar, 2.0f, 200.0f));
        plugin.GetFloatParameter("Room Size Z", out fvar);
        plugin.SetFloatParameter("Room Size Z", EditorGUILayout.Slider("Length", fvar, 2.0f, 200.0f));

        Separator();
        Label("WALL MATERIAL");
        plugin.GetFloatParameter("Front Wall Type", out fvar);
        if (fvar >= 0.0f && fvar <= 24.0f)
        {
            evar = (HvrWallMaterial)EditorGUILayout.EnumPopup("Front", (HvrWallMaterial)fvar);
        }
        fvar = (float)evar;
        plugin.SetFloatParameter("Front Wall Type", fvar);

        plugin.GetFloatParameter("Back Wall Type", out fvar);
        if (fvar >= 0.0f && fvar <= 24.0f)
        {
            evar = (HvrWallMaterial)EditorGUILayout.EnumPopup("Back", (HvrWallMaterial)fvar);
        }
        fvar = (float)evar;
        plugin.SetFloatParameter("Back Wall Type", fvar);

        plugin.GetFloatParameter("Left Wall Type", out fvar);
        if (fvar >= 0.0f && fvar <= 24.0f)
        {
            evar = (HvrWallMaterial)EditorGUILayout.EnumPopup("Left", (HvrWallMaterial)fvar);
        }
        fvar = (float)evar;
        plugin.SetFloatParameter("Left Wall Type", fvar);

        plugin.GetFloatParameter("Right Wall Type", out fvar);
        if (fvar >= 0.0f && fvar <= 24.0f)
        {
            evar = (HvrWallMaterial)EditorGUILayout.EnumPopup("Right", (HvrWallMaterial)fvar);
        }
        fvar = (float)evar;
        plugin.SetFloatParameter("Right Wall Type", fvar);

        plugin.GetFloatParameter("Ceil Wall Type", out fvar);
        if (fvar >= 0.0f && fvar <= 24.0f)
        {
            evar = (HvrWallMaterial)EditorGUILayout.EnumPopup("Ceil", (HvrWallMaterial)fvar);
        }
        fvar = (float)evar;
        plugin.SetFloatParameter("Ceil Wall Type", fvar);

        plugin.GetFloatParameter("Floor Wall Type", out fvar);
        if (fvar >= 0.0f && fvar <= 24.0f)
        {
            evar = (HvrWallMaterial)EditorGUILayout.EnumPopup("Floor", (HvrWallMaterial)fvar);
        }
        fvar = (float)evar;
        plugin.SetFloatParameter("Floor Wall Type", fvar);

        Separator();

        Label("Reverberation");
        plugin.GetFloatParameter("Early Reverb", out fvar);
        plugin.SetFloatParameter("Early Reverb", EditorGUILayout.Slider("Early Reverb", fvar, 0.0f, 1.0f));
        plugin.GetFloatParameter("Later Reverb", out fvar);
        plugin.SetFloatParameter("Later Reverb", EditorGUILayout.Slider("Later Reverb", fvar, 0.0f, 1.0f));

        //Separator();
        //plugin.GetFloatParameter("DRC Gain", out fvar);
		//plugin.SetFloatParameter("DRC Gain", EditorGUILayout.IntSlider("DRC Gain", (int)fvar, 0, 20));

        //Separator();

        //bvar = false;
        //bvar = EditorGUILayout.Toggle("EQ Debug", bvar);

        // We will override the controls with our own, so return false
        return false;
    }

    // Separator
    void Separator()
    {
        GUI.color = new Color(1, 1, 1, 0.3f);
        GUILayout.Box("", "HorizontalSlider", GUILayout.Height(15));
        GUI.color = Color.white;
    }

    // Label
    void Label(string label)
    {
        EditorGUILayout.LabelField(label);
    }


}
#endif
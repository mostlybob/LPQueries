<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
</Query>

void Main()
{
    // Documentation at https://www.sublimetext.com/docs/themes.html

    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<SublimeTheme>(Adaptive);

    obj.Variables.Select(x => new { x.Key, Type = x.Value.GetType().Name })
        .Where(x=>x.Type=="JObject")
        .OrderBy(x => x.Key).Dump("non-primitive");

    obj.Variables.Select(x => new { x.Key, Type = x.Value.GetType().Name })
        .OrderBy(x => x.Key).Dump("settings");

    var nonPrimitives = obj.Variables.Select(x => new { x.Key, Type = x.Value.GetType().Name })
        .Where(x => x.Type == "JObject")
        .Select(x=>x.Key);
        
    obj.Variables
        .Where(x=>nonPrimitives.Contains(  x.Key)).Dump();

    obj.Dump();
}

class SublimeTheme
{
    public Dictionary<string, object> Variables { get; set; }
}


#region Adaptive
const string Adaptive=@"{
	""variables"":
	{
		""font_face"": ""system"",
		""font_size_sm"": 11,
		""font_size"": 12,
		""font_size_lg"": 13,
		""font_size_title"": 24,

		""dark_bg"": ""color(var(--background) blend(white 85%))"",
		""medium_dark_bg"": ""color(var(--background) blend(black 60%))"",
		""medium_bg"": ""color(var(--background) blend(black 80%))"",
		""light_bg"": ""color(var(--background) blend(black 90%))"",

		""link_fg"": ""hsl(215, 60%, 50%)"",

		""vcs_modified"": ""color(var(--bluish) min-contrast(var(--background) 2.5))"",
		""vcs_missing"": ""color(var(--redish) min-contrast(var(--background) 2.5))"",
		""vcs_staged"": ""color(var(--bluish) min-contrast(var(--background) 2.5))"",
		""vcs_added"": ""color(var(--greenish) min-contrast(var(--background) 2.5))"",
		""vcs_deleted"": ""color(var(--redish) min-contrast(var(--background) 2.5))"",
		""vcs_unmerged"": ""color(var(--orangish) min-contrast(var(--background) 2.5))"",

		""adaptive_dividers"": ""hsl(0, 0%, 38%)"",

		""icon_tint"": ""white"",
		""icon_light_tint"": ""color(black a(0.7))"",

		""tool_tip_bg"": ""white"",
		""tool_tip_fg"": ""hsl(0, 0%, 25%)"",

		""tabset_button_opacity"": { ""target"": 0.6, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		""tabset_new_tab_button_opacity"": { ""target"": 0.3, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		""tabset_button_hover_opacity"": { ""target"": 0.8, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },

		""tabset_dark_tint_mod"": ""color(white a(0.15))"",
		""tabset_dark_bg"": ""var(dark_bg)"",
		""tabset_medium_dark_tint_mod"": ""var(medium_dark_bg)"",
		""tabset_medium_dark_bg"": ""var(medium_dark_bg)"",
		""tabset_medium_tint_mod"": ""color(black a(0.2))"",
		""tabset_medium_bg"": ""var(medium_bg)"",
		""tabset_light_tint_mod"": ""color(black a(0.1))"",
		""tabset_light_bg"": ""var(light_bg)"",

		""file_tab_angled_unselected_dark_tint"": ""color(white a(0.08))"",
		""file_tab_angled_unselected_medium_dark_tint"": ""color(black a(0.2))"",
		""file_tab_angled_unselected_medium_tint"": ""color(black a(0.15))"",
		""file_tab_angled_unselected_light_tint"": ""color(black a(0.06))"",

		""file_tab_selected_dark_tint"": ""color(var(tabset_dark_tint_mod) a(- 70%))"",
		""file_tab_selected_medium_dark_tint"": ""color(var(tabset_medium_dark_tint_mod) a(- 70%))"",
		""file_tab_selected_medium_tint"": ""color(var(tabset_medium_tint_mod) a(- 70%))"",
		""file_tab_selected_light_tint"": ""color(var(tabset_light_tint_mod) a(- 70%))"",

		""file_tab_angled_unselected_label_color"": ""hsl(0, 0%, 60%)"",
		""file_tab_angled_unselected_label_shadow"": ""color(black a(0.25))"",
		""file_tab_angled_unselected_medium_label_color"": ""hsl(0, 0%, 75%)"",
		""file_tab_angled_unselected_medium_label_shadow"": ""color(black a(0.12))"",
		""file_tab_angled_unselected_light_label_color"": ""hsl(0, 0%, 44%)"",
		""file_tab_angled_unselected_light_label_shadow"": ""color(white a(0.25))"",

		""file_tab_unselected_label_color"": ""white"",
		""file_tab_unselected_light_label_color"": ""hsl(0, 0%, 20%)"",
		""file_tab_selected_label_color"": ""white"",
		""file_tab_selected_light_label_color"": ""hsl(0, 0%, 20%)"",

		""file_tab_close_opacity"": { ""target"": 0.5, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		""file_tab_close_hover_opacity"": { ""target"": 0.9, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		""file_tab_close_selected_opacity"": { ""target"": 0.8, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		""file_tab_close_selected_hover_opacity"": { ""target"": 1, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },

		""sheet_dark_modifier"": ""blend(var(tabset_dark_bg) 70%)"",
		""sheet_medium_dark_modifier"": ""blend(var(tabset_medium_dark_bg) 70%)"",
		""sheet_medium_modifier"": ""blend(var(tabset_medium_bg) 70%)"",
		""sheet_light_modifier"": ""blend(var(tabset_light_bg) 70%)"",

		""text_widget_dark_modifier"": ""l(- 5%) s(* 50%)"",
		""text_widget_light_modifier"": ""l(- 5%) s(* 50%)"",

		""viewport_always_visible_color"": ""hsla(0, 0%, 50%, 0.18)"",
		""viewport_hide_show_color"": ""hsla(0, 0%, 50%, 0.25)"",

		""auto_complete_bg_dark_tint"": ""color(white a(0.05))"",
		""auto_complete_bg_light_tint"": ""color(black a(0.05))"",

		""auto_complete_selected_row_dark_tint"": ""color(white a(0.2))"",
		""auto_complete_selected_row_light_tint"": ""color(black a(0.15))"",

		""auto_complete_text_dark_tint"": ""color(white a(0.18))"",
		""auto_complete_text_light_tint"": ""color(black a(0.18))"",

		""auto_complete_detail_pane_dark_tint"": ""color(black a(0.1))"",
		""auto_complete_detail_pane_light_tint"": ""color(white a(0.1))"",

		""auto_complete_detail_panel_mono_dark_bg"": ""color(white a(0.12))"",
		""auto_complete_detail_panel_mono_light_bg"": ""color(black a(0.08))"",

		""kind_function_color"": ""var(--redish)"",
		""kind_keyword_color"": ""var(--pinkish)"",
		""kind_markup_color"": ""var(--orangish)"",
		""kind_namespace_color"": ""var(--bluish)"",
		""kind_navigation_color"": ""var(--yellowish)"",
		""kind_snippet_color"": ""var(--greenish)"",
		""kind_type_color"": ""var(--purplish)"",
		""kind_variable_color"": ""var(--cyanish)"",

		""kind_name_label_border_color"": ""color(var(--accent) a(0.8))"",

		""icon_opacity"": { ""target"": 0.7, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
		""icon_hover_opacity"": { ""target"": 1.0, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },

		""radio_back"": ""var(--background)"",
		""radio_border-unselected"": ""#a6a6a6"",
		""radio_selected"": ""var(--bluish)"",
		""radio_border-selected"": ""var(--bluish)"",

		""checkbox_back"": ""var(--background)"",
		""checkbox_border-unselected"": ""#a6a6a6"",
		""checkbox_selected"": ""var(--bluish)"",
		""checkbox_border-selected"": ""var(--bluish)"",
		""checkbox-disabled"": ""#a6a6a6"",
	},
	""rules"":
	[
		// Title Bar
		{
			""class"": ""title_bar"",
			""settings"": [""themed_title_bar""],
			""fg"": ""color(var(--background) blend(white 30%))"",
			""style"": ""system""
		},
		{
			""class"": ""title_bar"",
			""settings"": [""themed_title_bar""],
			""attributes"": [""file_dark""],
			""bg"": ""var(dark_bg)"",
			""style"": ""dark""
		},
		{
			""class"": ""title_bar"",
			""attributes"": [""file_medium_dark""],
			""settings"": [""themed_title_bar""],
			""bg"": ""var(medium_dark_bg)"",
			""style"": ""dark""
		},
		{
			""class"": ""title_bar"",
			""attributes"": [""file_medium""],
			""settings"": [""themed_title_bar""],
			""bg"": ""var(medium_bg)"",
			""style"": ""light""
		},
		{
			""class"": ""title_bar"",
			""attributes"": [""file_light""],
			""settings"": [""themed_title_bar""],
			""bg"": ""var(light_bg)"",
			""fg"": ""color(var(--background) blend(black 30%))"",
			""style"": ""light""
		},

		// Side Bar
		{
			""class"": ""sidebar_container"",
			""layer0.opacity"": 1.0,
			""content_margin"": 0,
		},
		{
			""class"": ""sidebar_container"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_dark""]}],
			""layer0.tint"": ""var(dark_bg)"",
		},
		{
			""class"": ""sidebar_container"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium_dark""]}],
			""layer0.tint"": ""var(medium_dark_bg)"",
		},
		{
			""class"": ""sidebar_container"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium""]}],
			""layer0.tint"": ""var(medium_bg)"",
		},
		{
			""class"": ""sidebar_container"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(light_bg)"",
		},
		{
			""class"": ""sidebar_tree"",
			""row_padding"": [16, 3, 4, 3],
			""indent"": 12,
			""indent_offset"": 13,
			""indent_top_level"": false,
			""dark_content"": true,
			""spacer_rows"": true
		},
		{
			""class"": ""sidebar_tree"",
			""platforms"": [""windows""],
			""row_padding"": [16, 2, 4, 2],
		},
		{
			""class"": ""sidebar_tree"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""dark_content"": false,
		},
		{
			""class"": ""tree_row"",
			""attributes"": [""!hover""],
			""layer0.opacity"": 0.0,
		},
		{
			""class"": ""tree_row"",
			""attributes"": [""selectable"", ""hover""],
			""layer0.tint"": ""color(white a(0.06))"",
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""tree_row"",
			""attributes"": [""selectable"", ""hover""],
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium""]}],
			""layer0.tint"": ""color(white a(0.08))"",
		},
		{
			""class"": ""tree_row"",
			""attributes"": [""selectable"", ""hover""],
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""color(white a(0.3))"",
		},
		{
			""class"": ""tree_row"",
			""attributes"": [""selected""],
			""layer0.tint"": ""color(white a(0.18))"",
			""layer0.opacity"": 0.6,
		},
		{
			""class"": ""tree_row"",
			""attributes"": [""selected""],
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium""]}],
			""layer0.tint"": ""color(white a(0.16))"",
		},
		{
			""class"": ""tree_row"",
			""attributes"": [""selected""],
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""color(white a(0.5))"",
		},
		{
			""class"": ""tree_row"",
			""attributes"": [""highlighted""],
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""sidebar_heading"",
			""fg"": ""color(var(--background) blend(white 45%))"",
			""font.face"": ""var(font_face)"",
			""font.size"": ""var(font_size_lg)"",
			""font.bold"": true,
			""shadow_color"": ""color(black a(0.1))"",
			""shadow_offset"": [0, 1]
		},
		{
			""class"": ""sidebar_heading"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""fg"": ""color(var(--background) blend(black 50%))"",
			""shadow_color"": ""color(white a(0.1))"",
		},
		{
			""class"": ""sidebar_label"",
			""fg"": ""color(var(--background) blend(white 20%))"",
			""font.face"": ""var(font_face)"",
			""font.size"": ""var(font_size)""
		},
		{
			""class"": ""sidebar_label"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""fg"": ""color(var(--background) blend(black 20%))"",
		},
		{
			""class"": ""sidebar_label"",
			""parents"": [{""class"": ""tree_row"", ""attributes"": [""selected""]}],
			""fg"": ""white"",
		},
		{
			""class"": ""sidebar_label"",
			""parents"": [
				{""class"": ""window"", ""attributes"": [""file_light""]},
				{""class"": ""tree_row"", ""attributes"": [""selected""]}
			],
			""fg"": ""black"",
		},
		{
			""class"": ""sidebar_label"",
			""parents"": [{""class"": ""tree_row"", ""attributes"": [""expandable""]}],
			""settings"": [""bold_folder_labels""],
			""font.bold"": true
		},

		// Open Files Icons
		{
			""class"": ""close_button"",
			""layer0.texture"": ""Theme - Default/common/open_file_close.png"",
			""layer0.opacity"": { ""target"": 0.7, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
			""layer0.tint"": ""color(white a(50%))"",
			""content_margin"": [8, 8],
		},
		{
			""class"": ""close_button"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""color(black a(50%))""
		},
		{
			""class"": ""close_button"",
			""attributes"": [""hover""],
			""layer0.opacity"": { ""target"": 1, ""speed"": 4.0, ""interpolation"": ""smoothstep"" }
		},
		{
			""class"": ""close_button"",
			""attributes"": [""!hover"", ""dirty""],
			""layer0.texture"": ""Theme - Default/common/open_file_dirty.png"",
		},
		{
			""class"": ""close_button"",
			""attributes"": [""added""],
			""layer0.tint"": ""var(vcs_added)"",
		},
		{
			""class"": ""close_button"",
			""attributes"": [""deleted""],
			""layer0.tint"": ""var(vcs_deleted)"",
		},

		// Folder & File Icons
		{
			""class"": ""disclosure_button_control"",
			""layer0.texture"": ""Theme - Default/common/disclosure_unexpanded.png"",
			""layer0.tint"": ""white"",
			""layer0.opacity"": { ""target"": 0.3, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
			""content_margin"": [8, 8]
		},
		{
			""class"": ""disclosure_button_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""black"",
		},
		{
			""class"": ""disclosure_button_control"",
			""parents"": [{""class"": ""tree_row"", ""attributes"": [""expanded""]}],
			""layer0.texture"": ""Theme - Default/common/disclosure_expanded.png"",
		},
		{
			""class"": ""disclosure_button_control"",
			""attributes"": [""hover""],
			""layer0.opacity"": { ""target"": 0.5, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""icon_folder"",
			""layer0.texture"": ""Theme - Default/common/folder_closed.png"",
			""layer0.tint"": ""white"",
			""layer0.opacity"": 0.3,
			""content_margin"": [9, 8]
		},
		{
			""class"": ""icon_folder"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""black"",
			""layer0.opacity"": 0.25,
		},
		{
			""class"": ""icon_folder"",
			""parents"": [{""class"": ""tree_row"", ""attributes"": [""expanded""]}],
			""layer0.texture"": ""Theme - Default/common/folder_open.png"",
			""content_margin"": [9, 8]
		},
		{
			""class"": ""icon_folder_loading"",
			""layer0.texture"":
			{
				""keyframes"":
				[
					""Theme - Default/common/folder_loading_01.png"",
					""Theme - Default/common/folder_loading_02.png"",
					""Theme - Default/common/folder_loading_03.png"",
					""Theme - Default/common/folder_loading_04.png"",
					""Theme - Default/common/folder_loading_05.png"",
					""Theme - Default/common/folder_loading_06.png"",
					""Theme - Default/common/folder_loading_07.png"",
					""Theme - Default/common/folder_loading_08.png"",
					""Theme - Default/common/folder_loading_09.png"",
					""Theme - Default/common/folder_loading_10.png"",
					""Theme - Default/common/folder_loading_11.png"",
					""Theme - Default/common/folder_loading_12.png"",
					""Theme - Default/common/folder_loading_13.png"",
					""Theme - Default/common/folder_loading_14.png"",
					""Theme - Default/common/folder_loading_15.png"",
					""Theme - Default/common/folder_loading_16.png"",
					""Theme - Default/common/folder_loading_17.png"",
					""Theme - Default/common/folder_loading_18.png"",
					""Theme - Default/common/folder_loading_19.png"",
					""Theme - Default/common/folder_loading_20.png"",
				],
				""loop"": true,
				""frame_time"": 0.08,
			},
			""layer0.tint"": ""white"",
			""layer0.opacity"": 0.3,
			""content_margin"": [9, 8]
		},
		{
			""class"": ""icon_folder_loading"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""black"",
			""layer0.opacity"": 0.4,
		},
		{
			""class"": ""icon_folder_dup"",
			""layer0.texture"": ""Theme - Default/common/symlink.png"",
			""layer0.tint"": ""white"",
			""layer0.opacity"": 0.3,
			""content_margin"": [9, 8]
		},
		{
			""class"": ""icon_folder_dup"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""black"",
			""layer0.opacity"": 0.4,
		},
		{
			""class"": ""icon_file_type"",
			""layer0.tint"": ""white"",
			""layer0.opacity"": 0.5,
			""content_margin"": [9, 8]
		},
		{
			""class"": ""icon_file_type"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""black"",
			""layer0.opacity"": 0.4,
		},

		// VCS badges
		{
			""class"": ""file_system_entry"",
			""content_margin"": [0, 0, 8, 0]
		},
		{
			""class"": ""file_system_entry"",
			""parents"": [{""class"": ""scroll_area_control"", ""attributes"": [""scrollable""]}],
			""settings"": [""!overlay_scroll_bars""],
			""content_margin"": [0, 0, 0, 0]
		},
		{
			""class"": ""vcs_status_badge"",
			""content_margin"": 6
		},
		{
			""class"": ""vcs_status_badge"",
			""parents"": [{""class"": ""file_system_entry"", ""attributes"": [""untracked""]}],
			""layer0.texture"": ""Theme - Default/common/status_untracked.png"",
			""layer0.tint"": ""color(var(--background) blend(white 60%))"",
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""vcs_status_badge"",
			""parents"":
			[
				{""class"": ""window"", ""attributes"": [""file_light""]},
				{""class"": ""file_system_entry"", ""attributes"": [""untracked""]}
			],
			""layer0.texture"": ""Theme - Default/common/status_untracked.png"",
			""layer0.tint"": ""color(var(--background) blend(black 60%))"",
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""vcs_status_badge"",
			""parents"": [{""class"": ""file_system_entry"", ""attributes"": [""modified""]}],
			""layer0.texture"": ""Theme - Default/common/status_modified.png"",
			""layer0.tint"": ""var(vcs_modified)"",
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""vcs_status_badge"",
			""parents"": [{""class"": ""file_system_entry"", ""attributes"": [""missing""]}],
			""layer0.texture"": ""Theme - Default/common/status_modified.png"",
			""layer0.tint"": ""var(vcs_missing)"",
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""vcs_status_badge"",
			""parents"": [{""class"": ""file_system_entry"", ""attributes"": [""staged""]}],
			""layer0.texture"": ""Theme - Default/common/status_staged.png"",
			""layer0.tint"": ""var(vcs_staged)"",
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""vcs_status_badge"",
			""parents"": [{""class"": ""file_system_entry"", ""attributes"": [""added""]}],
			""layer0.texture"": ""Theme - Default/common/status_staged.png"",
			""layer0.tint"": ""var(vcs_added)"",
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""vcs_status_badge"",
			""parents"": [{""class"": ""file_system_entry"", ""attributes"": [""deleted""]}],
			""layer0.texture"": ""Theme - Default/common/status_staged.png"",
			""layer0.tint"": ""var(vcs_deleted)"",
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""vcs_status_badge"",
			""parents"": [{""class"": ""file_system_entry"", ""attributes"": [""unmerged""]}],
			""layer0.texture"": ""Theme - Default/common/status_unmerged.png"",
			""layer0.tint"": ""var(vcs_unmerged)"",
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""vcs_status_badge"",
			""parents"": [{""class"": ""file_system_entry"", ""attributes"": [""ignored""]}],
			""content_margin"": 0,
		},
		{
			""class"": ""sidebar_label"",
			""parents"": [{""class"": ""file_system_entry"", ""attributes"": [""ignored""]}],
			""color"": ""color(var(--background) blend(white 50%))""
		},
		{
			""class"": ""sidebar_label"",
			""parents"":
			[
				{""class"": ""window"", ""attributes"": [""file_light""]},
				{""class"": ""file_system_entry"", ""attributes"": [""ignored""]}
			],
			""color"": ""color(var(--background) blend(black 50%))""
		},

		// Tabset
		{
			""class"": ""tabset_control"",
			""layer0.opacity"": 1.0,
			""content_margin"": [0, 0, 0, 0],
			""tab_height"": 34,
		},
		{
			""class"": ""tabset_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded""]},
			""tab_overlap"": 10,
			""tab_height"": 32,
			""connector_height"": 2,
		},
		{
			""class"": ""tabset_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""tab_overlap"": 16,
			""tint_index"": 0,
		},
		{
			""class"": ""tabset_control"",
			""settings"": {""file_tab_style"": ""square""},
			""tab_overlap"": 1,
			""tab_height"": 32,
			""connector_height"": 2,
			""spacing"": 5,
		},
		{
			""class"": ""tabset_control"",
			""settings"": [""mouse_wheel_switches_tabs"", ""!enable_tab_scrolling""],
			""mouse_wheel_switch"": true
		},
		{
			""class"": ""tabset_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""attributes"": [""file_dark""],
			""tint_modifier"": ""var(tabset_dark_tint_mod)""
		},
		{
			""class"": ""tabset_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""attributes"": [""file_medium_dark""],
			""tint_modifier"": ""var(tabset_medium_dark_tint_mod)"",
		},
		{
			""class"": ""tabset_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""attributes"": [""file_medium""],
			""tint_modifier"": ""var(tabset_medium_tint_mod)""
		},
		{
			""class"": ""tabset_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""attributes"": [""file_light""],
			""tint_modifier"": ""var(tabset_light_tint_mod)""
		},
		{
			""class"": ""tabset_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [{""class"": ""edit_window"", ""attributes"": [""file_dark""]}],
			""layer0.tint"": ""var(tabset_dark_bg)""
		},
		{
			""class"": ""tabset_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [{""class"": ""edit_window"", ""attributes"": [""file_medium_dark""]}],
			""layer0.tint"": ""var(tabset_medium_dark_bg)""
		},
		{
			""class"": ""tabset_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [{""class"": ""edit_window"", ""attributes"": [""file_medium""]}],
			""layer0.tint"": ""var(tabset_medium_bg)""
		},
		{
			""class"": ""tabset_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [{""class"": ""edit_window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(tabset_light_bg)""
		},
		{
			""class"": ""tab_connector"",
			""layer0.texture"": """",
			""layer0.opacity"": 1.0,
			""tint_index"": 0,
		},
		{
			""class"": ""tab_connector"",
			""settings"": {""file_tab_style"": ["""", ""rounded""]},
			""attributes"": [""left_overhang""],
			""layer0.texture"": ""Theme - Default/common/tab_connector_rounded_left_overhang.png"",
			""layer0.inner_margin"": [12, 0, 0, 0],
		},
		{
			""class"": ""tab_connector"",
			""settings"": {""file_tab_style"": ["""", ""rounded""]},
			""attributes"": [""right_overhang""],
			""layer0.texture"": ""Theme - Default/common/tab_connector_rounded_right_overhang.png"",
			""layer0.inner_margin"": [0, 0, 12, 0],
		},
		// Tabs
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded""]},
			""layer0.texture"": ""Theme - Default/common/tab_rounded_inverse.png"",
			""layer0.inner_margin"": [12, 0, 12, 0],
			""layer0.opacity"": 1.0,
			""layer1.texture"": ""Theme - Default/common/tab_rounded.png"",
			""layer1.inner_margin"": [12, 0, 12, 0],
			""layer1.opacity"": 1.0,
			""layer2.texture"": ""Theme - Default/common/tab_rounded_highlight.png"",
			""layer2.inner_margin"": [12, 0, 12, 0],
			""layer2.opacity"": 0.0,
			""layer3.texture"": ""Theme - Default/common/tab_rounded_divider.png"",
			""layer3.inner_margin"": [7, 0, 7, 0],
			""layer3.opacity"": { ""target"": 0.0, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
			""tint_index"": 1,
			""tint_modifier"": ""transparent"",
			""accent_tint_index"": 2,
			""content_margin"": [16, 5, 11, 4],
			""hit_test_level"": 0.3
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""square""},
			""layer0.opacity"": 1.0,
			""layer1.opacity"": 1.0,
			""layer2.texture"": ""Theme - Default/common/tab_square_highlight.png"",
			""layer2.opacity"": 0.0,
			""layer3.texture"": ""Theme - Default/common/tab_square_divider.png"",
			""layer3.inner_margin"": [2, 0, 2, 0],
			""layer3.opacity"": { ""target"": 0.0, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
			""tint_index"": 1,
			""tint_modifier"": ""transparent"",
			""accent_tint_index"": 2,
			""content_margin"": [14, 3, 9, 4],
			""hit_test_level"": 0.3
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""layer0.texture"": ""Theme - Default/common/tab_shadow.png"",
			""layer0.inner_margin"": [19, 0, 19, 0],
			""layer0.opacity"": 0.2,
			""layer1.texture"": ""Theme - Default/common/tab.png"",
			""layer1.inner_margin"": [19, 0, 19, 0],
			""layer1.opacity"": 1.0,
			""layer2.texture"": ""Theme - Default/common/tab_highlight.png"",
			""layer2.inner_margin"": [19, 0, 19, 0],
			""layer2.opacity"": 0.0,
			""layer3.inner_margin"": [19, 0, 19, 0],
			""tint_index"": 1,
			""accent_tint_index"": 2,
			""content_margin"": [26, 8, 22, 4],
			""hit_test_level"": 0.3
		},
		// Tabs - background
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""attributes"": [""file_dark""],
			""tint_modifier"": ""var(file_tab_angled_unselected_dark_tint)"",
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""attributes"": [""file_medium_dark""],
			""tint_modifier"": ""var(file_tab_angled_unselected_medium_dark_tint)"",
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""attributes"": [""file_medium""],
			""tint_modifier"": ""var(file_tab_angled_unselected_medium_tint)"",
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""attributes"": [""file_light""],
			""tint_modifier"": ""var(file_tab_angled_unselected_light_tint)"",
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""attributes"": [""selected""],
			""tint_modifier"": ""transparent"",
		},
		// These rules prevent the opacity of un-highlighted sheets from
		// stacking, which results in the rounded corners being dark
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [{""class"": ""edit_window"", ""attributes"": [""file_dark""]}],
			""layer0.tint"": ""var(tabset_dark_bg)"",
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [{""class"": ""edit_window"", ""attributes"": [""file_medium_dark""]}],
			""layer0.tint"": ""var(tabset_medium_dark_bg)"",
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [{""class"": ""edit_window"", ""attributes"": [""file_medium""]}],
			""layer0.tint"": ""var(tabset_medium_bg)"",
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [{""class"": ""edit_window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(tabset_light_bg)"",
		},
		// The following rules prevent aliasing in the tab corner between two
		// selected tabs
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded""]},
			""attributes"": [""selected""],
			""layer0.opacity"": 0,
		},
		// We don't use animation for the selected tab opacity changed due
		// to the hover state syncing with the hover state of the
		// sheet_contents, which has the background_modifier that can not
		// be animated
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""attributes"": [""selected""],
			""layer1.opacity"": 1.0,
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""attributes"": [""!selected""],
			""layer1.opacity"": { ""target"": 0.0, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""attributes"": [""!selected"", ""hover""],
			""layer1.opacity"": { ""target"": 0.7, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""attributes"": [""!selected"", ""hover"", ""file_light""],
			""layer1.opacity"": { ""target"": 0.7, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded""]},
			""attributes"": [""selected"", ""left_overhang""],
			""layer0.texture"": ""Theme - Default/common/tab_rounded_left_overhang.png"",
			""layer1.texture"": ""Theme - Default/common/tab_rounded_left_overhang.png"",
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded""]},
			""attributes"": [""selected"", ""right_overhang""],
			""layer0.texture"": ""Theme - Default/common/tab_rounded_right_overhang.png"",
			""layer1.texture"": ""Theme - Default/common/tab_rounded_right_overhang.png"",
		},
		// Tabs - modified highlight
		{
			""class"": ""tab_control"",
			""attributes"": [""dirty""],
			""settings"": {
				""file_tab_style"": ""angled"",
				""highlight_modified_tabs"": true
			},
			""layer2.opacity"": 0.6
		},
		{
			""class"": ""tab_control"",
			""attributes"": [""dirty"", ""file_light""],
			""settings"": {
				""file_tab_style"": ""angled"",
				""highlight_modified_tabs"": true
			},
			""layer2.opacity"": 0.8
		},
		{
			""class"": ""tab_control"",
			""attributes"": [""dirty""],
			""settings"": {
				""file_tab_style"": ["""", ""rounded"", ""square""],
				""highlight_modified_tabs"": true
			},
			""layer2.opacity"": 0.8
		},
		{
			""class"": ""tab_control"",
			""attributes"": [""dirty"", ""selected""],
			""settings"": [""highlight_modified_tabs""],
			""layer2.opacity"": 1.0
		},
		{
			""class"": ""tab_control"",
			""attributes"": [""dirty"", ""!selected""],
			""settings"": {
				""file_tab_style"": ["""", ""rounded""],
				""highlight_modified_tabs"": true
			},
			""layer2.texture"": ""Theme - Default/common/tab_rounded_pinstripe.png"",
			""layer2.inner_margin"": [12, 0, 12, 0],
		},
		{
			""class"": ""tab_control"",
			""attributes"": [""dirty"", ""!selected""],
			""settings"": {
				""file_tab_style"": ""square"",
				""highlight_modified_tabs"": true
			},
			""layer2.texture"": ""Theme - Default/common/tab_square_pinstripe.png"",
			""layer2.inner_margin"": [0, 0, 0, 0],
		},
		{
			""class"": ""tab_control"",
			""attributes"": [""added""],
			""layer2.tint"": ""var(--greenish)"",
		},
		{
			""class"": ""tab_control"",
			""attributes"": [""deleted""],
			""layer2.tint"": ""var(--redish)"",
		},
		// Tabs - dividers
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [{""class"": ""edit_window"", ""attributes"": [""file_light""]}],
			""layer3.tint"": ""var(file_tab_unselected_light_label_color)"",
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded""]},
			""attributes"": [""right"", ""!left""],
			""layer3.texture"": ""Theme - Default/common/tab_rounded_divider_right.png"",
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded""]},
			""attributes"": [""left_of_selected"", ""!left"", ""!right_of_selected"", ""!right_of_hover"", ""!selected"", ""!hover""],
			""layer3.texture"": ""Theme - Default/common/tab_rounded_divider_right.png"",
			""layer3.opacity"": { ""target"": 0.3, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded""]},
			""attributes"": [""left_of_hover"", ""!left"", ""!right_of_selected"", ""!right_of_hover"", ""!selected"", ""!hover""],
			""layer3.texture"": ""Theme - Default/common/tab_rounded_divider_right.png"",
			""layer3.opacity"": { ""target"": 0.3, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded""]},
			""attributes"": [""left"", ""!right""],
			""layer3.texture"": ""Theme - Default/common/tab_rounded_divider_left.png"",
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded""]},
			""attributes"": [""right_of_selected"", ""!right"", ""!left_of_selected"", ""!left_of_hover"", ""!selected"", ""!hover""],
			""layer3.texture"": ""Theme - Default/common/tab_rounded_divider_left.png"",
			""layer3.opacity"": { ""target"": 0.3, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded""]},
			""attributes"": [""right_of_hover"", ""!right"", ""!left_of_selected"", ""!left_of_hover"", ""!selected"", ""!hover""],
			""layer3.texture"": ""Theme - Default/common/tab_rounded_divider_left.png"",
			""layer3.opacity"": { ""target"": 0.3, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ["""", ""rounded""]},
			""attributes"": [""!highlighted"", ""!selected"", ""!hover"", ""!left_of_selected"", ""!right_of_selected"", ""!left_of_hover"", ""!right_of_hover""],
			""layer3.opacity"": { ""target"": 0.3, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""square""},
			""attributes"": [""right"", ""!left""],
			""layer3.texture"": ""Theme - Default/common/tab_square_divider_right.png"",
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""square""},
			""attributes"": [""left_of_selected"", ""!left"", ""!right_of_selected"", ""!right_of_hover"", ""!selected"", ""!hover""],
			""layer3.texture"": ""Theme - Default/common/tab_square_divider_right.png"",
			""layer3.opacity"": { ""target"": 0.3, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""square""},
			""attributes"": [""left_of_hover"", ""!left"", ""!right_of_selected"", ""!right_of_hover"", ""!selected"", ""!hover""],
			""layer3.texture"": ""Theme - Default/common/tab_square_divider_right.png"",
			""layer3.opacity"": { ""target"": 0.3, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""square""},
			""attributes"": [""left"", ""!right""],
			""layer3.texture"": ""Theme - Default/common/tab_square_divider_left.png"",
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""square""},
			""attributes"": [""right_of_selected"", ""!right"", ""!left_of_selected"", ""!left_of_hover"", ""!selected"", ""!hover""],
			""layer3.texture"": ""Theme - Default/common/tab_square_divider_left.png"",
			""layer3.opacity"": { ""target"": 0.3, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""square""},
			""attributes"": [""right_of_hover"", ""!right"", ""!left_of_selected"", ""!left_of_hover"", ""!selected"", ""!hover""],
			""layer3.texture"": ""Theme - Default/common/tab_square_divider_left.png"",
			""layer3.opacity"": { ""target"": 0.3, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""square""},
			""attributes"": [""!highlighted"", ""!selected"", ""!hover"", ""!left_of_selected"", ""!right_of_selected"", ""!left_of_hover"", ""!right_of_hover""],
			""layer3.opacity"": { ""target"": 0.3, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
		},
		// Tabs - border
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""attributes"": [""file_dark""],
			""layer3.texture"": ""Theme - Default/common/tab_border.png"",
			""layer3.tint"": ""black"",
			""layer3.opacity"": 0.1,
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""attributes"": [""file_medium_dark""],
			""layer3.texture"": ""Theme - Default/common/tab_border.png"",
			""layer3.tint"": ""black"",
			""layer3.opacity"": 0.05,
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""attributes"": [""file_medium""],
			""layer3.texture"": ""Theme - Default/common/tab_border_gradient.png"",
			""layer3.opacity"": 0.1,
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""attributes"": [""file_light""],
			""layer3.texture"": ""Theme - Default/common/tab_border_gradient.png"",
			""layer3.opacity"": 0.2,
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""attributes"": [""selected""],
			""layer3.opacity"": 0.2,
		},
		{
			""class"": ""tab_control"",
			""settings"": {""file_tab_style"": ""angled""},
			""attributes"": [""selected"", ""file_medium_dark""],
			""layer3.opacity"": 0.1,
		},
		// Tabs - label
		{
			""class"": ""tab_label"",
			""font.face"": ""var(font_face)"",
			""font.size"": ""var(font_size_sm)"",
		},
		{
			""class"": ""tab_label"",
			""attributes"": [""transient""],
			""font.italic"": true
		},
		{
			""class"": ""tab_label"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""fg"": ""var(file_tab_selected_label_color)"",
			""opacity"": { ""target"": 1.0, ""speed"": 5.0, ""interpolation"": ""smoothstep"" }
		},
		{
			""class"": ""tab_label"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [{""class"": ""tab_control"", ""attributes"": [""file_light""]}],
			""fg"": ""var(file_tab_selected_light_label_color)""
		},
		{
			""class"": ""tab_label"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [{""class"": ""tab_control"", ""attributes"": [""!selected""]}],
			""opacity"": { ""target"": 0.7, ""speed"": 5.0, ""interpolation"": ""smoothstep"" }
		},
		{
			""class"": ""tab_label"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [{""class"": ""tab_control"", ""attributes"": [""!selected"", ""hover""]}],
			""opacity"": { ""target"": 1.0, ""speed"": 5.0, ""interpolation"": ""smoothstep"" }
		},
		// Ensure unselected tabs use the correct text color based on what
		// background is being shown
		{
			""class"": ""tab_label"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [
				{""class"": ""tab_control"", ""attributes"": [""!selected""]}
			],
			""fg"": ""var(file_tab_unselected_label_color)""
		},
		{
			""class"": ""tab_label"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [
				{""class"": ""edit_window"", ""attributes"": [""file_light""]},
				{""class"": ""tab_control"", ""attributes"": [""!selected"", ""!hover""]}
			],
			""fg"": ""var(file_tab_unselected_light_label_color)""
		},
		{
			""class"": ""tab_label"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [
				{""class"": ""tab_control"", ""attributes"": [""!selected"", ""hover""]}
			],
			""fg"": ""var(file_tab_selected_label_color)""
		},
		{
			""class"": ""tab_label"",
			""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
			""parents"": [
				{""class"": ""tab_control"", ""attributes"": [""!selected"", ""hover"", ""file_light""]}
			],
			""fg"": ""var(file_tab_selected_light_label_color)""
		},
		{
			""class"": ""tab_label"",
			""settings"": {""file_tab_style"": ""angled""},
			""fg"": ""var(file_tab_angled_unselected_label_color)"",
			""shadow_color"": ""var(file_tab_angled_unselected_label_shadow)"",
			""shadow_offset"": [0, -1]
		},
		{
			""class"": ""tab_label"",
			""settings"": {""file_tab_style"": ""angled""},
			""parents"": [{""class"": ""tab_control"", ""attributes"": [""file_medium""]}],
			""fg"": ""var(file_tab_angled_unselected_medium_label_color)"",
			""shadow_color"": ""var(file_tab_angled_unselected_medium_label_shadow)""
		},
		{
			""class"": ""tab_label"",
			""settings"": {""file_tab_style"": ""angled""},
			""parents"": [{""class"": ""tab_control"", ""attributes"": [""file_light""]}],
			""fg"": ""var(file_tab_angled_unselected_light_label_color)"",
			""shadow_color"": ""var(file_tab_angled_unselected_light_label_shadow)"",
			""shadow_offset"": [0, 1]
		},
		{
			""class"": ""tab_label"",
			""parents"": [{""class"": ""tab_control"", ""attributes"": [""selected""]}],
			""fg"": ""var(file_tab_selected_label_color)""
		},
		{
			""class"": ""tab_label"",
			""parents"": [{""class"": ""tab_control"", ""attributes"": [""selected"", ""file_light""]}],
			""fg"": ""var(file_tab_selected_light_label_color)""
		},
		// Tabs - close button
		{
			""class"": ""tab_control"",
			""settings"": [""show_tab_close_buttons_on_left""],
			""close_button_side"": ""left"",
			""content_margin"": [22, 8, 26, 4],
		},
		{
			""class"": ""tab_control"",
			""settings"": [""!show_tab_close_buttons""],
			""content_margin"": [26, 10, 26, 4]
		},
		{
			""class"": ""tab_close_button"",
			""settings"": [""show_tab_close_buttons""],
			""layer0.texture"": ""Theme - Default/common/tab_close.png"",
			""layer0.tint"": ""color(white a(50%))"",
			""content_margin"": [10, 9]
		},
		{
			""class"": ""tab_close_button"",
			""attributes"": [""!hover""],
			""parents"": [{""class"": ""tab_control"", ""attributes"": [""dirty""]}],
			""layer0.texture"": ""Theme - Default/common/tab_dirty.png"",
		},
		{
			""class"": ""tab_close_button"",
			""parents"": [{""class"": ""tab_control"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""color(black a(50%))"",
		},
		{
			""class"": ""tab_close_button"",
			""parents"": [{""class"": ""tab_control"", ""attributes"": [""!selected""]}],
			""layer0.opacity"": ""var(file_tab_close_opacity)"",
		},
		{
			""class"": ""tab_close_button"",
			""parents"": [{""class"": ""tab_control"", ""attributes"": [""selected""]}],
			""layer0.opacity"": ""var(file_tab_close_selected_opacity)"",
		},
		{
			""class"": ""tab_close_button"",
			""attributes"": [""hover""],
			""parents"": [{""class"": ""tab_control"", ""attributes"": [""!selected""]}],
			""layer0.opacity"": ""var(file_tab_close_hover_opacity)"",
		},
		{
			""class"": ""tab_close_button"",
			""attributes"": [""hover""],
			""parents"": [{""class"": ""tab_control"", ""attributes"": [""selected""]}],
			""layer0.opacity"": ""var(file_tab_close_selected_hover_opacity)"",
		},
		{
			""class"": ""tab_close_button"",
			""parents"": [{""class"": ""tab_control"", ""attributes"": [""added""]}],
			""layer0.tint"": ""var(vcs_added)"",
		},
		{
			""class"": ""tab_close_button"",
			""parents"": [{""class"": ""tab_control"", ""attributes"": [""deleted""]}],
			""layer0.tint"": ""var(vcs_deleted)"",
		},
		// {
		// 	""class"": ""tab_close_button"",
		// 	""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
		// 	""parents"": [
		// 		{""class"": ""tab_control"", ""attributes"": [""!selected"", ""!hover""]}
		// 	],
		// 	""layer0.tint"": ""white""
		// },
		// {
		// 	""class"": ""tab_close_button"",
		// 	""settings"": {""file_tab_style"": ["""", ""rounded"", ""square""]},
		// 	""parents"": [
		// 		{""class"": ""edit_window"", ""attributes"": [""file_light""]},
		// 		{""class"": ""tab_control"", ""attributes"": [""!selected"", ""!hover""]}
		// 	],
		// 	""layer0.tint"": ""black""
		// },
		// Tab scrolling
		{
			""class"": ""scroll_tabs_left_button"",
			""layer0.texture"": ""Theme - Default/common/tab_scroll_left.png"",
			""layer0.opacity"": ""var(tabset_button_opacity)"",
			""layer0.tint"": ""white"",
			""layer0.inner_margin"": [1, 0, 13, 0],
			""content_margin"": [11, 12, 10, 12],
		},
		{
			""class"": ""scroll_tabs_left_button"",
			""parents"": [{""class"": ""edit_window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""color(black a(0.4))"",
		},
		{
			""class"": ""scroll_tabs_left_button"",
			""attributes"": [""hover""],
			""layer0.opacity"": ""var(tabset_button_hover_opacity)""
		},
		{
			""class"": ""scroll_tabs_left_button"",
			""settings"": [""hide_tab_scrolling_buttons""],
			""content_margin"": 0
		},
		{
			""class"": ""scroll_tabs_right_button"",
			""layer0.texture"": ""Theme - Default/common/tab_scroll_right.png"",
			""layer0.opacity"": ""var(tabset_button_opacity)"",
			""layer0.tint"": ""white"",
			""layer0.inner_margin"": [13, 0, 1, 0],
			// Reduces the right padding on the button due to accomodate for
			// tab overlap
			""content_margin"": [11, 12, 5, 12],
		},
		{
			""class"": ""scroll_tabs_right_button"",
			""settings"": [""hide_tab_scrolling_buttons""],
			""content_margin"": 0
		},
		{
			""class"": ""scroll_tabs_right_button"",
			""parents"": [{""class"": ""edit_window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""color(black a(0.4))"",
		},
		{
			""class"": ""scroll_tabs_right_button"",
			""attributes"": [""hover""],
			""layer0.opacity"": ""var(tabset_button_hover_opacity)""
		},
		{
			""class"": ""new_tab_button"",
			""layer0.texture"": ""Theme - Default/common/new_tab.png"",
			""layer0.tint"": ""white"",
			""layer0.opacity"": ""var(tabset_new_tab_button_opacity)"",
			""layer0.inner_margin"": [21, 0, 1, 0],
			""content_margin"": [12, 12]
		},
		{
			""class"": ""new_tab_button"",
			""settings"": [""!enable_tab_scrolling""],
			""content_margin"": [15, 12]
		},
		{
			""class"": ""new_tab_button"",
			""settings"": [""hide_new_tab_button""],
			""content_margin"": 0
		},
		{
			""class"": ""new_tab_button"",
			""parents"": [{""class"": ""edit_window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""color(black a(0.4))"",
		},
		{
			""class"": ""new_tab_button"",
			""attributes"": [""hover""],
			""layer0.opacity"": ""var(tabset_button_hover_opacity)"",
		},
		{
			""class"": ""show_tabs_dropdown_button"",
			""layer0.texture"": ""Theme - Default/common/tab_dropdown.png"",
			""layer0.opacity"": ""var(tabset_button_opacity)"",
			""layer0.tint"": ""white"",
			""layer0.inner_margin"": [1, 0, 21, 0],
			""content_margin"": [11, 12]
		},
		{
			""class"": ""show_tabs_dropdown_button"",
			""parents"": [{""class"": ""edit_window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""color(black a(0.4))"",
		},
		{
			""class"": ""show_tabs_dropdown_button"",
			""settings"": [""hide_new_tab_button""],
			""content_margin"": [13, 12]
		},
		{
			""class"": ""show_tabs_dropdown_button"",
			""attributes"": [""hover""],
			""layer0.opacity"": ""var(tabset_button_hover_opacity)""
		},

		// Sheets
		{
			""class"": ""sheet_contents"",
			""background_modifier"": """"
		},
		{
			""class"": ""sheet_contents"",
			""settings"": {
				""inactive_sheet_dimming"": true,
				""file_tab_style"": ["""", ""rounded"", ""square""],
			},
			""attributes"": [""file_dark"", ""!highlighted""],
			""background_modifier"": ""var(sheet_dark_modifier)""
		},
		{
			""class"": ""sheet_contents"",
			""settings"": {
				""inactive_sheet_dimming"": true,
				""file_tab_style"": ["""", ""rounded"", ""square""],
			},
			""attributes"": [""file_medium_dark"", ""!highlighted""],
			""background_modifier"": ""var(sheet_medium_dark_modifier)""
		},
		{
			""class"": ""sheet_contents"",
			""settings"": {
				""inactive_sheet_dimming"": true,
				""file_tab_style"": ["""", ""rounded"", ""square""],
			},
			""attributes"": [""file_medium"", ""!highlighted""],
			""background_modifier"": ""var(sheet_medium_modifier)""
		},
		{
			""class"": ""sheet_contents"",
			""settings"": {
				""inactive_sheet_dimming"": true,
				""file_tab_style"": ["""", ""rounded"", ""square""],
			},
			""attributes"": [""file_light"", ""!highlighted""],
			""background_modifier"": ""var(sheet_light_modifier)""
		},

		// Quick Panel
		{
			""class"": ""overlay_control"",
			""layer0.tint"": ""color(var(--background) blend(black 60%))"",
			""layer0.opacity"": 1.0,
			""content_margin"": 4
		},
		{
			""class"": ""overlay_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_dark""]}],
			""layer0.tint"": ""var(dark_bg)"",
		},
		{
			""class"": ""overlay_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium_dark""]}],
			""layer0.tint"": ""var(medium_dark_bg)"",
		},
		{
			""class"": ""overlay_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium""]}],
			""layer0.tint"": ""var(medium_bg)"",
		},
		{
			""class"": ""overlay_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(light_bg)"",
		},
		{
			""class"": ""quick_panel"",
			""row_padding"": [6, 4, 6, 4],
			""layer0.opacity"": 1.0,
			""dark_content"": true
		},
		{
			""class"": ""quick_panel"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_dark""]}],
			""layer0.tint"": ""var(dark_bg)"",
		},
		{
			""class"": ""quick_panel"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium_dark""]}],
			""layer0.tint"": ""var(medium_dark_bg)"",
		},
		{
			""class"": ""quick_panel"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium""]}],
			""layer0.tint"": ""var(medium_bg)"",
		},
		{
			""class"": ""quick_panel"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(light_bg)"",
			""dark_content"": false
		},
		{
			""class"": ""quick_panel"",
			""parents"": [{""class"": ""overlay_control kind_info""}],
			""row_padding"": [0, 0, 0, 0],
		},
		{
			""class"": ""mini_quick_panel_row"",
			""layer0.tint"": ""white"",
			""layer0.opacity"": 0.0
		},
		{
			""class"": ""mini_quick_panel_row"",
			""attributes"": [""selected""],
			""layer0.opacity"": 0.15
		},
		{
			""class"": ""mini_quick_panel_row"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""attributes"": [""selected""],
			""layer0.tint"": ""white"",
			""layer0.opacity"": 0.5
		},
		{
			""class"": ""quick_panel_row"",
			""layer0.tint"": ""white"",
			""layer0.opacity"": 0.0
		},
		{
			""class"": ""quick_panel_row"",
			""attributes"": [""selected""],
			""layer0.opacity"": 0.15
		},
		{
			""class"": ""quick_panel_row"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""attributes"": [""selected""],
			""layer0.tint"": ""white"",
			""layer0.opacity"": 0.35
		},
		{
			""class"": ""quick_panel_entry"",
			""spacing"": 1
		},
		{
			""class"": ""quick_panel_label"",
			""font.face"": ""var(font_face)"",
			""font.size"": ""var(font_size_lg)"",
			""fg"": ""color(var(--background) blend(white 40%))"",
			""match_fg"": ""color(var(--background) blend(white 20%))"",
			""selected_fg"": ""color(var(--background) blend(white 20%))"",
			""selected_match_fg"": ""white""
		},
		{
			""class"": ""quick_panel_label"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""fg"": ""color(var(--background) blend(black 40%))"",
			""match_fg"": ""color(var(--background) blend(black 20%))"",
			""selected_fg"": ""color(var(--background) blend(black 20%))"",
			""selected_match_fg"": ""black""
		},
		{
			""class"": ""quick_panel_path_label"",
			""font.size"": ""var(font_size_sm)"",
			""fg"": ""color(var(--background) blend(white 60%))"",
			""match_fg"": ""color(var(--background) blend(white 40%))"",
			""selected_fg"": ""color(var(--background) blend(white 50%))"",
			""selected_match_fg"": ""color(var(--background) blend(white 20%))"",
		},
		{
			""class"": ""quick_panel_detail_label"",
			""link_color"": ""var(--bluish)""
		},
		{
			""class"": ""quick_panel_path_label"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""fg"": ""color(var(--background) blend(black 50%))"",
			""match_fg"": ""color(var(--background) blend(black 40%))"",
			""selected_fg"": ""color(var(--background) blend(black 50%))"",
			""selected_match_fg"": ""color(var(--background) blend(black 20%))""
		},
		{
			""class"": ""quick_panel_label hint"",
			""font.size"": ""var(font_size_sm)"",
			""font.italic"": true,
			""fg"": ""color(var(--background) blend(white 40%) a(0.8))"",
			""selected_fg"": ""color(var(--background) blend(white 20%) a(0.8))"",
		},
		{
			""class"": ""quick_panel_label hint"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""fg"": ""color(var(--background) blend(black 40%) a(0.8))"",
			""selected_fg"": ""color(var(--background) blend(black 20%) a(0.8))"",
		},
		{
			""class"": ""quick_panel_label key_binding"",
			""font.size"": ""var(font_size_sm)"",
		},

		// Views
		{
			""class"": ""grid_layout_control"",
			""border_color"": ""var(--background)"",
			""border_size"": 2
		},
		{
			""class"": ""grid_layout_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_dark""]}],
			""border_color"": ""var(tabset_dark_bg)"",
		},
		{
			""class"": ""grid_layout_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium_dark""]}],
			""border_color"": ""var(tabset_medium_dark_bg)"",
		},
		{
			""class"": ""grid_layout_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium""]}],
			""border_color"": ""var(tabset_medium_bg)"",
		},
		{
			""class"": ""grid_layout_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""border_color"": ""var(tabset_light_bg)"",
		},
		{
			""class"": ""minimap_control"",
			""settings"": [""always_show_minimap_viewport""],
			""viewport_color"": ""var(viewport_always_visible_color)"",
			""viewport_opacity"": 1.0,
		},
		{
			""class"": ""minimap_control"",
			""settings"": [""!always_show_minimap_viewport""],
			""viewport_color"": ""var(viewport_hide_show_color)"",
			""viewport_opacity"": { ""target"": 0.0, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""minimap_control"",
			""attributes"": [""hover""],
			""settings"": [""!always_show_minimap_viewport""],
			""viewport_opacity"": { ""target"": 1.0, ""speed"": 20.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""fold_button_control"",
			""layer0.texture"": ""Theme - Default/common/fold_closed.png"",
			""layer0.tint"": ""white"",
			""layer0.opacity"": { ""target"": 0.4, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
			""content_margin"": 8
		},
		{
			""class"": ""fold_button_control"",
			""attributes"": [""hover""],
			""layer0.opacity"": { ""target"": 0.6, ""speed"": 4.0, ""interpolation"": ""smoothstep"" }
		},
		{
			""class"": ""fold_button_control"",
			""attributes"": [""expanded""],
			""layer0.texture"": ""Theme - Default/common/fold_opened.png"",
		},
		{
			""class"": ""fold_button_control"",
			""parents"": [{""class"": ""text_area_control"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""black"",
		},
		{
			""class"": ""popup_shadow"",
			""settings"": [""popup_shadows""],
			""platforms"": [""linux""],
			""layer0.texture"": ""Theme - Default/common/linux_shadow.png"",
			""layer0.inner_margin"": [24, 20, 24, 28],
			""layer0.draw_center"": false,
			""layer0.opacity"": 1.0,
			""content_margin"": [24, 20, 24, 28]
		},
		{
			""class"": ""popup_shadow"",
			""settings"": [""popup_shadows""],
			""platforms"": [""osx""],
			""layer0.texture"": ""Theme - Default/common/mac_shadow.png"",
			""layer0.inner_margin"": [24, 20, 24, 28],
			""layer0.draw_center"": false,
			""layer0.opacity"": 1.0,
			""content_margin"": [24, 20, 24, 28]
		},
		{
			""class"": ""popup_shadow"",
			""settings"": [""popup_shadows""],
			""platforms"": [""windows""],
			""layer0.texture"": ""Theme - Default/common/windows_shadow.png"",
			""layer0.inner_margin"": [15, 14, 15, 16],
			""layer0.draw_center"": false,
			""layer0.opacity"": 1.0,
			""content_margin"": [15, 14, 15, 16]
		},
		{
			""class"": ""popup_control"",
			""layer0.tint"": ""white"",
			""layer0.opacity"": 1.0
		},
		{
			""class"": ""auto_complete"",
			""row_padding"": 0,
			""tint_index"": 0,
			""layer0.opacity"": 1.0,
			""tint_modifier"": ""var(auto_complete_bg_dark_tint)"",
		},
		{
			""class"": ""auto_complete"",
			""attributes"": [""file_light""],
			""tint_modifier"": ""var(auto_complete_bg_light_tint)"",
		},
		{
			""class"": ""scroll_bar_control"",
			""parents"": [{""class"": ""popup_control auto_complete_popup""}],
			""tint_modifier"": ""var(auto_complete_bg_light_tint)"",
		},
		{
			""class"": ""scroll_bar_control"",
			""attributes"": [""dark""],
			""parents"": [{""class"": ""popup_control auto_complete_popup""}],
			""tint_modifier"": ""var(auto_complete_bg_dark_tint)"",
		},
		{
			""class"": ""table_row"",
			""layer0.tint"": ""transparent"",
			""layer0.opacity"": 1.0
		},
		{
			""class"": ""auto_complete_label"",
			""fg"": ""transparent"",
			""match_fg"": ""var(auto_complete_text_dark_tint)"",
			""selected_fg"": ""transparent"",
			""selected_match_fg"": ""var(auto_complete_text_dark_tint)"",
			""fg_blend"": true
		},
		{
			""class"": ""auto_complete_label"",
			""parents"": [{""class"": ""auto_complete"", ""attributes"": [""file_light""]}],
			""fg"": ""transparent"",
			""match_fg"": ""var(auto_complete_text_light_tint)"",
			""selected_fg"": ""transparent"",
			""selected_match_fg"": ""var(auto_complete_text_light_tint)"",
			""fg_blend"": true
		},
		{
			""class"": ""auto_complete_hint"",
			""opacity"": 0.7,
			""font.italic"": true
		},
		{
			""class"": ""table_row"",
			""attributes"": [""selected""],
			""layer0.tint"": ""var(auto_complete_selected_row_dark_tint)""
		},
		{
			""class"": ""table_row"",
			""parents"": [{""class"": ""auto_complete"", ""attributes"": [""file_light""]}],
			""attributes"": [""selected""],
			""layer0.tint"": ""var(auto_complete_selected_row_light_tint)""
		},
		{
			""class"": ""kind_container"",
			// Extra margin on the left makes the
			// italic kind_label look visually centered
			""content_margin"": [6, 0, 5, 0],
			""layer0.tint"": ""var(--background)"",
			""layer0.opacity"": 0.0,
			""layer1.tint"": ""white"",
			""layer1.opacity"": 0.0,
		},
		{
			""class"": ""kind_container"",
			""parents"":
			[
				{""class"": ""auto_complete"", ""attributes"": [""file_light""]},
			],
			""layer1.tint"": ""black"",
		},
		{
			""class"": ""kind_container"",
			""parents"":
			[
				{""class"": ""auto_complete""},
				{""class"": ""table_row"", ""attributes"": [""selected""]},
			],
			""layer1.tint"": ""white"",
		},
		{
			""class"": ""kind_container"",
			""parents"":
			[
				{""class"": ""auto_complete"", ""attributes"": [""file_light""]},
				{""class"": ""table_row"", ""attributes"": [""selected""]},
			],
			""layer1.tint"": ""black"",
		},
		{
			""class"": ""kind_label"",
			""font.face"": ""var(font_face)"",
			""font.size"": ""1.1rem"",
			""font.bold"": true,
			""font.italic"": true,
			""color"": ""var(--foreground)"",
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""quick_panel""}],
			""font.size"": ""var(font_size_lg)""
		},
		{
			""class"": ""kind_container kind_function"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(kind_function_color)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_function""}],
			""color"": ""var(kind_function_color)""
		},
		{
			""class"": ""kind_container kind_keyword"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(kind_keyword_color)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_keyword""}],
			""color"": ""var(kind_keyword_color)""
		},
		{
			""class"": ""kind_container kind_markup"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(kind_markup_color)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_markup""}],
			""color"": ""var(kind_markup_color)""
		},
		{
			""class"": ""kind_container kind_namespace"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(kind_namespace_color)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_namespace""}],
			""color"": ""var(kind_namespace_color)""
		},
		{
			""class"": ""kind_container kind_navigation"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(kind_navigation_color)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_navigation""}],
			""color"": ""var(kind_navigation_color)""
		},
		{
			""class"": ""kind_container kind_snippet"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(kind_snippet_color)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_snippet""}],
			""color"": ""var(kind_snippet_color)""
		},
		{
			""class"": ""kind_container kind_type"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(kind_type_color)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_type""}],
			""color"": ""var(kind_type_color)""
		},
		{
			""class"": ""kind_container kind_variable"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(kind_variable_color)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_variable""}],
			""color"": ""var(kind_variable_color)""
		},
		{
			""class"": ""kind_container kind_color_redish"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(--redish)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_color_redish""}],
			""color"": ""var(--redish)""
		},
		{
			""class"": ""kind_container kind_color_orangish"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(--orangish)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_color_orangish""}],
			""color"": ""var(--orangish)""
		},
		{
			""class"": ""kind_container kind_color_yellowish"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(--yellowish)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_color_yellowish""}],
			""color"": ""var(--yellowish)""
		},
		{
			""class"": ""kind_container kind_color_greenish"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(--greenish)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_color_greenish""}],
			""color"": ""var(--greenish)""
		},
		{
			""class"": ""kind_container kind_color_cyanish"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(--cyanish)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_color_cyanish""}],
			""color"": ""var(--cyanish)""
		},
		{
			""class"": ""kind_container kind_color_bluish"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(--bluish)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_color_bluish""}],
			""color"": ""var(--bluish)""
		},
		{
			""class"": ""kind_container kind_color_purplish"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(--purplish)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_color_purplish""}],
			""color"": ""var(--purplish)""
		},
		{
			""class"": ""kind_container kind_color_pinkish"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""var(--pinkish)"",
			""layer1.opacity"": 0.1,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_color_pinkish""}],
			""color"": ""var(--pinkish)""
		},
		{
			""class"": ""kind_container kind_color_dark"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""black"",
			""layer1.opacity"": 0.5,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_color_dark""}],
			""color"": ""white""
		},
		{
			""class"": ""kind_container kind_color_light"",
			""layer0.opacity"": 0.5,
			""layer1.tint"": ""white"",
			""layer1.opacity"": 1.0,
		},
		{
			""class"": ""kind_label"",
			""parents"": [{""class"": ""kind_container kind_color_light""}],
			""color"": ""#555""
		},
		{
			""class"": ""symbol_container"",
			""content_margin"": [4, 3, 4, 3]
		},
		{
			""class"": ""trigger_container"",
			""content_margin"": [4, 3, 4, 3]
		},
		{
			""class"": ""auto_complete_detail_pane"",
			""tint_index"": 0,
			""layer0.opacity"": 1.0,
			""tint_modifier"": ""var(auto_complete_detail_pane_dark_tint)"",
			""content_margin"": [8, 5, 8, 5]
		},
		{
			""class"": ""auto_complete_detail_pane"",
			""attributes"": [""file_light""],
			""tint_modifier"": ""var(auto_complete_detail_pane_light_tint)"",
		},
		{
			""class"": ""auto_complete_info"",
			""spacing"": 8,
		},
		{
			""class"": ""auto_complete_kind_name_label"",
			""font.size"": ""0.9rem"",
			""font.italic"": true,
			""border_color"": ""var(kind_name_label_border_color)""
		},
		{
			""class"": ""auto_complete_details"",
			""monospace_background_color"": ""var(auto_complete_detail_panel_mono_dark_bg)""
		},
		{
			""class"": ""auto_complete_details"",
			""parents"":
			[
				{
					""class"": ""auto_complete_detail_pane"",
					""attributes"": [""file_light""]
				}
			],
			""monospace_background_color"": ""var(auto_complete_detail_panel_mono_light_bg)"",
		},

		// Panels
		{
			""class"": ""panel_control"",
			""layer0.tint"": ""color(var(--background) blend(black 50%))"",
			""layer0.opacity"": 1.0,
			""content_margin"": 2
		},
		{
			""class"": ""panel_control"",
			""settings"": [""adaptive_dividers""],
			""layer1.texture"": ""Theme - Default/common/footer_divider.png"",
			""layer1.inner_margin"": [0, 1, 0, 1],
			""layer1.draw_center"": false,
			""layer1.opacity"": 0.15,
			""content_margin"": [2, 3, 2, 2]
		},
		{
			""class"": ""panel_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_dark""]}],
			""layer0.tint"": ""color(var(--background) blend(white 91%))"",
		},
		{
			""class"": ""panel_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium""]}],
			""layer0.tint"": ""color(var(--background) blend(black 70%))"",
		},
		{
			""class"": ""panel_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""color(var(--background) blend(black 82%))"",
		},
		{
			""class"": ""panel_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""attributes"": [""!panel_visible""],
			""settings"": [""adaptive_dividers""],
			""layer1.tint"": ""var(adaptive_dividers)"",
		},

		{
			""class"": ""status_bar"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""settings"": [""adaptive_dividers""],
			""layer1.tint"": ""black"",
		},
		{
			""class"": ""panel_control"",
			""parents"": [{""class"": ""switch_project_window"", ""attributes"": [""file_dark""]}],
			""layer0.tint"": ""var(dark_bg)""
		},
		{
			""class"": ""panel_control"",
			""parents"": [{""class"": ""switch_project_window"", ""attributes"": [""file_medium_dark""]}],
			""layer0.tint"": ""var(medium_dark_bg)""
		},
		{
			""class"": ""panel_control"",
			""parents"": [{""class"": ""switch_project_window"", ""attributes"": [""file_medium""]}],
			""layer0.tint"": ""var(medium_bg)""
		},
		{
			""class"": ""panel_control"",
			""parents"": [{""class"": ""switch_project_window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(light_bg)""
		},
		{
			""class"": ""switch_project_panel_cancel_container"",
			""layer0.tint"": ""color(var(--background) blend(black 50%))"",
			""layer0.opacity"": 1.0,
			""content_margin"": 4
		},
		{
			""class"": ""switch_project_panel_cancel_container"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_dark""]}],
			""layer0.tint"": ""color(var(--background) blend(white 91%))"",
		},
		{
			""class"": ""switch_project_panel_cancel_container"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium""]}],
			""layer0.tint"": ""color(var(--background) blend(black 70%))"",
		},
		{
			""class"": ""switch_project_panel_cancel_container"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""color(var(--background) blend(black 82%))"",
		},
		{
			""class"": ""panel_grid_control"",
			""inside_spacing"": 4,
			""outside_hspacing"": 4,
			""outside_vspacing"": 4
		},
		{
			""class"": ""panel_close_button"",
			""layer0.texture"": ""Theme - Default/common/panel_close.png"",
			""layer0.tint"": ""white"",
			""layer0.opacity"": { ""target"": 0.4, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
			""content_margin"": 8
		},
		{
			""class"": ""panel_close_button"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""color(var(--background) blend(black 20%))""
		},
		{
			""class"": ""panel_close_button"",
			""attributes"": [""hover""],
			""layer0.opacity"": { ""target"": 0.6, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		},

		// Dialogs
		{
			""class"": ""dialog"",
			""layer0.opacity"": 1.0
		},
		{
			""class"": ""dialog"",
			""attributes"": [""file_dark""],
			""layer0.tint"": ""var(dark_bg)"",
		},
		{
			""class"": ""dialog"",
			""attributes"": [""file_medium_dark""],
			""layer0.tint"": ""var(medium_dark_bg)"",
		},
		{
			""class"": ""dialog"",
			""attributes"": [""file_medium""],
			""layer0.tint"": ""var(medium_bg)"",
		},
		{
			""class"": ""dialog"",
			""attributes"": [""file_light""],
			""layer0.tint"": ""var(light_bg)"",
		},
		{
			""class"": ""progress_bar_control"",
			""layer0.tint"": ""color(white a(0.15))"",
			""layer0.opacity"": 1.0
		},
		{
			""class"": ""progress_bar_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""color(black a(0.1))"",
			""layer0.opacity"": 1.0
		},
		{
			""class"": ""progress_gauge_control"",
			""layer0.tint"": ""color(white a(0.35))"",
			""layer0.opacity"": 1.0,
			""content_margin"": [0, 6]
		},
		{
			""class"": ""progress_gauge_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""color(black a(0.2))"",
			""layer0.opacity"": 1.0
		},

		// Scroll Bars
		{
			""class"": ""scroll_area_control"",
			""settings"": [""overlay_scroll_bars""],
			""overlay"": true
		},
		{
			""class"": ""scroll_area_control"",
			""settings"": [""!overlay_scroll_bars""],
			""overlay"": false
		},
		{
			""class"": ""scroll_area_control"",
			""parents"": [{""class"": ""sidebar_container""}],
			""content_margin"": [0, 10, 0, 10]
		},
		{
			""class"": ""scroll_bar_control"",
			""layer0.opacity"": 1.0,
			""content_margin"": 4,
			""tint_index"": 0
		},
		{
			""class"": ""scroll_bar_control"",
			""settings"": [""overlay_scroll_bars""],
			""layer0.opacity"": 0.0
		},
		{
			""class"": ""scroll_bar_control"",
			""settings"": [""!overlay_scroll_bars""],
			""layer0.opacity"": 1.0
		},
		{
			""class"": ""scroll_track_control"",
			""layer0.texture"": ""Theme - Default/common/scroll.png"",
			""layer0.tint"": ""black"",
			""layer0.opacity"": 0.1,
			""layer0.inner_margin"": 2,
			""content_margin"": [4, 4, 3, 4]
		},
		{
			""class"": ""scroll_track_control"",
			""attributes"": [""dark""],
			""layer0.tint"": ""white"",
		},
		{
			""class"": ""puck_control"",
			""layer0.texture"": ""Theme - Default/common/scroll.png"",
			""layer0.tint"": ""black"",
			""layer0.opacity"": { ""target"": 0.2, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
			""layer0.inner_margin"": 2,
			""content_margin"": [0, 12]
		},
		{
			""class"": ""puck_control"",
			""parents"": [
				{""class"": ""scroll_bar_control"", ""attributes"": [""hover""]},
				{""class"": ""scroll_track_control""},
			],
			""layer0.opacity"": { ""target"": 0.6, ""speed"": 5.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""puck_control"",
			""attributes"": [""dark""],
			""layer0.tint"": ""white"",
		},
		{
			""class"": ""scroll_corner_control"",
			""layer0.opacity"": 1.0,
			""tint_index"": 0
		},
		// Scroll Bars (Horizontal)
		{
			""class"": ""scroll_track_control"",
			""attributes"": [""horizontal""],
			""layer0.texture"": ""Theme - Default/common/scroll_horiz.png"",
			""content_margin"": [4, 4, 4, 3]
		},
		{
			""class"": ""puck_control"",
			""attributes"": [""horizontal""],
			""layer0.texture"": ""Theme - Default/common/scroll_horiz.png"",
			""content_margin"": [12, 0]
		},
		// Scroll Bars (Sidebar)
		{
			""class"": ""scroll_bar_control"",
			""parents"": [{""class"": ""sidebar_container""}],
			""layer0.opacity"": 0.0,
		},
		{
			""class"": ""scroll_corner_control"",
			""parents"": [{""class"": ""sidebar_container""}],
			""layer0.opacity"": 0.0,
		},
		// Scroll Bars (Switch Project)
		{
			""class"": ""scroll_bar_control"",
			""parents"": [{""class"": ""switch_project_window""}],
			""tint_index"": -1
		},
		{
			""class"": ""scroll_bar_control"",
			""parents"": [{""class"": ""switch_project_window"", ""attributes"": [""file_dark""]}],
			""layer0.tint"": ""var(dark_bg)"",
		},
		{
			""class"": ""scroll_bar_control"",
			""parents"": [{""class"": ""switch_project_window"", ""attributes"": [""file_medium_dark""]}],
			""layer0.tint"": ""var(medium_dark_bg)"",
		},
		{
			""class"": ""scroll_bar_control"",
			""parents"": [{""class"": ""switch_project_window"", ""attributes"": [""file_medium""]}],
			""layer0.tint"": ""var(medium_bg)"",
		},
		{
			""class"": ""scroll_bar_control"",
			""parents"": [{""class"": ""switch_project_window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(light_bg)"",
		},
		// Scroll Bars (Overlay)
		{
			""class"": ""scroll_bar_control"",
			""parents"": [{""class"": ""overlay_control""}],
			""layer0.opacity"": 0.0,
			""content_margin"": [4, 0, 0, 0]
		},
		// Inputs
		{
			""class"": ""text_line_control"",
			""layer0.texture"": ""Theme - Default/common/input.png"",
			""layer0.opacity"": 1.0,
			""layer0.inner_margin"": 4,
			""tint_index"": 0,
			""content_margin"": 4,
		},
		{
			""class"": ""text_line_control"",
			""parents"": [{""class"": ""overlay_control""}],
			""font.face"": ""system"",
			""font.size"": ""var(font_size_lg)""
		},
		{
			""class"": ""text_line_control"",
			""parents"": [{""class"": ""switch_project_window""}],
			""font.face"": ""system"",
			""font.size"": ""var(font_size_lg)""
		},
		{
			""class"": ""text_area_control"",
			""settings"": {
				""inactive_sheet_dimming"": true,
			},
			""attributes"": [""!highlighted""],
			""parents"": [{""class"": ""text_line_control""}],
			""background_modifier"": ""var(text_widget_dark_modifier)"",
		},
		{
			""class"": ""text_area_control"",
			""settings"": {
				""inactive_sheet_dimming"": true,
			},
			""attributes"": [""file_light"", ""!highlighted""],
			""parents"": [{""class"": ""text_line_control""}],
			""background_modifier"": ""var(text_widget_light_modifier)"",
		},
		{
			""class"": ""dropdown_button_control"",
			""layer0.texture"": ""Theme - Default/common/dropdown_button.png"",
			""layer0.tint"": ""white"",
			""layer0.opacity"": { ""target"": 0.3, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
			""content_margin"": [9, 8, 9, 8]
		},
		{
			""class"": ""dropdown_button_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""black"",
		},
		{
			""class"": ""dropdown_button_control"",
			""attributes"": [""hover""],
			""layer0.opacity"": { ""target"": 0.5, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		},

		// Buttons
		{
			""class"": ""button_control"",
			""layer0.texture"": ""Theme - Default/common/button.png"",
			""layer0.opacity"": { ""target"": 0.15, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
			""layer0.inner_margin"": 4,
			""min_size"": [80, 18],
			""content_margin"": [10, 4]
		},
		{
			""class"": ""button_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_dark""]}],
			""layer0.opacity"": { ""target"": 0.15, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""button_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium""]}],
			""layer0.opacity"": { ""target"": 0.25, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""button_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.opacity"": { ""target"": 0.5, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
			""layer0.tint"": ""white"",
		},
		{
			""class"": ""button_control"",
			""attributes"": [""hover""],
			""layer0.opacity"": { ""target"": 0.25, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""button_control"",
			""attributes"": [""hover""],
			""parents"": [{""class"": ""window"", ""attributes"": [""file_dark""]}],
			""layer0.opacity"": { ""target"": 0.25, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""button_control"",
			""attributes"": [""hover""],
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium""]}],
			""layer0.opacity"": { ""target"": 0.4, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""button_control"",
			""attributes"": [""hover""],
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.opacity"": { ""target"": 0.75, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""button_control"",
			""attributes"": [""pressed""],
			""layer0.opacity"": { ""target"": 0.3, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""button_control"",
			""attributes"": [""pressed""],
			""parents"": [{""class"": ""window"", ""attributes"": [""file_dark""]}],
			""layer0.opacity"": { ""target"": 0.3, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""button_control"",
			""attributes"": [""pressed""],
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium""]}],
			""layer0.opacity"": { ""target"": 0.5, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""button_control"",
			""attributes"": [""pressed""],
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.opacity"": { ""target"": 0.9, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""button_control"",
			""attributes"": [""disabled""],
			""layer0.opacity"": 0.09,
		},
		{
			""class"": ""icon_button_group"",
			""spacing"": 4
		},
		{
			""class"": ""icon_button_control"",
			""layer0.texture"": ""Theme - Default/common/icon_button_highlight.png"",
			""layer0.opacity"": 0.0,
			""layer0.inner_margin"": 2,
			""content_margin"": 2
		},
		{
			""class"": ""icon_button_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_dark""]}],
		},
		{
			""class"": ""icon_button_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""white"",
		},
		{
			""class"": ""icon_button_control"",
			""attributes"": [""selected""],
			""layer0.opacity"": 0.15
		},
		{
			""class"": ""icon_button_control"",
			""attributes"": [""selected""],
			""parents"": [{""class"": ""window"", ""attributes"": [""file_dark""]}],
			""layer0.opacity"": 0.15
		},
		{
			""class"": ""icon_button_control"",
			""attributes"": [""selected""],
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium""]}],
			""layer0.opacity"": 0.25
		},
		{
			""class"": ""icon_button_control"",
			""attributes"": [""selected""],
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.opacity"": 0.5
		},
		{
			""class"": ""icon_regex"",
			""layer0.texture"": ""Theme - Default/common/icon_regex.png"",
			""layer0.tint"": ""var(icon_tint)"",
			""layer0.opacity"": ""var(icon_opacity)"",
			""content_margin"": [14, 11],
		},
		{
			""class"": ""icon_regex"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(icon_light_tint)"",
		},
		{
			""class"": ""icon_regex"",
			""attributes"": [""hover""],
			""layer0.opacity"": ""var(icon_hover_opacity)"",
		},
		{
			""class"": ""icon_regex"",
			""parents"": [{""class"": ""icon_button_control"", ""attributes"": [""selected""]}],
			""layer0.tint"": [""accent"", 1.0],
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""icon_case"",
			""layer0.texture"": ""Theme - Default/common/icon_case_sensitive.png"",
			""layer0.tint"": ""var(icon_tint)"",
			""layer0.opacity"": ""var(icon_opacity)"",
			""content_margin"": [14, 11]
		},
		{
			""class"": ""icon_case"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(icon_light_tint)"",
		},
		{
			""class"": ""icon_case"",
			""attributes"": [""hover""],
			""layer0.opacity"": ""var(icon_hover_opacity)"",
		},
		{
			""class"": ""icon_case"",
			""parents"": [{""class"": ""icon_button_control"", ""attributes"": [""selected""]}],
			""layer0.tint"": [""accent"", 1.0],
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""icon_whole_word"",
			""layer0.texture"": ""Theme - Default/common/icon_whole_word.png"",
			""layer0.tint"": ""var(icon_tint)"",
			""layer0.opacity"": ""var(icon_opacity)"",
			""content_margin"": [14, 11]
		},
		{
			""class"": ""icon_whole_word"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(icon_light_tint)"",
		},
		{
			""class"": ""icon_whole_word"",
			""attributes"": [""hover""],
			""layer0.opacity"": ""var(icon_hover_opacity)"",
		},
		{
			""class"": ""icon_whole_word"",
			""parents"": [{""class"": ""icon_button_control"", ""attributes"": [""selected""]}],
			""layer0.tint"": [""accent"", 1.0],
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""icon_wrap"",
			""layer0.texture"": ""Theme - Default/common/icon_wrap.png"",
			""layer0.tint"": ""var(icon_tint)"",
			""layer0.opacity"": ""var(icon_opacity)"",
			""content_margin"": [14, 11]
		},
		{
			""class"": ""icon_wrap"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(icon_light_tint)"",
		},
		{
			""class"": ""icon_wrap"",
			""attributes"": [""hover""],
			""layer0.opacity"": ""var(icon_hover_opacity)"",
		},
		{
			""class"": ""icon_wrap"",
			""parents"": [{""class"": ""icon_button_control"", ""attributes"": [""selected""]}],
			""layer0.tint"": [""accent"", 1.0],
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""icon_in_selection"",
			""layer0.texture"": ""Theme - Default/common/icon_in_selection.png"",
			""layer0.tint"": ""var(icon_tint)"",
			""layer0.opacity"": ""var(icon_opacity)"",
			""content_margin"": [14, 11]
		},
		{
			""class"": ""icon_in_selection"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(icon_light_tint)"",
		},
		{
			""class"": ""icon_in_selection"",
			""attributes"": [""hover""],
			""layer0.opacity"": ""var(icon_hover_opacity)"",
		},
		{
			""class"": ""icon_in_selection"",
			""parents"": [{""class"": ""icon_button_control"", ""attributes"": [""selected""]}],
			""layer0.tint"": [""accent"", 1.0],
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""icon_highlight"",
			""layer0.texture"": ""Theme - Default/common/icon_highlight_matches.png"",
			""layer0.tint"": ""var(icon_tint)"",
			""layer0.opacity"": ""var(icon_opacity)"",
			""content_margin"": [14, 11]
		},
		{
			""class"": ""icon_highlight"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(icon_light_tint)"",
		},
		{
			""class"": ""icon_highlight"",
			""attributes"": [""hover""],
			""layer0.opacity"": ""var(icon_hover_opacity)"",
		},
		{
			""class"": ""icon_highlight"",
			""parents"": [{""class"": ""icon_button_control"", ""attributes"": [""selected""]}],
			""layer0.tint"": [""accent"", 1.0],
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""icon_preserve_case"",
			""layer0.texture"": ""Theme - Default/common/icon_preserve_case.png"",
			""layer0.tint"": ""var(icon_tint)"",
			""layer0.opacity"": ""var(icon_opacity)"",
			""content_margin"": [14, 11]
		},
		{
			""class"": ""icon_preserve_case"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(icon_light_tint)"",
		},
		{
			""class"": ""icon_preserve_case"",
			""attributes"": [""hover""],
			""layer0.opacity"": ""var(icon_hover_opacity)"",
		},
		{
			""class"": ""icon_preserve_case"",
			""parents"": [{""class"": ""icon_button_control"", ""attributes"": [""selected""]}],
			""layer0.tint"": [""accent"", 1.0],
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""icon_context"",
			""layer0.texture"": ""Theme - Default/common/icon_context.png"",
			""layer0.tint"": ""var(icon_tint)"",
			""layer0.opacity"": ""var(icon_opacity)"",
			""content_margin"": [14, 11]
		},
		{
			""class"": ""icon_context"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(icon_light_tint)"",
		},
		{
			""class"": ""icon_context"",
			""attributes"": [""hover""],
			""layer0.opacity"": ""var(icon_hover_opacity)"",
		},
		{
			""class"": ""icon_context"",
			""parents"": [{""class"": ""icon_button_control"", ""attributes"": [""selected""]}],
			""layer0.tint"": [""accent"", 1.0],
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""icon_use_buffer"",
			""layer0.texture"": ""Theme - Default/common/icon_use_buffer.png"",
			""layer0.tint"": ""var(icon_tint)"",
			""layer0.opacity"": ""var(icon_opacity)"",
			""content_margin"": [14, 11]
		},
		{
			""class"": ""icon_use_buffer"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(icon_light_tint)"",
		},
		{
			""class"": ""icon_use_buffer"",
			""attributes"": [""hover""],
			""layer0.opacity"": ""var(icon_hover_opacity)"",
		},
		{
			""class"": ""icon_use_buffer"",
			""parents"": [{""class"": ""icon_button_control"", ""attributes"": [""selected""]}],
			""layer0.tint"": [""accent"", 1.0],
			""layer0.opacity"": 1.0,
		},
		{
			""class"": ""icon_use_gitignore"",
			""layer0.texture"": ""Theme - Default/common/icon_use_gitignore.png"",
			""layer0.tint"": ""white"",
			""layer0.opacity"": ""var(icon_opacity)"",
			""content_margin"": [14, 11]
		},
		{
			""class"": ""icon_use_gitignore"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""var(icon_light_tint)"",
		},
		{
			""class"": ""icon_use_gitignore"",
			""attributes"": [""hover""],
			""layer0.opacity"": ""var(icon_hover_opacity)"",
		},
		{
			""class"": ""icon_use_gitignore"",
			""parents"": [{""class"": ""icon_button_control"", ""attributes"": [""selected""]}],
			""layer0.tint"": [""accent"", 1.0],
			""layer0.opacity"": 1.0,
		},

		// Labels
		{
			""class"": ""label_control"",
			""fg"": ""color(var(--background) blend(white 10%))"",
			""font.face"": ""var(font_face)"",
			""font.size"": ""var(font_size)""
		},
		{
			""class"": ""label_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""fg"": ""color(var(--background) blend(black 20%))"",
		},
		{
			""class"": ""title_label_control"",
			""fg"": ""white"",
			""font.face"": ""var(font_face)"",
			""font.size"": ""var(font_size_title)""
		},
		{
			""class"": ""title_label_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""fg"": ""color(var(--background) blend(black 10%))"",
		},
		{
			""class"": ""label_control"",
			""parents"": [{""class"": ""button_control""}],
			""shadow_color"": ""color(black a(0.1))"",
			""shadow_offset"": [0, 1],
			""opacity"": 1,
		},
		{
			""class"": ""label_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}, {""class"": ""button_control""}],
			""shadow_color"": ""color(white a(0.1))"",
		},
		{
			""class"": ""label_control"",
			""parents"": [{""class"": ""button_control"", ""attributes"": [""disabled""]}],
			""opacity"": 0.7,
		},

		// Link Labels
		{
			""class"": ""link_label"",
			""fg"": ""color(var(--background) blend(var(link_fg) 10%))"",
		},

		// Tool tips
		{
			""class"": ""tool_tip_control"",
			""layer0.tint"": ""var(tool_tip_bg)"",
			""layer0.opacity"": 1.0,
			""content_margin"": [8, 3, 8, 3]
		},
		{
			""class"": ""tool_tip_label_control"",
			""font.face"": ""var(font_face)"",
			""font.size"": ""var(font_size_sm)"",
			""fg"": ""var(tool_tip_fg)""
		},

		// Status Bar
		{
			""class"": ""status_bar"",
			""layer0.tint"": ""color(var(--background) blend(black 50%))"",
			""layer0.opacity"": 1.0,
			""layer1.texture"": ""Theme - Default/common/footer_divider.png"",
			""layer1.inner_margin"": [0, 1, 0, 1],
			""layer1.draw_center"": false,
			""layer1.opacity"": 0.0,
			""content_margin"": [8, 0, 8, 0]
		},
		{
			""class"": ""status_bar"",
			""attributes"": [""panel_visible""],
			""settings"": [""adaptive_dividers""],
			""layer1.opacity"": 0.0,
			""content_margin"": [8, 0, 8, 0]
		},
		{
			""class"": ""status_bar"",
			""attributes"": [""!panel_visible""],
			""settings"": [""adaptive_dividers""],
			""layer1.opacity"": 0.15,
			""content_margin"": [8, 1, 8, 0]
		},
		{
			""class"": ""status_bar"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_dark""]}],
			""layer0.tint"": ""color(var(--background) blend(white 91%))"",
		},
		{
			""class"": ""status_bar"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_medium""]}],
			""layer0.tint"": ""color(var(--background) blend(black 70%))"",
		},
		{
			""class"": ""status_bar"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""color(var(--background) blend(black 82%))"",
		},
		{
			""class"": ""status_bar"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""attributes"": [""!panel_visible""],
			""settings"": [""adaptive_dividers""],
			""layer1.tint"": ""var(adaptive_dividers)"",
		},
		{
			""class"": ""sidebar_button_control"",
			""layer0.texture"": ""Theme - Default/common/sidebar_button.png"",
			""layer0.opacity"": { ""target"": 0.4, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
			""layer0.tint"": ""#fff"",
			""content_margin"": [10, 11]
		},
		{
			""class"": ""sidebar_button_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}],
			""layer0.tint"": ""#000""
		},
		{
			""class"": ""sidebar_button_control"",
			""attributes"": [""hover""],
			""layer0.opacity"": { ""target"": 0.6, ""speed"": 4.0, ""interpolation"": ""smoothstep"" },
		},
		{
			""class"": ""status_container"",
			""content_margin"": [8, 0, 0, 0]
		},
		{
			""class"": ""status_button"",
			""content_margin"": [10, 0, 10, 0],
			""min_size"": [80, 0]
		},
		{
			""class"": ""label_control"",
			""parents"": [{""class"": ""status_bar""}],
			""fg"": ""color(var(--background) blend(white 30%))"",
			""font.size"": ""var(font_size_sm)"",
			""shadow_color"": ""color(black a(0.18))"",
			""shadow_offset"": [0, 1]
		},
		{
			""class"": ""label_control"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}, {""class"": ""status_bar""}],
			""fg"": ""color(var(--background) blend(black 30%))"",
			""shadow_color"": ""color(white a(0.18))"",
		},
		{
			""class"": ""vcs_status"",
			""spacing"": 3
		},
		{
			""class"": ""vcs_branch_icon"",
			""layer0.texture"": ""Theme - Default/common/branch.png"",
			""layer0.tint"": ""color(var(--background) blend(white 50%))"",
			""layer0.opacity"": 1.0,
			""content_margin"": [6, 11]
		},
		{
			""class"": ""vcs_branch_icon"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}, {""class"": ""status_bar""}],
			""layer0.tint"": ""color(var(--background) blend(black 50%))"",
		},
		{
			""class"": ""vcs_changes_annotation"",
			""font.face"": ""var(font_face)"",
			""font.size"": 9,
			""color"": ""color(var(--background) blend(white 40%))"",
			""border_color"": ""color(var(--background) blend(white 70%))"",
			""content_margin"": [3, 0]
		},
		{
			""class"": ""vcs_changes_annotation"",
			""parents"": [{""class"": ""window"", ""attributes"": [""file_light""]}, {""class"": ""status_bar""}],
			""color"": ""color(var(--background) blend(black 40%))"",
			""border_color"": ""color(var(--background) blend(black 60%))"",
		},

		// Checkboxes
		{
			""class"": ""checkbox_box_control"",
			""content_margin"": [13, 13, 0, 0],
			""layer0.texture"": ""Theme - Default/common/checkbox_back.png"",
			""layer0.tint"": ""var(checkbox_back)"",
			""layer0.opacity"": 1,
			""layer1.texture"": ""Theme - Default/common/checkbox_border.png"",
			""layer1.tint"": ""var(checkbox_border-unselected)"",
			""layer1.opacity"": 1,
			""layer2.texture"": ""Theme - Default/common/checkbox_check.png"",
			""layer2.tint"": ""var(checkbox_selected)"",
			""layer2.opacity"": 0,
		},
		{
			""class"": ""checkbox_box_control"",
			""parents"": [ {""class"": ""checkbox_control"", ""attributes"": [""checked""]}],
			""layer1.tint"": ""var(checkbox_border-selected)"",
			""layer2.opacity"": 1,
		},
		{
			""class"": ""checkbox_box_control"",
			""parents"": [ {""class"": ""checkbox_control"", ""attributes"": [""disabled""]}],
			""layer2.texture"": ""Theme - Default/common/checkbox_disabled.png"",
			""layer2.tint"": ""var(checkbox-disabled)"",
			""layer2.opacity"": 1,
		},

		// Radio Buttons
		{
			""class"": ""radio_button_list_control"",
			""spacing"": 4
		},
		{
			""class"": ""checkbox_box_control"",
			""parents"": [{""class"": ""radio_button_list_control""}, {""class"": ""checkbox_control""}],
			""content_margin"": [13, 13, 0, 0],
			""layer0.texture"": ""Theme - Default/common/radio_button_back.png"",
			""layer0.tint"": ""var(radio_back)"",
			""layer0.opacity"": 1,
			""layer1.texture"": ""Theme - Default/common/radio_button_border.png"",
			""layer1.tint"": ""var(radio_border-unselected)"",
			""layer1.opacity"": 1,
			""layer2.texture"": ""Theme - Default/common/radio_button_on.png"",
			""layer2.tint"": ""var(radio_selected)"",
			""layer2.opacity"": 0,
		},
		{
			""class"": ""checkbox_box_control"",
			""parents"": [{""class"": ""radio_button_list_control""}, {""class"": ""checkbox_control"", ""attributes"": [""hover""]}],
			""layer1.tint"": ""var(radio_border-selected)"",
		},
		{
			""class"": ""checkbox_box_control"",
			""parents"": [{""class"": ""radio_button_list_control""}, {""class"": ""checkbox_control"", ""attributes"": [""checked""]}],
			""layer1.tint"": ""var(radio_border-selected)"",
			""layer2.opacity"": 1,
		},
	]
}
" ;
#endregion
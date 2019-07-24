if(window.Core == undefined) window.Core = {};

window.ClientMode = true;

Core.Config = {
	Version: window.external.Version,
	AppPath: window.external.AppPath,
	ResPath: window.external.ResPath,
	EnableDynamicApp: false
};
Core.AllPlugins = {
    "EmbedCS": {
        "Name": "EmbedCS",
        "InjectModules": {
            "MainForm": {
                "DependentModules": [],
                "UserFormToolbarExtent": [
					{
					    Command: "ViewComment",
					    Text: "查看留言",
					    Css: "btnviewcomment",
					    AdminPermission: false,
					    AllowTempUser: false,
					    OnCommand: function () {
					        Core.PluginsNS.EmbedCS.OnViewComment();
					    }
					}
                ]
            }
        },
        "Global": "EmbedCS.js",
        "AfterInit": function () {
            Core.PluginsNS.EmbedCS.AfterInit();
        },
        "AfterInitSession": function () {
            Core.PluginsNS.EmbedCS.AfterInitSession();
        }
    },
    "Comm": {
        "Name": "Comm",
        "InjectModules": {
            "MainForm": {
                "DependentModules": [],
                "MainMenuExtent": [
					{
					    Command: "CommMan",
					    Text: "用户/群组管理",
					    AdminPermission: true,
					    OnCommand: function () {
					        Core.PluginsNS.CommPlugin.ShowCommManForm();
					    }
					},
					{
					    Command: "CommMan",
					    Text: "好友/群组管理",
					    AdminPermission: false,
					    AllowTempUser: false,
					    OnCommand: function () {
					        Core.PluginsNS.CommPlugin.ShowCommManForm();
					    }
					},
					{
					    Command: "AddFriend",
					    Text: "添加好友/群",
					    AdminPermission: false,
					    AllowTempUser: false,
					    OnCommand: function () {
					        Core.Session.GetGlobal("SingletonForm").ShowAddFriendForm();
					    }
					}
                ]
            }
        },
        "Global": "CommPlugin.js",
        "AfterInit": function () {
        },
        "AfterInitSession": function () {
        }
    }
};
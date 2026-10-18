using HedgeModManager.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static HedgeModManager.Lang;

namespace HedgeModManager
{
    public static class Games
    {
        public const uint CodeLoaderMinCodeVersionStringId = 101;
        public const uint CodeLoaderMaxCodeVersionStringId = 102;
        public const string EmbeddedCPKREDIRVersion = "0.5.0.8";

        public static Game Unknown = new Game();
        public static Game SonicGenerations = new Game()
        {
            GameName = "SonicGenerations",
            ExecutableName = "SonicGenerations.exe",
            SaveName = "cpkredir.sav",
            SupportsCPKREDIR = true,
            SupportsSaveRedirection = true,
            Folders = new [] { "disk/bb", "disk/bb2", "disk/bb3" },
            AppID = "71340",
            GBProtocol = "hedgemmgens",
            Is64Bit = false,
            ModLoader = ModLoaders.HE1ModLoader,
            CodesURL = Resources.URL_BLUEBLUR_CODES,
            GamePath = Path.Combine("Sonic Generations", "SonicGenerations.exe")
        };

        public static Game SonicLostWorld = new Game()
        {
            GameName = "SonicLostWorld",
            ExecutableName = "slw.exe",
            SaveName = "cpkredir.sav",
            SupportsCPKREDIR = true,
            SupportsSaveRedirection = true,
            Folders = new[] { "disk/sonic2013_patch_0" },
            AppID = "329440",
            GBProtocol = "hedgemmlw",
            Is64Bit = false,
            ModLoader = ModLoaders.HE1ModLoader,
            CodesURL = Resources.URL_SONIC2013_CODES,
            GamePath = Path.Combine("Sonic Lost World", "slw.exe")
        };

        // TODO: Change SaveName to "savedata.xml" once we have code to transfer fallback saves to the new name.
        public static Game SonicForces = new Game()
        {
            GameName = "SonicForces",
            ExecutableName = "Sonic Forces.exe",
            SaveName = "cpkredir.sav",
            SupportsCPKREDIR = false,
            SupportsSaveRedirection = true,
            Folders = new[] { "disk/wars_patch" },
            AppID = "637100",
            GBProtocol = "hedgemmforces",
            Is64Bit = true,
            ModLoader = ModLoaders.HE2ModLoader,
            CodesURL = Resources.URL_WARS_CODES,
            GamePath = Path.Combine("SonicForces", "build", "main", "projects", "exec", "Sonic Forces.exe")
        };

        public static Game PuyoPuyoTetris2 = new Game()
        {
            GameName = "PuyoPuyoTetris2",
            ExecutableName = "PuyoPuyoTetris2.exe",
            SupportsCPKREDIR = false,
            SupportsSaveRedirection = false,
            Folders = new[] { "raw" },
            AppID = "1259790",
            GBProtocol = "hedgemmtenpex",
            Is64Bit = true,
            ModLoader = ModLoaders.HE2ModLoader,
            CodesURL = Resources.URL_TENPEX_CODES,
            GamePath = Path.Combine("PuyoPuyoTetris2", "PuyoPuyoTetris2.exe")
        };

        public static Game Tokyo2020 = new Game()
        {
            GameName = "Tokyo2020",
            ExecutableName = "musashi.exe",
            SupportsCPKREDIR = false,
            SupportsSaveRedirection = false,
            Folders = new[] { "musashi_0" },
            AppID = "981890",
            GBProtocol = "hedgemmmusashi",
            Is64Bit = true,
            ModLoader = ModLoaders.HE2ModLoader,
            CodesURL = Resources.URL_MUSASHI_CODES,
            GamePath = Path.Combine("Tokyo2020", "musashi.exe")
        };

        public static Game SonicColorsUltimate = new Game()
        {
            GameName = "SonicColorsUltimate",
            ExecutableName = "Sonic Colors - Ultimate.exe",
            SupportsCPKREDIR = false,
            SupportsSaveRedirection = false,
            Folders = new[] { "PCCriPak" },
            AppID = "2055290",
            EGSID = "e5071e19d08c45a6bdda5d92fbd0a03e",
            GBProtocol = "hedgemmrainbow",
            Is64Bit = true,
            ModLoader = ModLoaders.RainbowModLoader,
            CodesURL = Resources.URL_RAINBOW_CODES,
            GamePath = Path.Combine("SonicColorsUltimate", "exec", "SonicColorsUltimate.exe"),
            GamePathEGS = Path.Combine("SonicColorsUltimate", "rainbow Shipping", "Sonic Colors - Ultimate.exe")
        };

        public static Game SonicOrigins = new Game()
        {
            GameName = "SonicOrigins",
            ExecutableName = "SonicOrigins.exe",
            SaveName = "savedata",
            SupportsCPKREDIR = false,
            SupportsSaveRedirection = true,
            Folders = new[] { "raw", "Sonic1u", "Sonic2u", "Sonic3ku", "SonicCDu" },
            AppID = "1794960",
            EGSID = "5070a8e44cf74ba3b9a4ca0c0dce5cf1",
            GBProtocol = "hedgemmhite",
            Is64Bit = true,
            ModLoader = ModLoaders.HiteModLoader,
            CodesURL = Resources.URL_HITE_CODES,
            GamePath = Path.Combine("SonicOrigins", "build", "main", "projects", "exec", "SonicOrigins.exe")
        };

        public static Game SonicFrontiers = new Game()
        {
            GameName = "SonicFrontiers",
            ExecutableName = "SonicFrontiers.exe",
            SaveName = "savedata",
            SupportsCPKREDIR = false,
            SupportsSaveRedirection = true,
            Folders = new[] { "raw" },
            AppID = "1237320",
            GBProtocol = "hedgemmrangers",
            Is64Bit = true,
            ModLoader = ModLoaders.HE2ModLoader,
            CodesURL = Resources.URL_RANGERS_CODES,
            GamePath = Path.Combine("SonicFrontiers", "SonicFrontiers.exe")
        };
        public static Game MetalGearRising = new Game()
        {
            GameName = "MetalGearRising",
            ExecutableName = "METAL GEAR RISING REVENGEANCE.exe",
            SupportsCPKREDIR = true,
            SupportsSaveRedirection = false,
            Folders = new[] { "data000" },
            AppID = "235460",
            GBProtocol = "hedgemmmgr",
            Is64Bit = false,
            ModLoader = ModLoaders.HE1ModLoader,
            CodesURL = "https://raw.githubusercontent.com/RevOcelotMGS/RisingModManager/rewrite/HedgeModManager/Resources/Codesv2/MetalGearRising.hmm",
            GamePath = Path.Combine("METAL GEAR RISING REVENGEANCE", "METAL GEAR RISING REVENGEANCE.exe")
        };

        public static IEnumerable<Game> GetSupportedGames()
        {
            yield return MetalGearRising;
        }
    }

    internal static class EmbeddedLoaders
    {
        public static byte[] HE1ModLoader;
        public static byte[] HE2ModLoader;
        public static byte[] RainbowModLoader;
        public static byte[] HiteModLoader;

        static EmbeddedLoaders()
        {
            using (var stream = new MemoryStream(Resources.DAT_LOADERS_ZIP))
            using (var zip = new ZipArchive(stream))
            {
                HE1ModLoader = GetFile("HE1ML.dll");
                HE2ModLoader = GetFile("HE2ModLoader.dll");
                RainbowModLoader = GetFile("RainbowModLoader.dll");
                HiteModLoader = GetFile("HiteModLoader.dll");

                byte[] GetFile(string name)
                {
                    var entry = zip.GetEntry(name);
                    using (var file = entry.Open())
                    {
                        var buffer = new byte[entry.Length];
                        file.Read(buffer, 0, buffer.Length);
                        return buffer;
                    }
                }
            }
        }
    }

    public class Game
    {
        public string GameName = "NoGame";
        public bool IsCustom = false;
        public string ExecutableName = string.Empty;
        public string SaveName = string.Empty;
        public ModLoader ModLoader = null;
        public bool SupportsCPKREDIR = false;
        public bool SupportsSaveRedirection = false;
        public string[] Folders = { "raw" };
        public string AppID = "0";
        public string EGSID = null;
        public string GBProtocol;
        public bool Is64Bit = false;
        public string CodesURL;
        public string GamePath = string.Empty;
        public string GamePathEGS = string.Empty;

        public override string ToString() => Localise("Game" + GameName, GameName);
    }

    public class GameInstall
    {
        public Game BaseGame;
        public string GameDirectory;
        public GameLauncher Launcher;
        public bool ShowLauncher = false;
        public string CustomExecutablePath;

        public string GameName
        {
            get
            {
                var gameName = BaseGame?.IsCustom == true
                    ? BaseGame.GameName
                    : Localise("Game" + BaseGame?.GameName, BaseGame?.GameName);
                return gameName + (ShowLauncher ? $" ({Localise("Launcher" + Launcher)})" : "");
            }
        }

        public Uri GameImage
        {
            get
            {
                if (BaseGame?.IsCustom == true)
                    return null;

                return HedgeApp.GetResourceUri($"Resources/Graphics/Games/{BaseGame?.GameName}.png");
            }
        }

        public GameInstall(Game game, string directory, GameLauncher launcher, string customExecutablePath = null)
        {
            BaseGame = game;
            GameDirectory = directory;
            Launcher = launcher;
            CustomExecutablePath = customExecutablePath;
        }

        public void StartGame(bool useLauncher = true, string startDirectory = null)
        {
            if (string.IsNullOrEmpty(startDirectory))
                startDirectory = HedgeApp.StartDirectory;

            if (useLauncher)
            {
                switch (Launcher)
                {
                    case GameLauncher.Steam:
                        HedgeApp.StartURL($"steam://run/{BaseGame.AppID}", true);
                        break;
                    case GameLauncher.Epic:
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = $"com.epicgames.launcher://apps/{BaseGame.EGSID}?action=launch&silent=true",
                            UseShellExecute = true
                        });
                        break;
                    case GameLauncher.Heroic:
                        HedgeApp.StartURL($"heroic://launch/{BaseGame.EGSID}", true);
                        break;
                    default:
                        Process.Start(new ProcessStartInfo(GetExecutablePath(startDirectory))
                        {
                            WorkingDirectory = GetWorkingDirectory(startDirectory)
                        });
                        break;
                }
            }
            else
            {
                Process.Start(new ProcessStartInfo(GetExecutablePath(startDirectory))
                {
                    WorkingDirectory = GetWorkingDirectory(startDirectory)
                });
            }
        }

        public string GetExecutablePath(string startDirectory = null)
        {
            if (BaseGame?.IsCustom == true && !string.IsNullOrEmpty(CustomExecutablePath))
                return Path.GetFullPath(CustomExecutablePath);

            if (string.IsNullOrEmpty(startDirectory))
                startDirectory = GameDirectory;

            return Path.Combine(startDirectory ?? string.Empty, BaseGame?.ExecutableName ?? string.Empty);
        }

        private string GetWorkingDirectory(string startDirectory = null)
        {
            var executablePath = GetExecutablePath(startDirectory);
            return Path.GetDirectoryName(executablePath) ?? startDirectory;
        }

        public static List<GameInstall> SearchForGames(string preference = null)
        {
            var steamGames = Steam.SearchForGames();
            var epicGames = Epic.SearchForGames();

            var games = new List<GameInstall>();

            if (steamGames != null)
                games.AddRange(steamGames);

            if (epicGames != null)
                games.AddRange(epicGames);

            games.AddRange(LoadCustomGames());

            // Extra directories
            if (!string.IsNullOrEmpty(RegistryConfig.ExtraGameDirectories))
            {
                foreach (string path in RegistryConfig.ExtraGameDirectories.Split(';'))
                {
                    if (Directory.Exists(path))
                    {
                        foreach (var game in Games.GetSupportedGames())
                        {
                            string fullPath = Path.Combine(path, game.ExecutableName);
                            if (File.Exists(fullPath))
                            {
                                games.Add(new GameInstall(game, Path.GetDirectoryName(fullPath), GameLauncher.None));
                            }
                        }
                    }
                }
            }

            games = games
                .GroupBy(GetInstallIdentity, StringComparer.OrdinalIgnoreCase)
                .Select(group => group.First())
                .ToList();

            // Check for dupes
            foreach (var game in games.GroupBy(t => t.BaseGame).Where(t => t.Count() > 1).Select(t => t.Key))
            {
                foreach (var install in games.Where(t => t.BaseGame == game))
                {
                    install.ShowLauncher = true;
                }
            }

            return !string.IsNullOrEmpty(preference)
                ? games.OrderBy(x => x.BaseGame.GameName != preference).ToList()
                : games;
        }

        private static string GetInstallIdentity(GameInstall install)
        {
            var executablePath = install.GetExecutablePath(install.GameDirectory) ?? string.Empty;
            executablePath = executablePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);

            return $"{install.BaseGame?.GameName}|{executablePath}";
        }

        private static IEnumerable<GameInstall> LoadCustomGames()
        {
            var installs = new List<GameInstall>();
            if (string.IsNullOrWhiteSpace(RegistryConfig.CustomGameInstalls))
                return installs;

            List<CustomGameEntry> entries;
            try
            {
                entries = JsonConvert.DeserializeObject<List<CustomGameEntry>>(RegistryConfig.CustomGameInstalls);
            }
            catch
            {
                return installs;
            }

            if (entries == null)
                return installs;

            foreach (var entry in entries)
            {
                if (TryCreateFromPath(entry.DisplayName, entry.Path, out var install, out _))
                    installs.Add(install);
            }

            return installs;
        }

        public static bool TryAddCustomGameInstall(string displayName, string path, out GameInstall install, out string errorMessage)
        {
            install = null;
            errorMessage = null;

            if (!TryCreateFromPath(displayName, path, out install, out errorMessage))
                return false;

            var entries = new List<CustomGameEntry>();
            if (!string.IsNullOrWhiteSpace(RegistryConfig.CustomGameInstalls))
            {
                try
                {
                    entries = JsonConvert.DeserializeObject<List<CustomGameEntry>>(RegistryConfig.CustomGameInstalls)
                        ?? new List<CustomGameEntry>();
                }
                catch
                {
                    entries = new List<CustomGameEntry>();
                }
            }

            string normalizedInputPath = NormalizePath(path);
            if (entries.Any(e => string.Equals(NormalizePath(e.Path), normalizedInputPath, StringComparison.OrdinalIgnoreCase)))
            {
                errorMessage = Localise("CustomGameUIDuplicatePath", "A game with this path already exists.");
                return false;
            }

            entries.Add(new CustomGameEntry
            {
                DisplayName = displayName?.Trim(),
                Path = normalizedInputPath
            });

            RegistryConfig.CustomGameInstalls = JsonConvert.SerializeObject(entries);
            RegistryConfig.Save();
            return true;
        }

        public static bool TryCreateFromPath(string displayName, string path, out GameInstall install, out string errorMessage)
        {
            install = null;
            errorMessage = null;
            string normalizedPath = NormalizePath(path);

            if (string.IsNullOrWhiteSpace(normalizedPath))
            {
                errorMessage = Localise("CustomGameUIInvalidPath", "The selected game path is invalid.");
                return false;
            }

            if (File.Exists(normalizedPath))
            {
                string executable = Path.GetFileName(normalizedPath);
                string directory = Path.GetDirectoryName(normalizedPath);
                var detectedGame = Games.GetSupportedGames()
                    .FirstOrDefault(g => string.Equals(g.ExecutableName, executable, StringComparison.OrdinalIgnoreCase));

                if (detectedGame != null)
                {
                    install = new GameInstall(detectedGame, directory, GameLauncher.None);
                }
                else
                {
                    install = new GameInstall(new Game
                    {
                        IsCustom = true,
                        GameName = string.IsNullOrWhiteSpace(displayName)
                            ? Path.GetFileNameWithoutExtension(executable)
                            : displayName.Trim(),
                        ExecutableName = executable
                    }, directory, GameLauncher.None, normalizedPath);
                }

                return true;
            }

            if (Directory.Exists(normalizedPath))
            {
                var detectedInstalls = Games.GetSupportedGames()
                    .Select(game => new { game, fullPath = Path.Combine(normalizedPath, game.ExecutableName) })
                    .Where(x => File.Exists(x.fullPath))
                    .ToList();

                if (detectedInstalls.Count == 1)
                {
                    install = new GameInstall(detectedInstalls[0].game, normalizedPath, GameLauncher.None);
                    return true;
                }

                errorMessage = Localise("CustomGameUINeedsExecutable", "Select an executable file for custom games that cannot be matched safely.");
                return false;
            }

            errorMessage = Localise("CustomGameUIPathNotFound", "The selected game path does not exist.");
            return false;
        }

        private static string NormalizePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return string.Empty;

            var normalized = path.Trim().Trim('"').Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            try
            {
                normalized = Path.GetFullPath(normalized);
            }
            catch
            {
                return string.Empty;
            }

            return normalized.TrimEnd(Path.DirectorySeparatorChar);
        }

        public override string ToString() => Localise("Game" + BaseGame.GameName, BaseGame.GameName);
    }

    public class CustomGameEntry
    {
        public string DisplayName { get; set; }
        public string Path { get; set; }
    }

    public enum GameLauncher
    {
        None,
        Steam,
        Epic,
        Heroic
    }

    public class CodeLoaderInfo
    {
        public Version LoaderVersion { get; set; }
        public Version MinCodeVersion { get; set; }
        public Version MaxCodeVersion { get; set; }

        public CodeLoaderInfo(Version loader)
        {
            LoaderVersion = loader;
        }

        public CodeLoaderInfo(Version loader, Version minCode) : this(loader)
        {
            MinCodeVersion = minCode;
        }

        public CodeLoaderInfo(Version loader, Version minCode, Version maxCode) : this(loader, minCode)
        {
            MaxCodeVersion = maxCode;
        }
    }
}

# TowerDefenseV0

TowerDefenseV0 is a Unity 2021.3 project that implements the foundations of a classic tower defense game. It provides reusable systems for persisting player progress, configuring enemy waves, spawning towers, and handling win/loss conditions so you can focus on extending the gameplay and content.

## Features

- **Centralised game flow management.** `GameManager` tracks coins, score, energy, level timers, and enemy spawners while updating the HUD and determining win/lose states before returning to the main menu.【F:Assets/Scripts/TowerDefense/GameManager.cs†L10-L188】
- **Persistent player state.** `GameState` keeps coins, score, unlocked towers, and the active level across scene loads by using a `DontDestroyOnLoad` singleton pattern.【F:Assets/Scripts/TowerDefense/GameState.cs†L9-L90】
- **Configurable level data.** Each level is described by a `LevelData` ScriptableObject containing energy, starting coins, timer limits, and a list of enemy wave definitions.【F:Assets/Scripts/TowerDefense/Data/LevelData.cs†L7-L46】
- **Tower definitions.** Tower behaviour is driven by `TowerData` ScriptableObjects so designers can tune damage, fire rate, range, and upgrade costs without code changes.【F:Assets/Scripts/TowerDefense/Data/TowerData.cs†L3-L23】
- **Enemy wave spawning.** The reusable `Spawner` component instantiates or reuses enemy prefabs at configured intervals and exposes events so other systems can react when a new enemy appears.【F:Assets/Scripts/TowerDefense/Utilities/Spawner.cs†L8-L97】
- **Asynchronous scene transitions.** `SceneLoader` loads scenes asynchronously, keeping the loader alive across scene changes via another singleton component.【F:Assets/Scripts/TowerDefense/Utilities/SceneLoader.cs†L7-L52】

## Project structure

```text
Assets/
├── Scenes/               # Splash screen, main menu, and three playable levels
├── Scripts/              # Core gameplay, towers, enemies, utilities, and data definitions
├── Prefabs/              # Prefabricated towers, enemies, and gameplay elements
└── Objects/, UI/, etc.   # Supporting art and interface content
```

The `Scenes` folder includes `SplashScreen`, `MainMenu`, and three level scenes (`Level1`, `Level2`, and `Level3`) that demonstrate how to wire the systems together.【7ef75d†L1-L3】

## Getting started

1. **Install Unity 2021.3.27f1.** The project was authored with this LTS editor version; using the same release avoids upgrade prompts and import issues.【F:ProjectSettings/ProjectVersion.txt†L1-L2】
2. **Clone or download the repository.** Place it somewhere accessible to your Unity projects workspace.
3. **Open the project in Unity Hub.** Add the folder to Hub, select the 2021.3.27f1 editor, and open it.
4. **Import TextMesh Pro essentials (first launch only).** The project depends on the built-in `com.unity.textmeshpro` package, which Unity will prompt you to import the default resources for.【F:Packages/manifest.json†L1-L39】
5. **Set the startup scene.** Use the `SplashScreen` or `MainMenu` scene as your entry point depending on your flow.
6. **Enter Play Mode.** Press the Play button in the Unity Editor to test the tower defense loop.

## Extending the game

- **Add new levels:** Duplicate a `LevelData` asset, adjust the enemy wave list (`EnemySpawnData`) and link it to a new scene that references the asset in the `GameState` level list.【F:Assets/Scripts/TowerDefense/Data/LevelData.cs†L7-L46】【F:Assets/Scripts/TowerDefense/Enemy/EnemyDataScructure.cs†L9-L15】
- **Create new towers:** Create a `TowerData` asset, then assign it to a tower prefab that uses one of the tower scripts in `Assets/Scripts/TowerDefense/Tower/`. Tune the fire rate, damage, and upgrade costs in the inspector.【F:Assets/Scripts/TowerDefense/Data/TowerData.cs†L3-L23】
- **Hook into enemy spawns:** Subscribe to `Spawner.OnSpawned` to attach behaviours such as pathfinding or UI indicators when enemies are created.【F:Assets/Scripts/TowerDefense/Utilities/Spawner.cs†L8-L97】
- **Persist more data:** Extend `GameState` to store additional meta-progression like achievements or difficulty settings, then update `GameStateData` to serialize the new fields.【F:Assets/Scripts/TowerDefense/GameState.cs†L9-L90】

## Building

1. Open **File ▸ Build Settings** in Unity.
2. Add the scenes you want in the build order (e.g., `SplashScreen`, `MainMenu`, levels).
3. Choose your target platform and click **Build** or **Build and Run**.

With these systems in place, TowerDefenseV0 serves as a solid foundation for experimenting with new towers, enemies, maps, and progression loops.

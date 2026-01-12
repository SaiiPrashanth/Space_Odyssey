# Space Odyssey

![Gameplay](Screenshots/SpaceOdyssey_extra.gif)

**Space Odyssey** is a 3D arcade space shooter developed in **Unity**.

## Gameplay

Pilot a starship through deep space, blasting enemies and dodging obstacles. The game features a "rail-shooter" style movement system where the ship is confined to a flight corridor but has full freedom to dodge and aim within that window.

## Features

- **Dynamic Flight Physics**: Ship rotation (Pitch, Yaw, Roll) reacts fluidly to input and screen position.
- **Spaceship Variety**: Features a diverse fleet of player and enemy starships.
- **Combat System**: Particle-based laser cannons to destroy enemies.

## Controls

- **WASD / Arrows**: Move Ship (Up, Down, Left, Right).
- **Space / Mouse Click**: Fire Lasers.

## Project Structure

- `Assets/Scripts/SpaceShipController.cs`: Handles player input, banking/rolling physics, and weapon firing.
- `Assets/Scripts/EnemyUnit.cs`: Logic for enemy behaviors and damage handling.
- `Assets/Scripts/GameScoreManager.cs`: UI and data management for player score.

## Script Reference

### Player
- **`SpaceShipController.cs`**: The core flight model. Calculates position based on input (clamped to screen limits) and procedurally animates the ship's rotation (banking) for a dynamic feel. Also handles weapon firing.
- **`ShipCollisionManager.cs`**: Detects impacts with enemies or obstacles, triggering damage or game over states.

### Enemies & World
- **`EnemyUnit.cs`**: Controls enemy behavior (movement paths, firing) and health management.
- **`AutoCleanup.cs`**: A utility script that automatically destroys temporary objects (like laser bolts or explosion VFX) after a set duration to maintain performance.
- **`GameScoreManager.cs`**: Tracks the player's score and updates the UI.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
Copyright (c) 2026 ARGUS
# A Platform Game Inspired by Super Mario Bros for NES
[Leer en español](./README_es.md)

This document provides a detailed description of various C# scripts used in a Unity project. Each script serves a specific purpose that contributes to the overall functionality of the game.
- You can try the game directly in WebGL [here](http://ethannavarro.site/juegos/unplataformas/index.html)
- And here you can see a demonstration video of how it works [Youtube](https://www.youtube.com/watch?v=GJe659JDDjU&t=1s)

## Scripts

### HealthSystem.cs
- **Description**: Manages the health system of characters or enemies.
- **Key Functions**:
  - `TakeDamage(int damage)`: Applies damage to the entity.
  - `Heal(int amount)`: Heals the entity.
  - Methods for checking if the entity is alive or dead.

### SoundManager.cs
- **Description**: Responsible for sound management in the game.
- **Key Functions**:
  - Play, pause, and stop sounds.
  - Control of sound effects and background music.

### EnemyBehaviour.cs
- **Description**: Controls the behavior of enemies.
- **Key Functions**:
  - Logic for movement and player detection.
  - Execution of specific actions like attacking.

### EnemyHealth.cs
- **Description**: Manages the health of enemies.
- **Key Functions**:
  - Receive damage.
  - Check the life or death status of the enemy.

### UIData.cs
- **Description**: Handles the user interface and its data.
- **Key Functions**:
  - Control of visual elements like player health and scores.

### PlayerAnimations.cs
- **Description**: Manages the player's animations.
- **Key Functions**:
  - Activate animations based on player actions (jump, run, etc.).

### PlayerCollisionDetection.cs
- **Description**: Detects collisions for the player.
- **Key Functions**:
  - Interaction with the game environment and other objects.

### CharacterController2D.cs
- **Description**: Controller for 2D characters.
- **Key Functions**:
  - Management of movement, physics, and 2D interactions.

### EnemyAnimations.cs
- **Description**: Controls the animations of enemies.
- **Key Functions**:
  - Execution of animations based on the state and actions of the enemy.

### IAnimations.cs
- **Description**: Interface for implementing animations.
- **Key Functions**:
  - Defines common methods for animations (jump, death, damage, etc.).

### CoinScript.cs
- **Description**: Responsible for the movement of coins.

### GameManager.cs
- **Description**: Script with a static instance so that other scripts can access it directly.
- **Key Functions**:
  - Defines the gameover method if the player dies, showing one screen and if wins another.

### Mushroom
- **Description**: Used for the movement of the super mushroom.
- **Key Functions**:
  - Jumps upwards when appearing and then moves in a random direction.

### EnemyHealth.cs
- **Description**: Manages the life of enemies, they die when stomped.

### PlayerHealth.cs
- **Description**: Similar to the enemy health management script, but this one has the option to increase the life of the character.
- **Key Functions**:
  - Increases the size of the main character when picking a mushroom.
  - Manages calls to sound functions when taking hits and dying.

## Packages and Tools Used

Below are the packages and tools used in this Unity project:

### Player Camera
- **Cinemachine**: Used for the player's camera, allowing more dynamic and flexible management of cameras in the game. 
  - Official documentation: [Cinemachine](https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/index.html)

### Level Design
- **Tiles - 2D Pixel Art Platformer Biome American Forest**: This package has been the basis for the design of tiles in the game, with modifications to include special blocks Mario-style.
  - Package link: [2D Pixel Art Platformer Biome American Forest](https://assetstore.unity.com/packages/p/2d-pixel-art-platformer-biome-american-forest-255694)
  - ![Image of Tiles](https://assetstorev1-prd-cdn.unity3d.com/key-image/f7934ebb-d577-4a7d-8e81-62651e669484.webp)

### Enemies
- **Enemy Sprite and Animations**: Based on the same tile package, with modifications in the animator to fit the specific needs of the project.
  - Package link: [2D Pixel Art Platformer Biome American Forest](https://assetstore.unity.com/packages/p/2d-pixel-art-platformer-biome-american-forest-255694)
  - ![Image of Enemy](https://assetstorev1-prd-cdn.unity3d.com/key-image/8757df60-3816-4a96-b47a-710be9843d72.webp)

### Main Character
- **Hero Knight - Pixel Art**: The sprite and animations of the main character come from this package. The animator has been customized to fit the project.
  - Package link: [Hero Knight - Pixel Art](https://assetstore.unity.com/packages/2d/characters/hero-knight-pixel-art-165188)
  - ![Image of Main Character](https://assetstorev1-prd-cdn.unity3d.com/key-image/3fb94689-c52f-4e43-82af-a20f5524fecb.webp)

### Sound Effects
- **Game Sound Effects Package**: The sound effects and music are from the following Unity asset store package:
  - [Package link](https://assetstore.unity.com/packages/audio/sound-fx/cute-ui-interact-sound-effects-pack-239488)

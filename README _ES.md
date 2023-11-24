# Un juego de plataformas inspirado en Super Mario Bros para NES
[Read in English](./README.md)

Este documento proporciona una descripción detallada de varios scripts C# utilizados en un proyecto de Unity. Cada script tiene un propósito específico que contribuye a la funcionalidad general del juego.
- El juego lo podeis probar directamente en WebGL [aquí](http://ethannavarro.site/juegos/unplataformas/index.html)
- Y aqui podeis ver un video demostración de como funciona [Youtube](https://www.youtube.com/watch?v=GJe659JDDjU&t=1s)

## Scripts

### HealthSystem.cs
- **Descripción**: Gestiona el sistema de salud de personajes o enemigos.
- **Funciones clave**:
  - `TakeDamage(int damage)`: Aplica daño a la entidad.
  - `Heal(int amount)`: Cura a la entidad.
  - Métodos para verificar si la entidad está viva o muerta.

### SoundManager.cs
- **Descripción**: Responsable de la gestión de sonidos en el juego.
- **Funciones clave**:
  - Reproducir, pausar y detener sonidos.
  - Control de efectos de sonido y música de fondo.

### EnemyBehaviour.cs
- **Descripción**: Controla el comportamiento de los enemigos.
- **Funciones clave**:
  - Lógica para movimiento y detección del jugador.
  - Ejecución de acciones específicas como atacar.

### EnemyHealth.cs
- **Descripción**: Gestiona la salud de los enemigos.
- **Funciones clave**:
  - Recibir daño.
  - Verificar el estado de vida o muerte del enemigo.

### UIData.cs
- **Descripción**: Maneja la interfaz de usuario y sus datos.
- **Funciones clave**:
  - Control de elementos visuales como la salud del jugador y puntuaciones.

### PlayerAnimations.cs
- **Descripción**: Gestiona las animaciones del jugador.
- **Funciones clave**:
  - Activar animaciones basadas en acciones del jugador (saltar, correr, etc.).

### PlayerCollisionDetection.cs
- **Descripción**: Detecta colisiones para el jugador.
- **Funciones clave**:
  - Interacción con el entorno del juego y otros objetos.

### CharacterController2D.cs
- **Descripción**: Controlador para personajes en 2D.
- **Funciones clave**:
  - Gestión del movimiento, física e interacciones en 2D.

### EnemyAnimations.cs
- **Descripción**: Controla las animaciones de los enemigos.
- **Funciones clave**:
  - Ejecución de animaciones basadas en el estado y acciones del enemigo.

### IAnimations.cs
- **Descripción**: Interfaz para la implementación de animaciones.
- **Funciones clave**:
  - Define métodos comunes para animaciones (salto, muerte, daño, etc.).

### CoinScipt.cs
- **Descripcion**: Se encarga del movimiento de las monedas

### GameManager.cs
- **Descripción**: Script con instancia estatica para que los demas scripts puedan accedere a el directamente.
- **Funciones clave**:
    - Define el metodo de gameover si el jugador a muerto muestra una pantalla y si gana otra.

### Mushroom
- **Descripción**: Se usa para el movimiento de la superseta
- **Funciones clave**:
    - Al aparecer da un salto hacia arriba y luego se mueve en una direccion aleatoria

### EnemyHealth.cs
- **Descripción**: Gestiona la vida de los enemigos, al ser pisados muere.

### PlayerHealth.cs
- **Descripción**: Parecido al script de gestion de vida del enemigo, pero este tiene la opcion de aumentar de vida al personaje
- **Funciones clave**:
    - Se aumenta de tamaño al personaje principal cuando coge una seta
    - Gestiona las llamadas a funciones de sonidos al recibir golpes y morir

## Paquetes y Herramientas Utilizados

A continuación, se detallan los paquetes y herramientas utilizados en este proyecto de Unity:

### Cámara del Jugador
- **Cinemachine**: Utilizado para la cámara del jugador, permitiendo una gestión más dinámica y flexible de las cámaras en el juego. 
  - Documentación oficial: [Cinemachine](https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/index.html)

### Diseño de Niveles
- **Tiles - 2D Pixel Art Platformer Biome American Forest**: Este paquete ha sido la base para el diseño de los tiles en el juego, con modificaciones para incluir bloques especiales al estilo Mario.
  - Enlace al paquete: [2D Pixel Art Platformer Biome American Forest](https://assetstore.unity.com/packages/p/2d-pixel-art-platformer-biome-american-forest-255694)
  - ![Imagen de Tiles](https://assetstorev1-prd-cdn.unity3d.com/key-image/f7934ebb-d577-4a7d-8e81-62651e669484.webp)

### Enemigos
- **Sprite y Animaciones del Enemigo**: Basados en el mismo paquete de tiles, con modificaciones en el animator para ajustarlo a las necesidades específicas del proyecto.
  - Enlace al paquete: [2D Pixel Art Platformer Biome American Forest](https://assetstore.unity.com/packages/p/2d-pixel-art-platformer-biome-american-forest-255694)
  - ![Imagen de Enemigo](https://assetstorev1-prd-cdn.unity3d.com/key-image/8757df60-3816-4a96-b47a-710be9843d72.webp)

### Personaje Principal
- **Hero Knight - Pixel Art**: El sprite y las animaciones del personaje principal provienen de este paquete. El animator ha sido personalizado para adaptarse al proyecto
  - Enlace al paquete: [Hero Knight - Pixel Art](https://assetstore.unity.com/packages/2d/characters/hero-knight-pixel-art-165188)
  - ![Imagen del Personaje Principal](https://assetstorev1-prd-cdn.unity3d.com/key-image/3fb94689-c52f-4e43-82af-a20f5524fecb.webp)

### Efectos de sonido
- **Paquete de sonidos para juegos**: Los efectos de sonidos y musica son del siguiente paquete de la asset store de unity:
    - [Enlace al paquete](https://assetstore.unity.com/packages/audio/sound-fx/cute-ui-interact-sound-effects-pack-239488)
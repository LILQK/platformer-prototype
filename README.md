# Documentación de Scripts para Unity

Este documento proporciona una descripción detallada de varios scripts C# utilizados en un proyecto de Unity. Cada script tiene un propósito específico que contribuye a la funcionalidad general del juego.

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


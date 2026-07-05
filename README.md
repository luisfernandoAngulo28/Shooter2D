# Shooter2D

Juego de plataformas 2D hecho en Unity donde el jugador se mueve, salta, dispara balas y lanza granadas para eliminar enemigos que lo persiguen, hasta llegar a la bandera de meta.

**Materia:** Programación Gráfica
**Docente:** Ing. Kenji Kawaida Villegas

## Requisitos

- Unity **6000.3.19f1** (Unity 6) o superior.
- Paquete **Input System** (usado para el control del jugador).
- Paquete **TextMeshPro** (usado para la UI de vida y el mensaje de victoria).

## Cómo abrir el proyecto

1. Clona el repositorio.
2. Abre Unity Hub > Add > selecciona la carpeta del proyecto.
3. Abre con la versión de editor indicada arriba (o una compatible).
4. Carga la escena `Assets/Scenes/SampleScene.unity` y dale Play.

## Controles

| Acción              | Tecla           |
|---------------------|-----------------|
| Moverse izquierda   | A / ←           |
| Moverse derecha     | D / →           |
| Saltar              | Espacio         |
| Disparar bala       | X               |
| Lanzar granada      | Z               |

## Mecánicas principales

- **Movimiento y salto**: control por `Rigidbody2D` con detección de suelo mediante `OverlapCircle`.
- **Disparo**: instancia balas (`Bala.cs`) con cadencia limitada por cooldown.
- **Granadas**: se lanzan con fuerza física y explotan tras un tiempo, dañando enemigos en un radio (`Granada.cs`).
- **Vida**: sistema compartido entre jugador y enemigos (`Vida.cs`). El jugador reinicia el nivel al morir; los enemigos son destruidos.
- **Enemigos**: persiguen al jugador dentro de un radio de detección y le hacen daño por contacto (`EnemigoIA.cs`).
- **Cámara**: sigue al jugador suavemente (`CamaraSeguir.cs`).
- **Meta y victoria**: al tocar la bandera se dispara `GestorNivel.NivelCompletado()`, que muestra un cartel y congela el juego (`Meta.cs`, `GestorNivel.cs`).
- **HUD**: muestra la vida actual del jugador en pantalla con TextMeshPro (`UIVida.cs`).

## Estructura del proyecto

```
Assets/
  Prefabs/        Prefabs del juego (p. ej. Enemigo)
  Scenes/         Escenas (SampleScene)
  Scripts/        Scripts de gameplay (jugador, enemigos, vida, meta, UI, cámara)
  TextMesh Pro/   Recursos del paquete TMP
ProjectSettings/  Configuración del proyecto (tags, física, etc.)
```

## Estado del proyecto

Proyecto educativo/en desarrollo. Próximos pasos posibles: más tipos de enemigos, power-ups, sonido y varios niveles.

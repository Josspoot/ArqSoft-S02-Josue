# Juego de la Viborita (Snake)

## Descripción del Proyecto
Este proyecto es una versión moderna del legendario juego **Snake** (conocido localmente como "Viborita"), adaptado totalmente para ejecutarse en la consola de comandos, el juego se basa en controlar una serpiente en un entorno cerrado, recolectando comida para crecer y aumentar su puntuación.

## Cómo se Juega
1.  **Movimiento:** Utiliza las **teclas de flecha** del teclado para dirigir a la serpiente en las cuatro direcciones cardinales.
2.  **Objetivo:** Debes comer los símbolos de comida (`*`) que aparecen aleatoriamente en el tablero. Cada vez que comes, tu puntuación aumenta y la serpiente crece.
3.  **Puntuación:** Los puntos actuales se muestran en la parte superior del tablero en tiempo real.
4.  **Derrota:** El juego termina si la serpiente choca contra los bordes del tablero (marcados con `+`, `-`, `|`) o contra su propio cuerpo.
5.  **Salir:** Puedes presionar la tecla **Q** en cualquier momento para cerrar el juego.

## Vistazo al Juego

<table>
  <tr>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/9e449a53-9fbb-408f-8c1d-80ffa54a63b4" alt="Menú Principal" width="250"/><br/>
      <sub><b>Menú Principal</b></sub>
    </td>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/ed45b715-99c4-4c4c-bc84-4ff84fc51742" alt="Selección de Categoría" width="250"/><br/>
      <sub><b>Selección de Categoría</b></sub>
    </td>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/4331a540-d9ce-4769-b9c7-1858928a0023" alt="Tablero de Juego" width="250"/><br/>
      <sub><b>Partida en Curso</b></sub>
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/04496cdc-486b-43a4-b933-344baeef5101" alt="Fin del Juego" width="250"/><br/>
      <sub><b>Progreso del Ahorcado</b></sub>
    </td>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/7fbcf930-6a83-404f-be23-e389dd463325" alt="Resultado" width="250"/><br/>
      <sub><b>Resultado Final</b></sub>
    </td>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/6c87103d-852c-43df-9c68-f7ea4c5aeb4f" alt="Viborita fail PIPIPI" width="250"/><br/>
      <sub><b>Viborita fail PIPIPI</b></sub>
    </td>
  </tr>
  <tr>
    <td align="center" colspan="3">
      <img src="https://github.com/user-attachments/assets/328d4f5a-ac85-4e7b-ad64-2711beb01c52" alt="Viborita fail Pero no tanto" width="250"/><br/>
      <sub><b>Viborita fail Pero no tanto</b></sub>
    </td>
  </tr>
</table>

## Tecnologías Usadas
* **Lenguaje:** C#
* **Plataforma:** .NET (Versión 10.0)
* **Interfaz:** Consola de comandos con manipulación de posición del cursor (`Console.SetCursorPosition`) para una renderización fluida sin parpadeos.

---
**Cláusula de uso de IA:**
Este proyecto utiliza Inteligencia Artificial para el diseño estético de la interfaz de consola, específicamente en la implementación de esquemas de color dinámicos (`Console.ForegroundColor`) y la disposición visual de los elementos para mejorar la experiencia del usuario.

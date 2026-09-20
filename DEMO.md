# Demo TFU UT3 (Grupo 3) — paso a paso

## Antes de arrancar

1. Tener Docker Desktop instalado y abierto.
2. Abrir una terminal y pararse en la carpeta del repo:
   ```bash
   cd UT3-TFUGrupo3
   ```
3. Correr y dejar esta terminal abierta (tarda unos minutos la primera vez):
   ```bash
   docker compose up --build
   ```
4. Abrir una **segunda terminal** y pararse en la misma carpeta. Todos los
   comandos de acá en adelante van en esta segunda terminal.

## 1. Componentes e interfaces

1. Correr:
   ```bash
   ./scripts/demo-01-componentes.sh
   ```
2. Va a registrar un usuario, crear un proyecto, crear una tarea, asignarla y
   listar las tareas del proyecto — todo pasando por el ApiGateway.
3. Correr también:
   ```bash
   docker compose ps
   ```
   Tiene que mostrar 4 componentes (`apigateway`, `usermanager`,
   `projectmanager`, `taskmanager`) más 3 bases, todos en estado `Up`.
4. Cada paso del script habla con un componente distinto: crear proyecto hace
   que ProjectManager le pregunte a UserManager si el dueño existe; crear
   tarea hace que TaskManager le pregunte a ProjectManager y a UserManager.

## 2. Escalabilidad horizontal

1. Correr:
   ```bash
   ./scripts/demo-02-escalabilidad.sh
   ```
2. Escala TaskManager a 3 réplicas y hace 20 pedidos seguidos al mismo
   endpoint.
3. Al final imprime una lista agrupada por hostname (header `X-Served-By`).
   Si aparece más de un hostname, distintas réplicas respondieron los
   pedidos.
4. Si aparece un solo hostname, correr el script de nuevo (el reparto entre
   réplicas es automático pero con pocos pedidos puede no notarse).

## 3. Contenedores

1. Correr:
   ```bash
   docker compose ps
   ```
   y mostrar que cada componente corre en su propio contenedor.
2. Abrir el archivo `docker-compose.yml` y mostrar que cada componente tiene
   su propio contenedor y su propia base Postgres.
3. Abrir cualquier `Dockerfile` (por ejemplo `src/TaskManager/Dockerfile`) y
   mostrar las dos etapas: build (con el SDK) y runtime (liviano, solo
   ASP.NET).

## 4. ACID

1. Correr:
   ```bash
   ./scripts/demo-03-acid.sh
   ```
2. Intenta crear una tarea y asignarla a un usuario que no existe, en una
   sola transacción.
3. La operación falla con error 409, y el script confirma que la cantidad de
   tareas del proyecto no cambió — no quedó nada a medio crear (rollback).

## 5. Servicios sin estado

1. Correr:
   ```bash
   ./scripts/demo-04-sin-estado.sh
   ```
2. Reutiliza el token generado en el paso 1 (no vuelve a loguearse), escala
   ProjectManager a 3 réplicas y hace 10 pedidos con ese mismo token.
3. Todos los pedidos responden 200, aunque esas réplicas nuevas nunca vieron
   el login original.
4. Al final, un pedido sin token da 401 en cualquier réplica.

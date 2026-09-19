#!/usr/bin/env bash
# ─────────────────────────────────────────────────────────────────────────────
# DEMO 1 — Componentes e interfaces (API REST end-to-end a través del gateway)
#
# Recorre los 3 componentes de negocio pasando SIEMPRE por el ApiGateway:
#   registrar usuario → login → crear proyecto → crear tarea → asignar → listar.
# ─────────────────────────────────────────────────────────────────────────────
set -euo pipefail
GW="${GW:-http://localhost:8080}"

echo "== 1. Registrar usuario (POST /auth/register) =="
TOKEN=$(curl -s -X POST "$GW/auth/register" \
  -H 'Content-Type: application/json' \
  -d '{"name":"Euge","email":"euge@ucu.edu.uy","password":"secret123"}' \
  | tee /dev/stderr | sed -n 's/.*"token":"\([^"]*\)".*/\1/p')

# Si register no devolviera token, descomentar el login:
# TOKEN=$(curl -s -X POST "$GW/auth/login" -H 'Content-Type: application/json' \
#   -d '{"email":"euge@ucu.edu.uy","password":"secret123"}' \
#   | sed -n 's/.*"token":"\([^"]*\)".*/\1/p')

AUTH=(-H "Authorization: Bearer $TOKEN")
echo; echo "Token: $TOKEN"; echo

echo "== 2. Ver mi usuario (GET /users) =="
curl -s "${AUTH[@]}" "$GW/users"; echo

# TODO: capturar el userId y el projectId reales de las respuestas (con jq).
echo "== 3. Crear proyecto (POST /projects) =="
curl -s -X POST "${AUTH[@]}" -H 'Content-Type: application/json' \
  -d '{"ownerId":"<USER_ID>","name":"TFU UT3"}' "$GW/projects"; echo

echo "== 4. Crear tarea (POST /tasks) =="
curl -s -X POST "${AUTH[@]}" -H 'Content-Type: application/json' \
  -d '{"projectId":"<PROJECT_ID>","title":"Escribir el informe"}' "$GW/tasks"; echo

echo "== 5. Asignar tarea (POST /tasks/{id}/assign) =="
curl -s -X POST "${AUTH[@]}" -H 'Content-Type: application/json' \
  -d '{"userId":"<USER_ID>"}' "$GW/tasks/<TASK_ID>/assign"; echo

echo "== 6. Listar tareas del proyecto (GET /tasks?projectId=) =="
curl -s "${AUTH[@]}" "$GW/tasks?projectId=<PROJECT_ID>"; echo

#!/usr/bin/env bash
# ─────────────────────────────────────────────────────────────────────────────
# DEMO 3 — ACID (atomicidad con transacciones)
#
# Ejemplo del enunciado: "crear una tarea y asignarla" debe ser atómico.
# Se invoca crear+asignar con un usuario INEXISTENTE: la validación falla, la
# transacción hace rollback y la tarea NO queda persistida (todo o nada).
# ─────────────────────────────────────────────────────────────────────────────
set -euo pipefail
GW="${GW:-http://localhost:8080}"
AUTH=(-H "Authorization: Bearer ${TOKEN:-<TOKEN>}")

echo "== Tareas del proyecto ANTES =="
curl -s "${AUTH[@]}" "$GW/tasks?projectId=<PROJECT_ID>"; echo

echo "== crear+asignar con userId inexistente (debe fallar y NO crear la tarea) =="
curl -s -o /dev/null -w "HTTP %{http_code}\n" -X POST "${AUTH[@]}" \
  -H 'Content-Type: application/json' \
  -d '{"projectId":"<PROJECT_ID>","title":"Tarea que no debe quedar","userId":"00000000-0000-0000-0000-000000000000"}' \
  "$GW/tasks/create-and-assign"

echo "== Tareas del proyecto DESPUÉS (debe ser igual que ANTES → rollback OK) =="
curl -s "${AUTH[@]}" "$GW/tasks?projectId=<PROJECT_ID>"; echo

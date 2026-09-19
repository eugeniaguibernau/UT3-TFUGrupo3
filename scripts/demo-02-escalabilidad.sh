#!/usr/bin/env bash
# ─────────────────────────────────────────────────────────────────────────────
# DEMO 2 — Escalabilidad horizontal
#
# Levanta varias réplicas de TaskManager y muestra cómo el gateway (vía DNS de
# Docker) reparte las requests entre ellas.
#
# Requisito de implementación: que TaskManager devuelva su hostname en cada
# respuesta (p. ej. header "X-Served-By: $HOSTNAME") para poder distinguir réplicas.
# ─────────────────────────────────────────────────────────────────────────────
set -euo pipefail
GW="${GW:-http://localhost:8080}"

echo "== Escalando TaskManager a 3 réplicas =="
docker compose up -d --scale taskmanager=3
docker compose ps taskmanager

echo; echo "== 20 requests seguidas: ver qué réplica responde cada una =="
for i in $(seq 1 20); do
  curl -s -o /dev/null -D - "$GW/tasks?projectId=<PROJECT_ID>" \
    | grep -i '^X-Served-By:' || echo "(agregar header X-Served-By en TaskManager)"
done | sort | uniq -c

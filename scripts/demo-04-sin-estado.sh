#!/usr/bin/env bash
# ─────────────────────────────────────────────────────────────────────────────
# DEMO 4 — Servicios sin estado (JWT)
#
# El token se emite una vez y CUALQUIER réplica lo valida localmente con el
# secreto compartido, sin sesión en memoria. Escalamos, repetimos la MISMA
# request con el MISMO token y todas las réplicas la aceptan.
# ─────────────────────────────────────────────────────────────────────────────
set -euo pipefail
GW="${GW:-http://localhost:8080}"

echo "== Login: obtener un token =="
TOKEN=$(curl -s -X POST "$GW/auth/login" -H 'Content-Type: application/json' \
  -d '{"email":"euge@ucu.edu.uy","password":"secret123"}' \
  | sed -n 's/.*"token":"\([^"]*\)".*/\1/p')
echo "Token: $TOKEN"; echo

echo "== Escalar ProjectManager y pegarle con el mismo token 10 veces =="
docker compose up -d --scale projectmanager=3
for i in $(seq 1 10); do
  curl -s -o /dev/null -w "réplica respondió HTTP %{http_code}\n" \
    -H "Authorization: Bearer $TOKEN" "$GW/projects?userId=<USER_ID>"
done

echo; echo "Sin token → debe dar 401 en cualquier réplica:"
curl -s -o /dev/null -w "HTTP %{http_code}\n" "$GW/projects?userId=<USER_ID>"

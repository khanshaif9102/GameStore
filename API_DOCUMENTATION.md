# API Documentation - GameStore REST API

Base URL: `http://localhost:5290`

## Games Endpoints

### 1. Get All Games
**Endpoint:** `GET /games`

**Request:**
```http
GET http://localhost:5290/games HTTP/1.1
```

**Response (200 OK):**
```json
[
  {
	"id": 1,
	"name": "Elden Ring",
	"genre": "RPG",
	"price": 59.99,
	"releaseDate": "2022-02-25"
  },
  {
	"id": 2,
	"name": "Cyberpunk 2077",
	"genre": "Action",
	"price": 39.99,
	"releaseDate": "2020-12-10"
  }
]
```

**cURL:**
```bash
curl -X GET http://localhost:5290/games
```

---

### 2. Get Single Game by ID
**Endpoint:** `GET /games/{id}`

**Request:**
```http
GET http://localhost:5290/games/1 HTTP/1.1
```

**Response (200 OK):**
```json
{
  "id": 1,
  "name": "Elden Ring",
  "genreId": 3,
  "price": 59.99,
  "releaseDate": "2022-02-25"
}
```

**Response (404 Not Found):**
```json
null
```

**cURL:**
```bash
curl -X GET http://localhost:5290/games/1
```

---

### 3. Create New Game
**Endpoint:** `POST /games`

**Request:**
```http
POST http://localhost:5290/games HTTP/1.1
Content-Type: application/json

{
  "name": "Baldur's Gate 3",
  "genreId": 3,
  "price": 59.99,
  "releaseDate": "2023-08-03"
}
```

**Response (201 Created):**
```json
{
  "id": 5,
  "name": "Baldur's Gate 3",
  "genreId": 3,
  "price": 59.99,
  "releaseDate": "2023-08-03"
}
```

**Header:**
```
Location: http://localhost:5290/games/5
```

**cURL:**
```bash
curl -X POST http://localhost:5290/games \
  -H "Content-Type: application/json" \
  -d '{
	"name": "Baldur'\''s Gate 3",
	"genreId": 3,
	"price": 59.99,
	"releaseDate": "2023-08-03"
  }'
```

---

### 4. Update Game
**Endpoint:** `PUT /games/{id}`

**Request:**
```http
PUT http://localhost:5290/games/1 HTTP/1.1
Content-Type: application/json

{
  "name": "Elden Ring Updated",
  "genreId": 3,
  "price": 49.99,
  "releaseDate": "2022-02-25"
}
```

**Response (204 No Content):**
```
(empty body)
```

**Response (404 Not Found):**
```json
null
```

**cURL:**
```bash
curl -X PUT http://localhost:5290/games/1 \
  -H "Content-Type: application/json" \
  -d '{
	"name": "Elden Ring Updated",
	"genreId": 3,
	"price": 49.99,
	"releaseDate": "2022-02-25"
  }'
```

---

### 5. Delete Game
**Endpoint:** `DELETE /games/{id}`

**Request:**
```http
DELETE http://localhost:5290/games/1 HTTP/1.1
```

**Response (204 No Content):**
```
(empty body)
```

**cURL:**
```bash
curl -X DELETE http://localhost:5290/games/1
```

---

## Genres Endpoints

### 6. Get All Genres
**Endpoint:** `GET /genres`

**Request:**
```http
GET http://localhost:5290/genres HTTP/1.1
```

**Response (200 OK):**
```json
[
  {
	"id": 1,
	"name": "Action"
  },
  {
	"id": 2,
	"name": "Adventure"
  },
  {
	"id": 3,
	"name": "RPG"
  },
  {
	"id": 4,
	"name": "Strategy"
  },
  {
	"id": 5,
	"name": "Sports"
  }
]
```

**cURL:**
```bash
curl -X GET http://localhost:5290/genres
```

---

## Data Models

### GameSummaryDto (GET /games response)
```json
{
  "id": 1,
  "name": "string",
  "genre": "string",
  "price": 0.00,
  "releaseDate": "2023-01-15"
}
```

### GameDetailsDto (GET /games/{id} response)
```json
{
  "id": 1,
  "name": "string",
  "genreId": 1,
  "price": 0.00,
  "releaseDate": "2023-01-15"
}
```

### CreateGameDto (POST request body)
```json
{
  "name": "string",
  "genreId": 1,
  "price": 0.00,
  "releaseDate": "2023-01-15"
}
```

### UpdateGameDto (PUT request body)
```json
{
  "name": "string",
  "genreId": 1,
  "price": 0.00,
  "releaseDate": "2023-01-15"
}
```

### GenreDto (GET /genres response)
```json
{
  "id": 1,
  "name": "string"
}
```

---

## HTTP Status Codes

| Code | Meaning | Description |
|------|---------|-------------|
| 200 | OK | Request succeeded |
| 201 | Created | Resource created successfully |
| 204 | No Content | Request succeeded, no content to return |
| 400 | Bad Request | Invalid request format |
| 404 | Not Found | Resource not found |
| 500 | Server Error | Internal server error |

---

## Common Error Scenarios

### Missing Required Field
**Request:**
```json
{
  "name": "Game",
  "price": 59.99
  // Missing genreId and releaseDate
}
```

**Response (400 Bad Request):**
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
	"genreId": ["The genreId field is required."],
	"releaseDate": ["The releaseDate field is required."]
  }
}
```

### Invalid Genre ID
**Request:**
```json
{
  "name": "Game",
  "genreId": 999,
  "price": 59.99,
  "releaseDate": "2023-01-15"
}
```

**Response (400 Bad Request):**
No genre with ID 999 exists

### Game Not Found
**Request:**
```
GET /games/999
```

**Response (404 Not Found):**
```json
null
```

---

## Testing Examples

### Postman Collection
Import this into Postman:

```json
{
  "info": {
	"name": "GameStore API",
	"description": "GameStore CRUD API"
  },
  "item": [
	{
	  "name": "Get All Games",
	  "request": {
		"method": "GET",
		"url": "http://localhost:5290/games"
	  }
	},
	{
	  "name": "Create Game",
	  "request": {
		"method": "POST",
		"url": "http://localhost:5290/games",
		"header": [
		  {"key": "Content-Type", "value": "application/json"}
		],
		"body": {
		  "mode": "raw",
		  "raw": "{\"name\":\"Test\",\"genreId\":1,\"price\":9.99,\"releaseDate\":\"2023-01-01\"}"
		}
	  }
	}
  ]
}
```

### VS Code REST Client (.http files)
Create `test.http`:
```http
### Get all games
GET http://localhost:5290/games

### Create game
POST http://localhost:5290/games
Content-Type: application/json

{
  "name": "Test Game",
  "genreId": 1,
  "price": 9.99,
  "releaseDate": "2023-01-01"
}

### Update game
PUT http://localhost:5290/games/1
Content-Type: application/json

{
  "name": "Updated Game",
  "genreId": 2,
  "price": 19.99,
  "releaseDate": "2023-01-01"
}

### Delete game
DELETE http://localhost:5290/games/1

### Get all genres
GET http://localhost:5290/genres
```

---

## CORS Headers

The API accepts CORS requests from:
- Origin: http://localhost:4200
- Methods: GET, POST, PUT, DELETE, OPTIONS
- Headers: Content-Type, Authorization, etc.

---

## Rate Limiting

None implemented (add for production)

## Authentication

None implemented (add for production)

## Version

API Version: 1.0
Last Updated: June 2026

---

**Note:** All endpoints are available at http://localhost:5290 when the API is running.

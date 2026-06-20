# Testing Guide - GameStore CRUD Application

## Testing Checklist

### Backend API Testing (http://localhost:5290)

#### 1. Get All Games
```
GET http://localhost:5290/games
Expected: 200 OK, returns empty array []
```

#### 2. Get All Genres
```
GET http://localhost:5290/genres
Expected: 200 OK, returns empty array []
```

#### 3. Create a Game
```
POST http://localhost:5290/games
Content-Type: application/json

{
  "name": "Elden Ring",
  "genreId": 1,
  "price": 59.99,
  "releaseDate": "2022-02-25"
}
Expected: 201 Created, returns game with ID
```

#### 4. Get Single Game
```
GET http://localhost:5290/games/1
Expected: 200 OK, returns game details
```

#### 5. Update Game
```
PUT http://localhost:5290/games/1
Content-Type: application/json

{
  "name": "Elden Ring Updated",
  "genreId": 1,
  "price": 49.99,
  "releaseDate": "2022-02-25"
}
Expected: 204 No Content
```

#### 6. Delete Game
```
DELETE http://localhost:5290/games/1
Expected: 204 No Content
```

### Frontend UI Testing (http://localhost:4200)

#### 1. Page Load
- [ ] Page loads without errors
- [ ] "Games Library" heading visible
- [ ] "+ Add Game" button visible
- [ ] Table shows "No games found" message

#### 2. Create Game
- [ ] Click "+ Add Game" button
- [ ] Form appears with all fields
- [ ] Fill in: Name, Genre (select from dropdown), Price, Release Date
- [ ] Click "Create" button
- [ ] Game appears in table
- [ ] Success message displays

#### 3. View Games
- [ ] All game columns display correctly (ID, Name, Genre, Price, Date)
- [ ] Prices show with 2 decimal places
- [ ] Table updates in real-time

#### 4. Update Game
- [ ] Click "Edit" on any game
- [ ] Form populates with existing data
- [ ] Change any field
- [ ] Click "Update" button
- [ ] Table updates immediately
- [ ] Success message displays

#### 5. Delete Game
- [ ] Click "Delete" on any game
- [ ] Confirmation dialog appears
- [ ] Confirm deletion
- [ ] Game removed from table
- [ ] Success message displays

#### 6. Error Handling
- [ ] Try creating game without filling all fields
- [ ] Should show validation error
- [ ] Close form without saving
- [ ] Form clears and closes properly

#### 7. Responsive Design
- [ ] Resize browser to mobile width (< 768px)
- [ ] UI should adapt and remain usable
- [ ] Buttons stack properly
- [ ] Table remains readable

## API Testing Tools
- Postman: https://www.postman.com/
- VS Code REST Client: Use `games.http` file
- Thunder Client: VS Code extension
- curl command line

## Common Issues & Solutions

### Issue: Empty table on load
**Solution:** 
1. Check API is running on port 5290
2. Open browser console (F12) for errors
3. Check Network tab for failed requests

### Issue: Cannot add game
**Solution:**
1. Check all form fields are filled
2. Verify Genre is selected (not "Select a genre")
3. Check browser console for errors
4. Verify API endpoint returns 201 status

### Issue: Changes not appearing
**Solution:**
1. Refresh page (Ctrl+R)
2. Check browser DevTools console
3. Verify API response in Network tab
4. Restart Angular dev server

### Issue: CORS error
**Solution:**
1. Verify API CORS config in Program.cs
2. Check API is running
3. Clear browser cache
4. Check API URL in environment.ts

## Database Inspection

### SQLite Database File
Location: `GameStore.API/GameStore.db`

To inspect:
1. Download SQLite Browser: https://sqlitebrowser.org/
2. Open `GameStore.db`
3. View tables: Games, Genres, __EFMigrationsHistory

### Via Entity Framework
```bash
cd GameStore.API
dotnet ef database update
dotnet ef database drop
```

## Performance Testing

### Load Testing
- Create 100+ games and check performance
- Monitor API response times
- Check browser memory usage

### Data Validation
- Try invalid prices (negative, too large)
- Try invalid dates
- Try very long game names
- Try special characters

## Security Notes
- No authentication implemented (add for production)
- No input sanitization (add for production)
- CORS allows all methods (restrict for production)
- Database auto-created (use migrations in production)

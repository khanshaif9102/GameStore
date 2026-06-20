# 🚀 Quick Start Guide

## Prerequisites
- .NET 10 SDK installed
- Node.js 18+ with npm installed
- Visual Studio 2026 or VS Code

## ⚡ 5-Minute Setup

### Step 1: Start the API (Terminal 1)
```bash
cd GameStore.API
dotnet run
```
✅ API runs on http://localhost:5290

### Step 2: Start Angular App (Terminal 2)
```bash
cd gamestore-ui
npm install  # Only needed first time
npm start
```
✅ App runs on http://localhost:4200

### Step 3: Open Browser
Navigate to http://localhost:4200

## ✅ Verify Everything Works

### In the UI:
1. Page loads with "GameStore" heading
2. "+ Add Game" button is visible
3. Message shows "No games found"
4. Add a test game:
   - Click "+ Add Game"
   - Name: "Test Game"
   - Genre: Select any option
   - Price: 9.99
   - Date: Pick any date
   - Click "Create"
5. Table updates with new game
6. Success message appears
7. Edit/Delete buttons appear

### Via API (using REST Client or Postman):
```bash
# Get all games
curl http://localhost:5290/games

# Should return array of games
```

## 🎮 Basic Operations

### Add a Game
1. Click "+ Add Game"
2. Fill all fields
3. Click "Create"
4. Game appears in table

### Edit a Game
1. Click "Edit" on any game
2. Modify fields
3. Click "Update"
4. Changes appear immediately

### Delete a Game
1. Click "Delete" on any game
2. Confirm in dialog
3. Game removed from table

## 🐛 Troubleshooting

### API won't start
```bash
# Check if port is in use
# Try different port in launchSettings.json
# Or restart computer
```

### Angular app shows blank page
```bash
# Clear cache
npm cache clean --force

# Reinstall
rm -rf node_modules
npm install
npm start
```

### No games loading
- [ ] API running on port 5290?
- [ ] Check browser console (F12)
- [ ] Check Network tab for failed requests
- [ ] Verify environment.ts has correct URL

### Form doesn't submit
- [ ] Fill all fields?
- [ ] Genre selected (not placeholder)?
- [ ] Release date valid?
- [ ] Check console for errors

### CORS Error
- [ ] API running?
- [ ] Check Program.cs CORS config
- [ ] Verify client URL in CORS

## 📝 Example Test Data

Try creating these games:

| Name | Genre | Price | Date |
|------|-------|-------|------|
| Elden Ring | RPG | 59.99 | 2022-02-25 |
| Cyberpunk 2077 | Action | 39.99 | 2020-12-10 |
| Zelda | Adventure | 69.99 | 2023-05-12 |

## 🔗 URLs

| Service | URL | Port |
|---------|-----|------|
| API | http://localhost:5290 | 5290 |
| UI | http://localhost:4200 | 4200 |
| Database | GameStore.API/GameStore.db | N/A |

## 📚 Files to Know

- **Backend**: `GameStore.API/Program.cs` - Entry point
- **Frontend**: `gamestore-ui/src/main.ts` - Entry point
- **API Routes**: `GameStore.API/Endpoints/GamesEndpoints.cs`
- **Services**: `gamestore-ui/src/app/services/`
- **Template**: `gamestore-ui/src/app/app.html`
- **Styles**: `gamestore-ui/src/app/app.css`

## 🎯 What to Test Next

After basic setup works:

1. **Add 5+ games** - verify table performance
2. **Edit multiple times** - check updates work
3. **Delete and re-add** - verify functionality
4. **Refresh page** - data persists?
5. **Mobile view** - responsive design works?
6. **Errors** - leave field blank, see error

## 💾 Database

Database file: `GameStore.API/GameStore.db`

To reset database:
```bash
# Stop API
# Delete file
del GameStore.API/GameStore.db
# Restart API - fresh database created
```

## 🆘 Get Help

1. Check console (F12)
2. Check Network tab
3. See TESTING_GUIDE.md for detailed tests
4. See IMPLEMENTATION_SUMMARY.md for architecture

## ✨ Success Indicators

✅ API returns games
✅ Form submits new game
✅ Table updates instantly
✅ Edit works
✅ Delete works
✅ Messages display
✅ Mobile responsive
✅ No console errors

---

**All working? You're ready to go! 🎉**

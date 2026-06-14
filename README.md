# GameStore API 🎮

A modern RESTful API designed to manage a digital video game storefront. This backend service handles the core operations for managing games and genres, serving as a lightweight and efficient foundation for a gaming e-commerce platform.

## 🚀 Features

*   **Minimal APIs:** Utilizes lightweight and fast endpoint routing (`GamesEndpoints.cs`) for handling HTTP requests[cite: 1].
*   **Entity Framework Core:** Robust data access and database management using EF Core (`GameStoreContext.cs`)[cite: 1].
*   **Local SQLite Database:** Configured out-of-the-box with a local SQLite database (`GameStore.db`) for rapid development and testing[cite: 1].
*   **Data Transfer Objects (DTOs):** Enforces clean architecture by using DTOs (`CreateGameDto`, `GameDto`, `UpdateGameDto`) to separate domain models from API contracts[cite: 1].
*   **Direct API Testing:** Includes a `games.http` file, allowing you to execute and test REST endpoints directly within your IDE[cite: 1].
*   **Database Migrations:** Includes pre-configured EF Core migrations to easily build and update the database schema[cite: 1].

## 🛠 Tech Stack

*   **Framework:** .NET (C#)
*   **Architecture:** Minimal APIs[cite: 1]
*   **ORM:** Entity Framework Core[cite: 1]
*   **Database:** SQLite[cite: 1]

## 📦 Getting Started

Follow these steps to set up the development environment and run the API locally.

### Prerequisites

*   [.NET SDK](https://dotnet.microsoft.com/download) (Version matching your project target)
*   An IDE such as Visual Studio 2022 or Visual Studio Code

### Installation & Execution

1.  **Clone the repository**
```bash
    git clone [https://github.com/khanshaif9102/GameStore.git](https://github.com/khanshaif9102/GameStore.git)
    ```

2.  **Navigate to the API directory**
```bash
    cd GameStore/GameStore.API
    ```

3.  **Restore dependencies**
```bash
    dotnet restore
    ```

4.  **Apply database migrations**
    Ensure your local SQLite database is up to date with the latest schema[cite: 1].
```bash
    dotnet ef database update
    ```

5.  **Run the application**
```bash
    dotnet run
    ```

## 🧪 Testing the API

You do not need external tools like Postman to test this API. You can use the included `games.http` file[cite: 1]:
1. Open `games.http` in your IDE[cite: 1].
2. Click the "Send Request" button above the defined HTTP methods (GET, POST, PUT, DELETE) to interact directly with the running API.

## 📁 Project Structure

*   **`/Data`**: Contains the `GameStoreContext` and EF Core migration files[cite: 1].
*   **`/Dtos`**: Contains the Data Transfer Objects used for API requests and responses[cite: 1].
*   **`/Endpoints`**: Contains the Minimal API route definitions and handler logic[cite: 1].
*   **`/Models`**: Contains the core domain entities (`Game.cs`, `Genre.cs`)[cite: 1].

## 🤝 Contributing

This project is currently under development. If you would like to contribute:
1. Fork the repository.
2. Create your feature branch (`git checkout -b feature/NewFeature`).
3. Commit your changes (`git commit -m 'Add some NewFeature'`).
4. Push to the branch (`git push origin feature/NewFeature`).
5. Open a Pull Request.

## 📧 Contact

**Md Shaifullah Khan**
Project Link: [https://github.com/khanshaif9102/GameStore](https://github.com/khanshaif9102/GameStore)

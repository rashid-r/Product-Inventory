# Product Inventory API

A robust **RESTful API** for inventory management built with **ASP.NET Core 8**, following **Clean Architecture** principles. This solution uses **Dapper** for high-performance data access and **SQL Server Stored Procedures** for database operations.

## 🚀 Tech Stack

*   **Architecture**: Clean Architecture (Onion Architecture) / Microservices-ready
*   **Framework**: ASP.NET Core 8 (Web API)
*   **Data Access**: Dapper (Micro-ORM)
*   **Database**: MS SQL Server
*   **Database Logic**: Stored Procedures

## 🏗️ Project Structure

The solution is organized into four distinct layers to ensure separation of concerns:

*   **`ProductInventory.API`** (Presentation): The entry point. Contains Controllers and DI configuration.
*   **`ProductInventory.APPLICATION`** (Core): Contains Business Logic (Services) and Interfaces.
*   **`ProductInventory.DOMAIN`** (Core): Contains Entities, DTOs, and common Models.
*   **`ProductInventory.INFRASTRUCTURE`** (Data): Implements data access using Dapper and SQL protocols.

## 🔌 API Endpoints

### 1. Get Stock
**GET** `/api/Stocks?storeId={id}&productId={id}`

**Response:**
```json
{
  "statusCode": 200,
  "message": "Stock retrieved successfully",
  "data": {
    "storeId": 101,
    "productId": 110,
    "stockLevel": 50
  }
}
```

### 2. Update Stock
**POST** `/api/Stocks`

**Body:**
```json
{
  "storeId": 101,
  "productId": 110,
  "newStockLevel": 75
}
```

## ⚙️ Setup & Installation

1.  **Clone the Repository**:
    ```bash
    git clone https://github.com/yourusername/product-inventory.git
    ```
2.  **Database Setup**:
    *   Execute the SQL script provided in `Database/Schema.sql` (or create tables manually).
    *   Create Stored Procedures: `sp_GetStock` and `sp_UpdateStock`.
3.  **Configure Connection**:
    *   Open `ProductInventory.API/appsettings.json`.
    *   Update the `DefaultConnection` string to point to your SQL Server instance.
4.  **Run the Application**:
    ```bash
    dotnet run --project ProductInventory.API
    ```

## 🗄️ Database Schema

```sql
CREATE TABLE STORES ( StoreId INT IDENTITY PRIMARY KEY, StoreName NVARCHAR(100), Address NVARCHAR(200) );
CREATE TABLE PRODUCTS ( ProductId INT IDENTITY PRIMARY KEY, ProductName NVARCHAR(100), Category NVARCHAR(50) );
CREATE TABLE STOCKS ( StockId INT IDENTITY PRIMARY KEY, StoreId INT FOREIGN KEY REFERENCES STORES(StoreId), ProductId INT FOREIGN KEY REFERENCES PRODUCTS(ProductId), StockLevel INT );
```

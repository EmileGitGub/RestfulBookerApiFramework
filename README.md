# RestfulBooker API Automation Framework

A C#/.NET API automation framework built to test the [Restful Booker API](https://restful-booker.herokuapp.com/).

This project was designed with a focus on **reusability, maintainability, separation of concerns, and scalable API test automation**. The framework provides reusable components for API communication, authentication, test data generation, assertions, and service-level API operations.

---

## 🚀 Project Overview

The framework automates the main functionality of the Restful Booker API, including:

* Authentication
* Booking creation
* Booking retrieval
* Full booking updates
* Partial booking updates
* Booking deletion
* Positive test scenarios
* Negative test scenarios
* API health/ping validation

The framework uses a layered architecture where API communication, services, authentication, models, test data, assertions, configuration, and tests are separated into dedicated components.

---

## 🛠️ Technology Stack

| Technology | Purpose                         |
| ---------- | ------------------------------- |
| C#         | Programming language            |
| .NET       | Application and test platform   |
| NUnit      | Test framework                  |
| HttpClient | HTTP/API communication          |
| JSON       | API request and response format |
| Git        | Version control                 |
| GitHub     | Source code repository          |

---

## 🏗️ Framework Architecture

The framework follows a layered approach:

```text
                    ┌──────────────────┐
                    │      Tests       │
                    └────────┬─────────┘
                             │
                             ▼
                    ┌──────────────────┐
                    │     Services     │
                    └────────┬─────────┘
                             │
                             ▼
                    ┌──────────────────┐
                    │    ApiClient     │
                    └────────┬─────────┘
                             │
                             ▼
                    ┌──────────────────┐
                    │    HttpClient    │
                    └────────┬─────────┘
                             │
                             ▼
                    ┌──────────────────┐
                    │ Restful Booker   │
                    │       API        │
                    └──────────────────┘
```

Supporting components provide authentication, configuration, test data, models, and reusable assertions.

---

## 📁 Project Structure

```text
RestfulBookerApiFramework
│
├── Base
│   ├── ApiClient.cs
│   └── BaseTest.cs
│
├── Config
│   ├── Settings.cs
│   └── SettingsManager.cs
│
├── Helpers
│   ├── BookingAssertions.cs
│   └── TestDataFactory.cs
│
├── Models
│   ├── AuthRequest.cs
│   ├── AuthResponse.cs
│   ├── Booking.cs
│   ├── BookingDates.cs
│   ├── CreateBookingResponse.cs
│   └── PatchBookingRequest.cs
│
├── Security
│   └── AuthenticationManager.cs
│
├── Services
│   ├── AuthService.cs
│   └── BookingService.cs
│
├── Tests
│   ├── AuthTests.cs
│   ├── AuthenticationNegativeTests.cs
│   ├── BookingTests.cs
│   ├── DeleteBookingTests.cs
│   ├── GetBookingNegativeTests.cs
│   ├── GetBookingTests.cs
│   ├── PatchBookingTests.cs
│   ├── PingTest.cs
│   └── UpdateBookingTests.cs
│
├── .gitignore
├── global.json
└── RestfulBookerApiFramework.csproj
```

---

## 📦 Framework Components

### Base

#### `ApiClient`

The `ApiClient` provides a reusable abstraction over `HttpClient`.

It contains generic methods for common HTTP operations, including:

* `GET`
* `POST`
* `PUT`
* `PATCH`
* `DELETE`

This prevents individual tests and services from having to manage HTTP request logic themselves.

### `BaseTest`

`BaseTest` provides common test setup and initializes the core framework components used across the test suite.

It provides access to:

* `ApiClient`
* `AuthService`
* `AuthenticationManager`
* `BookingService`

This allows individual test classes to focus on **what is being tested** rather than repeatedly creating framework dependencies.

---

## 🔐 Authentication

Authentication is handled through dedicated components rather than being implemented directly inside individual tests.

### `AuthService`

Responsible for communicating with the authentication endpoint and obtaining an authentication response.

### `AuthenticationManager`

Manages the authentication token used by protected endpoints.

The manager also caches the token so that tests can reuse an existing valid token instead of repeatedly authenticating.

This provides a cleaner and more efficient authentication flow.

```text
Auth Test
    │
    ▼
AuthService
    │
    ▼
Authentication API
    │
    ▼
AuthenticationManager
    │
    ▼
Cached Token
    │
    ▼
Authenticated Requests
```

---

## 📡 Booking Service

`BookingService` contains the business-level API operations for bookings.

It provides methods for:

### Create

```text
POST /booking
```

Creates a new booking.

### Get

```text
GET /booking/{id}
```

Retrieves an existing booking.

### Update

```text
PUT /booking/{id}
```

Completely updates an existing booking.

### Patch

```text
PATCH /booking/{id}
```

Partially updates an existing booking.

### Delete

```text
DELETE /booking/{id}
```

Deletes an existing booking.

The service layer keeps API-specific operations separate from the test classes.

---

## 🧪 Test Coverage

The framework currently contains tests covering authentication, booking operations, negative scenarios, and API health.

### Authentication Tests

* Successful authentication
* Invalid username/password
* Invalid authentication scenarios
* Authentication token handling

### Booking Tests

* Create booking
* Retrieve booking
* Retrieve booking using an invalid booking ID
* Update booking using PUT
* Partially update booking using PATCH
* Delete booking

### API Tests

* Ping/health endpoint validation

---

## ❌ Negative Testing

Negative testing is included to verify that the API responds correctly when invalid data or invalid requests are provided.

Examples include:

* Invalid authentication credentials
* Invalid booking IDs
* Unauthorized requests
* Invalid API scenarios

The goal is not only to verify that valid requests succeed, but also that the API correctly handles invalid conditions.

---

## 🧱 Models

The framework uses strongly typed C# models to represent API request and response data.

Examples include:

* `AuthRequest`
* `AuthResponse`
* `Booking`
* `BookingDates`
* `CreateBookingResponse`
* `PatchBookingRequest`

This provides strongly typed interaction with API payloads and makes the tests easier to maintain.

---

## 🧪 Test Data

`TestDataFactory` provides reusable test data for booking scenarios.

This keeps test data generation separate from the test implementation and reduces duplication between test cases.

---

## ✅ Reusable Assertions

`BookingAssertions` contains reusable assertions for validating booking data.

This keeps validation logic centralized instead of duplicating the same assertions across multiple tests.

For example, booking validation can be performed consistently across create, update, and retrieval scenarios.

---

## ⚙️ Configuration

The framework uses configuration management through:

```text
Config
├── Settings.cs
└── SettingsManager.cs
```

The API base URL and other configuration values are managed separately from the test implementation.

Example:

```json
{
  "Application": {
    "BaseUrl": "https://restful-booker.herokuapp.com"
  }
}
```

Sensitive configuration such as credentials is kept out of source control.

---

## 🔒 Security

Sensitive configuration files are excluded using `.gitignore`.

For example:

```text
appsettings.json
```

is not committed to the repository when it contains credentials or other sensitive information.

**Never commit passwords, authentication tokens, API keys, or other secrets to source control.**

---

## ▶️ Running the Tests

### Prerequisites

Make sure you have:

* .NET SDK installed
* Git installed
* Internet access
* A supported IDE/editor such as Visual Studio or Visual Studio Code

The repository contains a `global.json` file to specify the .NET SDK version used by the project.

### Clone the Repository

```bash
git clone https://github.com/EmileGitGub/RestfulBookerApiFramework.git
```

Navigate into the project:

```bash
cd RestfulBookerApiFramework
```

### Restore Dependencies

```bash
dotnet restore
```

### Build the Framework

```bash
dotnet build
```

### Run All Tests

```bash
dotnet test
```

---

## 📊 Test Execution

The framework uses NUnit for test execution.

The complete test suite can be executed using:

```bash
dotnet test
```

The tests are designed to run against the Restful Booker API and validate both successful and unsuccessful API scenarios.

---

## 🔄 Git Workflow

The project uses Git for version control and GitHub for source-code management.

Typical workflow:

```text
Make changes
     │
     ▼
git status
     │
     ▼
git add .
     │
     ▼
git commit
     │
     ▼
git push
     │
     ▼
GitHub
```

---

## 🔮 Future Improvements

The framework can be extended with additional automation and CI/CD capabilities.

Planned improvements include:

* GitHub Actions CI/CD integration
* Automated test execution on every push
* Test result reporting
* Environment-specific configuration
* Enhanced logging
* Additional negative test coverage
* JSON schema validation
* Test categorization
* Parallel test execution
* Automated API test reports

---

## 🎯 Project Goals

This project was created to demonstrate practical API automation and framework development skills.

The main goals were to demonstrate:

* API automation
* C#/.NET development
* NUnit test automation
* Object-oriented programming
* Separation of concerns
* Reusable framework components
* Service-layer design
* Authentication management
* Test data management
* Reusable assertions
* Positive and negative testing
* Configuration management
* Git and GitHub usage

---

## 👨‍💻 Author

**Emile Koopman**

QA Automation Tester

---

⭐ This project is part of my continued development in API automation, test framework design, and CI/CD.

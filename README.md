# GitHub Explorer API

## Description

GitHub Explorer API is a RESTful web service built using ASP.NET Core that allows users to explore GitHub repositories based on various criteria such as user, language, and sorting options. It leverages the GitHub API to fetch repository information and provides a simple interface for retrieving and processing data.

## Features

- **Repository Search**: Search GitHub repositories by user, language, and sorting options.
- **Flexible Filtering**: Filter repositories based on language, user, and sorting preferences.
- **Pagination**: Supports pagination for large result sets.
- **Error Handling**: Provides error handling for invalid requests and API errors.

## Usage

To use the GitHub Explorer API, you can send HTTP requests to the designated endpoints. Here's an overview of the available endpoints:

- `GET /api/repositories`: Retrieve a list of GitHub repositories based on specified criteria.
  - Query Parameters:
    - `user`: Filter repositories by username.
    - `language`: Filter repositories by programming language.
    - `sort`: Sort repositories by criteria such as "updated" or "stars".
    - `include_forks`: Include forked repositories in the results (default is false).
    - `limit`: Limit the number of repositories returned (optional).

## Installation

To install and run the GitHub Explorer API locally, follow these steps:

1. Clone this repository to your local machine.
2. Navigate to the project directory.
3. Run the application using `dotnet run`.
4. Access the API endpoints using your preferred HTTP client.

## Dependencies

The GitHub Explorer API relies on the following dependencies:

- ASP.NET Core
- Newtonsoft.Json
- HttpClient
